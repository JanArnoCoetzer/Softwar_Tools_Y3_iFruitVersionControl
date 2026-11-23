using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SmoothieTruckApp.Front_End
{
    public class LineChart : Control
    {
        private string[] labels = Array.Empty<string>();
        private double[] values = Array.Empty<double>();

        private static readonly Color LineStart = Color.FromArgb(124, 58, 237);
        private static readonly Color LineEnd = Color.FromArgb(6, 182, 212);

        public LineChart()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;
            Size = new Size(400, 190);
        }

        public void SetData(string[] newLabels, double[] newValues)
        {
            labels = newLabels ?? Array.Empty<string>();
            values = newValues ?? Array.Empty<double>();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            string[] lbl = labels;
            double[] val = values;

            if (val.Length == 0 && DesignMode)
            {
                lbl = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
                val = new[] { 800.0, 950.0, 900.0, 1100.0, 1300.0, 1500.0, 1090.0 };
            }

            int n = val.Length;
            if (n < 2 || Width < 60 || Height < 60) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            float left = 18, right = Width - 18;
            float top = 12, bottom = Height - 28;
            float plotW = right - left, plotH = bottom - top;

            double min = double.MaxValue, max = double.MinValue;
            foreach (double v in val) { min = Math.Min(min, v); max = Math.Max(max, v); }
            double range = max - min;
            if (range < 1e-9) range = 1;
            double lo = min - range * 0.5;
            double hi = max + range * 0.15;

            var pts = new PointF[n];
            for (int i = 0; i < n; i++)
            {
                float x = left + i * (plotW / (n - 1));
                float y = bottom - (float)((val[i] - lo) / (hi - lo)) * plotH;
                pts[i] = new PointF(x, y);
            }

            using (var grid = new Pen(Color.FromArgb(235, 237, 242), 1f) { DashStyle = DashStyle.Dash })
            {
                for (int i = 0; i <= 3; i++)
                {
                    float y = top + i * (plotH / 3f);
                    g.DrawLine(grid, left, y, right, y);
                }
            }

            using (var area = new GraphicsPath())
            {
                area.AddLines(pts);
                area.AddLine(pts[n - 1], new PointF(pts[n - 1].X, bottom));
                area.AddLine(new PointF(pts[n - 1].X, bottom), new PointF(pts[0].X, bottom));
                area.CloseFigure();

                using (var fill = new LinearGradientBrush(
                    new PointF(0, top), new PointF(0, bottom),
                    Color.FromArgb(70, 124, 58, 237), Color.FromArgb(10, 6, 182, 212)))
                {
                    g.FillPath(fill, area);
                }
            }

            using (var lineBrush = new LinearGradientBrush(
                new PointF(left, 0), new PointF(right, 0), LineStart, LineEnd))
            using (var linePen = new Pen(lineBrush, 2.5f) { LineJoin = LineJoin.Round })
            {
                g.DrawLines(linePen, pts);
            }

            using (var markerFill = new SolidBrush(Color.White))
            using (var markerPen = new Pen(LineStart, 2f))
            {
                foreach (PointF p in pts)
                {
                    g.FillEllipse(markerFill, p.X - 4, p.Y - 4, 8, 8);
                    g.DrawEllipse(markerPen, p.X - 4, p.Y - 4, 8, 8);
                }
            }

            using (var font = new Font("Segoe UI", 7f))
            using (var textBrush = new SolidBrush(Color.FromArgb(156, 163, 175)))
            using (var fmt = new StringFormat { Alignment = StringAlignment.Center })
            {
                for (int i = 0; i < n && i < lbl.Length; i++)
                    g.DrawString(lbl[i], font, textBrush, pts[i].X, bottom + 10, fmt);
            }
        }
    }
}