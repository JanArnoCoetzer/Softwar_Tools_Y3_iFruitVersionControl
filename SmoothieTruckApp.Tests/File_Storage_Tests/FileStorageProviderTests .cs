using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.Storage;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using System;
using System.IO;
using Xunit;

public class FileStorageProviderTests : IDisposable
{
    private readonly string directory;
    private readonly FileStorageProvider storage;

    public FileStorageProviderTests()
    {
        directory = Path.Combine(
            Path.GetTempPath(),
            "SmoothieTruckAppTests",
            Guid.NewGuid().ToString("N"));

        storage = new FileStorageProvider(directory);
    }

    [Fact]
    public void CreateFile_CreatesDirectoryAndEmptyFile()
    {
        Assert.False(Directory.Exists(directory));

        FileResult result = storage.CreateFile("items");

        Assert.Equal(FileResult.Success, result);
        Assert.True(Directory.Exists(directory));
        Assert.True(File.Exists(Path.Combine(directory, "items")));

        Assert.Equal(
            FileResult.Success,
            storage.ReadFile("items", out string content));

        Assert.Equal(string.Empty, content);
    }

    [Fact]
    public void CreateFile_ExistingFile_DoesNotOverwriteContent()
    {
        Assert.Equal(
            FileResult.Success,
            storage.WriteFile("items", "original"));

        Assert.Equal(
            FileResult.FileAlreadyExists,
            storage.CreateFile("items"));

        Assert.Equal("original", ReadText("items"));
    }

    [Fact]
    public void WriteFile_MissingFile_CreatesIt()
    {
        Assert.Equal(
            FileResult.Success,
            storage.WriteFile("items", "Mango"));

        Assert.True(File.Exists(Path.Combine(directory, "items")));
        Assert.Equal("Mango", ReadText("items"));
    }

    [Fact]
    public void WriteFile_ExistingFile_ReplacesAllContent()
    {
        Assert.Equal(
            FileResult.Success,
            storage.WriteFile("items", "long original content"));

        Assert.Equal(
            FileResult.Success,
            storage.WriteFile("items", "new"));

        Assert.Equal("new", ReadText("items"));
    }

    [Fact]
    public void WriteFile_NullContent_EmptiesFile()
    {
        Assert.Equal(
            FileResult.Success,
            storage.WriteFile("items", "original"));

        Assert.Equal(
            FileResult.Success,
            storage.WriteFile("items", null));

        Assert.Equal(string.Empty, ReadText("items"));
    }

    [Fact]
    public void WriteAndRead_PreservesUnicodeAndLineBreaks()
    {
        string text = "Mángó €9.50\r\n草莓\nBerry";

        Assert.Equal(
            FileResult.Success,
            storage.WriteFile("items", text));

        Assert.Equal(text, ReadText("items"));
    }

    [Fact]
    public void ReadFile_MissingDirectory_ReturnsFileNotFound()
    {
        Assert.False(Directory.Exists(directory));

        FileResult result =
            storage.ReadFile("missing", out string content);

        Assert.Equal(FileResult.FileNotFound, result);
        Assert.Equal(string.Empty, content);
    }

    [Fact]
    public void ReadFile_MissingFile_ReturnsFileNotFound()
    {
        Assert.Equal(
            FileResult.Success,
            storage.CreateFile("items"));

        FileResult result =
            storage.ReadFile("missing", out string content);

        Assert.Equal(FileResult.FileNotFound, result);
        Assert.Equal(string.Empty, content);
    }

    [Fact]
    public void DeleteFile_ExistingFile_RemovesIt()
    {
        Assert.Equal(
            FileResult.Success,
            storage.WriteFile("items", "Mango"));

        Assert.Equal(
            FileResult.Success,
            storage.DeleteFile("items"));

        Assert.False(File.Exists(Path.Combine(directory, "items")));

        Assert.Equal(
            FileResult.FileNotFound,
            storage.ReadFile("items", out _));
    }

    [Fact]
    public void DeleteFile_MissingFile_ReturnsFileNotFound()
    {
        Assert.Equal(
            FileResult.FileNotFound,
            storage.DeleteFile("missing"));
    }

    [Fact]
    public void DeleteFile_DoesNotRemoveOtherFiles()
    {
        Assert.Equal(
            FileResult.Success,
            storage.WriteFile("items", "Mango"));

        Assert.Equal(
            FileResult.Success,
            storage.WriteFile("orders", "Order 1"));

        Assert.Equal(
            FileResult.Success,
            storage.DeleteFile("items"));

        Assert.Equal("Order 1", ReadText("orders"));
    }

    [Fact]
    public void NewProvider_SameDirectory_CanReadStoredFile()
    {
        Assert.Equal(
            FileResult.Success,
            storage.WriteFile("items", "Mango"));

        var secondProvider = new FileStorageProvider(directory);

        Assert.Equal(
            FileResult.Success,
            secondProvider.ReadFile("items", out string content));

        Assert.Equal("Mango", content);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(".")]
    [InlineData("..")]
    [InlineData("../outside")]
    [InlineData(@"..\outside")]
    [InlineData("folder/items")]
    [InlineData(@"folder\items")]
    public void FileOperations_InvalidName_ReturnInvalidPath(string name)
    {
        Assert.Equal(
            FileResult.InvalidPath,
            storage.CreateFile(name));

        Assert.Equal(
            FileResult.InvalidPath,
            storage.ReadFile(name, out string content));

        Assert.Equal(string.Empty, content);

        Assert.Equal(
            FileResult.InvalidPath,
            storage.WriteFile(name, "test"));

        Assert.Equal(
            FileResult.InvalidPath,
            storage.DeleteFile(name));

        Assert.False(Directory.Exists(directory));
    }

    [Fact]
    public void FileOperations_AbsolutePath_ReturnInvalidPath()
    {
        string absolutePath = Path.Combine(directory, "items");

        Assert.Equal(
            FileResult.InvalidPath,
            storage.CreateFile(absolutePath));

        Assert.Equal(
            FileResult.InvalidPath,
            storage.ReadFile(absolutePath, out _));

        Assert.Equal(
            FileResult.InvalidPath,
            storage.WriteFile(absolutePath, "test"));

        Assert.Equal(
            FileResult.InvalidPath,
            storage.DeleteFile(absolutePath));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_InvalidDirectory_ThrowsArgumentException(
        string path)
    {
        Assert.Throws<ArgumentException>(
            () => new FileStorageProvider(path));
    }

    private string ReadText(string name)
    {
        Assert.Equal(
            FileResult.Success,
            storage.ReadFile(name, out string content));

        return content;
    }

    public void Dispose()
    {
        if (Directory.Exists(directory))
        {
            Directory.Delete(directory, recursive: true);
        }
    }
}