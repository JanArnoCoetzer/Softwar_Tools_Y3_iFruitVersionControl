using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace SmoothieTruckApp.DataBaseContext
{
    internal class DataBase
    {
        private static string RootDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public static DbResult create_Table(string table_name)
        {
            try
            {
                FileResult fileResult = FileRepository.create_file(table_name);

                switch (fileResult)
                {
                    case FileResult.Success:
                        return DbResult.Success;

                    case FileResult.FileAlreadyExists:
                        return DbResult.DuplicateRecord; 

                    case FileResult.InvalidPath:
                        return DbResult.MismatchedStructure;

                    case FileResult.FileNotFound:
                        return DbResult.TableNotFound;

                    case FileResult.FileLocked:
                    case FileResult.IOError:
                    default:
                        return DbResult.ExecutionError;
                }
            }
            catch (Exception)
            {
                return DbResult.ExecutionError;
            }
        }


        public static DbResult set_table_columns(string table_name, TableColumn[] Columns)
        {

            var serializer = new TableSerializer();


            string headerContent = serializer.SerializeHeader(Columns);

            FileResult writeResult = FileRepository.write_file(table_name, headerContent);


            switch (writeResult)
            {
                case FileResult.Success:
                    return DbResult.Success;
                case FileResult.InvalidPath:
                    return DbResult.InvalidTableName;
                case FileResult.FileLocked:
                    return DbResult.TableLocked;
                default:
                    return DbResult.IOError;
            }
        }

        public static DbResult delete_table(string table_name)
        {

            if (string.IsNullOrWhiteSpace(table_name))
            {
                return DbResult.MismatchedStructure;
            }

            try
            {

                FileResult fileResult = FileRepository.delete_file(table_name);
                switch (fileResult)
                {
                    case FileResult.Success:
                        return DbResult.Success;

                    case FileResult.FileNotFound:
                        return DbResult.TableNotFound;

                    case FileResult.InvalidPath:
                        return DbResult.MismatchedStructure;

                    case FileResult.FileLocked:
                    case FileResult.IOError:
                    default:
                        return DbResult.ExecutionError;
                }
            }
            catch (Exception)
            {
                return DbResult.ExecutionError;
            }
        }


        public static DbResult add_new_row(string tablename, RowValue[] value)
        {
            // 1. Basic parameter validation
            if (string.IsNullOrWhiteSpace(tablename))
            {
                return DbResult.InvalidTableName;
            }

            if (value == null)
            {
                return DbResult.MismatchedStructure;
            }

            // 2. Read the existing table file content
            FileResult readResult = FileRepository.read_file(tablename, out string fileContent);
            if (readResult != FileResult.Success)
            {
                switch (readResult)
                {
                    case FileResult.FileNotFound:
                        return DbResult.TableNotFound;
                    case FileResult.InvalidPath:
                        return DbResult.InvalidTableName;
                    case FileResult.FileLocked:
                        return DbResult.TableLocked;
                    default:
                        return DbResult.IOError;
                }
            }

            // 3. Instantiate the local serializer exactly like set_table_columns does
            var serializer = new TableSerializer();

            // 4. Extract lines from file
            string[] databaseLines = fileContent.Split(new[] { Environment.NewLine, "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            if (databaseLines.Length == 0)
            {
                return DbResult.MismatchedStructure;
            }

            string headerLine = databaseLines[0];
            TableColumn[] schemaColumns = serializer.DeserializeHeader(headerLine);

            // 5. Structural validation: Caller sends data WITHOUT the PK, so length must equal columns count minus 1
            if (schemaColumns.Length == 0 || value.Length != schemaColumns.Length - 1)
            {
                return DbResult.MismatchedStructure;
            }

            // Verify the first schema column is actually configured as an INTEGER primary key
            if (schemaColumns[0].VarType != DataType.INTEGER)
            {
                return DbResult.MismatchedStructure;
            }

            // --- CALL THE NEWLY SIGNED FUNCTION TO GET THE NEXT PRIMARY KEY INDEX ---
            int nextId = next_available_index(tablename);
            if (nextId < 0)
            {
                return DbResult.ExecutionError; // Safe exit if helper fails internally
            }
            // -------------------------------------------------------------------------

            // 6. Initialize output data array matching full schema layout length
            object[] parsedObjects = new object[schemaColumns.Length];

            // Add the generated next index right in front of the dataset (position 0)
            parsedObjects[0] = nextId;

            // 7. Validate and map the remaining application row values
            for (int i = 0; i < value.Length; i++)
            {
                RowValue currentInput = value[i];
                TableColumn schemaColumn = schemaColumns[i + 1]; // Offset schema by 1 to skip PK column

                if (schemaColumn.VarType != currentInput.DataType)
                {
                    return DbResult.ValidationError;
                }

                if (!TryValidateAndParse(currentInput.DataType, currentInput.Value, out object parsedValue))
                {
                    return DbResult.ValidationError;
                }

                parsedObjects[i + 1] = parsedValue;
            }

            // 8. Format the complete row using the local serializer instance
            string serializedNewRow = serializer.SerializeRow(parsedObjects);

            // 9. Append the row data string right underneath the existing records
            string updatedContent = fileContent.EndsWith(Environment.NewLine) || fileContent.EndsWith("\n")
                ? $"{fileContent}{serializedNewRow}{Environment.NewLine}"
                : $"{fileContent}{Environment.NewLine}{serializedNewRow}{Environment.NewLine}";

            // 10. Commit data back down to disk file using the explicit switch statement pattern
            FileResult writeResult = FileRepository.write_file(tablename, updatedContent);

            switch (writeResult)
            {
                case FileResult.Success:
                    return DbResult.Success;
                case FileResult.InvalidPath:
                    return DbResult.InvalidTableName;
                case FileResult.FileLocked:
                    return DbResult.TableLocked;
                default:
                    return DbResult.IOError;
            }
        }

        public static DbResult add_new_row_at_index(string tablename, RowValue[] value, int insertId)
        {
            // 1. Basic parameter validation
            if (string.IsNullOrWhiteSpace(tablename))
            {
                return DbResult.InvalidTableName;
            }

            if (value == null)
            {
                return DbResult.MismatchedStructure;
            }

            if (insertId < 0)
            {
                return DbResult.ValidationError;
            }

            // 2. Read the existing table file content
            FileResult readResult = FileRepository.read_file(tablename, out string fileContent);
            if (readResult != FileResult.Success)
            {
                switch (readResult)
                {
                    case FileResult.FileNotFound:
                        return DbResult.TableNotFound;
                    case FileResult.InvalidPath:
                        return DbResult.InvalidTableName;
                    case FileResult.FileLocked:
                        return DbResult.TableLocked;
                    default:
                        return DbResult.IOError;
                }
            }

            // 3. Instantiate local serializer
            var serializer = new TableSerializer();

            // 4. Split file content into structural rows
            System.Collections.Generic.List<string> databaseLines = new System.Collections.Generic.List<string>(
                fileContent.Split(new[] { Environment.NewLine, "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries)
            );

            if (databaseLines.Count == 0)
            {
                return DbResult.MismatchedStructure;
            }

            // 5. Parse the header line to evaluate columns count constraints
            string headerLine = databaseLines[0];
            TableColumn[] schemaColumns = serializer.DeserializeHeader(headerLine);

            // Structural check: Caller sends data WITHOUT the PK, so length must equal columns count minus 1
            if (schemaColumns.Length == 0 || value.Length != schemaColumns.Length - 1)
            {
                return DbResult.MismatchedStructure;
            }

            // Verify the first schema column is actually configured as an INTEGER primary key
            if (schemaColumns[0].VarType != DataType.INTEGER)
            {
                return DbResult.MismatchedStructure;
            }

            // 6. Initialize full data array matching total schema column count
            object[] parsedObjects = new object[schemaColumns.Length];

            // --- ASSIGN THE INSERT ID AS THE PRIMARY KEY ---
            parsedObjects[0] = insertId;
            // -----------------------------------------------

            // 7. Data validation loop matching types & parsing rules (offset schema by 1 to skip PK)
            for (int i = 0; i < value.Length; i++)
            {
                RowValue currentInput = value[i];
                TableColumn schemaColumn = schemaColumns[i + 1];

                if (schemaColumn.VarType != currentInput.DataType)
                {
                    return DbResult.ValidationError;
                }

                if (!TryValidateAndParse(currentInput.DataType, currentInput.Value, out object parsedValue))
                {
                    return DbResult.ValidationError;
                }

                parsedObjects[i + 1] = parsedValue;
            }

            // 8. Format the row using the local serializer instance
            string serializedNewRow = serializer.SerializeRow(parsedObjects);

            // 9. Determine file insertion bounds line index position using the insertId
            int lineTargetIndex = insertId + 1;

            if (lineTargetIndex >= databaseLines.Count)
            {
                // If the target position is beyond the current lines, append it down at the bottom edge
                databaseLines.Add(serializedNewRow);
            }
            else
            {
                // --- OVERWRITE LOGIC ---
                // If a row already exists at this index position, replace it directly.
                // This deletes the old row data line and sets the new row at the exact position.
                databaseLines[lineTargetIndex] = serializedNewRow;
            }

            // 10. Reassemble full text string with proper newlines
            string updatedContent = string.Join(Environment.NewLine, databaseLines) + Environment.NewLine;

            // 11. Commit text contents back down to disk file
            FileResult writeResult = FileRepository.write_file(tablename, updatedContent);

            switch (writeResult)
            {
                case FileResult.Success:
                    return DbResult.Success;
                case FileResult.InvalidPath:
                    return DbResult.InvalidTableName;
                case FileResult.FileLocked:
                    return DbResult.TableLocked;
                default:
                    return DbResult.IOError;
            }
        }

        private static int next_available_index(string tablename)
        {
            FileResult readResult = FileRepository.read_file(tablename, out string fileContent);
            if (readResult != FileResult.Success)
            {
                return -1; // Flag calculation failure state safely 
            }

            var serializer = new TableSerializer();
            string[] databaseLines = fileContent.Split(new[] { Environment.NewLine, "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            if (databaseLines.Length == 0)
            {
                return -1;
            }

            string headerLine = databaseLines[0];
            TableColumn[] schemaColumns = serializer.DeserializeHeader(headerLine);

            int maxId = 0;

            // Read existing records (skipping header line at index 0)
            for (int j = 1; j < databaseLines.Length; j++)
            {
                object[] deserializedRow = serializer.DeserializeRow(databaseLines[j], schemaColumns);
                if (deserializedRow.Length > 0 && deserializedRow[0] is int currentId)
                {
                    if (currentId > maxId)
                    {
                        maxId = currentId;
                    }
                }
            }

            return maxId + 1;
        }

        private static bool TryValidateAndParse(DataType type, string rawValue, out object result)
        {
            result = null;
            if (rawValue == null) return false;

            switch (type)
            {
                case DataType.INTEGER:
                    if (int.TryParse(rawValue, out int intVal))
                    {
                        result = intVal;
                        return true;
                    }
                    return false;

                case DataType.DECIMAL:
                    if (decimal.TryParse(rawValue, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal decVal))
                    {
                        result = decVal;
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


        public static DbResult DeleteRow(string tablename, int index)
        {
            // 1. Basic parameter validation
            if (string.IsNullOrWhiteSpace(tablename))
            {
                return DbResult.InvalidTableName;
            }

            if (index < 0)
            {
                return DbResult.ValidationError; // Row positioning cannot be negative
            }

            // 2. Read the existing table file content
            FileResult readResult = FileRepository.read_file(tablename, out string fileContent);
            if (readResult != FileResult.Success)
            {
                switch (readResult)
                {
                    case FileResult.FileNotFound:
                        return DbResult.TableNotFound;
                    case FileResult.InvalidPath:
                        return DbResult.InvalidTableName;
                    case FileResult.FileLocked:
                        return DbResult.TableLocked;
                    default:
                        return DbResult.IOError;
                }
            }

            // 3. Split file content into structural rows
            List<string> databaseLines = new List<string>(
                fileContent.Split(new[] { Environment.NewLine, "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries)
            );

            if (databaseLines.Count == 0)
            {
                return DbResult.MismatchedStructure; // File is broken or completely empty
            }

            // 4. Determine file row deletion bounds position
            // databaseLines[0] is the column header, databaseLines[1] is row index 0, etc.
            int lineTargetIndex = index + 1;

            // 5. Verify the target record actually exists at the requested index
            if (lineTargetIndex >= databaseLines.Count)
            {
                return DbResult.RecordNotFound;
            }

            // 6. Delete the targeted line
            databaseLines.RemoveAt(lineTargetIndex);

            // 7. Reassemble the full file content layout with proper trailing line-endings
            string updatedContent = string.Join(Environment.NewLine, databaseLines);
            if (databaseLines.Count > 0)
            {
                updatedContent += Environment.NewLine;
            }

            // 8. Commit data wipes back down to physical flat-file storage
            FileResult writeResult = FileRepository.write_file(tablename, updatedContent);

            switch (writeResult)
            {
                case FileResult.Success:
                    return DbResult.Success;
                case FileResult.InvalidPath:
                    return DbResult.InvalidTableName;
                case FileResult.FileLocked:
                    return DbResult.TableLocked;
                default:
                    return DbResult.IOError;
            }
        }


    }
}
