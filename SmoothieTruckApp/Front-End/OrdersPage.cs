using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.Models;
using SmoothieTruckApp.Repositories;
using SmoothieTruckApp.Services;
using System.ComponentModel;

namespace SmoothieTruckApp.Front_End
{
    public partial class OrdersPage : UserControl
    {
        public OrdersPage()
        {
            InitializeComponent();

            // Cards stretch to the width of their column
            flowInProgress.ClientSizeChanged += (s, e) => FitCards(flowInProgress);
            flowCompleted.ClientSizeChanged += (s, e) => FitCards(flowCompleted);

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            lblStationSub.Text = $"Live order queue · {DateTime.Now:dddd, MMMM d}";
            //reloads each time the page is opened so new orders show up
            ParentChanged += (s, e) =>
            {
                if (Parent != null) LoadOrders();
            };
        }

        private void LoadOrders()
        {
            ClearCards(flowInProgress);
            ClearCards(flowCompleted);

            List<Order> orders = OrderRepository.GetAll();
            List<Order> queue = QueueService.GetInProgress(orders);
            Dictionary<int, int> waits = QueueService.CalculateWaitTimes(queue);

            foreach (Order order in queue)
            {
                TicketCard card = AddTicket($"Ticket {order.Id}", waits[order.Id],
                    order.Lines.Select(l => (l.Item.Name, l.Quantity)).ToArray());
                card.Tag = order.Id;
            }

            foreach (var done in QueueService.GetCompleted(orders))
            {
                AddCompleted($"Ticket {done.Order.Id}", ItemsSummary(done.Order), done.CompletedAt, done.WaitMinutes);
            }

            UpdateCounts();
        }

        private static void ClearCards(FlowLayoutPanel flow)
        {
            foreach (Control c in flow.Controls.Cast<Control>().ToList())
            {
                flow.Controls.Remove(c);
                c.Dispose();
            }
        }

        private static string ItemsSummary(Order order)
        {
            return string.Join(", ", order.Lines.Select(l => l.Quantity > 1 ? $"{l.Item.Name} ×{l.Quantity}" : l.Item.Name));
        }

        public TicketCard AddTicket(string ticketNo, int minutes,
                                    params (string Name, int Qty)[] items)
        {
            var card = new TicketCard { Margin = new Padding(0, 0, 0, 10) };
            card.SetTicket(ticketNo, minutes, items.Sum(i => i.Qty));
            foreach (var item in items) card.AddLine(item.Name, item.Qty);
            card.CompleteClicked += (s, e) => MarkComplete(card);

            flowInProgress.Controls.Add(card);
            FitCards(flowInProgress);
            UpdateCounts();
            return card;
        }

        public void AddCompleted(string ticketNo, string itemsSummary,
                                 DateTime completedAt, int waitMinutes)
        {
            var done = new CompletedCard { Margin = new Padding(0, 0, 0, 10) };
            done.SetCompleted(ticketNo, itemsSummary, completedAt, waitMinutes);

            flowCompleted.Controls.Add(done);
            flowCompleted.Controls.SetChildIndex(done, 0);
            FitCards(flowCompleted);
            UpdateCounts();
        }

        private void MarkComplete(TicketCard card)
        {
            BeginInvoke(new Action(() =>
            {
                if (card.Tag is int orderId)
                {
                    QueueService.Complete(orderId, card.Minutes);
                }

                LoadOrders();
            }));
        }

        private void UpdateCounts()
        {
            lblInProgressCount.Text = flowInProgress.Controls.Count.ToString();
            lblCompletedCount.Text = flowCompleted.Controls.Count.ToString();
        }

        private static void FitCards(FlowLayoutPanel flow)
        {
            foreach (Control c in flow.Controls)
                c.Width = flow.ClientSize.Width - c.Margin.Horizontal;
        }

        private void lblInProgress_Click(object sender, EventArgs e)
        {

        }

        private void OrdersPage_Load(object sender, EventArgs e)
        {

        }
    }

}