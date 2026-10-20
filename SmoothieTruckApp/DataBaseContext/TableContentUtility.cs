using System;
using System.Collections.Generic;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.DataBaseContext
{
    internal static class TableContentUtility
    {
        private static readonly string[] LineSeparators =
        {
            Environment.NewLine,
            "\n",
            "\r"
        };

        public static string[] SplitIntoLines(string fileContent)
        {
            if (string.IsNullOrWhiteSpace(fileContent))
            {
                return Array.Empty<string>();
            }

            return fileContent.Split(
                LineSeparators,
                StringSplitOptions.RemoveEmptyEntries);
        }

        public static bool TryGetSchema(
            string fileContent,
            TableSerializer serializer,
            out TableColumn[] schemaColumns)
        {
            schemaColumns = null;

            string[] lines = SplitIntoLines(fileContent);

            if (lines.Length == 0)
            {
                return false;
            }

            schemaColumns = serializer.DeserializeHeader(lines[0]);

            return schemaColumns != null &&
                   schemaColumns.Length > 0;
        }

        public static bool TryGetRowLines(
            string fileContent,
            out List<string> rowLines)
        {
            rowLines = null;

            string[] lines = SplitIntoLines(fileContent);

            if (lines.Length == 0)
            {
                return false;
            }

            rowLines = new List<string>();

            for (int i = 1; i < lines.Length; i++)
            {
                rowLines.Add(lines[i]);
            }

            return true;
        }

        public static string BuildFileContent(
            string headerLine,
            IReadOnlyList<string> rowLines)
        {
            var lines = new List<string>
            {
                headerLine
            };

            lines.AddRange(rowLines);

            return string.Join(Environment.NewLine, lines) +
                   Environment.NewLine;
        }

        public static string AppendRow(
            string fileContent,
            string serializedRow)
        {
            if (fileContent.EndsWith(Environment.NewLine) ||
                fileContent.EndsWith("\n"))
            {
                return fileContent + serializedRow + Environment.NewLine;
            }

            return fileContent +
                   Environment.NewLine +
                   serializedRow +
                   Environment.NewLine;
        }
    }
}