namespace SmoothieTruckApp.DataBaseContext
{
    internal struct TableColumn
    {
        internal string DataName;
        internal DataType VarType; 

        internal TableColumn(string name, DataType type)
        {
            DataName = name;
            VarType = type;
        }
    }
}



