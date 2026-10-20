using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.DataBaseContext
{
    internal static class FileRepository
    {
        public static FileResult CreateFile(string fileName)
        {
            return DefaultDatabaseContext.Storage.CreateFile(fileName);
        }

        public static FileResult ReadFile(
            string fileName,
            out string fileContent)
        {
            return DefaultDatabaseContext.Storage.ReadFile(
                fileName,
                out fileContent);
        }

        public static FileResult WriteFile(
            string fileName,
            string content)
        {
            return DefaultDatabaseContext.Storage.WriteFile(
                fileName,
                content);
        }

        public static FileResult DeleteFile(string fileName)
        {
            return DefaultDatabaseContext.Storage.DeleteFile(fileName);
        }
    }
}