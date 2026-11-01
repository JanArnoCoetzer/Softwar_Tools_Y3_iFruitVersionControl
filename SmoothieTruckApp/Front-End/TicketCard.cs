using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmoothieTruckApp.Front_End
{
    // One in-progress ticket. Click anywhere on the header to expand/collapse the item list.
    //
    // Controls this code expects (names matter):
    //   pnlTicketHeader (Panel), pnlTimer (RoundedPanel), lblTimer, lblTicketNo, lblOrderType,
    //   lblPreorder, lblBlendCount, btnChevron (Button), pnlBodyLine (Panel),
    //   flowItems (FlowLayoutPanel), pnlComplete (Panel), btnComplete (Button)
    public partial class TicketCard : UserControl
    {
        private const int CollapsedHeight = 58;   // 52px card + 3px shadow margin top and bottom
        private const int LineHeight = 26;        // each TicketLine is 24 tall + 2px margin

        private readonly List<(string Name, int Qty)> lines = new();

        public bool IsExpanded { get; private set; }
        public string TicketNo { get; private set; } = "";
        public string OrderType { get; private set; } = "";
        public int Minutes { get; private set; }

        // "Tropical Sunrise, Berry Blast ×2" - used when the ticket moves to Completed
        public string ItemsSummary => string.Join(", ",
            lines.Select(l => l.Qty > 1 ? $"{l.Name} ×{l.Qty}" : l.Name));

        // Raised when "Blends Ready - Mark Complete" is clicked
        public event EventHandler? CompleteClicked;

        public TicketCard()
        {
            InitializeComponent();
            btnChevron.Text = "";                  // chevron down (Segoe MDL2 Assets)
            HookToggle(pnlTicketHeader);                 // header + everything on it toggles the dropdown
            btnComplete.Click += (s, e) => CompleteClicked?.Invoke(this, EventArgs.Empty);
            Resize += (s, e) => FitLines();
        }

        // ---- What your teammates call ------------------------------------------------------

        // orderType is "Walk-up" or "Pre-order" (pre-orders get the purple pill)
        public void SetTicket(string ticketNo, string orderType, int minutes, int blendCount)
        {
            TicketNo = ticketNo;
            OrderType = orderType;

            bool preOrder = orderType == "Pre-order";
            lblTicketNo.Text = ticketNo;
            lblOrderType.Text = preOrder ? "·" : "· " + orderType;
            lblPreorder.Visible = preOrder;
            lblBlendCount.Text = $"{blendCount} blend{(blendCount == 1 ? "" : "s")}";

            SetWaitMinutes(minutes);
        }

        public void AddLine(string name, int quantity)
        {
            lines.Add((name, quantity));

            var line = new TicketLine { Margin = new Padding(0, 0, 0, 2) };
            line.SetLine(name, quantity);
            flowItems.Controls.Add(line);

            FitLines();
            UpdateHeight();
        }

        // Green up to 4 min, amber 5-8, red over 8 (matches the legend on the page)
        public void SetWaitMinutes(int minutes)
        {
            Minutes = minutes;

            Color back, fore;
            if (minutes <= 4) { back = Color.FromArgb(220, 252, 231); fore = Color.FromArgb(22, 163, 74); }
            else if (minutes <= 8) { back = Color.FromArgb(254, 243, 205); fore = Color.FromArgb(161, 98, 7); }
            else { back = Color.FromArgb(254, 226, 226); fore = Color.FromArgb(220, 38, 38); }

            pnlTimer.FillColor = back;
            lblTimer.ForeColor = fore;
            lblTimer.Text = $"● {minutes} min";     // ● 2 min
        }

        // ---- Dropdown ----------------------------------------------------------------------

        public void Toggle() => SetExpanded(!IsExpanded);

        public void SetExpanded(bool expanded)
        {
            IsExpanded = expanded;
            btnChevron.Text = expanded ? "" : "";   // chevron up / down
            UpdateHeight();
        }

        // Makes the header and every control on it clickable
        private void HookToggle(Control root)
        {
            root.Click += (s, e) => Toggle();
            foreach (Control c in root.Controls) HookToggle(c);
        }

        private void UpdateHeight()
        {
            flowItems.Height = flowItems.Padding.Vertical + flowItems.Controls.Count * LineHeight;

            Height = IsExpanded
                ? CollapsedHeight + pnlBodyLine.Height + flowItems.Height + pnlComplete.Height
                : CollapsedHeight;
        }

        // Keeps the item rows as wide as the list
        private void FitLines()
        {
            int w = flowItems.ClientSize.Width - flowItems.Padding.Horizontal;
            foreach (Control c in flowItems.Controls) c.Width = w;
        }


        private void btnComplete_Click(object sender, EventArgs e)
        {

        }
    }
}
