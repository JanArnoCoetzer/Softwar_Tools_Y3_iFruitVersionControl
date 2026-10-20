using SmoothieTruckApp.Models;
using MenuItem = SmoothieTruckApp.Models.MenuItem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmoothieTruckApp.Front_End
{
    public partial class ItemCard : UserControl
    {
        public MenuItem? Item { get; private set; }

        public event EventHandler? AddClicked;

        public ItemCard()
        {
            InitializeComponent();
        }

        public void SetItem(MenuItem item)
        {
            Item = item;
            lblName.Text = item.Name;
            lblPrice.Text = $"${item.Price:0.00}";
            lblIngredients.Text = string.Empty;
            ItemCatagory(item.CatagoryName, item.CatagoryColor);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClicked?.Invoke(this, EventArgs.Empty);
        }

        public void ItemCatagory(string CatagoryName, Color CatagoryColor) 
        {
            txtCatagoryLabel.Text = CatagoryName;
            rbCatagoryNameBackground.FillColor = CatagoryColor;
            CatagoryDivisionLine.BackColor = CatagoryColor;
        }
    }
}
