using System;
using System.Collections.Generic;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.DataBaseContext.Storage
{
    internal sealed class InMemoryStorageProvider : IStorageProvider
    {
        private readonly Dictionary<string, string> files =
            new Dictionary<string, string>(StringComparer.Ordinal);

        public FileResult CreateFile(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return FileResult.InvalidPath;
            }

            if (files.ContainsKey(name))
            {
                return FileResult.FileAlreadyExists;
            }

            files.Add(name, string.Empty);
            return FileResult.Success;
        }

        public FileResult ReadFile(
            string name,
            out string content)
        {
            content = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                return FileResult.InvalidPath;
            }

            if (!files.TryGetValue(name, out string storedContent))
            {
                return FileResult.FileNotFound;
            }

            content = storedContent;
            return FileResult.Success;
        }

        public FileResult WriteFile(
            string name,
            string content)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return FileResult.InvalidPath;
            }

            files[name] = content ?? string.Empty;
            return FileResult.Success;
        }

        public FileResult DeleteFile(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return FileResult.InvalidPath;
            }

            return files.Remove(name)
                ? FileResult.Success
                : FileResult.FileNotFound;
        }
    }
}