using SmoothieTruckApp.Models;
using SmoothieTruckApp.Repositories;

namespace SmoothieTruckApp.Services;

internal static class StockService
{
    public static Dictionary<int, decimal> CalculateUsage(Order order, List<RecipeIngredient> recipes)
    {
        var usage = new Dictionary<int, decimal>();

        foreach (OrderLine line in order.Lines)
        {
            foreach (RecipeIngredient ingredient in recipes.Where(r => r.ItemId == line.Item.Id))
            {
                usage.TryGetValue(ingredient.StockId, out decimal current);
                usage[ingredient.StockId] = current + ingredient.QuantityRequired * line.Quantity;
            }
        }

        return usage;
    }

    public static List<string> FindShortages(Order order, List<RecipeIngredient> recipes, List<StockItem> stock)
    {
        var shortages = new List<string>();

        foreach (KeyValuePair<int, decimal> used in CalculateUsage(order, recipes))
        {
            StockItem? item = stock.FirstOrDefault(s => s.Id == used.Key);

            if (item == null || item.Quantity < used.Value)
            {
                shortages.Add(item?.Name ?? $"Stock #{used.Key}");
            }
        }

        return shortages;
    }

    public static List<string> FindShortages(Order order)
    {
        return FindShortages(order, RecipeRepository.GetAll(), StockRepository.GetAll());
    }

    public static void ReduceStock(Order order)
    {
        List<StockItem> stock = StockRepository.GetAll();

        foreach (KeyValuePair<int, decimal> used in CalculateUsage(order, RecipeRepository.GetAll()))
        {
            StockItem? item = stock.FirstOrDefault(s => s.Id == used.Key);

            if (item == null) continue;

            item.Quantity -= used.Value;
            StockRepository.Update(item);
        }
    }
}
