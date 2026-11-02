using SmoothieTruckApp.Models;

namespace SmoothieTruckApp.Repositories;

internal static class RecipeRepository
{
    private const string TableName = "recipe_table";

    public static List<RecipeIngredient> GetAll()
    {
        return TableAccess.ReadRows(TableName)
            .Select(row => new RecipeIngredient
            {
                Id = (int)row[0],
                ItemId = (int)row[1],
                StockId = (int)row[2],
                QuantityRequired = (decimal)row[3]
            })
            .ToList();
    }

    public static List<RecipeIngredient> GetForItem(int itemId)
    {
        return GetAll().Where(r => r.ItemId == itemId).ToList();
    }

    public static string GetIngredientNames(int itemId, List<RecipeIngredient> recipes, List<StockItem> stock)
    {
        IEnumerable<string> names = recipes
            .Where(r => r.ItemId == itemId)
            .Select(r => stock.FirstOrDefault(s => s.Id == r.StockId)?.Name)
            .OfType<string>();

        return string.Join(", ", names);
    }
}
