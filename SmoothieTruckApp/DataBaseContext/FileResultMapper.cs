using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.DataBaseContext
{
    internal static class FileResultMapper
    {
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