using SmoothieTruckApp.Models;

namespace SmoothieTruckApp.Services;

internal static class QueueService
{
    public const int MinutesPerSmoothie = 4;

    //only kept while the app is open, will swap for completed_at once column is in the db
    private static readonly Dictionary<int, (DateTime CompletedAt, int WaitMinutes)> completed = new();

    public static List<Order> GetInProgress(List<Order> orders)
    {
        return orders
            .Where(o => !o.Complete)
            .OrderBy(o => o.Id)
            .ToList();
    }

    public static List<(Order Order, DateTime? CompletedAt, int? WaitMinutes)>
     GetCompleted(List<Order> orders)
    {
        return orders
            .Where(o => o.Complete)
            .Select(o =>
            {
                //saved times come from the db so they still show after a restart
                if (o.OrderedAt.HasValue && o.CompletedAt.HasValue)
                {
                    return (
                        Order: o,
                        CompletedAt: o.CompletedAt,
                        WaitMinutes: (int?)Math.Max(0, (int)(o.CompletedAt.Value - o.OrderedAt.Value).TotalMinutes));
                }

                if (completed.TryGetValue(o.Id, out var details))
                {
                    return (
                        Order: o,
                        CompletedAt: (DateTime?)details.CompletedAt,
                        WaitMinutes: (int?)details.WaitMinutes);
                }

                return (
                    Order: o,
                    CompletedAt: (DateTime?)null,
                    WaitMinutes: (int?)null);
            })
            .OrderBy(c => c.Order.Id)
            .ToList();
    }

    public static Dictionary<int, int> CalculateWaitTimes(List<Order> queue)
    {
        var waits = new Dictionary<int, int>();
        int smoothies = 0;

        foreach (Order order in queue)
        {
            //counts this orders smoothies too so its the time until ready
            smoothies += order.ItemCount;
            waits[order.Id] = smoothies * MinutesPerSmoothie;
        }

        return waits;
    }

    public static void Complete(int orderId, int waitMinutes)
    {
        completed[orderId] = (DateTime.Now, waitMinutes);
    }
}
