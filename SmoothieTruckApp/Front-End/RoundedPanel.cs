using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SmoothieTruckApp
{
    public class RoundedPanel : Panel
    {
        private int _radius = 60;
        private bool _isCircle = false;
        private Color _fill = Color.White;
        private Color _borderColor = Color.FromArgb(229, 231, 235);
        private int _borderSize = 1;
        private bool _dashed;
        private bool _useGradient;
        private Color _gradStart = Color.FromArgb(124, 58, 237);
        private Color _gradEnd = Color.FromArgb(6, 182, 212);
        private int _shadowSize;

        // Gradient tuning fields
        private float _gradAngle = 45f;
        private float _gradHardness = 0.0f; // 0.0 (smooth blend) to 1.0 (razor hard-cut)
        private float _gradPosition = 0.5f; // 0.0 (start) to 1.0 (end)

        [Category("Rounded")]
        [Description("Forces the control to render as a perfect circle, ignoring the manual CornerRadius value.")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsCircle
        {
            get => _isCircle;
            set { _isCircle = value; Invalidate(); }
        }

        [Category("Rounded")]
        [Description("The rounding radius applied to the corners of the panel card.")]
        [DefaultValue(60)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadius
        {
            get => _radius;
            set { _radius = Math.Max(0, value); Invalidate(); }
        }

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

        [Category("Rounded")]
        [Description("The angle/direction of the linear gradient in degrees.")]
        [DefaultValue(45f)]
        public float GradientAngle
        {
            get => _gradAngle;
            set { _gradAngle = value; Invalidate(); }
        }

        [Category("Rounded")]
        [Description("How sharp the transition is. 0.0 is a completely smooth blend, 1.0 is a crisp, hard-cut line.")]
        [DefaultValue(0.0f)]
        public float GradientHardness
        {
            get => _gradHardness;
            set { _gradHardness = Math.Max(0f, Math.Min(1f, value)); Invalidate(); }
        }

        [Category("Rounded")]
        [Description("The center location of the transition point relative to the card size (0.0 to 1.0).")]
        [DefaultValue(0.5f)]
        public float GradientPosition
        {
            get => _gradPosition;
            set { _gradPosition = Math.Max(0f, Math.Min(1f, value)); Invalidate(); }
        }

        [Category("Rounded"), DefaultValue(0)]
        public int ShadowSize { get => _shadowSize; set { _shadowSize = Math.Max(0, value); Invalidate(); } }

        public RoundedPanel()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Do not call base.OnPaint(e) when using custom transparency styles 
            // to avoid rendering flickering or solid artifacts behind the layout.
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float half = _borderSize / 2f;
            var card = new RectangleF(_shadowSize + half, _shadowSize + half,
                                      Width - 2 * _shadowSize - _borderSize,
                                      Height - 2 * _shadowSize - _borderSize);
            if (card.Width <= 0 || card.Height <= 0) return;

            int operationalRadius = _isCircle
                ? (int)(Math.Min(card.Width, card.Height) / 2f)
                : _radius;

            // 1. Smooth Path-Based Glow Shadow 
            if (_shadowSize > 0)
            {
                using (var shadowPath = RoundedRect(card, operationalRadius))
                {
                    using (var pgb = new PathGradientBrush(shadowPath))
                    {
                        pgb.CenterColor = Color.FromArgb(45, 40, 30, 80);
                        pgb.SurroundColors = new[] { Color.Transparent };
                        pgb.FocusScales = new PointF(0.9f, 0.9f);

                        var shadowBounds = card;
                        shadowBounds.Inflate(_shadowSize, _shadowSize);
                        g.FillRectangle(pgb, shadowBounds);
                    }
                }
            }

            // 2. Card Interior Background Painting
            using var path = RoundedRect(card, operationalRadius);

            if (_useGradient)
            {
                using (var gb = new LinearGradientBrush(card, _gradStart, _gradEnd, _gradAngle))
                {
                    // Compute multi-stop interpolation boundaries from hardness & position
                    float blendDistance = (1.0f - _gradHardness) * 0.5f;
                    float stop1 = Math.Max(0.0f, _gradPosition - blendDistance);
                    float stop2 = Math.Min(1.0f, _gradPosition + blendDistance);

                    // Map color arrays across structural positions
                    var colorBlend = new ColorBlend(4)
                    {
                        Colors = new[] { _gradStart, _gradStart, _gradEnd, _gradEnd },
                        Positions = new[] { 0.0f, stop1, stop2, 1.0f }
                    };

                    gb.InterpolationColors = colorBlend;
                    g.FillPath(gb, path);
                }
            }
            else
            {
                using var fill = new SolidBrush(_fill);
                g.FillPath(fill, path);
            }

            // 3. Card Border Line Painting
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
            if (d <= 0) d = 1f;

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
