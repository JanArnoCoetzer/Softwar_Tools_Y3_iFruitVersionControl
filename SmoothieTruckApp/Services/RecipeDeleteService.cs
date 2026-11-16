using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmoothieTruckApp.Repositories;

internal static class RecipeDeleteService
{
    public static void Delete(int itemId)
    {
        // Preserve menu items referenced by order history.
        bool usedByOrders = TableAccess
            .ReadRows("ordered_items_table")
            .Any(row => (int)row[1] == itemId);

        if (usedByOrders)
        {
            throw new InvalidOperationException(
                "This item is referenced by existing orders and cannot " +
                "be permanently deleted. Archive it instead to preserve " +
                "order history.");
        }

        // Stock can now be deleted too, so back up all three tables.
        var backups = new Dictionary<string, string>();

        foreach (string tableName in new[]
        {
            "item_table",
            "recipe_table",
            "stock_table"
        })
        {
            if (FileRepository.ReadFile(tableName, out string content)
                    != FileResult.Success ||
                string.IsNullOrWhiteSpace(content))
            {
                throw new InvalidOperationException(
                    $"Could not read '{tableName}'. Nothing was deleted.");
            }

            backups.Add(tableName, content);
        }

        try
        {
            bool itemExists = MenuItemRepository.GetAll()
                .Any(item => item.Id == itemId);

            if (!itemExists)
            {
                throw new InvalidOperationException(
                    "The menu item no longer exists. Reload the recipe page.");
            }

            var links = RecipeRepository.GetForItem(itemId);

            // Only these ingredients are candidates for deletion.
            var candidateStockIds = links
                .Select(link => link.StockId)
                .ToHashSet();

            // Delete the recipe's ingredient links first.
            foreach (var link in links)
            {
                if (!TableAccess.DeleteRow("recipe_table", link.Id))
                {
                    throw new InvalidOperationException(
                        "Could not delete the recipe's ingredient links.");
                }
            }

            // Delete its menu item.
            if (!TableAccess.DeleteRow("item_table", itemId))
            {
                throw new InvalidOperationException(
                    "Could not delete the menu item.");
            }

            // Check references after deleting this recipe's links.
            var remainingStockReferences = RecipeRepository.GetAll()
                .Select(link => link.StockId)
                .ToHashSet();

            var existingStockIds = StockRepository.GetAll()
                .Select(stock => stock.Id)
                .ToHashSet();

            foreach (int stockId in candidateStockIds)
            {
                // Keep any ingredient still used by another recipe.
                if (remainingStockReferences.Contains(stockId))
                    continue;

                // An already-missing stock record needs no deletion.
                if (!existingStockIds.Contains(stockId))
                    continue;

                if (!StockRepository.Delete(stockId))
                {
                    throw new InvalidOperationException(
                        $"Could not delete unused stock ingredient " +
                        $"with ID {stockId}.");
                }
            }
        }
        catch (Exception deleteError)
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
                    "Deletion failed and these tables could not be restored: " +
                    string.Join(", ", restoreFailures) +
                    ". Check the database before retrying.",
                    deleteError);
            }

            throw new InvalidOperationException(
                $"Recipe was not deleted. {deleteError.Message}",
                deleteError);
        }
    }
}