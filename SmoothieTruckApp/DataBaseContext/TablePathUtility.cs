using System;
using System.IO;

namespace SmoothieTruckApp.DataBaseContext
{
    internal static class TablePathUtility
    {
        public static bool TryGetSafeTablePath(
            string rootDirectory,
            string tableName,
            out string fullPath)
        {
            fullPath = null;

            if (string.IsNullOrWhiteSpace(tableName))
            {
                return false;
            }

            try
            {
                string absoluteRoot = Path.GetFullPath(rootDirectory);
                string candidatePath = Path.GetFullPath(
                    Path.Combine(absoluteRoot, tableName));

                string rootWithSeparator = absoluteRoot.EndsWith(
                    Path.DirectorySeparatorChar.ToString(),
                    StringComparison.Ordinal)
                    ? absoluteRoot
                    : absoluteRoot + Path.DirectorySeparatorChar;

                if (!candidatePath.StartsWith(
                        rootWithSeparator,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                fullPath = candidatePath;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}