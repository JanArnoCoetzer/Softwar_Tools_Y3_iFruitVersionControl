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
}
