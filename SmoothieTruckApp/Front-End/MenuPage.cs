using SmoothieTruckApp.Models;
using SmoothieTruckApp.Repositories;
using SmoothieTruckApp.Services;
using MenuItem = SmoothieTruckApp.Models.MenuItem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            //Force double buffering on the flow panels to prevent minor artifacts
            EnableDoubleBuffering(FlowMenu);
            EnableDoubleBuffering(flowOrder);

            MenuItemRepository.SeedIfEmpty();
            ShowMenu(MenuItemRepository.GetAll());

            currentOrder.Id = OrderRepository.GetNextOrderNumber();
            RefreshOrder();
        }

        private void ShowMenu(List<MenuItem> items)
        {
            // Freeze calculations before clearing and populating
            FlowMenu.SuspendLayout();

            // Clear old click handlers to prevent memory retention leaks
            foreach (Control control in FlowMenu.Controls)
            {
                if (control is ItemCard oldCard)
                {
                    oldCard.AddClicked -= ItemCard_AddClicked;
                }
                control.Dispose();
            }
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

            // Resume rendering instantly in a single frame sweep
            FlowMenu.ResumeLayout(true);
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

            List<string> shortages = StockService.FindShortages(currentOrder);

            if (shortages.Count > 0)
            {
                MessageBox.Show($"Not enough stock for: {string.Join(", ", shortages)}", "Out of stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int savedOrderNumber = OrderRepository.Save(currentOrder);

            if (savedOrderNumber == 0)
            {
                MessageBox.Show("The order could not be saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StockService.ReduceStock(currentOrder);

            currentOrder.Id = savedOrderNumber;
            MessageBox.Show(currentOrder.GetReceipt(), "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);

            currentOrder.Clear();
            currentOrder.Id = OrderRepository.GetNextOrderNumber();
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
            lblTicket.Text = $"Ticket #{currentOrder.Id}";
            lblCount.Text = $"{currentOrder.ItemCount} Items";
            lblSubtotal.Text = $"${currentOrder.Subtotal:0.00}";
            lblTax.Text = $"${currentOrder.Tax:0.00}";
            lblTotal.Text = $"${currentOrder.Total:0.00}";

            // Toggles empty state indicator
            lblEmpty.Visible = currentOrder.ItemCount == 0;
            flowOrder.Visible = currentOrder.ItemCount > 0;

            btnRemove.Enabled = currentOrder.ItemCount > 0;
            btnClearAll.Enabled = currentOrder.ItemCount > 0;
            btnAddOrder.Enabled = currentOrder.ItemCount > 0;

            ShowOrderLines();
        }

        private void ShowOrderLines()
        {
            // Suspend order sidebar rendering to kill drawing spikes
            flowOrder.SuspendLayout();

            // Safely clear out old panels completely
            foreach (Panel oldRow in flowOrder.Controls.OfType<Panel>().ToList())
            {
                oldRow.Click -= OrderLine_Click;
                foreach (Control sub in oldRow.Controls)
                {
                    sub.Click -= OrderLine_Click;
                }
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

            // Draw clean lines instantly
            flowOrder.ResumeLayout(true);
        }

        private void OrderLine_Click(object? sender, EventArgs e)
        {
            Control? clicked = sender as Control;
            Panel? row = clicked as Panel ?? clicked?.Parent as Panel;

            if (row?.Tag is int itemId)
            {
                currentOrder.RemoveOne(itemId);
                RefreshOrder();
            }
        }

        private static void EnableDoubleBuffering(Control control)
        {
            System.Reflection.PropertyInfo? property = typeof(Control).GetProperty(
                "DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            property?.SetValue(control, true, null);
        }

        private void lblEmpty_Click(object sender, EventArgs e)
        {
        }

        //Fixes the first load flickering using double buffering 
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // Turns on WS_EX_COMPOSITED
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
    }


}
