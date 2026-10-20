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

            try
            {
                Directory.CreateDirectory(rootDirectory);

                File.WriteAllText(
                    path,
                    content ?? string.Empty,
                    Encoding.UTF8);

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