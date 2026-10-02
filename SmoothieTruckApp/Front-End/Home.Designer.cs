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
            TopPanel = new Panel();
            lblAdmin = new Label();
            pnlAvatar = new RoundedPanel();
            lblA = new Label();
            lblClock = new Label();
            lblBrand = new Label();
            ContentPanel = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            TopPanel.SuspendLayout();
            pnlAvatar.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(13, 15, 20);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(56, 541);
            panel1.TabIndex = 0;
            // 
            // TopPanel
            // 
            TopPanel.Controls.Add(lblAdmin);
            TopPanel.Controls.Add(pnlAvatar);
            TopPanel.Controls.Add(lblClock);
            TopPanel.Controls.Add(lblBrand);
            TopPanel.Dock = DockStyle.Top;
            TopPanel.Location = new Point(0, 0);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new Size(1039, 56);
            TopPanel.TabIndex = 1;
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
            // pnlAvatar
            // 
            pnlAvatar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlAvatar.BackColor = Color.Transparent;
            pnlAvatar.Controls.Add(lblA);
            pnlAvatar.CornerRadius = 14;
            pnlAvatar.Location = new Point(929, 12);
            pnlAvatar.Name = "pnlAvatar";
            pnlAvatar.Size = new Size(28, 28);
            pnlAvatar.TabIndex = 2;
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
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBrand.Location = new Point(56, 18);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(70, 21);
            lblBrand.TabIndex = 0;
            lblBrand.Text = "iBlendit";
            lblBrand.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ContentPanel
            // 
            ContentPanel.BackColor = Color.FromArgb(244, 245, 247);
            ContentPanel.Dock = DockStyle.Fill;
            ContentPanel.Location = new Point(56, 56);
            ContentPanel.Name = "ContentPanel";
            ContentPanel.Size = new Size(983, 541);
            ContentPanel.TabIndex = 2;
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
            Controls.Add(ContentPanel);
            Controls.Add(panel1);
            Controls.Add(TopPanel);
            Name = "Home";
            Text = "Home";
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            pnlAvatar.ResumeLayout(false);
            pnlAvatar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel TopPanel;
        private Panel ContentPanel;
        private Label lblBrand;
        private Label lblClock;
        private RoundedPanel pnlAvatar;
        private Label lblA;
        private Label lblAdmin;
        private System.Windows.Forms.Timer timer1;
    }
}