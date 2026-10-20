using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.DataBaseContext.Mapping
{
    /// <summary>
    /// Converts low-level File System statuses (FileResult) into high-level Database operation statuses (DbResult).
    /// </summary>
    internal static class FileResultMapper
    {
        /// <summary>
        /// Maps file outcomes from table creation routines to database execution statuses.
        /// </summary>
        public static DbResult ToCreateTableResult(
            FileResult fileResult)
        {
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

        /// <summary>
        /// Translates file erasure outcomes into corresponding table deletion responses.
        /// </summary>
        public static DbResult ToDeleteTableResult(
            FileResult fileResult)
        {
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

        /// <summary>
        /// Maps file-reading states into descriptive table lookup or integrity errors.
        /// </summary>
        public static DbResult ToReadResult(
            FileResult fileResult)
        {
            switch (fileResult)
            {
                case FileResult.Success:
                    return DbResult.Success;

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

        /// <summary>
        /// Standardizes file storage updates or writes into high-level transaction results.
        /// </summary>
        public static DbResult ToWriteResult(
            FileResult fileResult)
        {
            switch (fileResult)
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
