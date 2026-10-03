//These tests are designed to test the order total/subtotal and tax calculations.
using SmoothieTruckApp.Models;
using Xunit;

public class OrderTotalTests
{
    [Fact]
    public void Subtotal_ReturnsCorrectSum()
    {
        var order = new Order();
        //using values from ux page design
        order.Lines.Add(new OrderLine { Item = new MenuItem { Name = "Tropical Sunrise", Price = 9.50m }, Quantity = 2 });
        order.Lines.Add(new OrderLine { Item = new MenuItem { Name = "Mango Tango", Price = 9.00m }, Quantity = 1 });

        Assert.Equal(28.00m, order.Subtotal);
    }

    [Fact]
    public void Tax_ReturnsEightPercentOfSubtotalRounded()
    {
        var order = new Order();
        order.Lines.Add(new OrderLine { Item = new MenuItem { Name = "Mango Tango", Price = 9.00m }, Quantity = 3 });
        //checking tax calculation with hardcoded correct value for multiple items (3x)
        Assert.Equal(2.16m, order.Tax);
    }

    [Fact]
    public void Total_IsSubtotalPlusTax()
    {
        var order = new Order();
        order.Lines.Add(new OrderLine { Item = new MenuItem { Name = "Green Machine", Price = 10.00m }, Quantity = 1 });
        Assert.Equal(10.80m, order.Total);
    }

    [Fact]
    public void EmptyOrder_HasZeroTotals()
    {
        var order = new Order();

        Assert.Equal(0m, order.Subtotal);
        Assert.Equal(0m, order.Total);
    }
}
//all tests return as successful