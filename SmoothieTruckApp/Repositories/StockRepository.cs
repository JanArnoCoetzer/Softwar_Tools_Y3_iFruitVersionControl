using SmoothieTruckApp.Models;

namespace SmoothieTruckApp.Repositories;

internal static class StockRepository
{
    private const string TableName = "stock_table";

    public static List<StockItem> GetAll()
    {
        return TableAccess.ReadRows(TableName)
            .Select(row => new StockItem
            {
                Id = (int)row[0],
                Name = (string)row[1],
                Quantity = (decimal)row[2],
                Unit = (string)row[3]
            })
            .ToList();
    }

    public static bool Update(StockItem item)
    {
        return TableAccess.UpdateRow(TableName, item.Id, new object[] { item.Id, item.Name, item.Quantity, item.Unit });
    }
}
