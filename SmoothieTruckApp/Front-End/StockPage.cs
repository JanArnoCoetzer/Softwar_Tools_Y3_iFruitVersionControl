using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SmoothieTruckApp.Front_End
{
    public partial class StockPage : UserControl
    {
        public event EventHandler<StockRow>? StockChanged;

        public StockPage()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            flowStock.ClientSizeChanged += (s, e) => FitRows();

            flowStock.SuspendLayout();
            AddSampleData(); // TEMPORARY: delete this line when the database is connected
            flowStock.ResumeLayout(true);
            FitRows();
            UpdateAttention();
        }

        public StockRow AddItem(string name, string category, int grams)
        {
            var row = new StockRow();
            row.Margin = new Padding(0);
            row.SetItem(name, category, grams);
            row.StockChanged += (s, e) =>
            {
                UpdateAttention();
                StockChanged?.Invoke(this, row);
            };

            flowStock.Controls.Add(row);
            FitRows();
            UpdateAttention();
            return row;
        }

        public void ClearItems()
        {
            while (flowStock.Controls.Count > 0)
            {
                Control c = flowStock.Controls[0];
                flowStock.Controls.RemoveAt(0);
                c.Dispose();
            }
            UpdateAttention();
        }

        private void UpdateAttention()
        {
            int count = 0;
            foreach (Control c in flowStock.Controls)
                if (c is StockRow r && r.Status != StockStatus.InStock) count++;

            pnlAttention.Visible = count > 0;
            lblAttention.Text = count == 1 ? "1 item needs attention" : $"{count} items need attention";
        }

        private void FitRows()
        {
            foreach (Control c in flowStock.Controls)
                c.Width = flowStock.ClientSize.Width - c.Margin.Horizontal;
        }

        // TEMPORARY sample data copied from the mockup
        private void AddSampleData()
        {
            AddItem("Spinach", "Fresh greens", 1350);
            AddItem("Mango", "Frozen fruit", 4800);
            AddItem("Mixed Berries", "Frozen fruit", 0);
            AddItem("Bananas", "Fresh fruit", 3600);
            AddItem("Almond Milk", "Milk & bases", 5400);
            AddItem("Coconut Milk", "Milk & bases", 900);
            AddItem("Pineapple", "Frozen fruit", 3200);
        }
    }
}