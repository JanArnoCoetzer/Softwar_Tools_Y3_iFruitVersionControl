//These tests are designed to test the order queue wait times and the in progress/completed lists.
using SmoothieTruckApp.Models;
using SmoothieTruckApp.Services;
using Xunit;

public class QueueServiceTests
{
    private static readonly MenuItem MangoTango = new MenuItem { Id = 1, Name = "Mango Tango", Price = 9.00m };

    private static Order MakeOrder(int id, int smoothies)
    {
        var order = new Order { Id = id };
        order.AddItem(MangoTango, smoothies);
        return order;
    }

    [Fact]
    public void CalculateWaitTimes_AddsUpSmoothiesInQueue()
    {
        var queue = new List<Order> { MakeOrder(1, 2), MakeOrder(2, 1) };

        Dictionary<int, int> waits = QueueService.CalculateWaitTimes(queue);
        //first order 2 x 4 min, second waits for those plus its own
        Assert.Equal(8, waits[1]);
        Assert.Equal(12, waits[2]);
    }

    [Fact]
    public void CalculateWaitTimes_ReturnsEmptyForEmptyQueue()
    {
        Assert.Empty(QueueService.CalculateWaitTimes(new List<Order>()));
    }

    [Fact]
    public void GetInProgress_SortsByTicketNumber()
    {
        //ids used here are not completed by any other test
        var orders = new List<Order> { MakeOrder(203, 1), MakeOrder(201, 1) };

        List<Order> inProgress = QueueService.GetInProgress(orders);

        Assert.Equal(new List<int> { 201, 203 }, inProgress.Select(o => o.Id).ToList());
    }

    [Fact]
    public void Complete_MovesOrderToCompleted()
    {
        var orders = new List<Order> { MakeOrder(301, 2), MakeOrder(302, 1) };
        //complete now comes from the db, MarkComplete sets it there
        orders[0].Complete = true;

        QueueService.Complete(301, 8);

        Assert.Equal(new List<int> { 302 }, QueueService.GetInProgress(orders).Select(o => o.Id).ToList());

        var completed = QueueService.GetCompleted(orders);
        Assert.Single(completed);
        Assert.Equal(301, completed[0].Order.Id);
        Assert.Equal(8, completed[0].WaitMinutes);
    }

    [Fact]
    public void GetCompleted_SortsByTicketNumber()
    {
        var orders = new List<Order> { MakeOrder(402, 1), MakeOrder(401, 1) };
        orders.ForEach(o => o.Complete = true);

        Assert.Equal(new List<int> { 401, 402 }, QueueService.GetCompleted(orders).Select(c => c.Order.Id).ToList());
    }
}
//all tests return as successful