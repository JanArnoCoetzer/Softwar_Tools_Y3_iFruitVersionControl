using System;
using SmoothieTruckApp.DataBaseContext.Domain;
using SmoothieTruckApp.DataBaseContext.Mapping;
using SmoothieTruckApp.DataBaseContext.Serialization;
using SmoothieTruckApp.DataBaseContext.Storage;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.DataBaseContext
{
    internal sealed class DatabaseEngine
    {
        private readonly IStorageProvider storage;
        private readonly TableDocumentSerializer serializer;

        public DatabaseEngine(
            IStorageProvider storage,
            TableDocumentSerializer serializer)
        {
            this.storage = storage
                ?? throw new ArgumentNullException(nameof(storage));

            this.serializer = serializer
                ?? throw new ArgumentNullException(nameof(serializer));
        }

        // Preserves the original empty-file creation operation.
        public DbResult CreateTable(string name)
        {
            return FileResultMapper.ToCreateTableResult(
                storage.CreateFile(name));
        }

        public DbResult DeleteTable(string name)
        {
            return FileResultMapper.ToDeleteTableResult(
                storage.DeleteFile(name));
        }

        public DbResult LoadTable(string name, out Table table)
        {
            table = null;

            if (string.IsNullOrWhiteSpace(name))
            {
                return DbResult.InvalidTableName;
            }

            FileResult result = storage.ReadFile(name, out string content);

            if (result != FileResult.Success)
            {
                return FileResultMapper.ToReadResult(result);
            }

            return serializer.Deserialize(name, content, out table);
        }

        public DbResult SaveTable(Table table)
        {
            if (table == null)
            {
                return DbResult.MismatchedStructure;
            }

            try
            {
                string content = serializer.Serialize(table);

                return FileResultMapper.ToWriteResult(
                    storage.WriteFile(table.Name, content));
            }
            catch (Exception)
            {
                return DbResult.ExecutionError;
            }
        }

        public DbResult SetTableColumns(
            string name,
            TableColumn[] columns)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return DbResult.InvalidTableName;
            }

            if (columns == null || columns.Length == 0)
            {
                return DbResult.MismatchedStructure;
            }

            try
            {
                var table = new Table(name, new TableSchema(columns));

                // Intentionally replaces all previous content.
                return SaveTable(table);
            }
            catch (Exception)
            {
                return DbResult.MismatchedStructure;
            }
        }
    }
}