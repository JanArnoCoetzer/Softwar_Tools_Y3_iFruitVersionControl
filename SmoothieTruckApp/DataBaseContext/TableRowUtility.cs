using System;
using System.Collections.Generic;
using System.Globalization;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.DataBaseContext
{
    internal static class TableRowUtility
    {
        public static bool IsValidRowShape(
            TableColumn[] schemaColumns,
            RowValue[] values)
        {
            return schemaColumns != null &&
                   schemaColumns.Length > 0 &&
                   values != null &&
                   values.Length == schemaColumns.Length - 1;
        }

        public static bool HasIntegerPrimaryKey(
            TableColumn[] schemaColumns)
        {
            return schemaColumns != null &&
                   schemaColumns.Length > 0 &&
                   schemaColumns[0].VarType == DataType.INTEGER;
        }

        public static bool TryParseRow(
            RowValue[] values,
            TableColumn[] schemaColumns,
            out object[] parsedObjects)
        {
            parsedObjects = null;

            if (!IsValidRowShape(schemaColumns, values))
            {
                return false;
            }

            parsedObjects = new object[schemaColumns.Length];

            for (int i = 0; i < values.Length; i++)
            {
                RowValue inputValue = values[i];
                TableColumn schemaColumn = schemaColumns[i + 1];

                if (schemaColumn.VarType != inputValue.DataType)
                {
                    return false;
                }

                if (!TryValidateAndParse(
                        inputValue.DataType,
                        inputValue.Value,
                        out object parsedValue))
                {
                    return false;
                }

                parsedObjects[i + 1] = parsedValue;
            }

            return true;
        }

        public static bool TryGetExistingIds(
            string fileContent,
            TableSerializer serializer,
            TableColumn[] schemaColumns,
            out HashSet<int> existingIds)
        {
            existingIds = new HashSet<int>();

            if (!TableContentUtility.TryGetRowLines(
                    fileContent,
                    out List<string> rowLines))
            {
                return false;
            }

            foreach (string rowLine in rowLines)
            {
                object[] row = serializer.DeserializeRow(
                    rowLine,
                    schemaColumns);

                if (row.Length > 0 &&
                    row[0] is int rowId)
                {
                    existingIds.Add(rowId);
                }
            }

            return true;
        }

        public static int GetNextAvailableId(
            HashSet<int> existingIds)
        {
            int candidateId = 1;

            while (existingIds.Contains(candidateId))
            {
                candidateId++;
            }

            return candidateId;
        }

        private static bool TryValidateAndParse(
            DataType type,
            string rawValue,
            out object result)
        {
            result = null;

            if (rawValue == null)
            {
                return false;
            }

            switch (type)
            {
                case DataType.INTEGER:
                    if (int.TryParse(rawValue, out int intValue))
                    {
                        result = intValue;
                        return true;
                    }

                    return false;

                case DataType.DECIMAL:
                    if (decimal.TryParse(
                            rawValue,
                            NumberStyles.Any,
                            CultureInfo.InvariantCulture,
                            out decimal decimalValue))
                    {
                        result = decimalValue;
                        return true;
                    }

                    return false;

                case DataType.STRING:
                    result = rawValue;
                    return true;

                default:
                    return false;
            }
        }
    }
}