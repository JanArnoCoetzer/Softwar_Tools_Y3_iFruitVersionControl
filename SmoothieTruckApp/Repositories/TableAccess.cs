using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.Repositories;

internal static class TableAccess
{
    private static readonly TableSerializer Serializer = new();

    public static List<object[]> ReadRows(string tableName)
    {
        var rows = new List<object[]>();

        if (FileRepository.read_file(tableName, out string content) != FileResult.Success)
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
        if (FileRepository.read_file(tableName, out string content) != FileResult.Success || string.IsNullOrWhiteSpace(content))
        {
            return false;
        }

        string newContent = content.TrimEnd() + Environment.NewLine + Serializer.SerializeRow(values) + Environment.NewLine;

        return FileRepository.write_file(tableName, newContent) == FileResult.Success;
    }

    public static bool UpdateRow(string tableName, int id, object[] values)
    {
        if (FileRepository.read_file(tableName, out string content) != FileResult.Success)
        {
            return false;
        }

        string[] lines = content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

        if (lines.Length == 0)
        {
            return false;
        }

        TableColumn[] columns = Serializer.DeserializeHeader(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            object[] row = Serializer.DeserializeRow(lines[i], columns);

            if (row.Length > 0 && row[0] is int rowId && rowId == id)
            {
                lines[i] = Serializer.SerializeRow(values);
                string newContent = string.Join(Environment.NewLine, lines) + Environment.NewLine;

                return FileRepository.write_file(tableName, newContent) == FileResult.Success;
            }
        }

        return false;
    }
}
