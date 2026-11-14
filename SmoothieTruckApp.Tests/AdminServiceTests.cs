//These tests are designed to test the admin stock input checks before anything is saved.
using SmoothieTruckApp.Services;
using Xunit;

public class AdminServiceTests
{
    //only tests the checks that return an error, so nothing is written to the db
    [Fact]
    public void AddStock_RejectsEmptyName()
    {
        Assert.Equal("Enter a stock name.", AdminService.AddStock(" ", 1m, "kg"));
    }

    [Fact]
    public void AddStock_RejectsEmptyUnit()
    {
        Assert.Equal("Enter a unit, e.g. kg or l.", AdminService.AddStock("Mango", 1m, ""));
    }

    [Fact]
    public void AddStock_RejectsNegativeQuantity()
    {
        Assert.Equal("Quantity cannot be negative.", AdminService.AddStock("Mango", -1m, "kg"));
    }

    [Fact]
    public void Restock_RejectsZeroOrLess()
    {
        Assert.Equal("Restock amount must be more than 0.", AdminService.Restock(1, 0m));
        Assert.Equal("Restock amount must be more than 0.", AdminService.Restock(1, -2m));
    }

    [Fact]
    public void SetStockQuantity_RejectsNegative()
    {
        Assert.Equal("Quantity cannot be negative.", AdminService.SetStockQuantity(1, -1m));
    }

    [Fact]
    public void StockChanges_ReturnNotFoundForMissingId()
    {
        //-1 is never used as an id so it only reads the table
        Assert.Equal("Stock item not found.", AdminService.Restock(-1, 1m));
        Assert.Equal("Stock item not found.", AdminService.SetStockQuantity(-1, 1m));
        Assert.Equal("Stock item not found.", AdminService.DeleteStock(-1));
    }
}
//all tests return as successful