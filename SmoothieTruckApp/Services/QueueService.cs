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
            .Where(o => !completed.ContainsKey(o.Id))
            .OrderBy(o => o.Id)
            .ToList();
    }

    public static List<(Order Order, DateTime CompletedAt, int WaitMinutes)> GetCompleted(List<Order> orders)
    {
        return orders
            .Where(o => completed.ContainsKey(o.Id))
            .Select(o => (o, completed[o.Id].CompletedAt, completed[o.Id].WaitMinutes))
            .OrderBy(c => c.CompletedAt)
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
