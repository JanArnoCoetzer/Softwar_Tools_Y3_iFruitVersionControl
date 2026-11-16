using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace SmoothieTruckApp.Front_End
{
    public sealed class RecipeSaveEventArgs : EventArgs
    {
        public bool Success { get; set; }
    }

    public partial class RecipeCard : UserControl
    {
        private const int CollapsedHeight = 96;

        private bool isEditing;

        private readonly List<(string Name, int Amount, string Unit)> ingredients = new();
        private List<(string Name, int Amount, string Unit)> snapshot = new();

        private string recipeNameSnapshot = string.Empty;
        private string categorySnapshot = string.Empty;
        private string priceSnapshot = string.Empty;

        public event EventHandler<RecipeSaveEventArgs>? SaveClicked;
        public event EventHandler? RemoveClicked;

        // Null for a new recipe. Set this when loading an existing item.
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? ItemId { get; set; }

        public bool IsEditing => isEditing;
        public string RecipeName => lblRecipeName.Text.Trim();
        public string RecipeCategory => txtCatagory.Text.Trim();
        public decimal RecipePrice => TryGetPrice(out decimal price) ? price : 0m;

        public IReadOnlyList<(string Name, int Amount, string Unit)> Ingredients =>
            ingredients;

        public RecipeCard()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            Height = CollapsedHeight;
            pnlEditForm.Visible = false;
            cboUnit.SelectedIndex = 0;

            UpdateTextFieldsEditing(false);

            btnEditRecipe.Click += btnEditRecipe_Click;

            btnRemoveRecipe.Click += (s, e) =>
                RemoveClicked?.Invoke(this, EventArgs.Empty);

            btnSaveChanges.Click += btnSaveChanges_Click;
            btnAddIngredient.Click += btnAddIngredient_Click;

            txtIngredientName.TextChanged += (s, e) =>
                UpdateAddButton();

            txtAmount.TextChanged += (s, e) =>
                UpdateAddButton();

            txtAmount.KeyPress += txtAmount_KeyPress;

            UpdateAddButton();
        }

        public void SetRecipe(
            int number,
            string name,
            string category,
            decimal price,
            string lastUpdated,
            params (string Name, int Amount, string Unit)[] items)
        {
            SetNumber(number);

            lblRecipeName.Text = name;
            txtCatagory.Text = category.ToUpperInvariant();
            txtPrice.Text = price.ToString("0.00", CultureInfo.InvariantCulture);
            lblRecipeTime.Text = lastUpdated;

            ClearIngredients();

            foreach (var item in items)
            {
                AddIngredient(item.Name, item.Amount, item.Unit);
            }
        }

        public void SetNumber(int number)
        {
            lblNumber.Text = number.ToString("00");
        }

        public void AddIngredient(string name, int amount, string unit)
        {
            //same name replaces the old amount instead of adding a second one
            int index = ingredients.FindIndex(i =>
                string.Equals(i.Name, name, StringComparison.OrdinalIgnoreCase));

            if (index >= 0)
            {
                ingredients[index] = (ingredients[index].Name, amount, unit);

                FindChip(ingredients[index].Name)?.SetIngredient(ingredients[index].Name, amount, unit);
                return;
            }

            ingredients.Add((name, amount, unit));

            var chip = new IngredientChip();
            chip.SetIngredient(name, amount, unit);
            chip.SetRemovable(isEditing);
            chip.RemoveClicked += Chip_RemoveClicked;

            flowChips.Controls.Add(chip);
        }

        public void ClearIngredients()
        {
            ingredients.Clear();

            while (flowChips.Controls.Count > 0)
            {
                Control control = flowChips.Controls[0];

                flowChips.Controls.RemoveAt(0);
                control.Dispose();
            }
        }

        public void SetEditing(bool editing)
        {
            if (editing == isEditing)
                return;

            if (editing)
            {
                recipeNameSnapshot = lblRecipeName.Text;
                categorySnapshot = txtCatagory.Text;
                priceSnapshot = txtPrice.Text;

                snapshot =
                    new List<(string Name, int Amount, string Unit)>(ingredients);
            }
            else
            {
                txtIngredientName.Clear();
                txtAmount.Clear();
            }

            isEditing = editing;

            foreach (IngredientChip chip in flowChips.Controls.OfType<IngredientChip>())
            {
                chip.SetRemovable(editing);
            }

            UpdateTextFieldsEditing(editing);

            pnlEditForm.Visible = editing;
            btnEditRecipe.Text = editing ? "Cancel" : "Edit Recipe";

            pnlCard.BorderColor = editing
                ? Color.FromArgb(167, 139, 250)
                : Color.FromArgb(236, 238, 242);

            Height = editing
                ? CollapsedHeight + pnlEditForm.Height
                : CollapsedHeight;

            pnlCard.Invalidate();

            if (editing)
            {
                lblRecipeName.Focus();
            }
        }

        private void UpdateTextFieldsEditing(bool editing)
        {
            foreach (TextBox textBox in new[] { lblRecipeName, txtCatagory })
            {
                textBox.Enabled = true;
                textBox.ReadOnly = !editing;
                textBox.TabStop = editing;

                textBox.BorderStyle = editing
                    ? BorderStyle.FixedSingle
                    : BorderStyle.None;

                textBox.BackColor = editing
                    ? SystemColors.Window
                    : pnlCard.FillColor;

                textBox.Cursor = editing
                    ? Cursors.IBeam
                    : Cursors.Default;
            }

            lblRecipeName.ForeColor = Color.Black;
        }

        private void btnEditRecipe_Click(object? sender, EventArgs e)
        {
            if (isEditing)
            {
                RestoreSnapshot();
                SetEditing(false);
            }
            else
            {
                SetEditing(true);
            }
        }

        private void btnSaveChanges_Click(object? sender, EventArgs e)
        {
            string recipeName = lblRecipeName.Text.Trim();
            string category = txtCatagory.Text.Trim();

            if (string.IsNullOrWhiteSpace(recipeName))
            {
                MessageBox.Show(
                    "Enter a recipe name.",
                    "Recipe name required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                lblRecipeName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show(
                    "Enter a category.",
                    "Category required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCatagory.Focus();
                return;
            }

            if (!TryGetPrice(out decimal price) || price <= 0)
            {
                MessageBox.Show(
                    "Enter a price greater than 0, e.g. 9.50.",
                    "Price required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPrice.Focus();
                return;
            }

            if (ingredients.Count == 0)
            {
                MessageBox.Show(
                    "Add at least one ingredient.",
                    "Ingredients required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtIngredientName.Focus();
                return;
            }

            lblRecipeName.Text = recipeName;
            txtCatagory.Text = category.ToUpperInvariant();
            txtPrice.Text = price.ToString("0.00", CultureInfo.InvariantCulture);

            var args = new RecipeSaveEventArgs();

            // The parent page performs the database save.
            SaveClicked?.Invoke(this, args);

            // Keep the editor open if saving did not succeed.
            if (!args.Success)
                return;

            recipeNameSnapshot = lblRecipeName.Text;
            categorySnapshot = txtCatagory.Text;
            priceSnapshot = txtPrice.Text;

            snapshot =
                new List<(string Name, int Amount, string Unit)>(ingredients);

            lblRecipeTime.Text = "Just now";

            SetEditing(false);
        }

        private void btnAddIngredient_Click(object? sender, EventArgs e)
        {
            if (!TryGetNewIngredient(out string name, out int amount))
                return;

            AddIngredient(name, amount, cboUnit.Text);

            txtIngredientName.Clear();
            txtAmount.Clear();
            txtIngredientName.Focus();
        }

        private void Chip_RemoveClicked(object? sender, EventArgs e)
        {
            if (sender is not IngredientChip chip)
                return;

            ingredients.RemoveAll(i =>
                string.Equals(i.Name, chip.IngredientName, StringComparison.OrdinalIgnoreCase));

            flowChips.Controls.Remove(chip);
            chip.Dispose();
        }

        private IngredientChip? FindChip(string name)
        {
            return flowChips.Controls
                .OfType<IngredientChip>()
                .FirstOrDefault(c => string.Equals(c.IngredientName, name, StringComparison.OrdinalIgnoreCase));
        }

        private void RestoreSnapshot()
        {
            lblRecipeName.Text = recipeNameSnapshot;
            txtCatagory.Text = categorySnapshot;
            txtPrice.Text = priceSnapshot;

            ClearIngredients();

            foreach (var item in snapshot)
            {
                AddIngredient(item.Name, item.Amount, item.Unit);
            }
        }

        private bool TryGetPrice(out decimal price)
        {
            return decimal.TryParse(
                txtPrice.Text.Trim(),
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out price);
        }

        private bool TryGetNewIngredient(
            out string name,
            out int amount)
        {
            name = txtIngredientName.Text.Trim();
            amount = 0;

            return name.Length > 0
                && int.TryParse(txtAmount.Text, out amount)
                && amount > 0;
        }

        private void UpdateAddButton()
        {
            bool valid = TryGetNewIngredient(out _, out _);

            btnAddIngredient.Enabled = valid;

            btnAddIngredient.BackColor = valid
                ? Color.FromArgb(237, 233, 254)
                : Color.FromArgb(243, 244, 246);

            btnAddIngredient.ForeColor = valid
                ? Color.FromArgb(124, 58, 237)
                : Color.FromArgb(156, 163, 175);
        }

        private void txtAmount_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
