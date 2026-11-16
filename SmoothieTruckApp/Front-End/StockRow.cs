using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SmoothieTruckApp.Front_End
{
    public enum StockStatus { InStock, LowStock, OutOfStock }

    public partial class StockRow : UserControl
    {
        public const int StepGrams = 100;        // how much one click adds / removes
        public const int LowThreshold = 1000;    // below this (but above 0) = Low Stock

        private int grams;

        public event EventHandler? StockChanged;

        public string IngredientName => lblStockName.Text;
        public int Grams => grams;

        public StockStatus Status =>
            grams <= 0 ? StockStatus.OutOfStock :
            grams < LowThreshold ? StockStatus.LowStock :
            StockStatus.InStock;

        public StockRow()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            lblStockStep.Text = $"{StepGrams}g";
            btnAddStock.Click += (s, e) => Adjust(+StepGrams);
            btnRemoveStock.Click += (s, e) => Adjust(-StepGrams);
        }

        public void SetItem(string name, string category, int grams)
        {
            lblStockName.Text = name;
            lblStockCategory.Text = category;
            SetGrams(grams);
        }

        public void SetGrams(int newGrams)
        {
            grams = Math.Max(0, newGrams);
            UpdateDisplay();
        }


        private void Adjust(int delta)
        {
            SetGrams(grams + delta);
            StockChanged?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateDisplay()
        {
            lblStockGrams.Text = $"{grams:N0} g";

            switch (Status)
            {
                case StockStatus.OutOfStock:
                    lblStatus.Text = "● Out of Stock";
                    pnlStatus.FillColor = Color.FromArgb(254, 226, 226);
                    lblStatus.ForeColor = Color.FromArgb(220, 38, 38);
                    break;
                case StockStatus.LowStock:
                    lblStatus.Text = "● Low Stock";
                    pnlStatus.FillColor = Color.FromArgb(254, 243, 205);
                    lblStatus.ForeColor = Color.FromArgb(161, 98, 7);
                    break;
                default:
                    lblStatus.Text = "● In Stock";
                    pnlStatus.FillColor = Color.FromArgb(220, 252, 231);
                    lblStatus.ForeColor = Color.FromArgb(22, 163, 74);
                    break;
            }

            pnlStatus.Width = TextRenderer.MeasureText(lblStatus.Text, lblStatus.Font).Width + 20;
            pnlStatus.Invalidate();

            bool canRemove = grams > 0;
            btnRemoveStock.Enabled = canRemove;
            btnRemoveStock.BackColor = canRemove ? Color.White : Color.FromArgb(243, 244, 246);
            btnRemoveStock.ForeColor = canRemove ? Color.FromArgb(185, 28, 28) : Color.FromArgb(156, 163, 175);
        }
    }
}