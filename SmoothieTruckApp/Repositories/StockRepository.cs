using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
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

    public static bool Add(string name, decimal quantity, string unit)
    {
        DbResult result = DataBase.AddNewRow(TableName, new[]
        {
            TableAccess.Text(name),
            TableAccess.Number(quantity),
            TableAccess.Text(unit)
        });

        return result == DbResult.Success;
    }

    public static bool Update(StockItem item)
    {
        return TableAccess.ReplaceRow(TableName, item.Id, new[]
        {
            TableAccess.Text(item.Name),
            TableAccess.Number(item.Quantity),
            TableAccess.Text(item.Unit)
        });
    }

    public static bool Delete(int stockId)
    {
        return TableAccess.DeleteRow(TableName, stockId);
    }
}
