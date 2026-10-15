using System.Globalization;
using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using MenuItem = SmoothieTruckApp.Models.MenuItem;

namespace SmoothieTruckApp.Repositories;

internal static class MenuItemRepository
{
    private const string TableName = "item_table";

    public static List<MenuItem> GetAll()
    {
        return TableAccess.ReadRows(TableName)
            .Select(row => new MenuItem
            {
                Id = (int)row[0],
                Name = (string)row[1],
                Price = (decimal)row[2]
            })
            .ToList();
    }

    public static bool Add(string name, decimal price)
    {
        DbResult result = DataBase.add_new_row(TableName, new[]
        {
            new RowValue(DataType.STRING, name),
            new RowValue(DataType.DECIMAL, price.ToString(CultureInfo.InvariantCulture))
        });

        return result == DbResult.Success;
    }

    public static void SeedIfEmpty()
    {
        if (GetAll().Count > 0) return;

        Add("Tropical Sunrise", 9.50m);
        Add("Berry Blast", 8.75m);
        Add("Green Machine", 10.00m);
        Add("Mango Tango", 9.00m);
    }
}
