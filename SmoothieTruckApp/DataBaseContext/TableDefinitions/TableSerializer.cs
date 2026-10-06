using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SmoothieTruckApp.DataBaseContext.TableDefinitions
{
    internal class TableSerializer
    {
        private const char Delimiter = '|';

        private const string EscapedPipe = "\\p";

        public string SerializeRow(object[] values)
        {
            if (values == null || values.Length == 0) return string.Empty;

            var serializedValues = values.Select(val =>
            {
                if (val == null) return string.Empty;

                if (val is decimal decVal)
                {
                    return decVal.ToString(CultureInfo.InvariantCulture);
                }

                string strVal = val.ToString();
                return strVal.Replace(Delimiter.ToString(), EscapedPipe);
            });

            return string.Join(Delimiter.ToString(), serializedValues);
        }

        public object[] DeserializeRow(string rawLine, TableColumn[] columns)
        {
            if (string.IsNullOrWhiteSpace(rawLine) || columns == null || columns.Length == 0)
            {
                return Array.Empty<object>();
            }

            string[] splitParts = rawLine.Split(Delimiter);
            object[] parsedObjects = new object[columns.Length];

            for (int i = 0; i < columns.Length; i++)
            {

                if (i >= splitParts.Length)
                {
                    parsedObjects[i] = GetDefaultValue(columns[i].VarType);
                    continue;
                }

                string rawValue = splitParts[i].Trim();

                try
                {
                    switch (columns[i].VarType)
                    {
                        case DataType.INTEGER:
                            parsedObjects[i] = int.TryParse(rawValue, out int intResult) ? intResult : 0;
                            break;

                        case DataType.DECIMAL:
                            parsedObjects[i] = decimal.TryParse(rawValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decResult)
                                ? decResult
                                : 0.0m;
                            break;

                        case DataType.STRING:
                        default:

                            parsedObjects[i] = rawValue.Replace(EscapedPipe, Delimiter.ToString());
                            break;
                    }
                }
                catch (Exception)
                {
                    parsedObjects[i] = GetDefaultValue(columns[i].VarType);
                }
            }

            return parsedObjects;
        }

        public TableColumn[] DeserializeHeader(string headerLine)
        {
            if (string.IsNullOrWhiteSpace(headerLine))
            {
                return Array.Empty<TableColumn>();
            }

            string[] tokens = headerLine.Split(Delimiter);
            List<TableColumn> columns = new List<TableColumn>();

            foreach (string token in tokens)
            {
                if (string.IsNullOrWhiteSpace(token)) continue;

                int colonIndex = token.IndexOf(':');
                if (colonIndex == -1) continue;

                string columnName = token.Substring(0, colonIndex).Trim();
                string columnTypeStr = token.Substring(colonIndex + 1).Trim();

                if (Enum.TryParse(columnTypeStr, out DataType dataType))
                {
                    columns.Add(new TableColumn(columnName, dataType));
                }
            }

            return columns.ToArray();
        }


        public string SerializeHeader(TableColumn[] columns)
        {
            if (columns == null || columns.Length == 0) return string.Empty;

            var headerFields = columns.Select(col => $"{col.DataName}:{col.VarType}");
            return string.Join($" {Delimiter} ", headerFields);
        }

        private object GetDefaultValue(DataType type)
        {
            return type switch
            {
                DataType.INTEGER => 0,
                DataType.DECIMAL => 0.0m,
                DataType.STRING => string.Empty,
                _ => string.Empty
            };
        }
    }
}
