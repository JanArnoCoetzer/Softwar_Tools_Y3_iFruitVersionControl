//These tests are designed to test adding, removing and clearing items in an order and the receipt.
using SmoothieTruckApp.Models;
using Xunit;

public class OrderItemTests
{
    private static readonly MenuItem MangoTango = new MenuItem { Id = 1, Name = "Mango Tango", Price = 9.00m };
    private static readonly MenuItem BerryBlast = new MenuItem { Id = 2, Name = "Berry Blast", Price = 9.50m };

    [Fact]
    public void AddItem_SameItemAddsToExistingLine()
    {
        var order = new Order();
        order.AddItem(MangoTango);
        order.AddItem(MangoTango, 2);
        //should be one line with 3 not two lines
        Assert.Single(order.Lines);
        Assert.Equal(3, order.ItemCount);
    }

    [Fact]
    public void AddItem_ThrowsWhenQuantityIsZero()
    {
        var order = new Order();

        Assert.Throws<ArgumentOutOfRangeException>(() => order.AddItem(MangoTango, 0));
    }

    [Fact]
    public void RemoveItem_RemovesWholeLine()
    {
        var order = new Order();
        order.AddItem(MangoTango, 2);
        order.AddItem(BerryBlast);

        Assert.True(order.RemoveItem(1));
        Assert.Equal(1, order.ItemCount);
        Assert.False(order.RemoveItem(1));
    }

    [Fact]
    public void RemoveOne_TakesOneOffAndRemovesLineAtZero()
    {
        var order = new Order();
        order.AddItem(MangoTango, 2);

        Assert.True(order.RemoveOne(1));
        Assert.Equal(1, order.ItemCount);
        //taking the last one off removes the line
        Assert.True(order.RemoveOne(1));
        Assert.Empty(order.Lines);
        Assert.False(order.RemoveOne(1));
    }

    [Fact]
    public void Clear_RemovesAllItems()
    {
        var order = new Order();
        order.AddItem(MangoTango);
        order.AddItem(BerryBlast);

        order.Clear();

        Assert.Empty(order.Lines);
        Assert.Equal(0m, order.Total);
    }

    [Fact]
    public void GetReceipt_ShowsTicketLinesAndTotals()
    {
        var order = new Order { Id = 42 };
        order.AddItem(MangoTango, 2);

        string receipt = order.GetReceipt();
        //2 x 9.00 = 18.00, tax 1.44, total 19.44
        Assert.Contains("Ticket #42", receipt);
        Assert.Contains("2 × Mango Tango   $18.00", receipt);
        Assert.Contains("Subtotal: $18.00", receipt);
        Assert.Contains("Tax (8%): $1.44", receipt);
        Assert.Contains("Total: $19.44", receipt);
    }
}
//all tests return as successful