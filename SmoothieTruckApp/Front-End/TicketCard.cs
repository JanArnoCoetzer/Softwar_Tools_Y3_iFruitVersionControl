using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmoothieTruckApp.Front_End
{
    public partial class TicketCard : UserControl
    {
        private const int CollapsedHeight = 58;
        private const int LineHeight = 26;       

        private readonly List<(string Name, int Qty)> lines = new();

        public bool IsExpanded { get; private set; }
        public string TicketNo { get; private set; } = "";
        public int Minutes { get; private set; }

        public string ItemsSummary => string.Join(", ",
            lines.Select(l => l.Qty > 1 ? $"{l.Name} ×{l.Qty}" : l.Name));

        public event EventHandler? CompleteClicked;

        public TicketCard()
        {
            InitializeComponent();
            btnChevron.Text = "";                  
            HookToggle(pnlTicketHeader);                
            btnComplete.Click += (s, e) => CompleteClicked?.Invoke(this, EventArgs.Empty);
            Resize += (s, e) => FitLines();
        }

        public void SetTicket(string ticketNo, int minutes, int blendCount)
        {
            TicketNo = ticketNo;

            lblTicketNo.Text = ticketNo;
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

        public void Toggle() => SetExpanded(!IsExpanded);

        public void SetExpanded(bool expanded)
        {
            IsExpanded = expanded;
            btnChevron.Text = expanded ? "" : "";
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
