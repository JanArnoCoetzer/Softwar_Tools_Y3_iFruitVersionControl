using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmoothieTruckApp.Front_End
{
    public partial class StatCard : UserControl
    {
        public StatCard()
        {
            InitializeComponent();
        }

        public void SetStat(string caption, string value, string subText, string delta = "")
        {
            lblStatCaption.Text = caption;
            lblStatValue.Text = value;
            lblStatSub.Text = subText;

            lblStatDelta.Text = delta;
            lblStatDelta.Visible = delta.Length > 0;
        }

 
        public void SetIcon(string glyph, Color fill, Color fore)
        {
            lblStatIcon.Text = glyph;
            lblStatIcon.ForeColor = fore;
            pnlStatIcon.FillColor = fill;
            pnlStatIcon.Invalidate();
        }

        public void SetHighlight(bool on)
        {
            pnlCard.UseGradient = on;
            pnlCard.GradientStart = Color.White;
            pnlCard.GradientEnd = Color.FromArgb(245, 240, 255);
            pnlCard.BorderColor = on ? Color.FromArgb(221, 214, 254) : Color.FromArgb(236, 238, 242);
            pnlCard.Invalidate();
        }
    }
}