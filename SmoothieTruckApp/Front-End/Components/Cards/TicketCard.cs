using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        public DateTime? OrderedAt { get; private set; }
        private readonly System.Windows.Forms.Timer elapsedTimer = new()
        {
            Interval = 1_000
        };

        public string ItemsSummary => string.Join(", ",
            lines.Select(l => l.Qty > 1
                ? $"{l.Name} ×{l.Qty}"
                : l.Name));

        public event EventHandler? CompleteClicked;

        public TicketCard()
        {
            InitializeComponent();

            btnChevron.Text = "\uE70D";

            HookToggle(pnlTicketHeader);

            btnComplete.Click += (s, e) =>
                CompleteClicked?.Invoke(this, EventArgs.Empty);

            Resize += (s, e) => FitLines();

            elapsedTimer.Tick += (s, e) => UpdateTimerText();

            Disposed += (s, e) => elapsedTimer.Dispose();

            UpdateTimerText();
            UpdateHeight();
        }

        public void SetTicket(
                                string ticketNo,
                                int minutes,
                                int blendCount,
                                DateTime? orderedAt = null)
        {
            TicketNo = ticketNo;

            lblTicketNo.Text = ticketNo;
            lblBlendCount.Text =
                $"{blendCount} blend{(blendCount == 1 ? "" : "s")}";

            // Keep the queue estimate separate from elapsed waiting time.
            SetWaitMinutes(minutes);
            SetOrderedTime(orderedAt);
        }

        public void SetOrderedTime(DateTime? orderedAt)
        {
            OrderedAt = orderedAt;

            elapsedTimer.Stop();
            UpdateTimerText();

            if (OrderedAt.HasValue)
            {
                elapsedTimer.Start();
            }
        }

        public void AddLine(string name, int quantity)
        {
            lines.Add((name, quantity));

            var line = new TicketLine
            {
                Margin = new Padding(0, 0, 0, 2)
            };

            line.SetLine(name, quantity);
            flowItems.Controls.Add(line);

            FitLines();
            UpdateHeight();
        }

        public void SetWaitMinutes(int minutes)
        {
            Minutes = minutes;

            Color back;
            Color fore;

            if (minutes <= 4)
            {
                back = Color.FromArgb(220, 252, 231);
                fore = Color.FromArgb(22, 163, 74);
            }
            else if (minutes <= 8)
            {
                back = Color.FromArgb(254, 243, 205);
                fore = Color.FromArgb(161, 98, 7);
            }
            else
            {
                back = Color.FromArgb(254, 226, 226);
                fore = Color.FromArgb(220, 38, 38);
            }

            pnlTimer.FillColor = back;
            lblTimer.ForeColor = fore;

            UpdateTimerText();
        }

        private void UpdateTimerText()
        {
            if (!OrderedAt.HasValue)
            {
                lblTimer.Text = "Unknown";
                pnlTimer.FillColor = Color.FromArgb(243, 244, 246);
                lblTimer.ForeColor = Color.DimGray;
                return;
            }

            TimeSpan elapsed = DateTime.UtcNow - OrderedAt.Value.ToUniversalTime();

            if (elapsed < TimeSpan.Zero)
            {
                elapsed = TimeSpan.Zero;
            }

            int totalMinutes = (int)elapsed.TotalMinutes;

            lblTimer.Text = $"● {totalMinutes}:{elapsed.Seconds:00}";

            if (totalMinutes <= 4)
            {
                pnlTimer.FillColor = Color.FromArgb(220, 252, 231);
                lblTimer.ForeColor = Color.FromArgb(22, 163, 74);
            }
            else if (totalMinutes <= 8)
            {
                pnlTimer.FillColor = Color.FromArgb(254, 243, 205);
                lblTimer.ForeColor = Color.FromArgb(161, 98, 7);
            }
            else
            {
                pnlTimer.FillColor = Color.FromArgb(254, 226, 226);
                lblTimer.ForeColor = Color.FromArgb(220, 38, 38);
            }
        }



        public void Toggle()
        {
            SetExpanded(!IsExpanded);
        }

        public void SetExpanded(bool expanded)
        {
            IsExpanded = expanded;
            btnChevron.Text = expanded ? "\uE70E" : "\uE70D";

            UpdateHeight();
        }

        private void HookToggle(Control root)
        {
            root.Click += (s, e) => Toggle();

            foreach (Control control in root.Controls)
            {
                HookToggle(control);
            }
        }

        private void UpdateHeight()
        {
            flowItems.Height =
                flowItems.Padding.Vertical +
                flowItems.Controls.Count * LineHeight;

            Height = IsExpanded
                ? CollapsedHeight +
                  pnlBodyLine.Height +
                  flowItems.Height +
                  pnlComplete.Height
                : CollapsedHeight;
        }

        private void FitLines()
        {
            int width = Math.Max(
                0,
                flowItems.ClientSize.Width -
                flowItems.Padding.Horizontal);

            foreach (Control control in flowItems.Controls)
            {
                control.Width = width;
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            // Completion is raised by the constructor's event subscription.
        }
    }
}