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
                Price = (decimal)row[2],
                CatagoryName = (string)row[3],
                CatagoryColor = ColorTranslator.FromHtml((string)row[4])
            })
            .ToList();
    }

    public static bool Add(string name, decimal price,string catagoryname,string catagorycolor)
    {
        DbResult result = DataBase.add_new_row(TableName, new[]
        {
            new RowValue(DataType.STRING, name),
            new RowValue(DataType.DECIMAL, price.ToString(CultureInfo.InvariantCulture)),
            new RowValue(DataType.STRING, catagoryname),
            new RowValue(DataType.STRING, catagorycolor),
        });

        return result == DbResult.Success;
    }

    public static void SeedIfEmpty()
    {
        if (GetAll().Count > 0) return;

        Add("Tropical Sunrise", 9.50m,"Fruit", "#f5b244");
        Add("Berry Blast", 8.75m,"Berry", "#9252a0");
        Add("Green Machine", 10.00m,"Green", "#52915e");
        Add("Mango Tango", 9.00m,"Fruit", "#ea944a");
    }
}
