//These tests are designed to test the smoke test the Docker container runs to check the app tables load.
using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.Domain;
using SmoothieTruckApp.DataBaseContext.Serialization;
using SmoothieTruckApp.DataBaseContext.Storage;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using SmoothieTruckApp.Services;
using Xunit;

public class SmokeTestTests
{
    private readonly DatabaseEngine database = new(
        new InMemoryStorageProvider(),
        new TableDocumentSerializer(new TableSerializer()));

    [Fact]
    public void Run_AllTablesLoad_ReturnsZero()
    {
        SaveTable("item_table", withRow: true);
        SaveTable("stock_table", withRow: true);
        SaveTable("recipe_table", withRow: true);
        SaveTable("ordered_items_table", withRow: false);

        Assert.Equal(0, SmokeTest.Run(database));
    }

    [Fact]
    public void Run_MissingTable_ReturnsOne()
    {
        SaveTable("item_table", withRow: true);
        SaveTable("recipe_table", withRow: true);
        SaveTable("ordered_items_table", withRow: false);

        Assert.Equal(1, SmokeTest.Run(database));
    }

    [Fact]
    public void Run_EmptyMenu_ReturnsOne()
    {
        SaveTable("item_table", withRow: false);
        SaveTable("stock_table", withRow: true);
        SaveTable("recipe_table", withRow: true);
        SaveTable("ordered_items_table", withRow: false);

        Assert.Equal(1, SmokeTest.Run(database));
    }

    [Fact]
    public void Run_MissingOrderTable_ReturnsOne()
    {
        SaveTable("item_table", withRow: true);
        SaveTable("stock_table", withRow: true);
        SaveTable("recipe_table", withRow: true);

        Assert.Equal(1, SmokeTest.Run(database));
    }

    private void SaveTable(string name, bool withRow)
    {
        var table = new Table(name, new TableSchema(new[]
        {
            new TableColumn("id PK", DataType.INTEGER),
            new TableColumn("name", DataType.STRING)
        }));

        if (withRow)
        {
            Assert.Equal(DbResult.Success, table.AddRow(new[] { new RowValue(DataType.STRING, "Mango") }));
        }

        Assert.Equal(DbResult.Success, database.SaveTable(table));
    }
}
//all tests return as successful
