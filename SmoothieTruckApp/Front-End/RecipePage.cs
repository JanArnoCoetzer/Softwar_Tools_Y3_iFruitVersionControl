using System;
using System.ComponentModel;
using System.Windows.Forms;

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

            AddSampleData();   // TEMPORARY: delete this line when the database is connected
            UpdateCount();
        }

        public RecipeCard AddRecipe(string name, string category, string lastUpdated,
                                    params (string Name, int Grams)[] items)
        {
            var card = new RecipeCard();
            card.Margin = new Padding(0, 0, 0, 10);
            card.SetRecipe(flowRecipes.Controls.Count + 1, name, category, lastUpdated, items);

            card.SaveClicked += (s, e) => RecipeSaved?.Invoke(this, card);
            card.RemoveClicked += (s, e) => RemoveRecipe(card);

            flowRecipes.Controls.Add(card);
            FitCards();
            UpdateCount();
            return card;
        }

        public void ClearRecipes()
        {
            while (flowRecipes.Controls.Count > 0)
            {
                Control c = flowRecipes.Controls[0];
                flowRecipes.Controls.RemoveAt(0);
                c.Dispose();
            }
            UpdateCount();
        }

        private void btnAddRecipe_Click(object? sender, EventArgs e)
        {
            RecipeCard card = AddRecipe("New recipe", "Uncategorised", "Just now");
            card.SetEditing(true);
        }

        private void RemoveRecipe(RecipeCard card)
        {
            var answer = MessageBox.Show($"Remove \"{card.RecipeName}\"?", "Remove recipe",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes) return;

            BeginInvoke(new Action(() =>
            {
                flowRecipes.Controls.Remove(card);
                RecipeRemoved?.Invoke(this, card);
                card.Dispose();
                Renumber();
                UpdateCount();
            }));
        }

        private void Renumber()
        {
            int n = 1;
            foreach (Control c in flowRecipes.Controls)
                if (c is RecipeCard rc) rc.SetNumber(n++);
        }

        private void UpdateCount()
        {
            lblRecipeSub.Text = $"{flowRecipes.Controls.Count} active recipes · Keep every blend consistent across shifts";
        }

        private void FitCards()
        {
            foreach (Control c in flowRecipes.Controls)
                c.Width = flowRecipes.ClientSize.Width - c.Margin.Horizontal;
        }

        private void AddSampleData()
        {
            AddRecipe("Green Machine", "Green", "Today, 9:42 AM",
                ("Spinach", 60), ("Kale", 35), ("Banana", 100), ("Ginger", 8), ("Almond milk", 180));
            AddRecipe("Mango Tango", "Fruit", "Yesterday, 4:18 PM",
                ("Mango", 140), ("Orange", 90), ("Turmeric", 4), ("Honey", 12), ("Ice", 80));
            AddRecipe("Tropical Sunrise", "Tropical", "May 21, 11:05 AM",
                ("Mango", 100), ("Pineapple", 110), ("Passion fruit", 45), ("Coconut milk", 170));
            AddRecipe("Berry Blast", "Berry", "May 20, 2:30 PM",
                ("Strawberry", 90), ("Blueberry", 70), ("Açaí", 50), ("Oat milk", 180));
        }
    }
}