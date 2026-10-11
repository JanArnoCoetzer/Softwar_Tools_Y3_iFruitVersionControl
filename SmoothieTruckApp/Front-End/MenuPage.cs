using SmoothieTruckApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmoothieTruckApp.Front_End
{
    public partial class MenuPage : UserControl
    {
        private readonly Order currentOrder = new();

        public MenuPage()
        {
            InitializeComponent();

            btnRemove.Click += btnRemove_Click;
            btnClearAll.Click += btnClearAll_Click;
            RefreshOrder();
        }

        private void btnRemove_Click(object? sender, EventArgs e)
        {
            if (currentOrder.Lines.Count == 0) return;
            OrderLine lastLine = currentOrder.Lines[^1];
            currentOrder.RemoveItem(lastLine.Item.Id);
            RefreshOrder();
        }

        private void btnClearAll_Click(object? sender, EventArgs e)
        {
            currentOrder.Clear();
            RefreshOrder();
        }

        private void RefreshOrder()
        {
            lblCount.Text = $"{currentOrder.ItemCount} Items";
            lblSubtotal.Text = $"${currentOrder.Subtotal:0.00}";
            lblTax.Text = $"${currentOrder.Tax:0.00}";
            lblTotal.Text = $"${currentOrder.Total:0.00}";
            lblEmpty.Visible = currentOrder.ItemCount == 0;
            btnRemove.Enabled = currentOrder.ItemCount > 0;
            btnClearAll.Enabled = currentOrder.ItemCount > 0;
        }

        //this label is the text in the order screen all you rly need to have for it is just to lblEmpty.Visible = false
        //when an item is added and the flowOrder will be uncovered by the text and that will have the items in it vise versa when the list is empty just make the lable visibe again
        private void lblEmpty_Click(object sender, EventArgs e)
        {

        }
    }
}
