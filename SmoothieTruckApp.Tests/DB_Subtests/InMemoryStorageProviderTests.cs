using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.Storage;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using Xunit;

public class InMemoryStorageProviderTests
{
    private readonly InMemoryStorageProvider storage = new();

    [Fact]
    public void CreateFile_ExistingName_ReturnsFileAlreadyExists()
    {
        Assert.Equal(FileResult.Success, storage.CreateFile("items"));

        Assert.Equal(
            FileResult.FileAlreadyExists,
            storage.CreateFile("items"));
    }

    [Fact]
    public void WriteAndRead_ReturnsStoredText()
    {
        Assert.Equal(
            FileResult.Success,
            storage.WriteFile("items", "test content"));

        Assert.Equal(
            FileResult.Success,
            storage.ReadFile("items", out string content));

        Assert.Equal("test content", content);
    }

    [Fact]
    public void WriteFile_ExistingName_ReplacesContent()
    {
        Assert.Equal(
            FileResult.Success,
            storage.WriteFile("items", "old"));

        Assert.Equal(
            FileResult.Success,
            storage.WriteFile("items", "new"));

        Assert.Equal(
            FileResult.Success,
            storage.ReadFile("items", out string content));

        Assert.Equal("new", content);
    }

    [Fact]
    public void DeleteFile_RemovesContent()
    {
        Assert.Equal(FileResult.Success, storage.CreateFile("items"));
        Assert.Equal(FileResult.Success, storage.DeleteFile("items"));

        Assert.Equal(
            FileResult.FileNotFound,
            storage.ReadFile("items", out _));
    }
}