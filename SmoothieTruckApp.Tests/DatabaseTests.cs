using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.Domain;
using SmoothieTruckApp.DataBaseContext.Serialization;
using SmoothieTruckApp.DataBaseContext.Storage;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using Xunit;

public class DatabaseTests
{
    private readonly DatabaseEngine database;
    private readonly Table table;

    public DatabaseTests()
    {
        database = new DatabaseEngine(
            new InMemoryStorageProvider(),
            new TableDocumentSerializer(new TableSerializer()));

        table = new Table("items", new TableSchema(new[]
        {
            new TableColumn("id PK", DataType.INTEGER),
            new TableColumn("name", DataType.STRING),
            new TableColumn("price", DataType.DECIMAL)
        }));
    }

    [Fact]
    public void SaveAndLoad_PreservesRowValues()
    {
        Assert.Equal(DbResult.Success, table.AddRow(Item("Mango", "9.50")));
        Assert.Equal(DbResult.Success, database.SaveTable(table));

        Assert.Equal(
            DbResult.Success,
            database.LoadTable("items", out Table loaded));

        Row row = Assert.Single(loaded.Rows);

        Assert.Equal(1, row.Id);
        Assert.Equal("Mango", row.GetValue(1));
        Assert.Equal(9.50m, row.GetValue(2));
    }

    [Fact]
    public void AddRow_AssignsSequentialIds()
    {
        Assert.Equal(DbResult.Success, table.AddRow(Item("Mango", "9.00")));
        Assert.Equal(DbResult.Success, table.AddRow(Item("Berry", "10.00")));

        Assert.Equal(1, table.Rows[0].Id);
        Assert.Equal(2, table.Rows[1].Id);
    }

    [Fact]
    public void AddRow_InvalidPrice_DoesNotAddRecord()
    {
        DbResult result = table.AddRow(Item("Mango", "abc"));

        Assert.Equal(DbResult.ValidationError, result);
        Assert.Empty(table.Rows);
    }

    [Fact]
    public void AddRowWithId_DuplicateId_IsRejected()
    {
        Assert.Equal(
            DbResult.Success,
            table.AddRowWithId(7, Item("Mango", "9.00")));

        Assert.Equal(
            DbResult.DuplicateRecord,
            table.AddRowWithId(7, Item("Berry", "10.00")));

        Assert.Single(table.Rows);
    }

    [Fact]
    public void DeleteRowById_RemovesRecord()
    {
        Assert.Equal(DbResult.Success, table.AddRow(Item("Mango", "9.00")));

        Assert.Equal(DbResult.Success, table.DeleteRowById(1));

        Assert.Empty(table.Rows);
    }

    [Fact]
    public void DeleteTable_RemovesStoredTable()
    {
        Assert.Equal(DbResult.Success, database.SaveTable(table));
        Assert.Equal(DbResult.Success, database.DeleteTable("items"));

        Assert.Equal(
            DbResult.TableNotFound,
            database.LoadTable("items", out _));
    }

    private static RowValue[] Item(string name, string price)
    {
        return new[]
        {
            new RowValue(DataType.STRING, name),
            new RowValue(DataType.DECIMAL, price)
        };
    }
}