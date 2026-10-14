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
            lblA = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            tableLayoutPanel2 = new TableLayoutPanel();
            pnlContent = new Panel();
            panel1 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            roundedPanel3 = new RoundedPanel();
            pictureBox1 = new PictureBox();
            btnHome = new Button();
            btnMenu = new Button();
            pnlAccent = new Panel();
            btnOrders = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblAdmin = new Label();
            lblBrand = new GradientLabel();
            lblClock = new Label();
            pnlAdmin = new RoundedPanel();
            label1 = new Label();
            lblAdminLtr = new Label();
            roundedPanel1 = new RoundedPanel();
            roundedPanel2 = new RoundedPanel();
            label2 = new Label();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            roundedPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            pnlAdmin.SuspendLayout();
            roundedPanel2.SuspendLayout();
            SuspendLayout();
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
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.White;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(pnlContent, 1, 1);
            tableLayoutPanel2.Controls.Add(panel1, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1872, 1204);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(244, 245, 247);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(80, 60);
            pnlContent.Margin = new Padding(0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1792, 1144);
            pnlContent.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(13, 15, 20);
            panel1.Controls.Add(tableLayoutPanel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 60);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(80, 1144);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint_1;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.FromArgb(13, 15, 20);
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(roundedPanel3, 0, 0);
            tableLayoutPanel3.Controls.Add(btnHome, 0, 1);
            tableLayoutPanel3.Controls.Add(btnMenu, 0, 2);
            tableLayoutPanel3.Controls.Add(pnlAccent, 0, 4);
            tableLayoutPanel3.Controls.Add(btnOrders, 0, 3);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 6;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(80, 1144);
            tableLayoutPanel3.TabIndex = 0;
            tableLayoutPanel3.Click += lblBrand_Click;
            // 
            // roundedPanel3
            // 
            roundedPanel3.BackColor = Color.Transparent;
            roundedPanel3.BorderColor = Color.FromArgb(229, 231, 235);
            roundedPanel3.BorderSize = 0;
            roundedPanel3.Controls.Add(pictureBox1);
            roundedPanel3.CornerRadius = 8;
            roundedPanel3.Dock = DockStyle.Fill;
            roundedPanel3.FillColor = Color.White;
            roundedPanel3.GradientEnd = Color.FromArgb(29, 182, 216);
            roundedPanel3.GradientStart = Color.FromArgb(130, 84, 237);
            roundedPanel3.Location = new Point(4, 5);
            roundedPanel3.Margin = new Padding(4, 5, 4, 5);
            roundedPanel3.Name = "roundedPanel3";
            roundedPanel3.Padding = new Padding(9, 7, 9, 7);
            roundedPanel3.Size = new Size(72, 70);
            roundedPanel3.TabIndex = 6;
            roundedPanel3.UseGradient = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.iblendfinal;
            pictureBox1.Location = new Point(9, 7);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(54, 56);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnHome
            // 
            btnHome.Cursor = Cursors.Hand;
            btnHome.Dock = DockStyle.Fill;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 22, 48);
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe MDL2 Assets", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.FromArgb(150, 154, 175);
            btnHome.Image = Properties.Resources.Home_Icon;
            btnHome.Location = new Point(4, 85);
            btnHome.Margin = new Padding(4, 5, 4, 5);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(72, 70);
            btnHome.TabIndex = 0;
            btnHome.TextImageRelation = TextImageRelation.ImageAboveText;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += NavButton_Click;
            btnHome.MouseEnter += NavButton_MouseEnter;
            btnHome.MouseLeave += NavButton_MouseLeave;
            // 
            // btnMenu
            // 
            btnMenu.Cursor = Cursors.Hand;
            btnMenu.Dock = DockStyle.Fill;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 22, 48);
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Segoe MDL2 Assets", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMenu.ForeColor = Color.FromArgb(150, 154, 175);
            btnMenu.Image = Properties.Resources.Menu_Icon;
            btnMenu.Location = new Point(4, 165);
            btnMenu.Margin = new Padding(4, 5, 4, 5);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(72, 70);
            btnMenu.TabIndex = 2;
            btnMenu.TextImageRelation = TextImageRelation.ImageAboveText;
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += NavButton_Click;
            btnMenu.MouseEnter += NavButton_MouseEnter;
            btnMenu.MouseLeave += NavButton_MouseLeave;
            // 
            // pnlAccent
            // 
            pnlAccent.Anchor = AnchorStyles.Left;
            pnlAccent.BackColor = Color.Purple;
            pnlAccent.Location = new Point(4, 335);
            pnlAccent.Margin = new Padding(4, 5, 4, 5);
            pnlAccent.Name = "pnlAccent";
            pnlAccent.Size = new Size(4, 50);
            pnlAccent.TabIndex = 1;
            // 
            // btnOrders
            // 
            btnOrders.Cursor = Cursors.Hand;
            btnOrders.Dock = DockStyle.Fill;
            btnOrders.FlatAppearance.BorderSize = 0;
            btnOrders.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 22, 48);
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.Font = new Font("Segoe MDL2 Assets", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOrders.ForeColor = Color.FromArgb(150, 154, 175);
            btnOrders.Image = Properties.Resources.Order_Icon;
            btnOrders.Location = new Point(4, 245);
            btnOrders.Margin = new Padding(4, 5, 4, 5);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(72, 70);
            btnOrders.TabIndex = 3;
            btnOrders.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOrders.UseVisualStyleBackColor = true;
            btnOrders.Click += NavButton_Click;
            btnOrders.MouseEnter += NavButton_MouseEnter;
            btnOrders.MouseLeave += NavButton_MouseLeave;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 48F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 178F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 3F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 62F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.Controls.Add(lblAdmin, 6, 0);
            tableLayoutPanel1.Controls.Add(lblBrand, 0, 0);
            tableLayoutPanel1.Controls.Add(lblClock, 3, 0);
            tableLayoutPanel1.Controls.Add(pnlAdmin, 5, 0);
            tableLayoutPanel1.Controls.Add(roundedPanel1, 4, 0);
            tableLayoutPanel1.Controls.Add(roundedPanel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(80, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1792, 60);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // lblAdmin
            // 
            lblAdmin.AutoSize = true;
            lblAdmin.Dock = DockStyle.Fill;
            lblAdmin.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblAdmin.Location = new Point(1676, 0);
            lblAdmin.Margin = new Padding(4, 0, 4, 0);
            lblAdmin.Name = "lblAdmin";
            lblAdmin.Size = new Size(112, 60);
            lblAdmin.TabIndex = 3;
            lblAdmin.Text = "Admin";
            lblAdmin.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBrand
            // 
            lblBrand.Anchor = AnchorStyles.Left;
            lblBrand.BackColor = Color.Transparent;
            lblBrand.FirstLetterColor = Color.FromArgb(26, 28, 46);
            lblBrand.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBrand.GradientEnd = Color.FromArgb(29, 182, 216);
            lblBrand.GradientStart = Color.FromArgb(107, 78, 234);
            lblBrand.Location = new Point(0, 10);
            lblBrand.Margin = new Padding(0, 10, 0, 10);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(120, 40);
            lblBrand.TabIndex = 5;
            lblBrand.Text = "iBlendit";
            lblBrand.UseFirstLetterColor = true;
            // 
            // lblClock
            // 
            lblClock.AutoSize = true;
            lblClock.Dock = DockStyle.Fill;
            lblClock.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblClock.ForeColor = Color.FromArgb(148, 147, 165);
            lblClock.Location = new Point(1433, 0);
            lblClock.Margin = new Padding(4, 0, 4, 0);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(170, 60);
            lblClock.TabIndex = 1;
            lblClock.Text = "Clock";
            lblClock.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlAdmin
            // 
            pnlAdmin.BackColor = Color.Transparent;
            pnlAdmin.BorderColor = Color.FromArgb(229, 231, 235);
            pnlAdmin.Controls.Add(label1);
            pnlAdmin.Controls.Add(lblAdminLtr);
            pnlAdmin.CornerRadius = 14;
            pnlAdmin.FillColor = Color.White;
            pnlAdmin.GradientEnd = Color.FromArgb(29, 182, 216);
            pnlAdmin.GradientStart = Color.FromArgb(107, 78, 234);
            pnlAdmin.IsCircle = true;
            pnlAdmin.Location = new Point(1615, 5);
            pnlAdmin.Margin = new Padding(5);
            pnlAdmin.Name = "pnlAdmin";
            pnlAdmin.Size = new Size(50, 50);
            pnlAdmin.TabIndex = 6;
            pnlAdmin.UseGradient = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(1, -1);
            label1.Margin = new Padding(2);
            label1.Name = "label1";
            label1.Size = new Size(52, 50);
            label1.TabIndex = 3;
            label1.Text = "A";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAdminLtr
            // 
            lblAdminLtr.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAdminLtr.AutoSize = true;
            lblAdminLtr.ForeColor = Color.White;
            lblAdminLtr.Location = new Point(-376, 10);
            lblAdminLtr.Margin = new Padding(4, 0, 4, 0);
            lblAdminLtr.Name = "lblAdminLtr";
            lblAdminLtr.Size = new Size(24, 25);
            lblAdminLtr.TabIndex = 0;
            lblAdminLtr.Text = "A";
            // 
            // roundedPanel1
            // 
            roundedPanel1.BackColor = Color.Transparent;
            roundedPanel1.BorderColor = Color.FromArgb(244, 245, 247);
            roundedPanel1.Dock = DockStyle.Fill;
            roundedPanel1.FillColor = Color.FromArgb(244, 245, 247);
            roundedPanel1.GradientEnd = Color.FromArgb(246, 246, 249);
            roundedPanel1.GradientStart = Color.FromArgb(246, 246, 249);
            roundedPanel1.Location = new Point(1607, 10);
            roundedPanel1.Margin = new Padding(0, 10, 0, 10);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(3, 40);
            roundedPanel1.TabIndex = 7;
            // 
            // roundedPanel2
            // 
            roundedPanel2.Anchor = AnchorStyles.None;
            roundedPanel2.BackColor = Color.Transparent;
            roundedPanel2.BorderColor = Color.FromArgb(229, 231, 235);
            roundedPanel2.Controls.Add(label2);
            roundedPanel2.CornerRadius = 5;
            roundedPanel2.FillColor = Color.FromArgb(240, 237, 255);
            roundedPanel2.GradientEnd = Color.FromArgb(6, 182, 212);
            roundedPanel2.GradientStart = Color.FromArgb(124, 58, 237);
            roundedPanel2.Location = new Point(124, 17);
            roundedPanel2.Margin = new Padding(0, 5, 0, 0);
            roundedPanel2.Name = "roundedPanel2";
            roundedPanel2.ShadowSize = 1;
            roundedPanel2.Size = new Size(40, 30);
            roundedPanel2.TabIndex = 8;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(129, 75, 239);
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(40, 30);
            label2.TabIndex = 4;
            label2.Text = "POS";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1872, 1204);
            Controls.Add(tableLayoutPanel2);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            roundedPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            pnlAdmin.ResumeLayout(false);
            pnlAdmin.PerformLayout();
            roundedPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private RoundedPanel pnlAvatar;
        private Label lblA;
        private System.Windows.Forms.Timer timer1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel pnlContent;
        private Panel panel1;
        private RoundedPanel roundedPanel3;
        private PictureBox pictureBox1;
        private Button btnMenu;
        private Button btnHome;
        private Button btnOrders;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblAdmin;
        private GradientLabel lblBrand;
        private Label lblClock;
        private RoundedPanel pnlAdmin;
        private Label lblAdminLtr;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel pnlAccent;
        private Label label1;
        private RoundedPanel roundedPanel1;
        private RoundedPanel roundedPanel2;
        private Label label2;
    }
}