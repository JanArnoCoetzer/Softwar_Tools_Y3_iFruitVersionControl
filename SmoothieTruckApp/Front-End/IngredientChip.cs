using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmoothieTruckApp.Front_End
{
    public partial class IngredientChip : UserControl
    {
        public IngredientChip()
        {
            InitializeComponent();
        }

        
        public void SetIngredient(string name, int grams)
        {
            lblChipName.Text = name;
            lblChipGrams.Text = $"{grams}g";

            flowChipInner.PerformLayout();
            Width = flowChipInner.GetPreferredSize(Size.Empty).Width + flowChipInner.Left * 2;
        }
    }
}