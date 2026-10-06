using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using System;
using System.IO;
using System.Text;

namespace SmoothieTruckApp.DataBaseContext
{
    internal static class FileRepository
    {
        private static readonly string RootDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"..", "..", "..", "DataBase", "DB_Tables");

        static FileRepository()
        {
            try
            {
                if (!Directory.Exists(RootDirectory))
                {
                    Directory.CreateDirectory(RootDirectory);
                }
            }
            catch (Exception)
            {
               
            }
        }

        public static FileResult create_file(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return FileResult.InvalidPath;
            }

            try
            {
                string fullPath = Path.Combine(RootDirectory, fileName);

                if (File.Exists(fullPath))
                {
                    return FileResult.FileAlreadyExists;
                }

                using (File.Create(fullPath)) { }

                return FileResult.Success;
            }
            catch (IOException)
            {
                return FileResult.FileLocked;
            }
            catch (Exception)
            {
                return FileResult.IOError;
            }
        }

        public static FileResult delete_file(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return FileResult.InvalidPath;
            }

            try
            {

                string combinedPath = Path.Combine(RootDirectory, fileName);


                string fullPath = Path.GetFullPath(combinedPath);

                if (!fullPath.StartsWith(RootDirectory, StringComparison.OrdinalIgnoreCase))
                {
                    return FileResult.InvalidPath;
                }

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return FileResult.Success;
                }
                return FileResult.FileNotFound;
            }
            catch (IOException)
            {
                return FileResult.FileLocked;
            }
            catch (Exception)
            {
                return FileResult.IOError;
            }
        }

        public static FileResult read_file(string fileName, out string fileContent)
        {
            fileContent = string.Empty;

            if (string.IsNullOrWhiteSpace(fileName))
            {
                return FileResult.InvalidPath;
            }

            try
            {
                string fullPath = Path.Combine(RootDirectory, fileName);

                if (!File.Exists(fullPath))
                {
                    return FileResult.FileNotFound;
                }

                fileContent = File.ReadAllText(fullPath, Encoding.UTF8);
                return FileResult.Success;
            }
            catch (IOException)
            {
                return FileResult.FileLocked;
            }
            catch (Exception)
            {
                return FileResult.IOError;
            }
        }

        public static FileResult write_file(string fileName, string content)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return FileResult.InvalidPath;
            }

            try
            {
                string fullPath = Path.Combine(RootDirectory, fileName);

                File.WriteAllText(fullPath, content ?? string.Empty, Encoding.UTF8);
                return FileResult.Success;
            }
            catch (IOException)
            {
                return FileResult.FileLocked;
            }
            catch (Exception)
            {
                return FileResult.IOError;
            }
        }
    }
}
