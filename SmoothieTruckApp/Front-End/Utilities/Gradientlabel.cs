using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace SmoothieTruckApp
{
    public class GradientLabel : Control
    {
        Color _start = Color.FromArgb(124, 58, 237);   // purple
        Color _end = Color.FromArgb(14, 165, 233);     // blue
        Color _firstLetterColor = Color.FromArgb(148, 147, 165); // Slate grey default
        bool _useFirstLetterColor = false;

        [Category("Gradient"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color GradientStart { get => _start; set { _start = value; Invalidate(); } }

        [Category("Gradient"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color GradientEnd { get => _end; set { _end = value; Invalidate(); } }

        [Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The solid color used for the first letter of the text.")]
        public Color FirstLetterColor { get => _firstLetterColor; set { _firstLetterColor = value; Invalidate(); } }

        [Category("Appearance"), DefaultValue(false)]
        [Description("Enables or disables a different solid color for the first letter.")]
        public bool UseFirstLetterColor { get => _useFirstLetterColor; set { _useFirstLetterColor = value; FitToText(); Invalidate(); } }

        public GradientLabel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            Text = "iBlendit";
        }

        private StringFormat GetCenterLeftFormat()
        {
            return new StringFormat(StringFormat.GenericTypographic)
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
        }

        void FitToText()
        {
            if (string.IsNullOrEmpty(Text)) return;
            using var g = Graphics.FromHwnd(IntPtr.Zero);
            using var format = GetCenterLeftFormat();

            if (_useFirstLetterColor && Text.Length > 0)
            {
                // Measure both pieces to get total width accurately
                string firstLetter = Text.Substring(0, 1);
                string remainingText = Text.Substring(1);

                var s1 = g.MeasureString(firstLetter, Font, int.MaxValue, format);
                var s2 = g.MeasureString(remainingText, Font, int.MaxValue, format);

                // Add up widths (GenericTypographic handles kerning spacing tightly)
                float totalWidth = s1.Width + s2.Width;
                float maxHeight = Math.Max(s1.Height, s2.Height);

                Size = new Size((int)Math.Ceiling(totalWidth) + 6, (int)Math.Ceiling(maxHeight) + 4);
            }
            else
            {
                var s = g.MeasureString(Text, Font, int.MaxValue, format);
                Size = new Size((int)Math.Ceiling(s.Width) + 6, (int)Math.Ceiling(s.Height) + 4);
            }
        }

        protected override void OnTextChanged(EventArgs e) { base.OnTextChanged(e); FitToText(); Invalidate(); }
        protected override void OnFontChanged(EventArgs e) { base.OnFontChanged(e); FitToText(); Invalidate(); }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (string.IsNullOrEmpty(Text) || Width < 2 || Height < 2) return;

            var g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            using var format = GetCenterLeftFormat();

            float leftPadding = 3f;

            if (_useFirstLetterColor && Text.Length > 0)
            {
                string firstLetter = Text.Substring(0, 1);
                string remainingText = Text.Substring(1);

                // 1. Measure the exact spacing footprint of the first letter
                var firstLetterSize = g.MeasureString(firstLetter, Font, int.MaxValue, format);

                // 2. Render the first letter using its solid brush
                var firstBounds = new RectangleF(leftPadding, 0, firstLetterSize.Width, ClientRectangle.Height);
                using var solidBrush = new SolidBrush(_firstLetterColor);
                g.DrawString(firstLetter, Font, solidBrush, firstBounds, format);

                // 3. Render the rest of the text with your gradient brush
                if (!string.IsNullOrEmpty(remainingText))
                {
                    // Push the remaining text rightward by the exact measured width of the first letter
                    var remainingBounds = new RectangleF(leftPadding + firstLetterSize.Width, 0, ClientRectangle.Width - (leftPadding + firstLetterSize.Width), ClientRectangle.Height);
                    using var gradientBrush = new LinearGradientBrush(ClientRectangle, _start, _end, LinearGradientMode.Horizontal);
                    g.DrawString(remainingText, Font, gradientBrush, remainingBounds, format);
                }
            }
            else
            {
                // Fallback standard behavior: render whole text gradient
                var textBounds = new RectangleF(leftPadding, 0, ClientRectangle.Width - 6, ClientRectangle.Height);
                using var brush = new LinearGradientBrush(ClientRectangle, _start, _end, LinearGradientMode.Horizontal);
                g.DrawString(Text, Font, brush, textBounds, format);
            }
        }
    }
}
