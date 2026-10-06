using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;

public class DataBaseTests
{
    //same header as the item_table file
    private const string Header = "item_index PK:INTEGER | name:STRING | price:DECIMAL";

    private readonly TableSerializer serializer = new();

    private readonly TableColumn[] columns =
    {
        new TableColumn("item_index PK", DataType.INTEGER),
        new TableColumn("name", DataType.STRING),
        new TableColumn("price", DataType.DECIMAL)
    };

    [Fact]
    public void SerializeRow_JoinsValuesWithPipe()
    {
        Assert.Equal("1|Mango Tango|9.50", serializer.SerializeRow(new object[] { 1, "Mango Tango", 9.50m }));
    }

    [Fact]
    public void DeserializeRow_ReturnsCorrectTypes()
    {
        //checking the text comes back as int, string and decimal, not all strings
        object[] row = serializer.DeserializeRow("1|Mango Tango|9.50", columns);

        Assert.Equal(1, row[0]);
        Assert.Equal("Mango Tango", row[1]);
        Assert.Equal(9.50m, row[2]);
    }

    [Fact]
    public void SerializeHeader_MatchesTableFile()
    {
        Assert.Equal(Header, serializer.SerializeHeader(columns));
    }

    [Fact]
    public void WriteThenRead_ReturnsSameText()
    {
        string table = NewTable();

        FileRepository.write_file(table, "hello");
        FileRepository.read_file(table, out string content);

        Assert.Equal("hello", content);
    }

    [Fact]
    public void ReadFile_MissingTable_ReturnsFileNotFound()
    {
        //database returns a result code instead of crashing when the table doesnt exist
        Assert.Equal(FileResult.FileNotFound, FileRepository.read_file("missing_table", out _));
    }

    [Fact]
    public void DeleteFile_ExistingTable_DeletesIt()
    {
        string table = NewTable();
        FileRepository.create_file(table);
        FileResult result = FileRepository.delete_file(table);
        Assert.Equal(FileResult.Success, result);
        Assert.Equal(FileResult.FileNotFound, FileRepository.read_file(table, out _));
        //failed
    }

    [Fact]
    public void AddNewRow_AddsRowWithNextId()
    {
        string table = NewTable();
        FileRepository.write_file(table, Header);

        //only name and price are passed in, add_new_row generates id
        AddItem(table, "Mango Tango", "9.00");
        AddItem(table, "Green Machine", "10.00");

        Assert.Equal(new[] { Header, "1|Mango Tango|9.00", "2|Green Machine|10.00" }, ReadLines(table));
    }

    [Fact]
    public void AddNewRow_WrongType_ReturnsValidationError()
    {
        string table = NewTable();
        FileRepository.write_file(table, Header);

        DbResult result = DataBase.add_new_row(table, new[]
        {
            new RowValue(DataType.STRING, "Mango Tango"),
            new RowValue(DataType.DECIMAL, "abc")
        });

        Assert.Equal(DbResult.ValidationError, result);
        Assert.Equal(new[] { Header }, ReadLines(table));
    }

    [Fact]
    public void DeleteRow_RemovesFirstRow()
    {
        string table = NewTable();
        FileRepository.write_file(table, Header);
        AddItem(table, "Mango Tango", "9.00");
        AddItem(table, "Green Machine", "10.00");
        DataBase.DeleteRow(table, 0);

        Assert.Equal(new[] { Header, "2|Green Machine|10.00" }, ReadLines(table));
    }

    [Fact]
    public void DeleteRow_PositionPastEnd_ReturnsRecordNotFound()
    {
        string table = NewTable();
        FileRepository.write_file(table, Header);
        AddItem(table, "Mango Tango", "9.00");
        AddItem(table, "Green Machine", "10.00");

        DbResult result = DataBase.DeleteRow(table, 5);

        Assert.Equal(DbResult.RecordNotFound, result);
        Assert.Equal(new[] { Header, "1|Mango Tango|9.00", "2|Green Machine|10.00" }, ReadLines(table));
    }

    //guid gives every test its own random table name so tests dont clash with each other or the real tables
    private static string NewTable() => "test_" + Guid.NewGuid().ToString("N");

    private static void AddItem(string table, string name, string price)
    {
        DbResult result = DataBase.add_new_row(table, new[]
        {
            new RowValue(DataType.STRING, name),
            new RowValue(DataType.DECIMAL, price)
        });

        Assert.Equal(DbResult.Success, result);
    }

    private static string[] ReadLines(string table)
    {
        FileRepository.read_file(table, out string content);
        return content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
    }
}
