using System.Globalization;
using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.Domain;
using SmoothieTruckApp.DataBaseContext.Serialization;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.Repositories;

internal static class TableAccess
{
    private static readonly TableSerializer Serializer = new();

    public static List<object[]> ReadRows(string tableName)
    {
        var rows = new List<object[]>();

        if (FileRepository.ReadFile(tableName, out string content) != FileResult.Success)
        {
            return rows;
        }

        string[] lines = content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

        if (lines.Length == 0)
        {
            return rows;
        }

        TableColumn[] columns = Serializer.DeserializeHeader(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
            {
                continue;
            }

            rows.Add(Serializer.DeserializeRow(lines[i], columns));
        }

        return rows;
    }

    public static int NextIndex(string tableName)
    {
        List<object[]> rows = ReadRows(tableName);

        return rows.Count == 0 ? 1 : rows.Max(r => (int)r[0]) + 1;
    }

    public static bool AppendRow(string tableName, object[] values)
    {
        if (FileRepository.ReadFile(tableName, out string content) != FileResult.Success || string.IsNullOrWhiteSpace(content))
        {
            return false;
        }

        string newContent = content.TrimEnd() + Environment.NewLine + Serializer.SerializeRow(values) + Environment.NewLine;

        return FileRepository.WriteFile(tableName, newContent) == FileResult.Success;
    }

    public static bool ReplaceRow(string tableName, int id, RowValue[] values)
    {
        DatabaseEngine engine = DefaultDatabaseContext.Engine;

        if (engine.LoadTable(tableName, out Table table) != DbResult.Success)
        {
            return false;
        }

        if (table.ReplaceRowById(id, values) != DbResult.Success)
        {
            return false;
        }

        return engine.SaveTable(table) == DbResult.Success;
    }

    public static bool DeleteRow(string tableName, int id)
    {
        DatabaseEngine engine = DefaultDatabaseContext.Engine;

        if (engine.LoadTable(tableName, out Table table) != DbResult.Success)
        {
            return false;
        }

        if (table.DeleteRowById(id) != DbResult.Success)
        {
            return false;
        }

        return engine.SaveTable(table) == DbResult.Success;
    }

    public static RowValue Text(string value)
    {
        return new RowValue(DataType.STRING, value);
    }

    public static RowValue Number(decimal value)
    {
        return new RowValue(DataType.DECIMAL, value.ToString(CultureInfo.InvariantCulture));
    }
}
