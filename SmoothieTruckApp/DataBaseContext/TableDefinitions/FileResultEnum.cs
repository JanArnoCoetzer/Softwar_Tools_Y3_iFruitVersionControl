using System;

namespace SmoothieTruckApp.DataBaseContext.TableDefinitions
{
    /// <summary>
    /// Represents the standardized operation outcomes for the physical file-system repository layer.
    /// </summary>
    internal enum FileResult
    {
        /// <summary>The file system operation completed successfully.</summary>
        Success = 0,

        /// <summary>A generic I/O exception occurred (e.g., unauthorized access or path error).</summary>
        IOError = -1,

        /// <summary>The operation failed because the target file already exists (protects data corruption).</summary>
        FileAlreadyExists = -2,

        /// <summary>The requested file could not be found inside the storage directory.</summary>
        FileNotFound = -3,

        /// <summary>The file is currently locked or being used by another process thread.</summary>
        FileLocked = -4,

        /// <summary>The provided filename string is null, empty, or contains illegal path characters.</summary>
        InvalidPath = -5
    }
}
