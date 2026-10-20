using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.Domain;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using Xunit;

public class RowTests
{
    private readonly TableSchema schema = new(new[]
    {
        new TableColumn("id PK", DataType.INTEGER),
        new TableColumn("name", DataType.STRING)
    });

    [Fact]
    public void TryCreate_ValidValues_CreatesRow()
    {
        bool result = Row.TryCreate(
            schema,
            new object[] { 1, "Mango" },
            out Row row);

        Assert.True(result);
        Assert.NotNull(row);
        Assert.Equal(1, row.Id);
        Assert.Equal("Mango", row.GetValue(1));
    }

    [Fact]
    public void TryCreate_InvalidValues_DoesNotCreateRow()
    {
        bool result = Row.TryCreate(
            schema,
            new object[] { "invalid ID", "Mango" },
            out Row row);

        Assert.False(result);
        Assert.Null(row);
    }

    [Fact]
    public void TryCreate_CopiesInputArray()
    {
        object[] values = { 1, "Mango" };

        Assert.True(Row.TryCreate(schema, values, out Row row));

        values[1] = "Changed";

        Assert.Equal("Mango", row.GetValue(1));
    }

    [Fact]
    public void GetValues_ReturnsCopy()
    {
        Assert.True(Row.TryCreate(
            schema,
            new object[] { 1, "Mango" },
            out Row row));

        object[] values = row.GetValues();
        values[1] = "Changed";

        Assert.Equal("Mango", row.GetValue(1));
    }
}