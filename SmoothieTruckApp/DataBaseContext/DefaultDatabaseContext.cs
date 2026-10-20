using SmoothieTruckApp.DataBaseContext.Serialization;
using SmoothieTruckApp.DataBaseContext.Storage;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using System;
using System.IO;

namespace SmoothieTruckApp.DataBaseContext
{
    internal static class DefaultDatabaseContext
    {
        internal static readonly IStorageProvider Storage =
            new FileStorageProvider(
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "..", "..", "..",
                    "DataBase",
                    "DB_Tables"));

        internal static readonly DatabaseEngine Engine =
            new DatabaseEngine(
                Storage,
                new TableDocumentSerializer(new TableSerializer()));
    }
}