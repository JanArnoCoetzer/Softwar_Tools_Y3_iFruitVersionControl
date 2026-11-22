//These tests are designed to test safe table writes with a backup and the checks on text saved to the table files.
using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.Serialization;
using SmoothieTruckApp.DataBaseContext.Storage;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using SmoothieTruckApp.Services;
using Xunit;

public class SafeSaveTests : IDisposable
{
    private readonly string directory = Path.Combine(
        Path.GetTempPath(),
        "SmoothieTruckAppTests",
        Guid.NewGuid().ToString("N"));

    private readonly TableSerializer serializer = new();

    private static readonly TableColumn[] Columns =
    {
        new TableColumn("item_index PK", DataType.INTEGER),
        new TableColumn("name", DataType.STRING)
    };

    [Fact]
    public void WriteFile_KeepsPreviousContentAsBackup()
    {
        var storage = new FileStorageProvider(directory);

        Assert.Equal(FileResult.Success, storage.WriteFile("items", "old"));
        Assert.Equal(FileResult.Success, storage.WriteFile("items", "new"));

        Assert.Equal("new", File.ReadAllText(Path.Combine(directory, "items")));
        Assert.Equal("old", File.ReadAllText(Path.Combine(directory, "items.bak")));
        Assert.False(File.Exists(Path.Combine(directory, "items.tmp")));
    }

    [Fact]
    public void WriteFile_NewFile_HasNoBackupOrTempFile()
    {
        var storage = new FileStorageProvider(directory);

        Assert.Equal(FileResult.Success, storage.WriteFile("items", "Mango"));

        Assert.False(File.Exists(Path.Combine(directory, "items.bak")));
        Assert.False(File.Exists(Path.Combine(directory, "items.tmp")));
    }

    [Theory]
    [InlineData("Mango | Lime")]
    [InlineData("Line one\r\nLine two")]
    [InlineData("Back\\slash and \\p")]
    public void SerializeRow_SpecialCharacters_StayOnOneLineAndReadBack(string name)
    {
        string line = serializer.SerializeRow(new object[] { 1, name });

        Assert.DoesNotContain("\n", line);
        Assert.DoesNotContain("\r", line);
        Assert.Equal(2, line.Split('|').Length);

        object[] row = serializer.DeserializeRow(line, Columns);

        Assert.Equal(name, row[1]);
    }

    [Fact]
    public void DeserializeRow_OldEscapedPipe_StillReadsBack()
    {
        object[] row = serializer.DeserializeRow("1|Mango\\pLime", Columns);

        Assert.Equal("Mango|Lime", row[1]);
    }

    [Fact]
    public void CheckText_AllowsNormalName()
    {
        Assert.Null(InputValidator.CheckText("Mango Tango", "recipe name"));
    }

    [Fact]
    public void CheckText_RejectsEmpty()
    {
        Assert.Equal("Enter a recipe name.", InputValidator.CheckText("  ", "recipe name"));
    }

    [Fact]
    public void CheckText_RejectsLineBreaks()
    {
        Assert.Equal(
            "The recipe name cannot contain line breaks or tabs.",
            InputValidator.CheckText("Mango\nTango", "recipe name"));
    }

    [Fact]
    public void CheckText_RejectsTooLong()
    {
        Assert.Equal(
            $"The recipe name must be {InputValidator.MaxTextLength} characters or less.",
            InputValidator.CheckText(new string('a', InputValidator.MaxTextLength + 1), "recipe name"));
    }

    [Fact]
    public void AddStock_RejectsLineBreakInName()
    {
        Assert.Equal(
            "The stock name cannot contain line breaks or tabs.",
            AdminService.AddStock("Mango\r\nLime", 1m, "kg"));
    }

    public void Dispose()
    {
        if (Directory.Exists(directory))
        {
            Directory.Delete(directory, recursive: true);
        }
    }
}
//all tests return as successful
