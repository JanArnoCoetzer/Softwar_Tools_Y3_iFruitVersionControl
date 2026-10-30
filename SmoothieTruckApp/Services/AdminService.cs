using SmoothieTruckApp.Models;
using SmoothieTruckApp.Repositories;

namespace SmoothieTruckApp.Services;

internal static class AdminService
{
    public static string? AddStock(string name, decimal quantity, string unit)
    {
        if (string.IsNullOrWhiteSpace(name)) return "Enter a stock name.";
        if (string.IsNullOrWhiteSpace(unit)) return "Enter a unit, e.g. kg or l.";
        if (quantity < 0) return "Quantity cannot be negative.";

        if (StockRepository.GetAll().Any(s => s.Name.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase)))
        {
            return $"{name.Trim()} is already in stock.";
        }

        return StockRepository.Add(name.Trim(), quantity, unit.Trim()) ? null : "The stock item could not be saved.";
    }

    public static string? Restock(int stockId, decimal amountAdded)
    {
        if (amountAdded <= 0) return "Restock amount must be more than 0.";

        StockItem? item = StockRepository.GetAll().FirstOrDefault(s => s.Id == stockId);
        if (item == null) return "Stock item not found.";

        item.Quantity += amountAdded;

        return StockRepository.Update(item) ? null : "The stock could not be updated.";
    }

    public static string? SetStockQuantity(int stockId, decimal quantity)
    {
        if (quantity < 0) return "Quantity cannot be negative.";

        StockItem? item = StockRepository.GetAll().FirstOrDefault(s => s.Id == stockId);
        if (item == null) return "Stock item not found.";

        item.Quantity = quantity;

        return StockRepository.Update(item) ? null : "The stock could not be updated.";
    }

    public static string? DeleteStock(int stockId)
    {
        StockItem? item = StockRepository.GetAll().FirstOrDefault(s => s.Id == stockId);
        if (item == null) return "Stock item not found.";

        List<int> usedInItems = RecipeRepository.GetAll()
            .Where(r => r.StockId == stockId)
            .Select(r => r.ItemId)
            .Distinct()
            .ToList();

        if (usedInItems.Count > 0)
        {
            IEnumerable<string> names = MenuItemRepository.GetAll()
                .Where(m => usedInItems.Contains(m.Id))
                .Select(m => m.Name);

            return $"{item.Name} is used in: {string.Join(", ", names)}. Remove it from those recipes first.";
        }

        return StockRepository.Delete(stockId) ? null : "The stock item could not be deleted.";
    }
}
