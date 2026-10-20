using System;
using System.Collections.Generic;
using SmoothieTruckApp.DataBaseContext.Domain;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.DataBaseContext.Serialization
{
    internal sealed class TableDocumentSerializer
    {
        private readonly TableSerializer serializer;

        public TableDocumentSerializer(TableSerializer serializer)
        {
            this.serializer = serializer
                ?? throw new ArgumentNullException(nameof(serializer));
        }

        public string Serialize(Table table)
        {
            var lines = new List<string>
            {
                serializer.SerializeHeader(table.Schema.GetColumns())
            };

            foreach (Row row in table.Rows)
            {
                lines.Add(serializer.SerializeRow(row.GetValues()));
            }

            return string.Join(Environment.NewLine, lines)
                + Environment.NewLine;
        }

        public DbResult Deserialize(
            string name,
            string content,
            out Table table)
        {
            table = null;

            if (string.IsNullOrWhiteSpace(content))
            {
                return DbResult.MismatchedStructure;
            }

            try
            {
                string[] lines = content.Split(
                    new[] { "\r\n", "\n", "\r" },
                    StringSplitOptions.RemoveEmptyEntries);

                TableColumn[] columns =
                    serializer.DeserializeHeader(lines[0]);

                var schema = new TableSchema(columns);
                var loadedTable = new Table(name, schema);

                for (int i = 1; i < lines.Length; i++)
                {
                    object[] values =
                        serializer.DeserializeRow(lines[i], columns);

                    DbResult result = loadedTable.AddParsedRow(values);

                    if (result != DbResult.Success)
                    {
                        return result;
                    }
                }

                table = loadedTable;
                return DbResult.Success;
            }
            catch (Exception)
            {
                return DbResult.MismatchedStructure;
            }
        }
    }
}