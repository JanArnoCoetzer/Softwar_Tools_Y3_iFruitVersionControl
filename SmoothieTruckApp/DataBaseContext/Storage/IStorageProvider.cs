using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.DataBaseContext.Storage
{
    internal interface IStorageProvider
    {
        FileResult CreateFile(string name);

        FileResult ReadFile(
            string name,
            out string content);

        FileResult WriteFile(
            string name,
            string content);

        FileResult DeleteFile(string name);
    }
}