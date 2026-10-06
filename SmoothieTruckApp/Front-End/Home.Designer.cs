namespace SmoothieTruckApp.Front_End
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            roundedPanel3 = new RoundedPanel();
            pictureBox1 = new PictureBox();
            pnlAccent = new Panel();
            btnMenu = new Button();
            btnHome = new Button();
            btnOrders = new Button();
            TopPanel = new Panel();
            pnlAdmin = new RoundedPanel();
            lblAdminLtr = new Label();
            lblBrand = new GradientLabel();
            lblAdmin = new Label();
            lblClock = new Label();
            lblA = new Label();
            pnlContent = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            roundedPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            TopPanel.SuspendLayout();
            pnlAdmin.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(13, 15, 20);
            panel1.Controls.Add(roundedPanel3);
            panel1.Controls.Add(pnlAccent);
            panel1.Controls.Add(btnMenu);
            panel1.Controls.Add(btnHome);
            panel1.Controls.Add(btnOrders);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(56, 541);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // roundedPanel3
            // 
            roundedPanel3.BackColor = Color.Transparent;
            roundedPanel3.BorderColor = Color.FromArgb(229, 231, 235);
            roundedPanel3.BorderSize = 0;
            roundedPanel3.Controls.Add(pictureBox1);
            roundedPanel3.CornerRadius = 8;
            roundedPanel3.FillColor = Color.White;
            roundedPanel3.GradientEnd = Color.FromArgb(6, 182, 212);
            roundedPanel3.GradientStart = Color.FromArgb(124, 58, 237);
            roundedPanel3.Location = new Point(12, 20);
            roundedPanel3.Name = "roundedPanel3";
            roundedPanel3.Padding = new Padding(6, 4, 6, 4);
            roundedPanel3.Size = new Size(30, 30);
            roundedPanel3.TabIndex = 6;
            roundedPanel3.UseGradient = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.iblendfinal;
            pictureBox1.Location = new Point(6, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(18, 22);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pnlAccent
            // 
            pnlAccent.Anchor = AnchorStyles.Left;
            pnlAccent.BackColor = Color.Purple;
            pnlAccent.Location = new Point(12, 70);
            pnlAccent.Name = "pnlAccent";
            pnlAccent.Size = new Size(3, 32);
            pnlAccent.TabIndex = 1;
            // 
            // btnMenu
            // 
            btnMenu.Cursor = Cursors.Hand;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 22, 48);
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Segoe MDL2 Assets", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMenu.ForeColor = Color.FromArgb(150, 154, 175);
            btnMenu.Image = Properties.Resources.Menu_Icon;
            btnMenu.Location = new Point(12, 125);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(36, 36);
            btnMenu.TabIndex = 2;
            btnMenu.TextImageRelation = TextImageRelation.ImageAboveText;
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += NavButton_Click;
            btnMenu.MouseEnter += NavButton_MouseEnter;
            btnMenu.MouseLeave += NavButton_MouseLeave;
            // 
            // btnHome
            // 
            btnHome.Cursor = Cursors.Hand;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 22, 48);
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe MDL2 Assets", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.FromArgb(150, 154, 175);
            btnHome.Image = Properties.Resources.Home_Icon;
            btnHome.Location = new Point(12, 70);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(36, 36);
            btnHome.TabIndex = 0;
            btnHome.TextImageRelation = TextImageRelation.ImageAboveText;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += NavButton_Click;
            btnHome.MouseEnter += NavButton_MouseEnter;
            btnHome.MouseLeave += NavButton_MouseLeave;
            // 
            // btnOrders
            // 
            btnOrders.Cursor = Cursors.Hand;
            btnOrders.FlatAppearance.BorderSize = 0;
            btnOrders.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 22, 48);
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.Font = new Font("Segoe MDL2 Assets", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOrders.ForeColor = Color.FromArgb(150, 154, 175);
            btnOrders.Image = Properties.Resources.Order_Icon;
            btnOrders.Location = new Point(12, 177);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(36, 36);
            btnOrders.TabIndex = 3;
            btnOrders.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOrders.UseVisualStyleBackColor = true;
            btnOrders.Click += NavButton_Click;
            btnOrders.MouseEnter += NavButton_MouseEnter;
            btnOrders.MouseLeave += NavButton_MouseLeave;
            // 
            // TopPanel
            // 
            TopPanel.Controls.Add(pnlAdmin);
            TopPanel.Controls.Add(lblBrand);
            TopPanel.Controls.Add(lblAdmin);
            TopPanel.Controls.Add(lblClock);
            TopPanel.Dock = DockStyle.Top;
            TopPanel.Location = new Point(0, 0);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new Size(1039, 56);
            TopPanel.TabIndex = 1;
            // 
            // pnlAdmin
            // 
            pnlAdmin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlAdmin.BackColor = Color.Transparent;
            pnlAdmin.BorderColor = Color.FromArgb(229, 231, 235);
            pnlAdmin.Controls.Add(lblAdminLtr);
            pnlAdmin.CornerRadius = 14;
            pnlAdmin.FillColor = Color.White;
            pnlAdmin.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlAdmin.GradientStart = Color.FromArgb(124, 58, 237);
            pnlAdmin.Location = new Point(929, 14);
            pnlAdmin.Name = "pnlAdmin";
            pnlAdmin.Size = new Size(28, 28);
            pnlAdmin.TabIndex = 6;
            pnlAdmin.UseGradient = true;
            // 
            // lblAdminLtr
            // 
            lblAdminLtr.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAdminLtr.AutoSize = true;
            lblAdminLtr.ForeColor = Color.White;
            lblAdminLtr.Location = new Point(7, 6);
            lblAdminLtr.Name = "lblAdminLtr";
            lblAdminLtr.Size = new Size(15, 15);
            lblAdminLtr.TabIndex = 0;
            lblAdminLtr.Text = "A";
            // 
            // lblBrand
            // 
            lblBrand.BackColor = Color.Transparent;
            lblBrand.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblBrand.GradientEnd = Color.FromArgb(14, 165, 233);
            lblBrand.GradientStart = Color.FromArgb(124, 58, 237);
            lblBrand.Location = new Point(56, 14);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(65, 26);
            lblBrand.TabIndex = 5;
            lblBrand.Text = "iBlendit";
            lblBrand.Click += lblBrand_Click;
            // 
            // lblAdmin
            // 
            lblAdmin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAdmin.AutoSize = true;
            lblAdmin.Location = new Point(963, 19);
            lblAdmin.Name = "lblAdmin";
            lblAdmin.Size = new Size(43, 15);
            lblAdmin.TabIndex = 3;
            lblAdmin.Text = "Admin";
            // 
            // lblClock
            // 
            lblClock.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblClock.AutoSize = true;
            lblClock.Location = new Point(861, 19);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(37, 15);
            lblClock.TabIndex = 1;
            lblClock.Text = "Clock";
            lblClock.Click += lblClock_Click;
            // 
            // lblA
            // 
            lblA.AutoSize = true;
            lblA.ForeColor = Color.White;
            lblA.Location = new Point(7, 7);
            lblA.Name = "lblA";
            lblA.Size = new Size(15, 15);
            lblA.TabIndex = 0;
            lblA.Text = "A";
            lblA.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(244, 245, 247);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(56, 56);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(983, 541);
            pnlContent.TabIndex = 2;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 597);
            Controls.Add(pnlContent);
            Controls.Add(panel1);
            Controls.Add(TopPanel);
            Name = "Home";
            Text = "Home";
            panel1.ResumeLayout(false);
            roundedPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            pnlAdmin.ResumeLayout(false);
            pnlAdmin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel TopPanel;
        private Panel pnlContent;
        private Label lblClock;
        private RoundedPanel pnlAvatar;
        private Label lblA;
        private Label lblAdmin;
        private System.Windows.Forms.Timer timer1;
        private Button btnHome;
        private Panel pnlAccent;
        private Button btnMenu;
        private Button btnOrders;
        private RoundedPanel roundedPanel3;
        private PictureBox pictureBox1;
        private GradientLabel lblBrand;
        private RoundedPanel pnlAdmin;
        private Label lblAdminLtr;
    }
}