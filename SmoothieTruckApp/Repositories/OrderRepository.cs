using System.Globalization;
using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using SmoothieTruckApp.Models;

namespace SmoothieTruckApp.Repositories;

internal static class OrderRepository
{
    private const string IncomeTable = "income_table";
    private const string OrderedItemsTable = "ordered_items_table";

    public static int GetNextOrderNumber()
    {
        return TableAccess.NextIndex(IncomeTable);
    }

    public static int Save(Order order)
    {
        if (order.Lines.Count == 0)
        {
            return 0;
        }

        int orderNumber = GetNextOrderNumber();

        DbResult result = DataBase.AddNewRow(IncomeTable, new[]
        {
            new RowValue(DataType.DECIMAL, order.Total.ToString(CultureInfo.InvariantCulture))
        });

        if (result != DbResult.Success)
        {
            return 0;
        }

        foreach (OrderLine line in order.Lines)
        {
            if (!TableAccess.AppendRow(OrderedItemsTable, new object[] { orderNumber, line.Item.Id, line.Quantity }))
            {
                return 0;
            }
        }

        return orderNumber;
    }
}
