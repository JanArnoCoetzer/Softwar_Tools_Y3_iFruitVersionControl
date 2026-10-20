using System;
using System.Collections.Generic;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.DataBaseContext.Domain
{
    internal sealed class Table
    {
        private readonly List<Row> rows = new List<Row>();

        public string Name { get; }
        public TableSchema Schema { get; }
        public IReadOnlyList<Row> Rows => rows.AsReadOnly();

        public Table(string name, TableSchema schema)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "A table name is required.",
                    nameof(name));
            }

            Name = name;
            Schema = schema ?? throw new ArgumentNullException(nameof(schema));
        }

        public DbResult AddRow(RowValue[] values)
        {
            DbResult result = Schema.ParseInput(
                values,
                out object[] parsed);

            if (result != DbResult.Success)
            {
                return result;
            }

            var ids = new HashSet<int>();

            foreach (Row row in rows)
            {
                ids.Add(row.Id);
            }

            int id = 1;

            while (ids.Contains(id))
            {
                if (id == int.MaxValue)
                {
                    return DbResult.ExecutionError;
                }

                id++;
            }

            parsed[0] = id;
            return AddParsedRow(parsed);
        }

        public DbResult AddRowWithId(int id, RowValue[] values)
        {
            if (id < 0)
            {
                return DbResult.ValidationError;
            }

            if (FindPosition(id) >= 0)
            {
                return DbResult.DuplicateRecord;
            }

            DbResult result = Schema.ParseInput(
                values,
                out object[] parsed);

            if (result != DbResult.Success)
            {
                return result;
            }

            parsed[0] = id;
            return AddParsedRow(parsed);
        }

        public DbResult ReplaceRowById(int id, RowValue[] values)
        {
            if (id < 0)
            {
                return DbResult.ValidationError;
            }

            int position = FindPosition(id);

            if (position < 0)
            {
                return DbResult.RecordNotFound;
            }

            DbResult result = Schema.ParseInput(
                values,
                out object[] parsed);

            if (result != DbResult.Success)
            {
                return result;
            }

            parsed[0] = id;

            if (!Row.TryCreate(Schema, parsed, out Row replacement))
            {
                return DbResult.ValidationError;
            }

            rows[position] = replacement;
            return DbResult.Success;
        }

        public DbResult DeleteRowById(int id)
        {
            if (id < 0)
            {
                return DbResult.ValidationError;
            }

            int position = FindPosition(id);

            return position < 0
                ? DbResult.RecordNotFound
                : DeleteRowAt(position);
        }

        public DbResult DeleteRowAt(int position)
        {
            if (position < 0)
            {
                return DbResult.ValidationError;
            }

            if (position >= rows.Count)
            {
                return DbResult.RecordNotFound;
            }

            rows.RemoveAt(position);
            return DbResult.Success;
        }

        // Supports the original positional API without allowing duplicate IDs.
        internal DbResult PutRowAtPosition(
            int position,
            RowValue[] values)
        {
            if (position < 0)
            {
                return DbResult.ValidationError;
            }

            DbResult result = Schema.ParseInput(
                values,
                out object[] parsed);

            if (result != DbResult.Success)
            {
                return result;
            }

            int existingPosition = FindPosition(position);

            if (existingPosition >= 0 &&
                existingPosition != position)
            {
                return DbResult.DuplicateRecord;
            }

            parsed[0] = position;

            if (!Row.TryCreate(Schema, parsed, out Row row))
            {
                return DbResult.ValidationError;
            }

            if (position < rows.Count)
            {
                rows[position] = row;
            }
            else
            {
                rows.Add(row);
            }

            return DbResult.Success;
        }

        // Used when loading typed records from storage.
        internal DbResult AddParsedRow(object[] values)
        {
            if (!Row.TryCreate(Schema, values, out Row row))
            {
                return DbResult.ValidationError;
            }

            if (FindPosition(row.Id) >= 0)
            {
                return DbResult.DuplicateRecord;
            }

            rows.Add(row);
            return DbResult.Success;
        }

        private int FindPosition(int id)
        {
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Id == id)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}