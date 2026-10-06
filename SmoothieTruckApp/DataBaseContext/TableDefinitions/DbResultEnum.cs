using System;

namespace SmoothieTruckApp.DataBaseContext.TableDefinitions
{
    internal enum DbResult
    {
        /// <summary>The operation completed successfully.</summary>
        Success = 0,

        /// <summary>An unhandled database exception or file-locking failure occurred.</summary>
        ExecutionError = -1,

        /// <summary>The input parameters (e.g., column arrays) had mismatched counts or structural issues.</summary>
        MismatchedStructure = -2,

        /// <summary>The specified table or file could not be located in the storage path.</summary>
        TableNotFound = -3,

        /// <summary>The target primary key or record index does not exist in the database table.</summary>
        RecordNotFound = -4,

        /// <summary>Operation blocked because a unique constraint (like an active filename or name check) failed.</summary>
        DuplicateRecord = -5,

        /// <summary>The record data failed validation criteria (e.g., negative price or empty item values).</summary>
        ValidationError = -6,

        /// <summary>The provided table name is empty, null, or invalid.</summary>
        InvalidTableName = -7,

        /// <summary>The table file is currently locked by another process.</summary>
        TableLocked = -8,

        /// <summary>A generic Input/Output error occurred while accessing file systems.</summary>
        IOError = -9,

        /// <summary>Database setup failed to create or apply schema structures to one or more tables.</summary>
        SetupFailed = -10
    }
}
