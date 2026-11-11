using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.Models;
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
            AddSampleData();      // TEMPORARY - delete this line once real tickets come from the database
        }

        public TicketCard AddTicket(string ticketNo, string orderType, int minutes,
                                    params (string Name, int Qty)[] items)
        {
            var card = new TicketCard { Margin = new Padding(0, 0, 0, 10) };
            card.SetTicket(ticketNo, orderType, minutes, items.Sum(i => i.Qty));
            foreach (var item in items) card.AddLine(item.Name, item.Qty);
            card.CompleteClicked += (s, e) => MarkComplete(card);

            flowInProgress.Controls.Add(card);
            FitCards(flowInProgress);
            UpdateCounts();
            return card;
        }

        public void AddCompleted(string ticketNo, string orderType, string itemsSummary,
                                 DateTime completedAt, int waitMinutes)
        {
            var done = new CompletedCard { Margin = new Padding(0, 0, 0, 10) };
            done.SetCompleted(ticketNo, orderType, itemsSummary, completedAt, waitMinutes);

            flowCompleted.Controls.Add(done);
            flowCompleted.Controls.SetChildIndex(done, 0);
            FitCards(flowCompleted);
            UpdateCounts();
        }

        private void MarkComplete(TicketCard card)
        {
            BeginInvoke(new Action(() =>
            {
                AddCompleted(card.TicketNo, card.OrderType, card.ItemsSummary, DateTime.Now, card.Minutes);
                flowInProgress.Controls.Remove(card);
                card.Dispose();
                UpdateCounts();
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

        private void AddSampleData()
        {
            AddTicket("Ticket 41", "Walk-up", 2, ("Tropical Sunrise", 1), ("Berry Blast", 1));
            AddTicket("Ticket 42", "Pre-order", 6, ("Green Machine", 1), ("Mango Tango", 1));
            AddTicket("Ticket 43", "Walk-up", 11, ("Berry Blast", 1));

            AddCompleted("Ticket 37", "Walk-up", "Green Machine, Tropical Sunrise, Berry Blast ×2", At(12, 29), 33);
            AddCompleted("Ticket 38", "Walk-up", "Mango Tango ×2, Berry Blast", At(12, 37), 25);
            AddCompleted("Ticket 39", "Pre-order", "Tropical Sunrise ×2, Green Machine", At(12, 44), 19);
        }

        private static DateTime At(int hour, int minute) => DateTime.Today.AddHours(hour).AddMinutes(minute);

        private void lblInProgress_Click(object sender, EventArgs e)
        {

        }

        private void OrdersPage_Load(object sender, EventArgs e)
        {

        }
    }

}