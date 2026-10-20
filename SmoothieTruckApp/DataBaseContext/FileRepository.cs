using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using System;
using System.IO;
using System.Text;

namespace SmoothieTruckApp.DataBaseContext
{
    internal static class FileRepository
    {
        private static readonly string RootDirectory = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "..", "..", "..",
            "DataBase",
            "DB_Tables");

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
                // Intentionally suppress startup directory-creation failures.
            }
        }

        public static FileResult CreateFile(string fileName)
        {
            if (!TablePathUtility.TryGetSafeTablePath(
                    RootDirectory, fileName, out string fullPath))
            {
                return FileResult.InvalidPath;
            }

            try
            {
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

        public static FileResult DeleteFile(string fileName)
        {
            if (!TablePathUtility.TryGetSafeTablePath(
                    RootDirectory, fileName, out string fullPath))
            {
                return FileResult.InvalidPath;
            }

            try
            {
                if (!File.Exists(fullPath))
                {
                    return FileResult.FileNotFound;
                }

                File.Delete(fullPath);
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

        public static FileResult ReadFile(
            string fileName,
            out string fileContent)
        {
            fileContent = string.Empty;

            if (!TablePathUtility.TryGetSafeTablePath(
                    RootDirectory, fileName, out string fullPath))
            {
                return FileResult.InvalidPath;
            }

            try
            {
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

        public static FileResult WriteFile(
            string fileName,
            string content)
        {
            if (!TablePathUtility.TryGetSafeTablePath(
                    RootDirectory, fileName, out string fullPath))
            {
                return FileResult.InvalidPath;
            }

            try
            {
                File.WriteAllText(
                    fullPath,
                    content ?? string.Empty,
                    Encoding.UTF8);

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