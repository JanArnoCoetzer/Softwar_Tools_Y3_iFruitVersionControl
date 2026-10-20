using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.Mapping;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using Xunit;

public class FileResultMapperTests
{
    [Theory]
    [InlineData(FileResult.Success, DbResult.Success)]
    [InlineData(FileResult.FileAlreadyExists, DbResult.DuplicateRecord)]
    [InlineData(FileResult.InvalidPath, DbResult.MismatchedStructure)]
    [InlineData(FileResult.IOError, DbResult.ExecutionError)]
    public void ToCreateTableResult_ReturnsExpectedResult(
        object input,
        object expected)
    {
        Assert.Equal(
            (DbResult)expected,
            FileResultMapper.ToCreateTableResult((FileResult)input));
    }

    [Theory]
    [InlineData(FileResult.Success, DbResult.Success)]
    [InlineData(FileResult.FileNotFound, DbResult.TableNotFound)]
    [InlineData(FileResult.InvalidPath, DbResult.MismatchedStructure)]
    public void ToDeleteTableResult_ReturnsExpectedResult(
        object input,
        object expected)
    {
        Assert.Equal(
            (DbResult)expected,
            FileResultMapper.ToDeleteTableResult((FileResult)input));
    }

    [Theory]
    [InlineData(FileResult.Success, DbResult.Success)]
    [InlineData(FileResult.FileNotFound, DbResult.TableNotFound)]
    [InlineData(FileResult.InvalidPath, DbResult.InvalidTableName)]
    [InlineData(FileResult.FileLocked, DbResult.TableLocked)]
    [InlineData(FileResult.IOError, DbResult.IOError)]
    public void ToReadResult_ReturnsExpectedResult(
        object input,
        object expected)
    {
        Assert.Equal(
            (DbResult)expected,
            FileResultMapper.ToReadResult((FileResult)input));
    }

    [Theory]
    [InlineData(FileResult.Success, DbResult.Success)]
    [InlineData(FileResult.InvalidPath, DbResult.InvalidTableName)]
    [InlineData(FileResult.FileLocked, DbResult.TableLocked)]
    [InlineData(FileResult.IOError, DbResult.IOError)]
    public void ToWriteResult_ReturnsExpectedResult(
        object input,
        object expected)
    {
        Assert.Equal(
            (DbResult)expected,
            FileResultMapper.ToWriteResult((FileResult)input));
    }
}