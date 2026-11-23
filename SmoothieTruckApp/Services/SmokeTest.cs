using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.Domain;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.Services;

internal static class SmokeTest
{
    public const string Argument = "--smoke-test";

    private static readonly string[] MenuTables =
    {
        "item_table",
        "stock_table",
        "recipe_table"
    };

    public static int Run(DatabaseEngine database)
    {
        try
        {
            foreach (string name in MenuTables)
            {
                if (database.LoadTable(name, out Table table) != DbResult.Success || table.Rows.Count == 0)
                {
                    return 1;
                }
            }

            return database.LoadTable("ordered_items_table", out _) == DbResult.Success ? 0 : 1;
        }
        catch (Exception)
        {
            return 1;
        }
    }
}
