using System;
using System.Collections.Generic;
using System.Linq;
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
        return GetAll()
            .Where(recipe => recipe.ItemId == itemId)
            .ToList();
    }

    public static string GetIngredientNames(
        int itemId,
        List<RecipeIngredient> recipes,
        List<StockItem> stock)
    {
        IEnumerable<string> names = recipes
            .Where(recipe => recipe.ItemId == itemId)
            .Select(recipe =>
                stock.FirstOrDefault(
                    ingredient => ingredient.Id == recipe.StockId)?.Name)
            .OfType<string>();

        return string.Join(", ", names);
    }

    // Inserts one ingredient link for an item.
    // This does not create the item or its stock ingredient.
    public static bool AddIngredient(
        int itemId,
        int stockId,
        decimal quantityRequired)
    {
        if (itemId <= 0 || stockId <= 0 || quantityRequired <= 0)
        {
            return false;
        }

        List<RecipeIngredient> existingRecipes = GetAll();

        // Do not create another link for the same item and ingredient.
        if (existingRecipes.Any(recipe =>
                recipe.ItemId == itemId &&
                recipe.StockId == stockId))
        {
            return false;
        }

        int maximumId = existingRecipes
            .Select(recipe => recipe.Id)
            .DefaultIfEmpty(0)
            .Max();

        if (maximumId == int.MaxValue)
        {
            return false;
        }

        int nextId = maximumId + 1;

        object[] values =
        {
            nextId,
            itemId,
            stockId,
            quantityRequired
        };

        return TableAccess.AppendRow(TableName, values);
    }


}