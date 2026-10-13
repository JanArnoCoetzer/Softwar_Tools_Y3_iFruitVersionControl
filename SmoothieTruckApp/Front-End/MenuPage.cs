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
    public partial class MenuPage : UserControl
    {
        private readonly Order currentOrder = new();

        public MenuPage()
        {
            InitializeComponent();

            btnRemove.Click += btnRemove_Click;
            btnClearAll.Click += btnClearAll_Click;
            btnAddOrder.Click += btnAddOrder_Click;

            ShowMenu(new List<MenuItem>
            {
                new MenuItem { Id = 1, Name = "Tropical Sunrise", Price = 9.50m },
                new MenuItem { Id = 2, Name = "Berry Blast", Price = 8.75m },
                new MenuItem { Id = 3, Name = "Green Machine", Price = 10.00m },
                new MenuItem { Id = 4, Name = "Mango Tango", Price = 9.00m }
            });

            RefreshOrder();
        }

        private void ShowMenu(List<MenuItem> items)
        {
            FlowMenu.Controls.Clear();

            foreach (MenuItem item in items)
            {
                var card = new ItemCard
                {
                    Margin = new Padding(0, 0, 16, 16)
                };

                card.SetItem(item);
                card.AddClicked += ItemCard_AddClicked;
                FlowMenu.Controls.Add(card);
            }

            lblBlends.Text = $"{items.Count} Blends";
        }

        private void ItemCard_AddClicked(object? sender, EventArgs e)
        {
            if (sender is ItemCard card && card.Item != null)
            {
                currentOrder.AddItem(card.Item);
                RefreshOrder();
            }
        }

        private void btnAddOrder_Click(object? sender, EventArgs e)
        {
            if (currentOrder.Lines.Count == 0) return;

            MessageBox.Show(currentOrder.GetReceipt(), "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);

            currentOrder.Clear();
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
            btnAddOrder.Enabled = currentOrder.ItemCount > 0;
            ShowOrderLines();
        }

        private void ShowOrderLines()
        {
            foreach (Panel oldRow in flowOrder.Controls.OfType<Panel>().ToList())
            {
                flowOrder.Controls.Remove(oldRow);
                oldRow.Dispose();
            }

            foreach (OrderLine line in currentOrder.Lines)
            {
                var row = new Panel
                {
                    Width = flowOrder.ClientSize.Width - 6,
                    Height = 28,
                    Cursor = Cursors.Hand,
                    Tag = line.Item.Id
                };

                var lblLineName = new Label
                {
                    Text = $"{line.Quantity} × {line.Item.Name}",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft
                };

                var lblLinePrice = new Label
                {
                    Text = $"${line.LineTotal:0.00}",
                    Dock = DockStyle.Right,
                    Width = 60,
                    TextAlign = ContentAlignment.MiddleRight
                };

                row.Controls.Add(lblLineName);
                row.Controls.Add(lblLinePrice);

                row.Click += OrderLine_Click;
                lblLineName.Click += OrderLine_Click;
                lblLinePrice.Click += OrderLine_Click;

                flowOrder.Controls.Add(row);
            }
        }

        private void OrderLine_Click(object? sender, EventArgs e)
        {
            Control? clicked = sender as Control;
            Panel? row = clicked as Panel ?? clicked?.Parent as Panel;

            if (row?.Tag is int itemId)
            {
                BeginInvoke(() =>
                {
                    currentOrder.RemoveOne(itemId);
                    RefreshOrder();
                });
            }
        }

        //this label is the text in the order screen all you rly need to have for it is just to lblEmpty.Visible = false
        //when an item is added and the flowOrder will be uncovered by the text and that will have the items in it vise versa when the list is empty just make the lable visibe again
        private void lblEmpty_Click(object sender, EventArgs e)
        {

        }
    }
}
