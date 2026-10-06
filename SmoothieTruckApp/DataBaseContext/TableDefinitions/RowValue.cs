using System;
using System.Collections.Generic;
using System.Text;

namespace SmoothieTruckApp.DataBaseContext.TableDefinitions
{
    internal class RowValue
    {
        public DataType DataType;
        public string Value;

        public RowValue(DataType type, string value) 
        {
            DataType = type;
            Value = value;
        }

    
    }
}
