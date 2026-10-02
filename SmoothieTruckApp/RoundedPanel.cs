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

        [Category("Rounded"), DefaultValue(20)]
        public int CornerRadius { get => _radius; set { _radius = value; Invalidate(); } }

        [Category("Rounded")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color FillColor { get => _fill; set { _fill = value; Invalidate(); } }

        [Category("Rounded")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor { get => _borderColor; set { _borderColor = value; Invalidate(); } }

        [Category("Rounded"), DefaultValue(1)]
        public int BorderSize { get => _borderSize; set { _borderSize = value; Invalidate(); } }

        [Category("Rounded"), DefaultValue(false)]
        public bool Dashed { get => _dashed; set { _dashed = value; Invalidate(); } }

        public RoundedPanel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;   // lets the parent's colour show in the corners
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float half = _borderSize / 2f;
            var rect = new RectangleF(half, half, Width - _borderSize, Height - _borderSize);

            using var path = RoundedRect(rect, _radius);
            using var fill = new SolidBrush(_fill);
            g.FillPath(fill, path);

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