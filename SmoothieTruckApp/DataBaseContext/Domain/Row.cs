using System;

namespace SmoothieTruckApp.DataBaseContext.Domain
{
    internal sealed class Row
    {
        private readonly object[] values;

        public int Id => (int)values[0];

        private Row(object[] values)
        {
            this.values = (object[])values.Clone();
        }

        public static bool TryCreate(
            TableSchema schema,
            object[] values,
            out Row row)
        {
            row = null;

            if (schema == null || !schema.IsValidRecord(values))
            {
                return false;
            }

            row = new Row(values);
            return true;
        }

        public object GetValue(int columnIndex)
        {
            return values[columnIndex];
        }

        public object[] GetValues()
        {
            return (object[])values.Clone();
        }
    }
}