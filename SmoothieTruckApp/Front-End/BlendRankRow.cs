using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SmoothieTruckApp.Front_End
{
    public partial class BlendRankRow : UserControl
    {
        private double percent = 100;

        public BlendRankRow()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            pnlBarTrack.Resize += (s, e) => ApplyBar();
        }

        public void SetBlend(int rank, string name, int unitsSold, decimal revenue,
                             double percentOfTop, Color barColor)
        {
            lblRank.Text = rank.ToString();
            lblBlendName.Text = name;
            lblBlendSold.Text = $"{unitsSold} sold";
            lblRevenue.Text = $"${revenue:N2}";

            pnlBarFill.FillColor = barColor;
            percent = Math.Max(0, Math.Min(100, percentOfTop));
            ApplyBar();
        }

        private void ApplyBar()
        {
            pnlBarFill.Width = (int)Math.Round(pnlBarTrack.Width * percent / 100.0);
            pnlBarFill.Visible = pnlBarFill.Width > 0;
            pnlBarFill.Invalidate();
        }
    }
}