using SmoothieTruckApp.Models;

namespace SmoothieTruckApp.Services;

internal static class RevenueService
{
    //only completed orders with an order time count as sales, from is included and to is not
    public static List<Order> Sales(List<Order> orders, DateTime from, DateTime to)
    {
        return orders
            .Where(o => o.Complete && o.OrderedAt.HasValue && o.OrderedAt.Value >= from && o.OrderedAt.Value < to)
            .ToList();
    }

    public static decimal TotalSales(List<Order> orders, DateTime from, DateTime to)
    {
        return Sales(orders, from, to).Sum(o => o.Total);
    }

    public static decimal AverageOrder(List<Order> orders, DateTime from, DateTime to)
    {
        List<Order> sales = Sales(orders, from, to);

        return sales.Count == 0 ? 0m : Math.Round(sales.Average(o => o.Total), 2);
    }

    //null when there was nothing to compare against
    public static decimal? PercentChange(decimal current, decimal previous)
    {
        if (previous == 0)
        {
            return null;
        }

        return Math.Round((current - previous) / previous * 100, 1);
    }

    //revenue here is before tax, the same as the line totals on the receipt
    public static List<(string Name, int Units, decimal Revenue)> TopBlends(List<Order> orders, DateTime from, DateTime to, int count)
    {
        return Sales(orders, from, to)
            .SelectMany(o => o.Lines)
            .GroupBy(l => l.Item.Id)
            .Select(g => (Name: g.First().Item.Name, Units: g.Sum(l => l.Quantity), Revenue: g.Sum(l => l.LineTotal)))
            .OrderByDescending(b => b.Units)
            .ThenByDescending(b => b.Revenue)
            .ThenBy(b => b.Name)
            .Take(count)
            .ToList();
    }

    public static List<(DateTime Day, decimal Total)> DailyTotals(List<Order> orders, DateTime start, int days)
    {
        var totals = new List<(DateTime Day, decimal Total)>();

        for (int i = 0; i < days; i++)
        {
            DateTime day = start.Date.AddDays(i);
            totals.Add((day, TotalSales(orders, day, day.AddDays(1))));
        }

        return totals;
    }

    public static DateTime WeekStart(DateTime date)
    {
        //monday is the first day of the week
        int daysSinceMonday = ((int)date.DayOfWeek + 6) % 7;
        return date.Date.AddDays(-daysSinceMonday);
    }

    public static DateTime MonthStart(DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1);
    }
}
