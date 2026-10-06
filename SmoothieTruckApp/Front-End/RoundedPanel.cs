using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace SmoothieTruckApp
{
    public class RoundedPanel : Panel
    {
        int _radius = 20;
        Color _fill = Color.White;
        Color _borderColor = Color.FromArgb(229, 231, 235);
        int _borderSize = 1;
        bool _dashed;
        bool _useGradient;
        Color _gradStart = Color.FromArgb(124, 58, 237);
        Color _gradEnd = Color.FromArgb(6, 182, 212);
        int _shadowSize;

        [Category("Rounded"), DefaultValue(20)]
        public int CornerRadius { get => _radius; set { _radius = value; Invalidate(); } }

        [Category("Rounded"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color FillColor { get => _fill; set { _fill = value; Invalidate(); } }

        [Category("Rounded"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor { get => _borderColor; set { _borderColor = value; Invalidate(); } }

        [Category("Rounded"), DefaultValue(1)]
        public int BorderSize { get => _borderSize; set { _borderSize = value; Invalidate(); } }

        [Category("Rounded"), DefaultValue(false)]
        public bool Dashed { get => _dashed; set { _dashed = value; Invalidate(); } }

        [Category("Rounded"), DefaultValue(false)]
        public bool UseGradient { get => _useGradient; set { _useGradient = value; Invalidate(); } }

        [Category("Rounded"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color GradientStart { get => _gradStart; set { _gradStart = value; Invalidate(); } }

        [Category("Rounded"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color GradientEnd { get => _gradEnd; set { _gradEnd = value; Invalidate(); } }

        // Margin reserved around the card for the shadow. 0 = no shadow.
        [Category("Rounded"), DefaultValue(0)]
        public int ShadowSize { get => _shadowSize; set { _shadowSize = Math.Max(0, value); Invalidate(); } }

        public RoundedPanel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float half = _borderSize / 2f;
            var card = new RectangleF(_shadowSize + half, _shadowSize + half,
                                      Width - 2 * _shadowSize - _borderSize,
                                      Height - 2 * _shadowSize - _borderSize);
            if (card.Width <= 0 || card.Height <= 0) return;

            // Soft shadow: stacked, faint rounded rectangles that grow outwards
            if (_shadowSize > 0)
            {
                int offset = Math.Max(1, _shadowSize / 4);      // pushes the shadow slightly downwards
                int layers = Math.Max(1, _shadowSize - offset);
                int alpha = Math.Max(1, 70 / layers);
                using var shadowBrush = new SolidBrush(Color.FromArgb(alpha, 40, 30, 80));
                for (int i = layers; i >= 1; i--)
                {
                    var r = new RectangleF(card.X - i, card.Y - i + offset, card.Width + 2 * i, card.Height + 2 * i);
                    using var sp = RoundedRect(r, _radius + i);
                    g.FillPath(shadowBrush, sp);
                }
            }

            using var path = RoundedRect(card, _radius);

            if (_useGradient)
            {
                using var gb = new LinearGradientBrush(card, _gradStart, _gradEnd, 45f);
                g.FillPath(gb, path);
            }
            else
            {
                using var fill = new SolidBrush(_fill);
                g.FillPath(fill, path);
            }

            if (_borderSize > 0)
            {
                using var pen = new Pen(_borderColor, _borderSize);
                if (_dashed) pen.DashStyle = DashStyle.Dash;
                g.DrawPath(pen, path);
            }
        }

        static GraphicsPath RoundedRect(RectangleF r, int radius)
        {
            float d = Math.Min(radius * 2, Math.Min(r.Width, r.Height));
            var p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }
    }
}