using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmoothieTruckApp.Front_End
{
    // One finished ticket in the Completed column.
    //
    // Controls this code expects (names matter):
    //   lblCheck, lblDoneTicket, lblDoneItems, lblDoneTime, lblDoneWait
    public partial class CompletedCard : UserControl
    {
        public CompletedCard()
        {
            InitializeComponent();
            lblCheck.Text = "\uE73E"; 
        }

        public void SetCompleted(string ticketNo, string itemsSummary,
                                 DateTime? completedAt, int? waitMinutes)
        {
            lblDoneTicket.Text = ticketNo;
            lblDoneItems.Text = itemsSummary;
            lblDoneTime.Text = completedAt?.ToString("h:mm tt") ?? "Time unknown";
            lblDoneWait.Text = waitMinutes.HasValue
                ? $"{waitMinutes.Value} min wait"
                : "Wait unknown";
        }
    }
}