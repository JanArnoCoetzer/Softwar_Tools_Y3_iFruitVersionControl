using System;
using System.Collections.Generic;
using System.Linq;

namespace SmoothieTruckApp.Repositories;

internal sealed class LoadedRecipe
{
    public int ItemId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public List<(string Name, int Grams)> Ingredients { get; } = new();

    public List<string> Warnings { get; } = new();

    public bool CanEdit => Warnings.Count == 0;
}

internal static class RecipeLoadService
{
    public static List<LoadedRecipe> LoadAll()
    {
        var menuItems = MenuItemRepository.GetAll();
        var recipeLinks = RecipeRepository.GetAll();
        var stockItems = StockRepository.GetAll();

        var stockById = stockItems.ToDictionary(stock => stock.Id);

        var recipesByItem = recipeLinks.ToLookup(recipe => recipe.ItemId);

        var result = new List<LoadedRecipe>();

        foreach (var item in menuItems.OrderBy(item => item.Id))
        {
            var loadedRecipe = new LoadedRecipe
            {
                ItemId = item.Id,
                Name = item.Name,
                Category = item.CatagoryName
            };

            foreach (var recipeLink in recipesByItem[item.Id])
            {
                if (!stockById.TryGetValue(
                        recipeLink.StockId,
                        out var stockItem))
                {
                    loadedRecipe.Warnings.Add(
                        $"Stock ingredient ID {recipeLink.StockId} " +
                        "could not be found.");

                    continue;
                }

                if (!TryConvertToGrams(
                        recipeLink.QuantityRequired,
                        stockItem.Unit,
                        out int grams,
                        out string error))
                {
                    loadedRecipe.Warnings.Add(
                        $"{stockItem.Name}: {error}");

                    continue;
                }

                loadedRecipe.Ingredients.Add((
                    stockItem.Name,
                    grams));
            }

            result.Add(loadedRecipe);
        }

        return result;
    }

    private static bool TryConvertToGrams(
        decimal quantity,
        string unit,
        out int grams,
        out string error)
    {
        grams = 0;
        error = string.Empty;

        if (quantity <= 0)
        {
            error = "The required quantity must be greater than zero.";
            return false;
        }

        decimal gramsValue;

        switch ((unit ?? string.Empty).Trim().ToLowerInvariant())
        {
            case "kg":
                // Check before multiplying to avoid overflow.
                if (quantity > int.MaxValue / 1000m)
                {
                    error = "The quantity is too large to display.";
                    return false;
                }

                gramsValue = quantity * 1000m;
                break;

            case "g":
                gramsValue = quantity;
                break;

            default:
                error =
                    $"Unit '{unit}' cannot be displayed by the " +
                    "current grams-only recipe card.";

                return false;
        }

        if (gramsValue > int.MaxValue)
        {
            error = "The quantity is too large to display.";
            return false;
        }

        if (gramsValue != decimal.Truncate(gramsValue))
        {
            error =
                "The quantity contains fractional grams, but the " +
                "current recipe card only supports whole grams.";

            return false;
        }

        grams = (int)gramsValue;
        return true;
    }
}