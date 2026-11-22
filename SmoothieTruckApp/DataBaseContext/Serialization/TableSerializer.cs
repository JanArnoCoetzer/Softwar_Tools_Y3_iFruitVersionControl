using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SmoothieTruckApp.DataBaseContext.Serialization
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

                return Escape(val.ToString() ?? string.Empty);
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
                            parsedObjects[i] = int.TryParse(rawValue, out int intResult)
                                ? intResult
                                : 0;
                            break;

                        case DataType.DECIMAL:
                            parsedObjects[i] = decimal.TryParse(
                                rawValue,
                                NumberStyles.Any,
                                CultureInfo.InvariantCulture,
                                out decimal decResult)
                                ? decResult
                                : 0.0m;
                            break;

                        case DataType.BOOLEAN:
                            parsedObjects[i] = bool.TryParse(rawValue, out bool boolResult)
                                ? boolResult
                                : false;
                            break;

                        case DataType.STRING:
                        default:
                            parsedObjects[i] = Unescape(rawValue);
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
            var columns = new List<TableColumn>();

            foreach (string token in tokens)
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    continue;
                }

                int colonIndex = token.IndexOf(':');

                if (colonIndex == -1)
                {
                    throw new FormatException(
                        $"Invalid column definition: '{token.Trim()}'.");
                }

                string columnName = token.Substring(0, colonIndex).Trim();
                string columnTypeStr = token.Substring(colonIndex + 1).Trim();

                if (!Enum.TryParse(
                        columnTypeStr,
                        ignoreCase: true,
                        out DataType dataType)
                    || !Enum.IsDefined(typeof(DataType), dataType))
                {
                    throw new FormatException(
                        $"Unsupported data type '{columnTypeStr}' " +
                        $"for column '{columnName}'.");
                }

                columns.Add(new TableColumn(columnName, dataType));
            }

            return columns.ToArray();
        }


        public string SerializeHeader(TableColumn[] columns)
        {
            if (columns == null || columns.Length == 0) return string.Empty;

            var headerFields = columns.Select(col => $"{col.DataName}:{col.VarType}");
            return string.Join($" {Delimiter} ", headerFields);
        }

        //backslash is escaped first so \p typed by a user is not read back as a pipe
        private static string Escape(string value)
        {
            return value
                .Replace("\\", "\\\\")
                .Replace(Delimiter.ToString(), EscapedPipe)
                .Replace("\r", "\\r")
                .Replace("\n", "\\n");
        }

        private static string Unescape(string value)
        {
            var result = new StringBuilder(value.Length);

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] != '\\' || i == value.Length - 1)
                {
                    result.Append(value[i]);
                    continue;
                }

                char next = value[i + 1];

                switch (next)
                {
                    case '\\': result.Append('\\'); i++; break;
                    case 'p': result.Append(Delimiter); i++; break;
                    case 'r': result.Append('\r'); i++; break;
                    case 'n': result.Append('\n'); i++; break;
                    default: result.Append(value[i]); break;
                }
            }

            return result.ToString();
        }

        private object GetDefaultValue(DataType type)
        {
            return type switch
            {
                DataType.INTEGER => 0,
                DataType.DECIMAL => 0.0m,
                DataType.BOOLEAN => false,
                DataType.STRING => string.Empty,
                _ => string.Empty
            };
        }
    }
    
}
