using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmoothieTruckApp.Front_End
{
    public partial class IngredientChip : UserControl
    {
        public event EventHandler? RemoveClicked;

        public string IngredientName => lblChipName.Text;

        public IngredientChip()
        {
            InitializeComponent();

            lblChipRemove.Click += (s, e) => RemoveClicked?.Invoke(this, EventArgs.Empty);
        }


        public void SetIngredient(string name, int amount, string unit)
        {
            lblChipName.Text = name;
            lblChipGrams.Text = $"{amount}{unit}";

            FitWidth();
        }

        public void SetRemovable(bool removable)
        {
            lblChipRemove.Visible = removable;

            FitWidth();
        }

        private void FitWidth()
        {
            flowChipInner.PerformLayout();
            Width = flowChipInner.GetPreferredSize(Size.Empty).Width + flowChipInner.Left * 2;
        }
    }
}
