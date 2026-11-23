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

    // Column layout of ordered_items_table (one row per order line):
    // line_index PK | order_index FK | item_index FK | quantity | complete | ordered_at | completed_at
    private const int LineIdColumn = 0;
    private const int OrderIdColumn = 1;
    private const int ItemIdColumn = 2;
    private const int QuantityColumn = 3;
    private const int CompleteColumn = 4;
    private const int OrderedAtColumn = 5;
    private const int CompletedAtColumn = 6;

    public static int GetNextOrderNumber()
    {
        // The order number lives in order_index, not the line PK, so lines
        // from the same order can share it.
        List<object[]> rows = TableAccess.ReadRows(OrderedItemsTable);

        return rows.Count == 0
            ? 1
            : rows.Max(r => (int)r[OrderIdColumn]) + 1;
    }

    public static int Save(Order order)
    {
        if (order.Lines.Count == 0)
        {
            return 0;
        }

        //copy of the table so a failed save does not leave half an order
        if (FileRepository.ReadFile(OrderedItemsTable, out string backup)
            != FileResult.Success)
        {
            return 0;
        }

        int orderNumber = GetNextOrderNumber();

        order.OrderedAt ??= DateTime.Now;

        string orderedAt = FormatTimestamp(order.OrderedAt);
        string completedAt = FormatTimestamp(order.CompletedAt);

        foreach (OrderLine line in order.Lines)
        {
            // Each line gets its own PK; AppendRow may bump it, which is fine
            // because the order is identified by order_index.
            bool appended = TableAccess.AppendRow(
                OrderedItemsTable,
                new object[]
                {
                    TableAccess.NextIndex(OrderedItemsTable),
                    orderNumber,
                    line.Item.Id,
                    line.Quantity,
                    order.Complete,
                    orderedAt,
                    completedAt
                });

            if (!appended)
            {
                FileRepository.WriteFile(OrderedItemsTable, backup);
                return 0;
            }
        }

        order.Id = orderNumber;
        return orderNumber;
    }

    public static List<Order> GetAll()
    {
        Dictionary<int, MenuItem> menu = MenuItemRepository.GetAll()
            .ToDictionary(m => m.Id);

        List<object[]> lineRows = TableAccess.ReadRows(OrderedItemsTable);

        var orders = new List<Order>();

        foreach (var orderRows in lineRows.GroupBy(row => (int)row[OrderIdColumn]))
        {
            object[] firstRow = orderRows.First();

            bool complete = orderRows.All(row =>
                row.Length > CompleteColumn &&
                bool.TryParse(row[CompleteColumn]?.ToString(), out bool value) &&
                value);

            var order = new Order
            {
                Id = orderRows.Key,
                Complete = complete,
                OrderedAt = ReadTimestamp(firstRow, OrderedAtColumn),
                CompletedAt = complete
                    ? ReadTimestamp(firstRow, CompletedAtColumn)
                    : null
            };

            foreach (object[] lineRow in orderRows)
            {
                int itemId = (int)lineRow[ItemIdColumn];

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
                    Quantity = (int)lineRow[QuantityColumn]
                });
            }

            orders.Add(order);
        }

        return orders;
    }

    public static bool MarkComplete(int orderId)
    {
        List<object[]> rows = TableAccess.ReadRows(OrderedItemsTable)
            .Where(r => (int)r[OrderIdColumn] == orderId)
            .ToList();

        if (rows.Count == 0)
        {
            System.Diagnostics.Debug.WriteLine(
                $"MarkComplete failed: order {orderId} was not found.");

            return false;
        }

        //copy of the table so a failed update does not leave half an order complete
        if (FileRepository.ReadFile(OrderedItemsTable, out string backup)
            != FileResult.Success)
        {
            return false;
        }

        // One completion time for the whole order; keep an existing one.
        DateTime completedAt =
            rows.Select(r => ReadTimestamp(r, CompletedAtColumn))
                .FirstOrDefault(t => t.HasValue)
            ?? DateTime.Now;

        foreach (object[] row in rows)
        {
            string orderedAt = row.Length > OrderedAtColumn
                ? row[OrderedAtColumn]?.ToString() ?? string.Empty
                : string.Empty;

            bool replaced = TableAccess.ReplaceRow(
                OrderedItemsTable,
                (int)row[LineIdColumn],
                new[]
                {
                    new RowValue(
                        DataType.INTEGER,
                        orderId.ToString(CultureInfo.InvariantCulture)),

                    new RowValue(
                        DataType.INTEGER,
                        ((int)row[ItemIdColumn]).ToString(CultureInfo.InvariantCulture)),

                    new RowValue(
                        DataType.INTEGER,
                        ((int)row[QuantityColumn]).ToString(CultureInfo.InvariantCulture)),

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

            if (!replaced)
            {
                FileRepository.WriteFile(OrderedItemsTable, backup);

                System.Diagnostics.Debug.WriteLine(
                    $"MarkComplete failed: line {row[LineIdColumn]} of order {orderId} could not be updated.");

                return false;
            }
        }

        System.Diagnostics.Debug.WriteLine(
            $"MarkComplete: Order={orderId}, Lines={rows.Count}, " +
            $"CompletedAt={FormatTimestamp(completedAt)}");

        return true;
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