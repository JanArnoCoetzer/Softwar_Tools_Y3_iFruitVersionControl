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

        private static readonly TableSerializer Serializer = new TableSerializer();

        public static DbResult CreateRow(string tablename, object[] values)
        {
            DbResult result = 0;

            return result;
        }
    

        public DbResult UpdateRow(string tablename, int index, string value)
        {
            DbResult result = 0;

            return result;
        }
        public DbResult DeleteRow(string tablename, int index)
        {
            DbResult result = 0;

            return result;
        }


    }
}
