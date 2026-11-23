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
    private const string Header = "line_index PK:INTEGER | order_index FK:INTEGER | item_index FK:INTEGER | quantity:INTEGER | complete:BOOLEAN | ordered_at:STRING | completed_at:STRING";

    private static readonly MenuItem MangoTango = new MenuItem { Id = 1, Name = "Mango Tango", Price = 9.00m };
    private static readonly MenuItem BerryBlast = new MenuItem { Id = 2, Name = "Berry Blast", Price = 8.50m };

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

    //bugfix: an order with different smoothies must load back as one ticket, not one per line
    [Fact]
    public void GetAll_LoadsMixedOrderAsOneTicket()
    {
        var order = new Order();
        order.AddItem(MangoTango, 2);
        order.AddItem(BerryBlast);

        int id = OrderRepository.Save(order);

        Order saved = Assert.Single(OrderRepository.GetAll());
        Assert.Equal(id, saved.Id);
        Assert.Equal(2, saved.Lines.Count);
        Assert.Equal(3, saved.ItemCount);
    }

    //bugfix: completing a mixed order must complete every line, not just the first
    [Fact]
    public void MarkComplete_CompletesEveryLineOfMixedOrder()
    {
        var order = new Order();
        order.AddItem(MangoTango);
        order.AddItem(BerryBlast);

        int id = OrderRepository.Save(order);
        Assert.True(OrderRepository.MarkComplete(id));

        Order saved = Assert.Single(OrderRepository.GetAll());
        Assert.True(saved.Complete);
        Assert.NotNull(saved.CompletedAt);
        Assert.Empty(QueueService.GetInProgress(new List<Order> { saved }));
    }

    //bugfix: separate orders still get separate order numbers
    [Fact]
    public void Save_KeepsSeparateOrdersApart()
    {
        var first = new Order();
        first.AddItem(MangoTango);
        first.AddItem(BerryBlast);
        var second = new Order();
        second.AddItem(MangoTango);

        int firstId = OrderRepository.Save(first);
        int secondId = OrderRepository.Save(second);

        Assert.NotEqual(firstId, secondId);
        Assert.Equal(2, OrderRepository.GetAll().Count);
    }
}
