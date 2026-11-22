using System;
using System.IO;
using System.Text;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.DataBaseContext.Storage
{
    internal sealed class FileStorageProvider : IStorageProvider
    {
        private readonly string rootDirectory;

        public FileStorageProvider(string rootDirectory)
        {
            if (string.IsNullOrWhiteSpace(rootDirectory))
            {
                throw new ArgumentException(
                    "A storage directory is required.",
                    nameof(rootDirectory));
            }

            this.rootDirectory = Path.GetFullPath(rootDirectory);
        }

        public FileResult CreateFile(string name)
        {
            if (!TryGetPath(name, out string path))
            {
                return FileResult.InvalidPath;
            }

            try
            {
                Directory.CreateDirectory(rootDirectory);

                if (File.Exists(path))
                {
                    return FileResult.FileAlreadyExists;
                }

                using (new FileStream(
                    path,
                    FileMode.CreateNew,
                    FileAccess.Write,
                    FileShare.None))
                {
                }

                return FileResult.Success;
            }
            catch (IOException)
            {
                return File.Exists(path)
                    ? FileResult.FileAlreadyExists
                    : FileResult.IOError;
            }
            catch (Exception)
            {
                return FileResult.IOError;
            }
        }

        public FileResult ReadFile(
            string name,
            out string content)
        {
            content = string.Empty;

            if (!TryGetPath(name, out string path))
            {
                return FileResult.InvalidPath;
            }

            try
            {
                content = File.ReadAllText(path, Encoding.UTF8);
                return FileResult.Success;
            }
            catch (FileNotFoundException)
            {
                return FileResult.FileNotFound;
            }
            catch (DirectoryNotFoundException)
            {
                return FileResult.FileNotFound;
            }
            catch (IOException)
            {
                return FileResult.IOError;
            }
            catch (Exception)
            {
                return FileResult.IOError;
            }
        }

        public FileResult WriteFile(
            string name,
            string content)
        {
            if (!TryGetPath(name, out string path))
            {
                return FileResult.InvalidPath;
            }

            string tempPath = path + ".tmp";

            try
            {
                Directory.CreateDirectory(rootDirectory);

                //written to a temp file first so a crash cannot leave a half written table
                File.WriteAllText(
                    tempPath,
                    content ?? string.Empty,
                    Encoding.UTF8);

                if (File.Exists(path))
                {
                    //last good copy is kept as a .bak file
                    File.Replace(tempPath, path, path + ".bak");
                }
                else
                {
                    File.Move(tempPath, path);
                }

                return FileResult.Success;
            }
            catch (IOException)
            {
                DeleteTempFile(tempPath);
                return FileResult.IOError;
            }
            catch (Exception)
            {
                DeleteTempFile(tempPath);
                return FileResult.IOError;
            }
        }

        private static void DeleteTempFile(string tempPath)
        {
            try
            {
                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }
            }
            catch (Exception)
            {
            }
        }

        public FileResult DeleteFile(string name)
        {
            if (!TryGetPath(name, out string path))
            {
                return FileResult.InvalidPath;
            }

            try
            {
                if (!File.Exists(path))
                {
                    return FileResult.FileNotFound;
                }

                File.Delete(path);
                return FileResult.Success;
            }
            catch (IOException)
            {
                return FileResult.IOError;
            }
            catch (Exception)
            {
                return FileResult.IOError;
            }
        }

        private bool TryGetPath(
            string name,
            out string path)
        {
            path = null;

            if (string.IsNullOrWhiteSpace(name) ||
                name == "." ||
                name == "..")
            {
                return false;
            }

            // Table names are file names, not directory paths.
            if (name.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0 ||
                name.Contains("/") ||
                name.Contains("\\") ||
                Path.IsPathRooted(name))
            {
                return false;
            }

            try
            {
                path = Path.Combine(rootDirectory, name);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}