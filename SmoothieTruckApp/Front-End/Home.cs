using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices; // Critical for native UI rendering calls
using System.Text;
using System.Windows.Forms;

namespace SmoothieTruckApp.Front_End
{
    public partial class Home : Form
    {
        private readonly HomePage homePage = new();
        private readonly MenuPage menuPage = new();
        private readonly OrdersPage ordersPage = new();
        private Button? activeButton;
        private bool isFullScreen = false;
        private Rectangle previousBounds;
        private FormBorderStyle previousBorderStyle;
        private FormWindowState previousWindowState;

        // --- NATIVE WINDOWS API HOOKS FOR ROUNDING & SHADOWS ---
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        private const int CS_DROPSHADOW = 0x00020000;

        // Injects a smooth window drop shadow profile underneath the custom frame
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public Home()
        {
            InitializeComponent();

            // 1. Strip the ugly standard Windows title bar away
            this.FormBorderStyle = FormBorderStyle.None;

            // 2. Lock application startup dimensions safely
            this.StartPosition = FormStartPosition.CenterScreen;

            // 3. Trigger initial layout corner clip parameters
            ApplyWindowRounding();

            NavButton_Click(btnHome, EventArgs.Empty);

            // Hook up window dragging to your top header panel or logo area
            this.MouseDown += Window_MouseDown;
            // Tip: Inside the designer, bind the MouseDown event of your Top Header Panel/Logo to "Window_MouseDown" as well!
        }

        // Recalculates and masks the borders to stay perfectly round during sizing actions
        private void ApplyWindowRounding()
        {
            // Changes 30, 30 to configure the curvature tightness (higher numbers = more round)
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ApplyWindowRounding();
            UpdateAccentPosition();
        }

        // Drags your custom form workspace across your monitor safely using native handles
        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void lblClock_Click(object sender, EventArgs e) { }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("h:mm tt");
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void ShowPage(UserControl page)
        {
            pnlContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(page);
        }

        private Image GetIcon(Button b, bool coloured)
        {
            if (b == btnHome) return coloured ? Properties.Resources.Home_Hover : Properties.Resources.Home_Icon;
            if (b == btnMenu) return coloured ? Properties.Resources.Menu_Hover : Properties.Resources.Menu_Icon;
            return coloured ? Properties.Resources.Order_Hover : Properties.Resources.Order_Icon;
        }

        private void NavButton_Click(object sender, EventArgs e)
        {
            activeButton = (Button)sender;

            foreach (var b in new[] { btnHome, btnMenu, btnOrders })
            {
                bool isActive = b == activeButton;

                b.Image = GetIcon(b, isActive);
                b.BackColor = isActive ? Color.FromArgb(28, 22, 48) : Color.FromArgb(13, 15, 20);
                b.ForeColor = isActive ? Color.FromArgb(167, 139, 250) : Color.FromArgb(150, 154, 175);
            }

            UpdateAccentPosition();

            if (activeButton == btnHome) ShowPage(homePage);
            else if (activeButton == btnMenu) ShowPage(menuPage);
            else ShowPage(ordersPage);
        }

        private void UpdateAccentPosition()
        {
            if (activeButton == null)
                return;

            // Get the selected button's position on the screen
            Point buttonPosition = activeButton.Parent.PointToScreen(activeButton.Location);

            // Convert that position to the accent panel's parent coordinates
            Point accentPosition = pnlAccent.Parent.PointToClient(buttonPosition);

            // Centre the accent beside the selected button
            pnlAccent.Top = accentPosition.Y +
                (activeButton.Height - pnlAccent.Height) / 2;
        }


        private void NavButton_MouseEnter(object sender, EventArgs e)
        {
            var b = (Button)sender;
            b.Image = GetIcon(b, true);
        }

        private void NavButton_MouseLeave(object sender, EventArgs e)
        {
            var b = (Button)sender;
            b.Image = GetIcon(b, b == activeButton);
        }

        private void Logo_Click(object sender, EventArgs e) { }
        private void lblBrand_Click(object sender, EventArgs e) { }
        private void pnlContent_Paint(object sender, PaintEventArgs e) { }
        private void panel1_Paint_1(object sender, PaintEventArgs e) { }

        private void lblAdmin_Click(object sender, EventArgs e)
        {
            ctxUser.Show(lblAdmin, new Point(lblAdmin.Width, lblAdmin.Height + 4),
               ToolStripDropDownDirection.BelowLeft);
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Close iBlendit?", "Exit", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void mnuFullScreen_Click(object sender, EventArgs e)
        {
            if (!isFullScreen)
            {
                // Save the current window settings
                previousBounds = this.Bounds;
                previousBorderStyle = this.FormBorderStyle;
                previousWindowState = this.WindowState;

                // Switch to fullscreen
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Normal;
                this.Bounds = Screen.FromControl(this).Bounds;

                isFullScreen = true;
            }
            else
            {
                // Restore the previous window settings
                this.WindowState = FormWindowState.Normal;
                this.Bounds = previousBounds;
                this.FormBorderStyle = previousBorderStyle;
                this.WindowState = previousWindowState;

                isFullScreen = false;
            }
        }
    }
}
