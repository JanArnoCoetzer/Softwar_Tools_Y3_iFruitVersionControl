using System;
using System.Collections.Generic;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.DataBaseContext
{
    internal class DataBase
    {
        private static readonly TableSerializer Serializer =
            new TableSerializer();

        public static DbResult CreateTable(string tableName)
        {
            try
            {
                FileResult fileResult =
                    FileRepository.CreateFile(tableName);

                return FileResultMapper.ToCreateTableResult(fileResult);
            }
            catch (Exception)
            {
                return DbResult.ExecutionError;
            }
        }

        public static DbResult SetTableColumns(
            string tableName,
            TableColumn[] columns)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                return DbResult.InvalidTableName;
            }

            if (columns == null || columns.Length == 0)
            {
                return DbResult.MismatchedStructure;
            }

            string headerContent =
                Serializer.SerializeHeader(columns);

            FileResult writeResult =
                FileRepository.WriteFile(tableName, headerContent);

            return FileResultMapper.ToWriteResult(writeResult);
        }

        public static DbResult DeleteTable(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                return DbResult.MismatchedStructure;
            }

            try
            {
                FileResult fileResult =
                    FileRepository.DeleteFile(tableName);

                return FileResultMapper.ToDeleteTableResult(fileResult);
            }
            catch (Exception)
            {
                return DbResult.ExecutionError;
            }
        }

        public static DbResult AddNewRow(
            string tableName,
            RowValue[] values)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                return DbResult.InvalidTableName;
            }

            if (values == null)
            {
                return DbResult.MismatchedStructure;
            }

            FileResult readResult = FileRepository.ReadFile(
                tableName,
                out string fileContent);

            if (readResult != FileResult.Success)
            {
                return FileResultMapper.ToReadResult(readResult);
            }

            if (!TableContentUtility.TryGetSchema(
                    fileContent,
                    Serializer,
                    out TableColumn[] schemaColumns))
            {
                return DbResult.MismatchedStructure;
            }

            if (!TableRowUtility.HasIntegerPrimaryKey(schemaColumns))
            {
                return DbResult.MismatchedStructure;
            }

            if (!TableRowUtility.IsValidRowShape(
                    schemaColumns,
                    values))
            {
                return DbResult.MismatchedStructure;
            }

            if (!TableRowUtility.TryParseRow(
                    values,
                    schemaColumns,
                    out object[] parsedObjects))
            {
                return DbResult.ValidationError;
            }

            if (!TableRowUtility.TryGetExistingIds(
                    fileContent,
                    Serializer,
                    schemaColumns,
                    out HashSet<int> existingIds))
            {
                return DbResult.ExecutionError;
            }

            parsedObjects[0] =
                TableRowUtility.GetNextAvailableId(existingIds);

            string serializedRow =
                Serializer.SerializeRow(parsedObjects);

            string updatedContent =
                TableContentUtility.AppendRow(
                    fileContent,
                    serializedRow);

            FileResult writeResult = FileRepository.WriteFile(
                tableName,
                updatedContent);

            return FileResultMapper.ToWriteResult(writeResult);
        }

        public static DbResult AddNewRowAtIndex(
            string tableName,
            RowValue[] values,
            int insertId)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                return DbResult.InvalidTableName;
            }

            if (values == null)
            {
                return DbResult.MismatchedStructure;
            }

            if (insertId < 0)
            {
                return DbResult.ValidationError;
            }

            FileResult readResult = FileRepository.ReadFile(
                tableName,
                out string fileContent);

            if (readResult != FileResult.Success)
            {
                return FileResultMapper.ToReadResult(readResult);
            }

            if (!TableContentUtility.TryGetSchema(
                    fileContent,
                    Serializer,
                    out TableColumn[] schemaColumns))
            {
                return DbResult.MismatchedStructure;
            }

            if (!TableRowUtility.HasIntegerPrimaryKey(schemaColumns))
            {
                return DbResult.MismatchedStructure;
            }

            if (!TableRowUtility.IsValidRowShape(
                    schemaColumns,
                    values))
            {
                return DbResult.MismatchedStructure;
            }

            if (!TableRowUtility.TryParseRow(
                    values,
                    schemaColumns,
                    out object[] parsedObjects))
            {
                return DbResult.ValidationError;
            }

            parsedObjects[0] = insertId;

            string serializedRow =
                Serializer.SerializeRow(parsedObjects);

            if (!TableContentUtility.TryGetRowLines(
                    fileContent,
                    out List<string> rowLines))
            {
                return DbResult.MismatchedStructure;
            }

            int targetRowIndex = insertId;

            if (targetRowIndex >= rowLines.Count)
            {
                rowLines.Add(serializedRow);
            }
            else
            {
                rowLines[targetRowIndex] = serializedRow;
            }

            string headerLine =
                TableContentUtility.SplitIntoLines(fileContent)[0];

            string updatedContent =
                TableContentUtility.BuildFileContent(
                    headerLine,
                    rowLines);

            FileResult writeResult = FileRepository.WriteFile(
                tableName,
                updatedContent);

            return FileResultMapper.ToWriteResult(writeResult);
        }

        public static DbResult DeleteRow(
            string tableName,
            int index)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                return DbResult.InvalidTableName;
            }

            if (index < 0)
            {
                return DbResult.ValidationError;
            }

            FileResult readResult = FileRepository.ReadFile(
                tableName,
                out string fileContent);

            if (readResult != FileResult.Success)
            {
                return FileResultMapper.ToReadResult(readResult);
            }

            if (!TableContentUtility.TryGetRowLines(
                    fileContent,
                    out List<string> rowLines))
            {
                return DbResult.MismatchedStructure;
            }

            if (index >= rowLines.Count)
            {
                return DbResult.RecordNotFound;
            }

            rowLines.RemoveAt(index);

            string headerLine =
                TableContentUtility.SplitIntoLines(fileContent)[0];

            string updatedContent =
                TableContentUtility.BuildFileContent(
                    headerLine,
                    rowLines);

            FileResult writeResult = FileRepository.WriteFile(
                tableName,
                updatedContent);

            return FileResultMapper.ToWriteResult(writeResult);
        }
    }
}