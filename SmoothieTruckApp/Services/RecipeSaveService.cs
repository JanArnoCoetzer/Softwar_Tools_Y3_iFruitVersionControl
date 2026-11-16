using System;
using System.Collections.Generic;
using System.Linq;
using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.Repositories;

internal static class RecipeSaveService
{
    private static readonly object SaveLock = new();

    private static readonly string[] Tables =
    {
        "item_table",
        "stock_table",
        "recipe_table"
    };

    public static int Save(
        int? itemId,
        string name,
        string category,
        IReadOnlyList<(string Name, int Grams)> ingredients)
    {
        lock (SaveLock)
        {
            return SaveInternal(itemId, name, category, ingredients);
        }
    }

    private static int SaveInternal(
        int? itemId,
        string name,
        string category,
        IReadOnlyList<(string Name, int Grams)> ingredients)
    {
        name = name.Trim();
        category = category.Trim();

        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException("Enter a recipe name.");

        if (string.IsNullOrWhiteSpace(category))
            throw new InvalidOperationException("Enter a category.");

        if (ingredients.Count == 0)
            throw new InvalidOperationException(
                "Add at least one ingredient.");

        if (ingredients.Any(i =>
                string.IsNullOrWhiteSpace(i.Name) || i.Grams <= 0))
        {
            throw new InvalidOperationException(
                "Each ingredient needs a name and a positive amount.");
        }

        // Capture the files before making changes.
        var backups = new Dictionary<string, string>();

        foreach (string tableName in Tables)
        {
            if (FileRepository.ReadFile(tableName, out string content)
                    != FileResult.Success ||
                string.IsNullOrWhiteSpace(content))
            {
                throw new InvalidOperationException(
                    $"Could not read '{tableName}'. Nothing was saved.");
            }

            backups.Add(tableName, content);
        }

        try
        {
            var menuItems = MenuItemRepository.GetAll();
            var stock = StockRepository.GetAll();

            if (itemId.HasValue &&
                !menuItems.Any(i => i.Id == itemId.Value))
            {
                throw new InvalidOperationException(
                    "The menu item no longer exists. Reload the recipe page.");
            }

            // Combine repeated ingredient names into one recipe entry.
            var requestedIngredients = ingredients
                .GroupBy(
                    i => i.Name.Trim(),
                    StringComparer.OrdinalIgnoreCase)
                .Select(group => (
                    Name: group.Key,
                    Grams: group.Sum(i => (decimal)i.Grams)))
                .ToList();

            // Resolve ingredients and units before writing anything.
            var resolved = new List<(
                string Name,
                int? StockId,
                decimal QuantityRequired)>();

            foreach (var ingredient in requestedIngredients)
            {
                var matches = stock
                    .Where(s => string.Equals(
                        s.Name.Trim(),
                        ingredient.Name,
                        StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (matches.Count > 1)
                {
                    throw new InvalidOperationException(
                        $"Multiple stock entries match '{ingredient.Name}'. " +
                        "Resolve the duplicate stock names first.");
                }

                if (matches.Count == 0)
                {
                    resolved.Add((
                        ingredient.Name,
                        null,
                        ingredient.Grams / 1000m));

                    continue;
                }

                var existing = matches[0];

                decimal quantityRequired =
                    existing.Unit.Trim().ToLowerInvariant() switch
                    {
                        "kg" => ingredient.Grams / 1000m,
                        "g" => ingredient.Grams,

                        _ => throw new InvalidOperationException(
                            $"'{existing.Name}' uses '{existing.Unit}', " +
                            "but this recipe form accepts grams only. " +
                            "Add a unit selector before saving this ingredient.")
                    };

                resolved.Add((
                    existing.Name,
                    existing.Id,
                    quantityRequired));
            }

            int savedItemId;

            if (itemId.HasValue)
            {
                var existingItem = menuItems.Single(
                    i => i.Id == itemId.Value);

                // Preserve the existing price and category colour.
                Require(
                    TableAccess.ReplaceRow(
                        "item_table",
                        existingItem.Id,
                        new[]
                        {
                            TableAccess.Text(name),
                            TableAccess.Number(existingItem.Price),
                            TableAccess.Text(category),
                            TableAccess.Text(
                                System.Drawing.ColorTranslator.ToHtml(
                                    existingItem.CatagoryColor))
                        }),
                    "Could not update the menu item.");

                savedItemId = existingItem.Id;
            }
            else
            {
                var previousIds = menuItems
                    .Select(i => i.Id)
                    .ToHashSet();

                Require(
                    MenuItemRepository.Add(
                        name,
                        0.00m,
                        category,
                        "#7C3AED"),
                    "Could not create the menu item.");

                // Find the ID actually assigned by the database.
                savedItemId = MenuItemRepository.GetAll()
                    .Single(i => !previousIds.Contains(i.Id))
                    .Id;
            }

            var desiredLinks =
                new Dictionary<int, decimal>();

            foreach (var ingredient in resolved)
            {
                int stockId;

                if (ingredient.StockId.HasValue)
                {
                    stockId = ingredient.StockId.Value;
                }
                else
                {
                    var previousIds = StockRepository.GetAll()
                        .Select(s => s.Id)
                        .ToHashSet();

                    Require(
                        StockRepository.Add(
                            ingredient.Name,
                            0m,
                            "kg"),
                        $"Could not create '{ingredient.Name}' in stock.");

                    stockId = StockRepository.GetAll()
                        .Single(s => !previousIds.Contains(s.Id))
                        .Id;
                }

                desiredLinks.Add(
                    stockId,
                    ingredient.QuantityRequired);
            }

            var previousLinks =
                RecipeRepository.GetForItem(savedItemId);

            foreach (var desired in desiredLinks)
            {
                var matches = previousLinks
                    .Where(r => r.StockId == desired.Key)
                    .ToList();

                if (matches.Count == 0)
                {
                    Require(
                        DataBase.AddNewRow(
                            "recipe_table",
                            new[]
                            {
                                new RowValue(
                                    DataType.INTEGER,
                                    savedItemId.ToString(
                                        System.Globalization.CultureInfo.InvariantCulture)),

                                new RowValue(
                                    DataType.INTEGER,
                                    desired.Key.ToString(
                                        System.Globalization.CultureInfo.InvariantCulture)),

                                TableAccess.Number(desired.Value)
                            }) == DbResult.Success,
                        "Could not add a recipe ingredient.");
                }
                else
                {
                    Require(
                        TableAccess.ReplaceRow(
                            "recipe_table",
                            matches[0].Id,
                            new[]
                            {
                                new RowValue(
                                    DataType.INTEGER,
                                    savedItemId.ToString(
                                        System.Globalization.CultureInfo.InvariantCulture)),

                                new RowValue(
                                    DataType.INTEGER,
                                    desired.Key.ToString(
                                        System.Globalization.CultureInfo.InvariantCulture)),

                                TableAccess.Number(desired.Value)
                            }),
                        "Could not update a recipe ingredient.");

                    // Remove any duplicate links already present.
                    foreach (var duplicate in matches.Skip(1))
                    {
                        Require(
                            TableAccess.DeleteRow(
                                "recipe_table",
                                duplicate.Id),
                            "Could not remove a duplicate recipe link.");
                    }
                }
            }

            // Remove links for ingredients removed from the card.
            foreach (var oldLink in previousLinks)
            {
                if (!desiredLinks.ContainsKey(oldLink.StockId))
                {
                    Require(
                        TableAccess.DeleteRow(
                            "recipe_table",
                            oldLink.Id),
                        "Could not remove an old recipe ingredient.");
                }
            }

            return savedItemId;
        }
        catch (Exception saveError)
        {
            var restoreFailures = new List<string>();

            foreach (var backup in backups)
            {
                try
                {
                    if (FileRepository.WriteFile(
                            backup.Key,
                            backup.Value) != FileResult.Success)
                    {
                        restoreFailures.Add(backup.Key);
                    }
                }
                catch
                {
                    restoreFailures.Add(backup.Key);
                }
            }

            if (restoreFailures.Count > 0)
            {
                throw new InvalidOperationException(
                    "Saving failed and some backups could not be restored: " +
                    string.Join(", ", restoreFailures) +
                    ". Check these tables before retrying.",
                    saveError);
            }

            throw new InvalidOperationException(
                $"Recipe was not saved. {saveError.Message}",
                saveError);
        }
    }

    private static void Require(bool success, string message)
    {
        if (!success)
            throw new InvalidOperationException(message);
    }
}