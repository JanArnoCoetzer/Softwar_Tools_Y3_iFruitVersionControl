using System;
using System.Globalization;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.DataBaseContext.Domain
{
    internal sealed class TableSchema
    {
        private readonly TableColumn[] columns;

        public int ColumnCount => columns.Length;

        public TableSchema(TableColumn[] columns)
        {
            if (columns == null || columns.Length == 0)
            {
                throw new ArgumentException(
                    "At least one column is required.",
                    nameof(columns));
            }

            this.columns = (TableColumn[])columns.Clone();
        }

        public TableColumn[] GetColumns()
        {
            return (TableColumn[])columns.Clone();
        }

        public DbResult ParseInput(
            RowValue[] values,
            out object[] parsedValues)
        {
            parsedValues = null;

            if (columns[0].VarType != DataType.INTEGER ||
                values == null ||
                values.Length != columns.Length - 1)
            {
                return DbResult.MismatchedStructure;
            }

            object[] parsed = new object[columns.Length];

            for (int i = 0; i < values.Length; i++)
            {
                RowValue input = values[i];
                DataType expectedType = columns[i + 1].VarType;

                if (input.DataType != expectedType ||
                    !TryParse(expectedType, input.Value, out object value))
                {
                    return DbResult.ValidationError;
                }

                parsed[i + 1] = value;
            }

            parsedValues = parsed;
            return DbResult.Success;
        }

        public bool IsValidRecord(object[] values)
        {
            if (values == null ||
                values.Length != columns.Length ||
                columns[0].VarType != DataType.INTEGER ||
                !(values[0] is int id) ||
                id < 0)
            {
                return false;
            }

            for (int i = 0; i < columns.Length; i++)
            {
                switch (columns[i].VarType)
                {
                    case DataType.INTEGER:
                        if (!(values[i] is int))
                        {
                            return false;
                        }
                        break;

                    case DataType.DECIMAL:
                        if (!(values[i] is decimal))
                        {
                            return false;
                        }
                        break;

                    case DataType.STRING:
                        if (!(values[i] is string))
                        {
                            return false;
                        }
                        break;

                    default:
                        return false;
                }
            }

            return true;
        }

        private static bool TryParse(
            DataType type,
            string raw,
            out object value)
        {
            value = null;

            if (raw == null)
            {
                return false;
            }

            switch (type)
            {
                case DataType.INTEGER:
                    if (int.TryParse(raw, out int integer))
                    {
                        value = integer;
                        return true;
                    }
                    return false;

                case DataType.DECIMAL:
                    if (decimal.TryParse(
                        raw,
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture,
                        out decimal number))
                    {
                        value = number;
                        return true;
                    }
                    return false;

                case DataType.STRING:
                    value = raw;
                    return true;

                default:
                    return false;
            }
        }
    }
}