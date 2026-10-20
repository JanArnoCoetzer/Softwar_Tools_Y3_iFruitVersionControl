using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.Domain;
using SmoothieTruckApp.DataBaseContext.Serialization;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using Xunit;

public class TableDocumentSerializerTests
{
    private readonly TableDocumentSerializer serializer =
        new(new TableSerializer());

    [Fact]
    public void SerializeAndDeserialize_PreservesTable()
    {
        var table = new Table("items", new TableSchema(new[]
        {
            new TableColumn("id PK", DataType.INTEGER),
            new TableColumn("name", DataType.STRING)
        }));

        Assert.Equal(
            DbResult.Success,
            table.AddRow(new[]
            {
                new RowValue(DataType.STRING, "Mango")
            }));

        string content = serializer.Serialize(table);

        DbResult result =
            serializer.Deserialize("items", content, out Table loaded);

        Assert.Equal(DbResult.Success, result);
        Assert.Equal("items", loaded.Name);

        Row row = Assert.Single(loaded.Rows);

        Assert.Equal(1, row.Id);
        Assert.Equal("Mango", row.GetValue(1));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Deserialize_EmptyContent_ReturnsMismatchedStructure(
        string content)
    {
        DbResult result =
            serializer.Deserialize("items", content, out Table table);

        Assert.Equal(DbResult.MismatchedStructure, result);
        Assert.Null(table);
    }

    [Fact]
    public void Deserialize_DuplicateIds_ReturnsDuplicateRecord()
    {
        string content =
            "id PK:INTEGER | name:STRING\n" +
            "1|Mango\n" +
            "1|Berry\n";

        DbResult result =
            serializer.Deserialize("items", content, out Table table);

        Assert.Equal(DbResult.DuplicateRecord, result);
        Assert.Null(table);
    }
}