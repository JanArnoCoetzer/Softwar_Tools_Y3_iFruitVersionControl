using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace SmoothieTruckApp
{
    public class GradientLabel : Control
    {
        Color _start = Color.FromArgb(124, 58, 237);   // purple
        Color _end = Color.FromArgb(14, 165, 233);     // blue

        [Category("Gradient"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color GradientStart { get => _start; set { _start = value; Invalidate(); } }

        [Category("Gradient"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color GradientEnd { get => _end; set { _end = value; Invalidate(); } }

        public GradientLabel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            Text = "iBlendit";
        }

        // Resize the control to fit the text whenever the text or font changes
        void FitToText()
        {
            if (string.IsNullOrEmpty(Text)) return;
            using var g = Graphics.FromHwnd(IntPtr.Zero);
            var s = g.MeasureString(Text, Font, int.MaxValue, StringFormat.GenericTypographic);
            Size = new Size((int)Math.Ceiling(s.Width) + 6, (int)Math.Ceiling(s.Height) + 4);
        }

        protected override void OnTextChanged(EventArgs e) { base.OnTextChanged(e); FitToText(); Invalidate(); }
        protected override void OnFontChanged(EventArgs e) { base.OnFontChanged(e); FitToText(); Invalidate(); }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (string.IsNullOrEmpty(Text) || Width < 2 || Height < 2) return;

            var g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            using var brush = new LinearGradientBrush(ClientRectangle, _start, _end, LinearGradientMode.Horizontal);
            g.DrawString(Text, Font, brush, new PointF(3, 2), StringFormat.GenericTypographic);
        }
    }
}