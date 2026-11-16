using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

        order.OrderedAt ??= DateTime.Now;

        string orderedAt = FormatTimestamp(order.OrderedAt);
        string completedAt = FormatTimestamp(order.CompletedAt);

        foreach (OrderLine line in order.Lines)
        {
            bool appended = TableAccess.AppendRow(
                OrderedItemsTable,
                new object[]
                {
                    orderNumber,
                    line.Item.Id,
                    line.Quantity,
                    order.Complete,
                    orderedAt,
                    completedAt
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

        var orders = new List<Order>();

        foreach (var orderRows in lineRows.GroupBy(row => (int)row[0]))
        {
            object[] firstRow = orderRows.First();

            bool complete = orderRows.All(row =>
                row.Length > 3 &&
                bool.TryParse(row[3]?.ToString(), out bool value) &&
                value);

            var order = new Order
            {
                Id = orderRows.Key,
                Complete = complete,
                OrderedAt = ReadTimestamp(firstRow, 4),
                CompletedAt = complete
                    ? ReadTimestamp(firstRow, 5)
                    : null
            };

            foreach (object[] lineRow in orderRows)
            {
                int itemId = (int)lineRow[1];

                MenuItem item = menu.TryGetValue(itemId, out MenuItem? found)
                    ? found
                    : new MenuItem
                    {
                        Id = itemId,
                        Name = $"Item #{itemId}"
                    };

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

        string orderedAt = row.Length > 4
            ? row[4]?.ToString() ?? string.Empty
            : string.Empty;

        // Preserve an existing completion timestamp.
        DateTime completedAt = ReadTimestamp(row, 5) ?? DateTime.Now;

        bool success = TableAccess.ReplaceRow(
            OrderedItemsTable,
            orderId,
            new[]
            {
                new RowValue(
                    DataType.INTEGER,
                    ((int)row[1]).ToString(CultureInfo.InvariantCulture)),

                new RowValue(
                    DataType.INTEGER,
                    ((int)row[2]).ToString(CultureInfo.InvariantCulture)),

                new RowValue(
                    DataType.BOOLEAN,
                    bool.TrueString),

                new RowValue(
                    DataType.STRING,
                    orderedAt),

                new RowValue(
                    DataType.STRING,
                    FormatTimestamp(completedAt))
            });

        System.Diagnostics.Debug.WriteLine(
            $"MarkComplete: Order={orderId}, " +
            $"CompletedAt={FormatTimestamp(completedAt)}, " +
            $"Success={success}");

        return success;
    }

    private static string FormatTimestamp(DateTime? timestamp)
    {
        return timestamp?.ToString(
            "O",
            CultureInfo.InvariantCulture)
            ?? string.Empty;
    }

    private static DateTime? ReadTimestamp(object[] row, int index)
    {
        if (index >= row.Length)
        {
            return null;
        }

        string? raw = row[index]?.ToString();

        if (string.IsNullOrWhiteSpace(raw))
        {
            return null;
        }

        return DateTime.TryParse(
            raw,
            CultureInfo.InvariantCulture,
            DateTimeStyles.RoundtripKind,
            out DateTime timestamp)
            ? timestamp
            : null;
    }
}