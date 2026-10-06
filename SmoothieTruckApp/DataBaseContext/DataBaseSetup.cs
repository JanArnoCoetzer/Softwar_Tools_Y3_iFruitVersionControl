using System;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;

namespace SmoothieTruckApp.DataBaseContext
{
    internal class DataBaseSetup
    {
        /// <summary>
        /// Creates database tables and applies the schemas from the system diagram.
        /// </summary>
        /// <returns>DbResult.Success if setup completes cleanly; otherwise, the specific failure code.</returns>
        /// 

        public static DbResult InitializeDatabase()
        {
            string[] tables = { "ordered_items_table", "item_table", "recipe_table", "stock_table", "income_table" };

            // 1. Create all table files
            foreach (var table in tables)
            {
                DbResult createResult = DataBase.create_Table(table);

                if (createResult != DbResult.Success && createResult != DbResult.DuplicateRecord)
                {
                    return createResult;
                }
            }


            TableColumn[] orderedItemsColumns = new TableColumn[]
            {
                new TableColumn("order_index PK", DataType.INTEGER),
                new TableColumn("item_index FK", DataType.INTEGER),
                new TableColumn("quantity", DataType.INTEGER)
            };
            DbResult result = DataBase.set_table_columns("ordered_items_table", orderedItemsColumns);
            if (result != DbResult.Success) return result;


            TableColumn[] itemColumns = new TableColumn[]
            {
                new TableColumn("item_index PK", DataType.INTEGER),
                new TableColumn("name", DataType.STRING),
                new TableColumn("price", DataType.DECIMAL)
            };
            result = DataBase.set_table_columns("item_table", itemColumns);
            if (result != DbResult.Success) return result;


            TableColumn[] recipeColumns = new TableColumn[]
            {
                new TableColumn("recipe_index PK", DataType.INTEGER),
                new TableColumn("item_index FK", DataType.INTEGER),
                new TableColumn("stock_index FK", DataType.INTEGER),
                new TableColumn("quantity_required", DataType.DECIMAL)
            };
            result = DataBase.set_table_columns("recipe_table", recipeColumns);
            if (result != DbResult.Success) return result;


            TableColumn[] stockColumns = new TableColumn[]
            {
                new TableColumn("stock_index PK", DataType.INTEGER),
                new TableColumn("name", DataType.STRING),
                new TableColumn("quantity", DataType.DECIMAL),
                new TableColumn("unit", DataType.STRING)
            };
            result = DataBase.set_table_columns("stock_table", stockColumns);
            if (result != DbResult.Success) return result;


            TableColumn[] incomeColumns = new TableColumn[]
            {
                new TableColumn("income_index PK", DataType.INTEGER),
                new TableColumn("order_total", DataType.DECIMAL)
            };
            result = DataBase.set_table_columns("income_table", incomeColumns);
            if (result != DbResult.Success) return result;


            return DbResult.Success;
        }

    }

}

