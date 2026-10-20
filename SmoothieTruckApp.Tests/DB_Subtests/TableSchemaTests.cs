using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.Domain;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using Xunit;

public class TableSchemaTests
{
    private readonly TableSchema schema = new(new[]
    {
        new TableColumn("id PK", DataType.INTEGER),
        new TableColumn("name", DataType.STRING),
        new TableColumn("price", DataType.DECIMAL)
    });

    [Fact]
    public void ParseInput_ValidValues_ReturnsTypedValues()
    {
        DbResult result = schema.ParseInput(new[]
        {
            new RowValue(DataType.STRING, "Mango"),
            new RowValue(DataType.DECIMAL, "9.50")
        }, out object[] values);

        Assert.Equal(DbResult.Success, result);
        Assert.Equal(3, values.Length);
        Assert.Null(values[0]); // The table assigns the ID.
        Assert.Equal("Mango", Assert.IsType<string>(values[1]));
        Assert.Equal(9.50m, Assert.IsType<decimal>(values[2]));
    }

    [Fact]
    public void ParseInput_WrongValueCount_ReturnsMismatchedStructure()
    {
        DbResult result = schema.ParseInput(new[]
        {
            new RowValue(DataType.STRING, "Mango")
        }, out _);

        Assert.Equal(DbResult.MismatchedStructure, result);
    }

    [Fact]
    public void ParseInput_WrongDeclaredType_ReturnsValidationError()
    {
        DbResult result = schema.ParseInput(new[]
        {
            new RowValue(DataType.INTEGER, "12"),
            new RowValue(DataType.DECIMAL, "9.50")
        }, out _);

        Assert.Equal(DbResult.ValidationError, result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("abc")]
    public void ParseInput_InvalidDecimal_ReturnsValidationError(
        string price)
    {
        DbResult result = schema.ParseInput(new[]
        {
            new RowValue(DataType.STRING, "Mango"),
            new RowValue(DataType.DECIMAL, price)
        }, out _);

        Assert.Equal(DbResult.ValidationError, result);
    }

    [Fact]
    public void IsValidRecord_WrongStoredType_ReturnsFalse()
    {
        bool result = schema.IsValidRecord(
            new object[] { 1, "Mango", "9.50" });

        Assert.False(result);
    }
}