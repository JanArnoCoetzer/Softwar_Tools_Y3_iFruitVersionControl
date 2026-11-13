//These tests are designed to test the stock usage, shortage and smoothies left calculations.
using SmoothieTruckApp.Models;
using SmoothieTruckApp.Services;
using Xunit;

public class StockServiceTests
{
    //mango tango uses mango and banana, berry blast uses banana
    private static readonly MenuItem MangoTango = new MenuItem { Id = 1, Name = "Mango Tango", Price = 9.00m };
    private static readonly MenuItem BerryBlast = new MenuItem { Id = 2, Name = "Berry Blast", Price = 9.50m };

    private static List<RecipeIngredient> Recipes() => new List<RecipeIngredient>
    {
        new RecipeIngredient { Id = 1, ItemId = 1, StockId = 1, QuantityRequired = 0.2m },
        new RecipeIngredient { Id = 2, ItemId = 1, StockId = 2, QuantityRequired = 0.1m },
        new RecipeIngredient { Id = 3, ItemId = 2, StockId = 2, QuantityRequired = 0.15m }
    };

    private static List<StockItem> Stock(decimal mango, decimal banana) => new List<StockItem>
    {
        new StockItem { Id = 1, Name = "Mango", Quantity = mango, Unit = "kg" },
        new StockItem { Id = 2, Name = "Banana", Quantity = banana, Unit = "kg" }
    };

    [Fact]
    public void CalculateUsage_AddsUpIngredientsForEachSmoothie()
    {
        var order = new Order();
        order.AddItem(MangoTango, 2);
        order.AddItem(BerryBlast);

        Dictionary<int, decimal> usage = StockService.CalculateUsage(order, Recipes());
        //banana is shared, 2 x 0.1 + 1 x 0.15
        Assert.Equal(0.4m, usage[1]);
        Assert.Equal(0.35m, usage[2]);
    }

    [Fact]
    public void FindShortages_ReturnsEmptyWhenEnoughStock()
    {
        var order = new Order();
        order.AddItem(MangoTango, 2);

        Assert.Empty(StockService.FindShortages(order, Recipes(), Stock(1.0m, 1.0m)));
    }

    [Fact]
    public void FindShortages_ReturnsNameOfShortIngredient()
    {
        var order = new Order();
        order.AddItem(MangoTango, 2);
        //2 mango tangos need 0.4kg mango but only 0.3kg left
        List<string> shortages = StockService.FindShortages(order, Recipes(), Stock(0.3m, 1.0m));

        Assert.Equal(new List<string> { "Mango" }, shortages);
    }

    [Fact]
    public void CanAddOne_ReturnsFalseWhenNoStockLeftForAnother()
    {
        var order = new Order();
        order.AddItem(MangoTango);
        //only enough mango for the one already in the order
        Assert.False(StockService.CanAddOne(order, MangoTango, Recipes(), Stock(0.2m, 1.0m)));
        Assert.True(StockService.CanAddOne(order, BerryBlast, Recipes(), Stock(0.2m, 1.0m)));
    }

    [Fact]
    public void CanAddOne_DoesNotChangeOrder()
    {
        var order = new Order();
        order.AddItem(MangoTango);

        StockService.CanAddOne(order, MangoTango, Recipes(), Stock(1.0m, 1.0m));
        //checks a copy so the real order should still have 1
        Assert.Equal(1, order.ItemCount);
    }

    [Fact]
    public void SmoothiesLeft_UsesLargestAmountNeeded()
    {
        StockItem banana = Stock(1.0m, 1.0m)[1];
        //banana used 0.1 and 0.15, 1.0 / 0.15 = 6.66 rounded down
        Assert.Equal(6, StockService.SmoothiesLeft(banana, Recipes()));
    }

    [Fact]
    public void SmoothiesLeft_ReturnsNullWhenNotInAnyRecipe()
    {
        var ginger = new StockItem { Id = 3, Name = "Ginger", Quantity = 5m, Unit = "kg" };

        Assert.Null(StockService.SmoothiesLeft(ginger, Recipes()));
    }
}
//all tests return as successful
