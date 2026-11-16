using System.Globalization;
using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using SmoothieTruckApp.Models;
using MenuItem = SmoothieTruckApp.Models.MenuItem;

namespace SmoothieTruckApp.Repositories;

internal static class OrderRepository
{
    private const string OrderedItemsTable = "ordered_items_table";

    public static int GetNextOrderNumber()
    {
        return TableAccess.NextIndex(OrderedItemsTable);
    }

    public static int Save(Order order)
    {


        if (order.Lines.Count == 0)
        {

            return 0;
        }

        int orderNumber = GetNextOrderNumber();


        foreach (OrderLine line in order.Lines)
        {
           

            bool appended = TableAccess.AppendRow(
                OrderedItemsTable,
                new object[]
                {
                orderNumber,
                line.Item.Id,
                line.Quantity,
                false
                });

          

            if (!appended)
            {
                return 0;
            }
        }

       

        return orderNumber;
    }

    public static List<Order> GetAll()
    {
        Dictionary<int, MenuItem> menu = MenuItemRepository.GetAll()
            .ToDictionary(m => m.Id);

        List<object[]> lineRows = TableAccess.ReadRows(OrderedItemsTable);

        foreach (object[] row in lineRows)
        {
            System.Diagnostics.Debug.WriteLine(
                $"Row columns: {row.Length}, Values: {string.Join(" | ", row)}");

            if (row.Length > 3)
            {
                System.Diagnostics.Debug.WriteLine(
                    $"Complete value: {row[3]}, Type: {row[3]?.GetType().FullName}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Complete column is missing.");
            }
        }


        var orders = new List<Order>();

        foreach (var orderRows in lineRows.GroupBy(row => (int)row[0]))
        {
            var order = new Order
            {
                Id = orderRows.Key,
                Complete = orderRows.All(row =>
                    row.Length > 3 &&
                    bool.TryParse(row[3]?.ToString(), out bool complete) &&
                    complete)
            };

            foreach (object[] lineRow in orderRows)
            {
                int itemId = (int)lineRow[1];

                MenuItem item = menu.TryGetValue(itemId, out MenuItem? found)
                    ? found
                    : new MenuItem { Id = itemId, Name = $"Item #{itemId}" };

                order.Lines.Add(new OrderLine
                {
                    Item = item,
                    Quantity = (int)lineRow[2]
                });
            }

            orders.Add(order);
        }

        return orders;
    }

    public static bool MarkComplete(int orderId)
    {
        List<object[]> rows = TableAccess.ReadRows(OrderedItemsTable);

        object[]? row = rows.FirstOrDefault(r => (int)r[0] == orderId);

        if (row == null)
        {
            System.Diagnostics.Debug.WriteLine(
                $"MarkComplete failed: order {orderId} was not found.");

            return false;
        }

        bool success = TableAccess.ReplaceRow(
            OrderedItemsTable,
            orderId,
            new[]
            {
            new RowValue(DataType.INTEGER, ((int)row[1]).ToString()),
            new RowValue(DataType.INTEGER, ((int)row[2]).ToString()),
            new RowValue(DataType.BOOLEAN, bool.TrueString)
            });

        System.Diagnostics.Debug.WriteLine(
            $"MarkComplete: ReplaceRow returned {success}.");

        return success;
    }
}
