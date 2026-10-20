using System;
using SmoothieTruckApp.DataBaseContext.Domain;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.DataBaseContext
{
    internal static class DataBase
    {
        public static DbResult CreateTable(string tableName)
        {
            return Execute(() =>
                DefaultDatabaseContext.Engine.CreateTable(tableName));
        }

        public static DbResult SetTableColumns(
            string tableName,
            TableColumn[] columns)
        {
            return Execute(() =>
                DefaultDatabaseContext.Engine.SetTableColumns(
                    tableName,
                    columns));
        }

        public static DbResult DeleteTable(string tableName)
        {
            return Execute(() =>
                DefaultDatabaseContext.Engine.DeleteTable(tableName));
        }

        public static DbResult AddNewRow(
            string tableName,
            RowValue[] values)
        {
            return Modify(tableName, values, table =>
                table.AddRow(values));
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

            return Modify(tableName, values, table =>
                table.PutRowAtPosition(insertId, values));
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

            return Execute(() =>
            {
                DatabaseEngine database = DefaultDatabaseContext.Engine;

                DbResult result = database.LoadTable(
                    tableName,
                    out Table table);

                if (result != DbResult.Success)
                {
                    return result;
                }

                result = table.DeleteRowAt(index);

                return result == DbResult.Success
                    ? database.SaveTable(table)
                    : result;
            });
        }

        private static DbResult Modify(
            string name,
            RowValue[] values,
            Func<Table, DbResult> operation)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return DbResult.InvalidTableName;
            }

            if (values == null)
            {
                return DbResult.MismatchedStructure;
            }

            return Execute(() =>
            {
                DatabaseEngine database = DefaultDatabaseContext.Engine;

                DbResult result = database.LoadTable(name, out Table table);

                if (result != DbResult.Success)
                {
                    return result;
                }

                result = operation(table);

                return result == DbResult.Success
                    ? database.SaveTable(table)
                    : result;
            });
        }

        private static DbResult Execute(Func<DbResult> operation)
        {
            try
            {
                return operation();
            }
            catch (Exception)
            {
                return DbResult.ExecutionError;
            }
        }
    }
}