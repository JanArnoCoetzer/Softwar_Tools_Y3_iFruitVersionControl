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
        decimal price,
        IReadOnlyList<(string Name, int Amount, string Unit)> ingredients)
    {
        lock (SaveLock)
        {
            return SaveInternal(itemId, name, category, price, ingredients);
        }
    }

    //card amounts are g or ml, stock is stored in kg/g or l/ml
    internal static decimal ToStockQuantity(
        string ingredientName,
        int amount,
        string cardUnit,
        string stockUnit)
    {
        string unit = cardUnit.Trim().ToLowerInvariant();

        return (unit, stockUnit.Trim().ToLowerInvariant()) switch
        {
            ("g", "kg") or ("ml", "l") => amount / 1000m,
            ("g", "g") or ("ml", "ml") => amount,

            _ => throw new InvalidOperationException(
                $"'{ingredientName}' is stocked in '{stockUnit}', " +
                $"so it can't be entered in '{cardUnit}'. " +
                (stockUnit.Trim().ToLowerInvariant() is "l" or "ml"
                    ? "Use ml."
                    : "Use g."))
        };
    }

    private static int SaveInternal(
        int? itemId,
        string name,
        string category,
        decimal price,
        IReadOnlyList<(string Name, int Amount, string Unit)> ingredients)
    {
        name = name.Trim();
        category = category.Trim();

        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException("Enter a recipe name.");

        if (string.IsNullOrWhiteSpace(category))
            throw new InvalidOperationException("Enter a category.");

        if (price <= 0)
            throw new InvalidOperationException(
                "Enter a price greater than 0.");

        if (ingredients.Count == 0)
            throw new InvalidOperationException(
                "Add at least one ingredient.");

        if (ingredients.Any(i =>
                string.IsNullOrWhiteSpace(i.Name) || i.Amount <= 0))
        {
            throw new InvalidOperationException(
                "Each ingredient needs a name and a positive amount.");
        }

        if (ingredients.Any(i =>
                i.Unit?.Trim().ToLowerInvariant() is not ("g" or "ml")))
        {
            throw new InvalidOperationException(
                "Each ingredient amount must be in g or ml.");
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
                .Select(group =>
                {
                    if (group.Select(i => i.Unit.Trim().ToLowerInvariant()).Distinct().Count() > 1)
                    {
                        throw new InvalidOperationException(
                            $"'{group.Key}' is entered in both g and ml. Use one unit.");
                    }

                    return (
                        Name: group.Key,
                        Amount: group.Sum(i => i.Amount),
                        Unit: group.First().Unit.Trim().ToLowerInvariant());
                })
                .ToList();

            // Resolve ingredients and units before writing anything.
            var resolved = new List<(
                string Name,
                int? StockId,
                decimal QuantityRequired,
                string NewStockUnit)>();

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
                    //new stock is kept in kg or l like the rest of the stock table
                    string newUnit = ingredient.Unit == "ml" ? "l" : "kg";

                    resolved.Add((
                        ingredient.Name,
                        null,
                        ToStockQuantity(ingredient.Name, ingredient.Amount, ingredient.Unit, newUnit),
                        newUnit));

                    continue;
                }

                var existing = matches[0];

                resolved.Add((
                    existing.Name,
                    existing.Id,
                    ToStockQuantity(existing.Name, ingredient.Amount, ingredient.Unit, existing.Unit),
                    existing.Unit));
            }

            int savedItemId;

            if (itemId.HasValue)
            {
                var existingItem = menuItems.Single(
                    i => i.Id == itemId.Value);

                // Preserve the existing category colour.
                Require(
                    TableAccess.ReplaceRow(
                        "item_table",
                        existingItem.Id,
                        new[]
                        {
                            TableAccess.Text(name),
                            TableAccess.Number(price),
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
                        price,
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
                            ingredient.NewStockUnit),
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