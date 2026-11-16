using System;
using System.Collections.Generic;
using System.Linq;

namespace SmoothieTruckApp.Repositories;

internal sealed class LoadedRecipe
{
    public int ItemId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public List<(string Name, int Amount, string Unit)> Ingredients { get; } = new();

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
                Category = item.CatagoryName,
                Price = item.Price
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

                if (!TryConvertForCard(
                        recipeLink.QuantityRequired,
                        stockItem.Unit,
                        out int amount,
                        out string cardUnit,
                        out string error))
                {
                    loadedRecipe.Warnings.Add(
                        $"{stockItem.Name}: {error}");

                    continue;
                }

                loadedRecipe.Ingredients.Add((
                    stockItem.Name,
                    amount,
                    cardUnit));
            }

            result.Add(loadedRecipe);
        }

        return result;
    }

    //kg and l show as g and ml on the card
    internal static bool TryConvertForCard(
        decimal quantity,
        string unit,
        out int amount,
        out string cardUnit,
        out string error)
    {
        amount = 0;
        cardUnit = string.Empty;
        error = string.Empty;

        if (quantity <= 0)
        {
            error = "The required quantity must be greater than zero.";
            return false;
        }

        decimal cardValue;

        switch ((unit ?? string.Empty).Trim().ToLowerInvariant())
        {
            case "kg":
            case "l":
                // Check before multiplying to avoid overflow.
                if (quantity > int.MaxValue / 1000m)
                {
                    error = "The quantity is too large to display.";
                    return false;
                }

                cardValue = quantity * 1000m;
                cardUnit = unit!.Trim().ToLowerInvariant() == "kg" ? "g" : "ml";
                break;

            case "g":
            case "ml":
                cardValue = quantity;
                cardUnit = unit!.Trim().ToLowerInvariant();
                break;

            default:
                error =
                    $"Unit '{unit}' cannot be displayed by the " +
                    "recipe card, use kg, g, l or ml.";

                return false;
        }

        if (cardValue > int.MaxValue)
        {
            error = "The quantity is too large to display.";
            return false;
        }

        if (cardValue != decimal.Truncate(cardValue))
        {
            error =
                $"The quantity contains a fraction of a {cardUnit}, but the " +
                "recipe card only supports whole amounts.";

            return false;
        }

        amount = (int)cardValue;
        return true;
    }
}