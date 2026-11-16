using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SmoothieTruckApp.Models;
using SmoothieTruckApp.Repositories;

namespace SmoothieTruckApp.Front_End
{
    public enum StockStatus
    {
        InStock,
        LowStock,
        OutOfStock
    }

    public partial class StockRow : UserControl
    {
        public const int StepGrams = 100;
        public const int LowThreshold = 1000;

        private int grams;
        private int? stockId;

        public event EventHandler? StockChanged;

        public string IngredientName => lblStockName.Text;
        public int Grams => grams;

        public StockStatus Status =>
            grams <= 0
                ? StockStatus.OutOfStock
                : grams < LowThreshold
                    ? StockStatus.LowStock
                    : StockStatus.InStock;

        public StockRow()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            lblStockStep.Text = $"{StepGrams}g";

            btnAddStock.Click += (s, e) => Adjust(StepGrams);
            btnRemoveStock.Click += (s, e) => Adjust(-StepGrams);

            UpdateDisplay();
        }

        // Retained for compatibility with existing display-only code.
        // Use SetDatabaseItem when loading a real stock record.
        public void SetItem(string name, string category, int grams)
        {
            stockId = null;

            lblStockName.Text = name;
            lblStockCategory.Text = category;

            SetGrams(grams);
        }

        public void SetDatabaseItem(StockItem item)
        {
            int displayGrams = ConvertToGrams(
                item.Quantity,
                item.Unit);

            stockId = item.Id;

            lblStockName.Text = item.Name;
            lblStockCategory.Text = $"Stock unit: {item.Unit}";

            SetGrams(displayGrams);
        }

        public void SetGrams(int newGrams)
        {
            grams = Math.Max(0, newGrams);
            UpdateDisplay();
        }

        private void Adjust(int delta)
        {
            if (!stockId.HasValue)
            {
                MessageBox.Show(
                    "This row is not linked to a database stock item. " +
                    "Reload the stock page.",
                    "Stock item not linked",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            btnAddStock.Enabled = false;
            btnRemoveStock.Enabled = false;

            try
            {
                // Read the current database value rather than relying
                // on a potentially outdated displayed quantity.
                StockItem? item = StockRepository.GetAll()
                    .SingleOrDefault(s => s.Id == stockId.Value);

                if (item == null)
                {
                    throw new InvalidOperationException(
                        "This ingredient no longer exists in the stock table.");
                }

                decimal adjustment = ConvertFromGrams(delta, item.Unit);
                decimal newQuantity = Math.Max(
                    0m,
                    item.Quantity + adjustment);

                // Validate that the result can be displayed before saving.
                int newGrams = ConvertToGrams(
                    newQuantity,
                    item.Unit);

                item.Quantity = newQuantity;

                if (!StockRepository.Update(item))
                {
                    throw new InvalidOperationException(
                        "The database could not save the stock adjustment.");
                }

                lblStockName.Text = item.Name;
                lblStockCategory.Text = $"Stock unit: {item.Unit}";

                SetGrams(newGrams);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Stock adjustment failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            finally
            {
                UpdateDisplay();
            }

            // Notify the page only after the database update succeeds.
            StockChanged?.Invoke(this, EventArgs.Empty);
        }

        private static decimal ConvertFromGrams(int amount, string unit)
        {
            switch ((unit ?? string.Empty).Trim().ToLowerInvariant())
            {
                case "kg":
                    return amount / 1000m;

                case "g":
                    return amount;

                default:
                    throw new InvalidOperationException(
                        $"Unit '{unit}' is not supported by this " +
                        "grams-only stock row.");
            }
        }

        private static int ConvertToGrams(decimal quantity, string unit)
        {
            if (quantity < 0)
            {
                throw new InvalidOperationException(
                    "Stock quantity cannot be negative.");
            }

            decimal displayGrams;

            switch ((unit ?? string.Empty).Trim().ToLowerInvariant())
            {
                case "kg":
                    if (quantity > int.MaxValue / 1000m)
                    {
                        throw new InvalidOperationException(
                            "The stock quantity is too large to display.");
                    }

                    displayGrams = quantity * 1000m;
                    break;

                case "g":
                    displayGrams = quantity;
                    break;

                default:
                    throw new InvalidOperationException(
                        $"Unit '{unit}' is not supported by this " +
                        "grams-only stock row.");
            }

            if (displayGrams > int.MaxValue ||
                displayGrams != decimal.Truncate(displayGrams))
            {
                throw new InvalidOperationException(
                    "The stock quantity must fit within the supported " +
                    "range and be expressible as whole grams.");
            }

            return (int)displayGrams;
        }

        private void UpdateDisplay()
        {
            lblStockGrams.Text = $"{grams:N0} g";

            switch (Status)
            {
                case StockStatus.OutOfStock:
                    lblStatus.Text = "● Out of Stock";
                    pnlStatus.FillColor =
                        Color.FromArgb(254, 226, 226);
                    lblStatus.ForeColor =
                        Color.FromArgb(220, 38, 38);
                    break;

                case StockStatus.LowStock:
                    lblStatus.Text = "● Low Stock";
                    pnlStatus.FillColor =
                        Color.FromArgb(254, 243, 205);
                    lblStatus.ForeColor =
                        Color.FromArgb(161, 98, 7);
                    break;

                default:
                    lblStatus.Text = "● In Stock";
                    pnlStatus.FillColor =
                        Color.FromArgb(220, 252, 231);
                    lblStatus.ForeColor =
                        Color.FromArgb(22, 163, 74);
                    break;
            }

            pnlStatus.Width =
                TextRenderer.MeasureText(
                    lblStatus.Text,
                    lblStatus.Font).Width + 20;

            pnlStatus.Invalidate();

            btnAddStock.Enabled = stockId.HasValue;

            bool canRemove = stockId.HasValue && grams > 0;

            btnRemoveStock.Enabled = canRemove;

            btnRemoveStock.BackColor = canRemove
                ? Color.White
                : Color.FromArgb(243, 244, 246);

            btnRemoveStock.ForeColor = canRemove
                ? Color.FromArgb(185, 28, 28)
                : Color.FromArgb(156, 163, 175);
        }
    }
}