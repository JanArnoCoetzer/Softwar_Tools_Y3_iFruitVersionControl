using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SmoothieTruckApp.Front_End
{
    public partial class RecipeCard : UserControl
    {
        private const int CollapsedHeight = 96;

        private bool isEditing;
        private readonly List<(string Name, int Grams)> ingredients = new();
        private List<(string Name, int Grams)> snapshot = new();

        public event EventHandler? SaveClicked;
        public event EventHandler? RemoveClicked;

        public bool IsEditing => isEditing;
        public string RecipeName => lblRecipeName.Text;
        public IReadOnlyList<(string Name, int Grams)> Ingredients => ingredients;

        public RecipeCard()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            Height = CollapsedHeight;
            pnlEditForm.Visible = false;

            btnEditRecipe.Click += (s, e) => SetEditing(!isEditing);
            btnRemoveRecipe.Click += (s, e) => RemoveClicked?.Invoke(this, EventArgs.Empty);
            btnSaveChanges.Click += btnSaveChanges_Click;
            btnAddIngredient.Click += btnAddIngredient_Click;

            txtIngredientName.TextChanged += (s, e) => UpdateAddButton();
            txtAmount.TextChanged += (s, e) => UpdateAddButton();
            txtAmount.KeyPress += txtAmount_KeyPress;

            UpdateAddButton();
        }
        public void SetRecipe(int number, string name, string category, string lastUpdated,
                              params (string Name, int Grams)[] items)
        {
            SetNumber(number);
            lblRecipeName.Text = name;
            lblRecipeCategory.Text = category.ToUpper();
            lblRecipeTime.Text = lastUpdated;

            ClearIngredients();
            foreach (var item in items)
                AddIngredient(item.Name, item.Grams);
        }

        public void SetNumber(int number)
        {
            lblNumber.Text = number.ToString("00");
        }

        public void AddIngredient(string name, int grams)
        {
            ingredients.Add((name, grams));

            var chip = new IngredientChip();
            chip.SetIngredient(name, grams);
            flowChips.Controls.Add(chip);
        }

        public void ClearIngredients()
        {
            ingredients.Clear();
            while (flowChips.Controls.Count > 0)
            {
                Control c = flowChips.Controls[0];
                flowChips.Controls.RemoveAt(0);
                c.Dispose();
            }
        }

        // Opens or closes the edit form.
        public void SetEditing(bool editing)
        {
            if (editing == isEditing) return;

            if (editing)
            {
                snapshot = new List<(string Name, int Grams)>(ingredients);
            }
            else
            {
                txtIngredientName.Clear();
                txtAmount.Clear();
            }

            isEditing = editing;
            pnlEditForm.Visible = editing;
            btnEditRecipe.Text = editing ? "Cancel" : "Edit Recipe";
            pnlCard.BorderColor = editing ? Color.FromArgb(167, 139, 250) : Color.FromArgb(236, 238, 242);
            Height = editing ? CollapsedHeight + pnlEditForm.Height : CollapsedHeight;
            pnlCard.Invalidate();
        }


        private void btnSaveChanges_Click(object? sender, EventArgs e)
        {
            snapshot = new List<(string Name, int Grams)>(ingredients);
            SetEditing(false);
            SaveClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnAddIngredient_Click(object? sender, EventArgs e)
        {
            if (!TryGetNewIngredient(out string name, out int grams)) return;

            AddIngredient(name, grams);
            txtIngredientName.Clear();
            txtAmount.Clear();
            txtIngredientName.Focus();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
        }

        private void RestoreSnapshot()
        {
            ClearIngredients();
            foreach (var item in snapshot)
                AddIngredient(item.Name, item.Grams);
        }

        private bool TryGetNewIngredient(out string name, out int grams)
        {
            name = txtIngredientName.Text.Trim();
            grams = 0;
            return name.Length > 0 && int.TryParse(txtAmount.Text, out grams) && grams > 0;
        }

        private void UpdateAddButton()
        {
            bool ok = TryGetNewIngredient(out _, out _);
            btnAddIngredient.BackColor = ok ? Color.FromArgb(237, 233, 254) : Color.FromArgb(243, 244, 246);
            btnAddIngredient.ForeColor = ok ? Color.FromArgb(124, 58, 237) : Color.FromArgb(156, 163, 175);
        }


        private void txtAmount_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}