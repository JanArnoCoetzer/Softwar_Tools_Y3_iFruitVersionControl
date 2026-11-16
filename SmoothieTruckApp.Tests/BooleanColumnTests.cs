//These tests are designed to test saving, reading and checking true/false columns in the database.
using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.Domain;
using SmoothieTruckApp.DataBaseContext.Serialization;
using SmoothieTruckApp.DataBaseContext.Storage;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using Xunit;

public class BooleanColumnTests
{
    private readonly TableSerializer serializer = new();

    private static readonly TableColumn[] Columns =
    {
        new TableColumn("order_index PK", DataType.INTEGER),
        new TableColumn("item_index FK", DataType.INTEGER),
        new TableColumn("quantity", DataType.INTEGER),
        new TableColumn("complete", DataType.BOOLEAN)
    };

    [Fact]
    public void SerializeRow_WritesBooleanAsText()
    {
        Assert.Equal("1|2|3|True", serializer.SerializeRow(new object[] { 1, 2, 3, true }));
        Assert.Equal("1|2|3|False", serializer.SerializeRow(new object[] { 1, 2, 3, false }));
    }

    [Fact]
    public void DeserializeHeader_ReadsBooleanColumn()
    {
        TableColumn[] columns = serializer.DeserializeHeader("order_index PK:INTEGER | complete:BOOLEAN");

        Assert.Equal(2, columns.Length);
        Assert.Equal(DataType.BOOLEAN, columns[1].VarType);
    }

    [Fact]
    public void DeserializeHeader_ThrowsForUnknownType()
    {
        Assert.Throws<FormatException>(() => serializer.DeserializeHeader("order_index PK:INTEGER | complete:YESNO"));
    }

    [Theory]
    [InlineData("1|2|3|True", true)]
    [InlineData("1|2|3|false", false)]
    [InlineData("1|2|3| True ", true)]
    public void DeserializeRow_ParsesBoolean(string line, bool expected)
    {
        object[] row = serializer.DeserializeRow(line, Columns);

        Assert.Equal(expected, Assert.IsType<bool>(row[3]));
    }

    [Theory]
    [InlineData("1|2|3|maybe")]
    [InlineData("1|2|3")]
    public void DeserializeRow_BadOrMissingBooleanIsFalse(string line)
    {
        object[] row = serializer.DeserializeRow(line, Columns);
        //old rows without the complete column load as not complete
        Assert.False(Assert.IsType<bool>(row[3]));
    }

    [Fact]
    public void ParseInput_AcceptsBooleanValue()
    {
        var schema = new TableSchema(Columns);

        DbResult result = schema.ParseInput(Line("True"), out object[] values);

        Assert.Equal(DbResult.Success, result);
        Assert.True(Assert.IsType<bool>(values[3]));
    }

    [Fact]
    public void ParseInput_RejectsTextThatIsNotBoolean()
    {
        var schema = new TableSchema(Columns);

        Assert.Equal(DbResult.ValidationError, schema.ParseInput(Line("yes"), out _));
    }

    [Fact]
    public void ParseInput_RejectsWrongTypeForBooleanColumn()
    {
        var schema = new TableSchema(Columns);
        RowValue[] input = Line("True");
        input[2] = new RowValue(DataType.STRING, "True");

        Assert.Equal(DbResult.ValidationError, schema.ParseInput(input, out _));
    }

    [Fact]
    public void IsValidRecord_ChecksBooleanType()
    {
        var schema = new TableSchema(Columns);

        Assert.True(schema.IsValidRecord(new object[] { 1, 2, 3, true }));
        Assert.False(schema.IsValidRecord(new object[] { 1, 2, 3, "True" }));
    }

    [Fact]
    public void SaveAndLoad_KeepsBooleanValue()
    {
        var database = new DatabaseEngine(
            new InMemoryStorageProvider(),
            new TableDocumentSerializer(new TableSerializer()));
        var table = new Table("orders", new TableSchema(Columns));

        Assert.Equal(DbResult.Success, table.AddRow(Line("True")));
        Assert.Equal(DbResult.Success, database.SaveTable(table));
        Assert.Equal(DbResult.Success, database.LoadTable("orders", out Table loaded));

        Row row = Assert.Single(loaded.Rows);
        Assert.True(Assert.IsType<bool>(row.GetValue(3)));
    }

    private static RowValue[] Line(string complete)
    {
        return new[]
        {
            new RowValue(DataType.INTEGER, "2"),
            new RowValue(DataType.INTEGER, "3"),
            new RowValue(DataType.BOOLEAN, complete)
        };
    }
}
//all tests return as successful
