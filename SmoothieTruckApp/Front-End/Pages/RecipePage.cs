using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using SmoothieTruckApp.Repositories;

namespace SmoothieTruckApp.Front_End
{
    public partial class RecipePage : UserControl
    {
        public event EventHandler<RecipeCard>? RecipeSaved;
        public event EventHandler<RecipeCard>? RecipeRemoved;

        public RecipePage()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            flowRecipes.ClientSizeChanged += (s, e) => FitCards();
            btnAddRecipe.Click += btnAddRecipe_Click;

            ParentChanged += (s, e) =>
            {
                if (Parent != null) LoadRecipes();
            };

            LoadRecipes();
        }

        public void LoadRecipes()
        {
            List<LoadedRecipe> recipes;

            try
            {
                // Read first so a loading failure does not clear the page.
                recipes = RecipeLoadService.LoadAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Could not load recipes:\n{ex.Message}",
                    "Load failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                UpdateCount();
                return;
            }

            var warnings = new List<string>();

            flowRecipes.SuspendLayout();

            try
            {
                ClearRecipes();

                foreach (var recipe in recipes)
                {
                    RecipeCard card = AddRecipe(
                        recipe.Name,
                        recipe.Category,
                        recipe.Price,
                        "Loaded from database",
                        recipe.Ingredients.ToArray());

                    // Use the actual database ID, not the display number.
                    card.ItemId = recipe.ItemId;

                    if (!recipe.CanEdit)
                    {
                        // Prevent incomplete ingredient lists from
                        // overwriting the saved recipe.
                        card.Enabled = false;

                        foreach (string warning in recipe.Warnings)
                        {
                            warnings.Add($"{recipe.Name}: {warning}");
                        }
                    }
                }
            }
            finally
            {
                flowRecipes.ResumeLayout(true);
                FitCards();
                UpdateCount();
            }

            if (warnings.Count > 0)
            {
                MessageBox.Show(
                    "Some recipes could not be fully displayed. " +
                    "Affected cards have been disabled to prevent " +
                    "saving incomplete ingredient lists.\n\n" +
                    string.Join(Environment.NewLine, warnings),
                    "Recipe loading warnings",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        public RecipeCard AddRecipe(
            string name,
            string category,
            decimal price,
            string lastUpdated,
            params (string Name, int Amount, string Unit)[] items)
        {
            var card = new RecipeCard
            {
                Margin = new Padding(0, 0, 0, 10)
            };

            card.SetRecipe(
                flowRecipes.Controls.Count + 1,
                name,
                category,
                price,
                lastUpdated,
                items);

            card.SaveClicked += RecipeCard_SaveClicked;
            card.RemoveClicked += RecipeCard_RemoveClicked;

            flowRecipes.Controls.Add(card);

            FitCards();
            UpdateCount();

            return card;
        }

        private void RecipeCard_SaveClicked(
            object? sender,
            RecipeSaveEventArgs e)
        {
            if (sender is not RecipeCard card)
                return;

            try
            {
                card.ItemId = RecipeSaveService.Save(
                    card.ItemId,
                    card.RecipeName,
                    card.RecipeCategory,
                    card.RecipePrice,
                    card.Ingredients);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Save failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            e.Success = true;

            UpdateCount();

            // Other screens can use this event to refresh.
            RecipeSaved?.Invoke(this, card);
        }

        private void RecipeCard_RemoveClicked(
            object? sender,
            EventArgs e)
        {
            if (sender is RecipeCard card)
            {
                RemoveRecipe(card);
            }
        }

        public void ClearRecipes()
        {
            while (flowRecipes.Controls.Count > 0)
            {
                Control control = flowRecipes.Controls[0];

                if (control is RecipeCard card)
                {
                    card.SaveClicked -= RecipeCard_SaveClicked;
                    card.RemoveClicked -= RecipeCard_RemoveClicked;
                }

                flowRecipes.Controls.RemoveAt(0);
                control.Dispose();
            }

            UpdateCount();
        }

        private void btnAddRecipe_Click(object? sender, EventArgs e)
        {
            RecipeCard card = AddRecipe(
                "New recipe",
                "Uncategorised",
                0m,
                "Just now");

            card.SetEditing(true);
        }

        private void RemoveRecipe(RecipeCard card)
        {
            string message = card.ItemId.HasValue
             ? $"Permanently delete \"{card.RecipeName}\" from the " +
               "menu and recipe database?\n\n" +
               "Its stock ingredients will also be deleted if no other " +
               "recipe uses them, even if they still have stock on hand."
             : $"Discard the unsaved recipe \"{card.RecipeName}\"?";

            DialogResult answer = MessageBox.Show(
                message,
                "Remove recipe",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (answer != DialogResult.Yes)
                return;

            try
            {
                // Unsaved cards have no database records to delete.
                if (card.ItemId.HasValue)
                {
                    RecipeDeleteService.Delete(card.ItemId.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Delete failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // Keep the card visible if deletion fails.
                return;
            }

            flowRecipes.Controls.Remove(card);

            try
            {
                // Notification only: database deletion has already completed.
                RecipeRemoved?.Invoke(this, card);
            }
            finally
            {
                card.SaveClicked -= RecipeCard_SaveClicked;
                card.RemoveClicked -= RecipeCard_RemoveClicked;

                card.Dispose();

                Renumber();
                UpdateCount();
                FitRowsAfterRemoval();
            }
        }

        private void FitRowsAfterRemoval()
        {
            FitCards();
        }

        private void Renumber()
        {
            int number = 1;

            foreach (Control control in flowRecipes.Controls)
            {
                if (control is RecipeCard card)
                {
                    card.SetNumber(number++);
                }
            }
        }

        private void UpdateCount()
        {
            int count = flowRecipes.Controls
                .OfType<RecipeCard>()
                .Count();

            lblRecipeSub.Text =
                $"{count} active recipes · " +
                "Keep every blend consistent across shifts";
        }

        private void FitCards()
        {
            foreach (Control control in flowRecipes.Controls)
            {
                control.Width = Math.Max(
                    0,
                    flowRecipes.ClientSize.Width -
                    control.Margin.Horizontal);
            }
        }
    }
}