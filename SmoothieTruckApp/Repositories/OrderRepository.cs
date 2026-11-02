using System.Globalization;
using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using SmoothieTruckApp.Models;
using MenuItem = SmoothieTruckApp.Models.MenuItem;

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

    public static List<Order> GetAll()
    {
        Dictionary<int, MenuItem> menu = MenuItemRepository.GetAll().ToDictionary(m => m.Id);
        List<object[]> lineRows = TableAccess.ReadRows(OrderedItemsTable);

        var orders = new List<Order>();

        foreach (object[] incomeRow in TableAccess.ReadRows(IncomeTable))
        {
            var order = new Order { Id = (int)incomeRow[0] };

            foreach (object[] lineRow in lineRows.Where(l => (int)l[0] == order.Id))
            {
                int itemId = (int)lineRow[1];

                MenuItem item = menu.TryGetValue(itemId, out MenuItem? found)
                    ? found
                    : new MenuItem { Id = itemId, Name = $"Item #{itemId}" };

                order.Lines.Add(new OrderLine { Item = item, Quantity = (int)lineRow[2] });
            }

            orders.Add(order);
        }

        return orders;
    }
}
