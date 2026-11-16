//These tests are designed to test marking orders complete and loading completed orders after the app restarts.
using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.Domain;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using SmoothieTruckApp.Models;
using SmoothieTruckApp.Repositories;
using SmoothieTruckApp.Services;
using Xunit;

public class OrderCompletionTests
{
    private const string OrdersTable = "ordered_items_table";
    private const string Header = "order_index PK:INTEGER | item_index FK:INTEGER | quantity:INTEGER | complete:BOOLEAN | ordered_at:STRING | completed_at:STRING";

    private static readonly MenuItem MangoTango = new MenuItem { Id = 1, Name = "Mango Tango", Price = 9.00m };

    public OrderCompletionTests()
    {
        //fresh orders table in the test project db folder for each test
        FileRepository.WriteFile(OrdersTable, Header + Environment.NewLine);
    }

    private static Table MakeTable()
    {
        var table = new Table(OrdersTable, new TableSchema(new[]
        {
            new TableColumn("order_index PK", DataType.INTEGER),
            new TableColumn("item_index FK", DataType.INTEGER),
            new TableColumn("quantity", DataType.INTEGER),
            new TableColumn("complete", DataType.BOOLEAN)
        }));

        table.AddRowWithId(7, Values(bool.FalseString));
        return table;
    }

    private static RowValue[] Values(string complete)
    {
        return new[]
        {
            new RowValue(DataType.INTEGER, "1"),
            new RowValue(DataType.INTEGER, "2"),
            new RowValue(DataType.BOOLEAN, complete)
        };
    }

    [Fact]
    public void ReplaceRowById_UpdatesCompleteWithoutId()
    {
        Table table = MakeTable();

        Assert.Equal(DbResult.Success, table.ReplaceRowById(7, Values(bool.TrueString)));

        Row row = Assert.Single(table.Rows);
        Assert.Equal(7, row.Id);
        Assert.Equal(1, row.GetValue(1));
        Assert.Equal(2, row.GetValue(2));
        Assert.True((bool)row.GetValue(3));
    }

    [Fact]
    public void ReplaceRowById_RejectsValuesThatIncludeId()
    {
        Table table = MakeTable();
        var withId = new[] { new RowValue(DataType.INTEGER, "7") }.Concat(Values(bool.TrueString)).ToArray();

        Assert.Equal(DbResult.MismatchedStructure, table.ReplaceRowById(7, withId));
        //row is left as it was
        Assert.False((bool)Assert.Single(table.Rows).GetValue(3));
    }

    [Fact]
    public void MarkComplete_ReturnsFalseForMissingOrder()
    {
        Assert.False(OrderRepository.MarkComplete(99));
    }

    [Fact]
    public void GetAll_LoadsCompletedOrderAfterRestart()
    {
        var order = new Order();
        order.AddItem(MangoTango, 2);

        int id = OrderRepository.Save(order);
        Assert.True(OrderRepository.MarkComplete(id));

        //reading from the file again is the same as opening the app again
        List<Order> loaded = OrderRepository.GetAll();

        Order saved = Assert.Single(loaded);
        Assert.Equal(id, saved.Id);
        Assert.True(saved.Complete);
        Assert.NotNull(saved.OrderedAt);
        Assert.NotNull(saved.CompletedAt);
        Assert.Equal(2, saved.ItemCount);
        Assert.Empty(QueueService.GetInProgress(loaded));
        Assert.Equal(id, Assert.Single(QueueService.GetCompleted(loaded)).Order.Id);
    }

    [Fact]
    public void GetAll_LoadsUnfinishedOrderAsInProgress()
    {
        var order = new Order();
        order.AddItem(MangoTango);

        int id = OrderRepository.Save(order);

        List<Order> loaded = OrderRepository.GetAll();

        Assert.False(Assert.Single(loaded).Complete);
        Assert.Equal(id, Assert.Single(QueueService.GetInProgress(loaded)).Id);
        Assert.Empty(QueueService.GetCompleted(loaded));
    }
}
//all tests return as successful
