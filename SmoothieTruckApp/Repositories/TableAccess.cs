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

        FileResult result = FileRepository.ReadFile(tableName, out string content);

        System.Diagnostics.Debug.WriteLine(
            $"ReadRows: Table={tableName}, Read result={result}");

        if (result != FileResult.Success)
        {
            return rows;
        }

        string[] lines = content.Split(
            new[] { "\r\n", "\n" },
            StringSplitOptions.RemoveEmptyEntries);

        if (lines.Length == 0)
        {
            System.Diagnostics.Debug.WriteLine("Table file is empty.");
            return rows;
        }

        System.Diagnostics.Debug.WriteLine($"Raw header: {lines[0]}");

        TableColumn[] columns = Serializer.DeserializeHeader(lines[0]);

        System.Diagnostics.Debug.WriteLine(
            $"Deserialized header column count: {columns.Length}");

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
            {
                continue;
            }

            System.Diagnostics.Debug.WriteLine($"Raw row {i}: {lines[i]}");

            object[] row = Serializer.DeserializeRow(lines[i], columns);

            System.Diagnostics.Debug.WriteLine(
                $"Deserialized row {i}: Columns={row.Length}, " +
                $"Values={string.Join(" | ", row)}");

            rows.Add(row);
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
        System.Diagnostics.Debug.WriteLine(
            $"ReplaceRow started. Table: {tableName}, ID: {id}, Value count: {values.Length}");

        DatabaseEngine engine = DefaultDatabaseContext.Engine;

        DbResult loadResult = engine.LoadTable(tableName, out Table table);

        System.Diagnostics.Debug.WriteLine(
            $"ReplaceRow: LoadTable returned {loadResult}");

        if (loadResult != DbResult.Success)
        {
            return false;
        }

        DbResult replaceResult = table.ReplaceRowById(id, values);

        System.Diagnostics.Debug.WriteLine(
            $"ReplaceRow: ReplaceRowById returned {replaceResult}");

        if (replaceResult != DbResult.Success)
        {
            return false;
        }

        DbResult saveResult = engine.SaveTable(table);

        System.Diagnostics.Debug.WriteLine(
            $"ReplaceRow: SaveTable returned {saveResult}");

        return saveResult == DbResult.Success;
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
