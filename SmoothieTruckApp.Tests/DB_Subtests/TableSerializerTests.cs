using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.Serialization;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using Xunit;

public class TableSerializerTests
{
    private readonly TableSerializer serializer = new();

    private readonly TableColumn[] columns =
    {
        new TableColumn("id PK", DataType.INTEGER),
        new TableColumn("name", DataType.STRING),
        new TableColumn("price", DataType.DECIMAL)
    };

    [Fact]
    public void SerializeHeader_ReturnsExpectedText()
    {
        Assert.Equal(
            "id PK:INTEGER | name:STRING | price:DECIMAL",
            serializer.SerializeHeader(columns));
    }

    [Fact]
    public void SerializeRow_ReturnsExpectedText()
    {
        Assert.Equal(
            "1|Mango|9.50",
            serializer.SerializeRow(
                new object[] { 1, "Mango", 9.50m }));
    }

    [Fact]
    public void DeserializeRow_ReturnsCorrectTypes()
    {
        object[] values =
            serializer.DeserializeRow("1|Mango|9.50", columns);

        Assert.Equal(1, Assert.IsType<int>(values[0]));
        Assert.Equal("Mango", Assert.IsType<string>(values[1]));
        Assert.Equal(9.50m, Assert.IsType<decimal>(values[2]));
    }
}