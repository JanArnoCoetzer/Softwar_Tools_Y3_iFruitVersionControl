using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using SmoothieTruckApp.Repositories;
using System.Collections.Generic;
using System.Linq;


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

            LoadStock();
        }

        public void LoadStock()
        {
            var preparedRows = new List<StockRow>();
            var warnings = new List<string>();

            try
            {
                var stockItems = StockRepository.GetAll();

                foreach (var item in stockItems.OrderBy(item => item.Id))
                {
                    var row = new StockRow
                    {
                        Margin = new Padding(0)
                    };

                    try
                    {
                        row.SetDatabaseItem(item);
                        preparedRows.Add(row);
                    }
                    catch (InvalidOperationException ex)
                    {
                        row.Dispose();
                        warnings.Add($"{item.Name}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                foreach (var row in preparedRows)
                {
                    row.Dispose();
                }

                MessageBox.Show(
                    $"Could not load stock:\n{ex.Message}",
                    "Stock loading failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            flowStock.SuspendLayout();

            try
            {
                ClearItems();

                foreach (var row in preparedRows)
                {
                    row.StockChanged += StockRow_StockChanged;
                    flowStock.Controls.Add(row);
                }
            }
            finally
            {
                flowStock.ResumeLayout(true);
                FitRows();
                UpdateAttention();
            }

            if (warnings.Count > 0)
            {
                MessageBox.Show(
                    "Some stock items could not be displayed:\n\n" +
                    string.Join(Environment.NewLine, warnings),
                    "Stock loading warnings",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        public StockRow AddItem(
            string name,
            string category,
            int grams)
        {
            var row = new StockRow
            {
                Margin = new Padding(0)
            };

            row.SetItem(name, category, grams);
            row.StockChanged += StockRow_StockChanged;

            flowStock.Controls.Add(row);

            FitRows();
            UpdateAttention();

            return row;
        }

        private void StockRow_StockChanged(object? sender, EventArgs e)
        {
            if (sender is not StockRow row)
                return;

            UpdateAttention();

            // Notification only: the row has already saved the change.
            StockChanged?.Invoke(this, row);
        }

        public void ClearItems()
        {
            while (flowStock.Controls.Count > 0)
            {
                Control control = flowStock.Controls[0];

                if (control is StockRow row)
                {
                    row.StockChanged -= StockRow_StockChanged;
                }

                flowStock.Controls.RemoveAt(0);
                control.Dispose();
            }

            UpdateAttention();
        }

        private void UpdateAttention()
        {
            int count = 0;

            foreach (Control control in flowStock.Controls)
            {
                if (control is StockRow row &&
                    row.Status != StockStatus.InStock)
                {
                    count++;
                }
            }

            pnlAttention.Visible = count > 0;

            lblAttention.Text = count == 1
                ? "1 item needs attention"
                : $"{count} items need attention";
        }

        private void FitRows()
        {
            foreach (Control control in flowStock.Controls)
            {
                control.Width = Math.Max(
                    0,
                    flowStock.ClientSize.Width -
                    control.Margin.Horizontal);
            }
        }
    }
}