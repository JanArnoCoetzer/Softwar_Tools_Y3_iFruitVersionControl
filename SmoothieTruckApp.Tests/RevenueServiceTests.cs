//These tests are designed to test the revenue totals, average order, top blends and daily sales.
using SmoothieTruckApp.Models;
using SmoothieTruckApp.Services;
using Xunit;

public class RevenueServiceTests
{
    private static readonly MenuItem MangoTango = new MenuItem { Id = 1, Name = "Mango Tango", Price = 9.00m };
    private static readonly MenuItem BerryBlast = new MenuItem { Id = 2, Name = "Berry Blast", Price = 9.50m };

    //monday 16 nov 2026
    private static readonly DateTime Monday = new DateTime(2026, 11, 16);

    private static Order MakeOrder(DateTime? orderedAt, bool complete, MenuItem item, int quantity)
    {
        var order = new Order { OrderedAt = orderedAt, Complete = complete };
        order.AddItem(item, quantity);
        return order;
    }

    private static List<Order> Orders() => new List<Order>
    {
        //2 x 9.00 = 18.00 + tax 1.44 = 19.44
        MakeOrder(Monday.AddHours(10), true, MangoTango, 2),
        //1 x 9.50 = 9.50 + tax 0.76 = 10.26
        MakeOrder(Monday.AddHours(12), true, BerryBlast, 1),
        //not complete so not a sale
        MakeOrder(Monday.AddHours(13), false, BerryBlast, 5),
        //tuesday 3 x 9.50 = 28.50 + tax 2.28 = 30.78
        MakeOrder(Monday.AddDays(1).AddHours(9), true, BerryBlast, 3)
    };

    [Fact]
    public void TotalSales_AddsUpCompletedOrdersOnly()
    {
        Assert.Equal(29.70m, RevenueService.TotalSales(Orders(), Monday, Monday.AddDays(1)));
    }

    [Fact]
    public void TotalSales_SkipsOrdersWithoutOrderTime()
    {
        var orders = new List<Order> { MakeOrder(null, true, MangoTango, 1) };

        Assert.Equal(0m, RevenueService.TotalSales(orders, Monday, Monday.AddDays(1)));
    }

    [Fact]
    public void AverageOrder_DividesByCompletedOrders()
    {
        Assert.Equal(14.85m, RevenueService.AverageOrder(Orders(), Monday, Monday.AddDays(1)));
    }

    [Fact]
    public void AverageOrder_ReturnsZeroWhenNoSales()
    {
        Assert.Equal(0m, RevenueService.AverageOrder(Orders(), Monday.AddDays(5), Monday.AddDays(6)));
    }

    [Fact]
    public void PercentChange_ComparesToPreviousPeriod()
    {
        Assert.Equal(12.5m, RevenueService.PercentChange(112.50m, 100m));
        Assert.Equal(-50m, RevenueService.PercentChange(50m, 100m));
        Assert.Null(RevenueService.PercentChange(50m, 0m));
    }

    [Fact]
    public void TopBlends_RanksByUnitsSold()
    {
        var top = RevenueService.TopBlends(Orders(), Monday, Monday.AddDays(7), 4);
        //berry blast 1 + 3 sold, the 5 not complete are left out
        Assert.Equal(2, top.Count);
        Assert.Equal(("Berry Blast", 4, 38.00m), top[0]);
        Assert.Equal(("Mango Tango", 2, 18.00m), top[1]);
    }

    [Fact]
    public void TopBlends_OnlyReturnsCountAsked()
    {
        Assert.Single(RevenueService.TopBlends(Orders(), Monday, Monday.AddDays(7), 1));
    }

    [Fact]
    public void DailyTotals_ReturnsOneTotalPerDay()
    {
        var days = RevenueService.DailyTotals(Orders(), Monday, 7);

        Assert.Equal(7, days.Count);
        Assert.Equal(Monday, days[0].Day);
        Assert.Equal(29.70m, days[0].Total);
        Assert.Equal(30.78m, days[1].Total);
        Assert.Equal(0m, days[6].Total);
    }

    [Fact]
    public void WeekStart_ReturnsMonday()
    {
        Assert.Equal(Monday, RevenueService.WeekStart(new DateTime(2026, 11, 22, 18, 0, 0)));
        Assert.Equal(Monday, RevenueService.WeekStart(Monday.AddHours(8)));
    }

    [Fact]
    public void MonthStart_ReturnsFirstOfMonth()
    {
        Assert.Equal(new DateTime(2026, 11, 1), RevenueService.MonthStart(Monday.AddHours(15)));
    }
}
//all tests return as successful
