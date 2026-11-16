namespace SmoothieTruckApp.Front_End
{
    partial class RevenuePage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlRevenueHeader = new Panel();
            lblRevenueTitle = new Label();
            lblRevenueSub = new Label();
            pnlPeriod = new RoundedPanel();
            pnlWeek = new RoundedPanel();
            pnlMonth = new RoundedPanel();
            btnWeek = new Button();
            btnMonth = new Button();
            tblStats = new TableLayoutPanel();
            tblCharts = new TableLayoutPanel();
            pnlTrendCard = new RoundedPanel();
            pnlBlendsCard = new RoundedPanel();
            lblTrendTile = new Label();
            lblTrendSub = new Label();
            lblWeekCaption = new Label();
            lblWeekTotal = new Label();
            lblBlendsTitle = new Label();
            lblBlendsSub = new Label();
            pnlRevenueHeader.SuspendLayout();
            pnlPeriod.SuspendLayout();
            pnlWeek.SuspendLayout();
            pnlMonth.SuspendLayout();
            tblCharts.SuspendLayout();
            pnlTrendCard.SuspendLayout();
            pnlBlendsCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRevenueHeader
            // 
            pnlRevenueHeader.BackColor = Color.Transparent;
            pnlRevenueHeader.Controls.Add(pnlPeriod);
            pnlRevenueHeader.Controls.Add(lblRevenueSub);
            pnlRevenueHeader.Controls.Add(lblRevenueTitle);
            pnlRevenueHeader.Dock = DockStyle.Top;
            pnlRevenueHeader.Location = new Point(20, 18);
            pnlRevenueHeader.Name = "pnlRevenueHeader";
            pnlRevenueHeader.Size = new Size(960, 62);
            pnlRevenueHeader.TabIndex = 0;
            // 
            // lblRevenueTitle
            // 
            lblRevenueTitle.AutoSize = true;
            lblRevenueTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRevenueTitle.ForeColor = Color.FromArgb(17, 17, 27);
            lblRevenueTitle.Location = new Point(0, 0);
            lblRevenueTitle.Name = "lblRevenueTitle";
            lblRevenueTitle.Size = new Size(146, 25);
            lblRevenueTitle.TabIndex = 0;
            lblRevenueTitle.Text = "Revenue Check";
            // 
            // lblRevenueSub
            // 
            lblRevenueSub.AutoSize = true;
            lblRevenueSub.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRevenueSub.ForeColor = Color.FromArgb(120, 124, 145);
            lblRevenueSub.Location = new Point(0, 32);
            lblRevenueSub.Name = "lblRevenueSub";
            lblRevenueSub.Size = new Size(213, 15);
            lblRevenueSub.TabIndex = 1;
            lblRevenueSub.Text = "Sales performance for Monday, May 26";
            // 
            // pnlPeriod
            // 
            pnlPeriod.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlPeriod.BorderColor = Color.FromArgb(236, 238, 242);
            pnlPeriod.Controls.Add(pnlMonth);
            pnlPeriod.Controls.Add(pnlWeek);
            pnlPeriod.CornerRadius = 10;
            pnlPeriod.FillColor = Color.White;
            pnlPeriod.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlPeriod.GradientStart = Color.FromArgb(124, 58, 237);
            pnlPeriod.Location = new Point(840, 6);
            pnlPeriod.Name = "pnlPeriod";
            pnlPeriod.Size = new Size(118, 34);
            pnlPeriod.TabIndex = 2;
            // 
            // pnlWeek
            // 
            pnlWeek.BorderColor = Color.FromArgb(229, 231, 235);
            pnlWeek.BorderSize = 0;
            pnlWeek.Controls.Add(btnWeek);
            pnlWeek.CornerRadius = 8;
            pnlWeek.FillColor = Color.FromArgb(124, 58, 237);
            pnlWeek.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlWeek.GradientStart = Color.FromArgb(124, 58, 237);
            pnlWeek.Location = new Point(3, 3);
            pnlWeek.Name = "pnlWeek";
            pnlWeek.Size = new Size(54, 28);
            pnlWeek.TabIndex = 0;
            // 
            // pnlMonth
            // 
            pnlMonth.BorderColor = Color.FromArgb(229, 231, 235);
            pnlMonth.BorderSize = 0;
            pnlMonth.Controls.Add(btnMonth);
            pnlMonth.CornerRadius = 8;
            pnlMonth.FillColor = Color.White;
            pnlMonth.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlMonth.GradientStart = Color.FromArgb(124, 58, 237);
            pnlMonth.Location = new Point(61, 3);
            pnlMonth.Name = "pnlMonth";
            pnlMonth.Size = new Size(54, 28);
            pnlMonth.TabIndex = 1;
            // 
            // btnWeek
            // 
            btnWeek.Cursor = Cursors.Hand;
            btnWeek.Dock = DockStyle.Fill;
            btnWeek.FlatAppearance.BorderSize = 0;
            btnWeek.FlatStyle = FlatStyle.Flat;
            btnWeek.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWeek.ForeColor = Color.White;
            btnWeek.Location = new Point(0, 0);
            btnWeek.Name = "btnWeek";
            btnWeek.Size = new Size(54, 28);
            btnWeek.TabIndex = 0;
            btnWeek.Text = "Week";
            btnWeek.UseVisualStyleBackColor = true;
            // 
            // btnMonth
            // 
            btnMonth.Cursor = Cursors.Hand;
            btnMonth.Dock = DockStyle.Fill;
            btnMonth.FlatAppearance.BorderSize = 0;
            btnMonth.FlatStyle = FlatStyle.Flat;
            btnMonth.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMonth.ForeColor = Color.FromArgb(120, 124, 145);
            btnMonth.Location = new Point(0, 0);
            btnMonth.Name = "btnMonth";
            btnMonth.Size = new Size(54, 28);
            btnMonth.TabIndex = 0;
            btnMonth.Text = "Month";
            btnMonth.UseVisualStyleBackColor = true;
            // 
            // tblStats
            // 
            tblStats.BackColor = Color.Transparent;
            tblStats.ColumnCount = 3;
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblStats.Dock = DockStyle.Top;
            tblStats.Location = new Point(20, 80);
            tblStats.Name = "tblStats";
            tblStats.RowCount = 1;
            tblStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblStats.Size = new Size(960, 96);
            tblStats.TabIndex = 1;
            // 
            // tblCharts
            // 
            tblCharts.BackColor = Color.Transparent;
            tblCharts.ColumnCount = 2;
            tblCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66F));
            tblCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tblCharts.Controls.Add(pnlBlendsCard, 1, 0);
            tblCharts.Controls.Add(pnlTrendCard, 0, 0);
            tblCharts.Dock = DockStyle.Top;
            tblCharts.Location = new Point(20, 176);
            tblCharts.Name = "tblCharts";
            tblCharts.RowCount = 1;
            tblCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblCharts.Size = new Size(960, 270);
            tblCharts.TabIndex = 2;
            // 
            // pnlTrendCard
            // 
            pnlTrendCard.BorderColor = Color.FromArgb(236, 238, 242);
            pnlTrendCard.Controls.Add(lblWeekTotal);
            pnlTrendCard.Controls.Add(lblWeekCaption);
            pnlTrendCard.Controls.Add(lblTrendSub);
            pnlTrendCard.Controls.Add(lblTrendTile);
            pnlTrendCard.CornerRadius = 14;
            pnlTrendCard.Dock = DockStyle.Fill;
            pnlTrendCard.FillColor = Color.White;
            pnlTrendCard.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlTrendCard.GradientStart = Color.FromArgb(124, 58, 237);
            pnlTrendCard.Location = new Point(0, 0);
            pnlTrendCard.Margin = new Padding(0, 0, 10, 0);
            pnlTrendCard.Name = "pnlTrendCard";
            pnlTrendCard.Padding = new Padding(3);
            pnlTrendCard.ShadowSize = 3;
            pnlTrendCard.Size = new Size(623, 270);
            pnlTrendCard.TabIndex = 0;
            // 
            // pnlBlendsCard
            // 
            pnlBlendsCard.BorderColor = Color.FromArgb(236, 238, 242);
            pnlBlendsCard.Controls.Add(lblBlendsSub);
            pnlBlendsCard.Controls.Add(lblBlendsTitle);
            pnlBlendsCard.CornerRadius = 14;
            pnlBlendsCard.Dock = DockStyle.Fill;
            pnlBlendsCard.FillColor = Color.White;
            pnlBlendsCard.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlBlendsCard.GradientStart = Color.FromArgb(124, 58, 237);
            pnlBlendsCard.Location = new Point(633, 0);
            pnlBlendsCard.Margin = new Padding(0);
            pnlBlendsCard.Name = "pnlBlendsCard";
            pnlBlendsCard.Padding = new Padding(3);
            pnlBlendsCard.ShadowSize = 3;
            pnlBlendsCard.Size = new Size(327, 270);
            pnlBlendsCard.TabIndex = 1;
            // 
            // lblTrendTile
            // 
            lblTrendTile.AutoSize = true;
            lblTrendTile.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTrendTile.ForeColor = Color.FromArgb(17, 17, 27);
            lblTrendTile.Location = new Point(14, 12);
            lblTrendTile.Name = "lblTrendTile";
            lblTrendTile.Size = new Size(97, 17);
            lblTrendTile.TabIndex = 0;
            lblTrendTile.Text = "Revenue trend";
            // 
            // lblTrendSub
            // 
            lblTrendSub.AutoSize = true;
            lblTrendSub.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTrendSub.ForeColor = Color.FromArgb(120, 124, 145);
            lblTrendSub.Location = new Point(14, 34);
            lblTrendSub.Name = "lblTrendSub";
            lblTrendSub.Size = new Size(112, 13);
            lblTrendSub.TabIndex = 1;
            lblTrendSub.Text = "Daily sales this week";
            // 
            // lblWeekCaption
            // 
            lblWeekCaption.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblWeekCaption.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWeekCaption.ForeColor = Color.FromArgb(120, 124, 145);
            lblWeekCaption.Location = new Point(490, 12);
            lblWeekCaption.Name = "lblWeekCaption";
            lblWeekCaption.Size = new Size(120, 14);
            lblWeekCaption.TabIndex = 2;
            lblWeekCaption.Text = "WEEK TOTAL";
            lblWeekCaption.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblWeekTotal
            // 
            lblWeekTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblWeekTotal.Location = new Point(490, 26);
            lblWeekTotal.Name = "lblWeekTotal";
            lblWeekTotal.Size = new Size(120, 22);
            lblWeekTotal.TabIndex = 3;
            lblWeekTotal.Text = "$7,640";
            lblWeekTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBlendsTitle
            // 
            lblBlendsTitle.AutoSize = true;
            lblBlendsTitle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBlendsTitle.ForeColor = Color.FromArgb(17, 17, 27);
            lblBlendsTitle.Location = new Point(14, 12);
            lblBlendsTitle.Name = "lblBlendsTitle";
            lblBlendsTitle.Size = new Size(122, 17);
            lblBlendsTitle.TabIndex = 0;
            lblBlendsTitle.Text = "Top Selling Blends";
            // 
            // lblBlendsSub
            // 
            lblBlendsSub.AutoSize = true;
            lblBlendsSub.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBlendsSub.ForeColor = Color.FromArgb(120, 124, 145);
            lblBlendsSub.Location = new Point(14, 34);
            lblBlendsSub.Name = "lblBlendsSub";
            lblBlendsSub.Size = new Size(105, 13);
            lblBlendsSub.TabIndex = 1;
            lblBlendsSub.Text = "By units sold today";
            // 
            // RevenuePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 247);
            Controls.Add(tblCharts);
            Controls.Add(tblStats);
            Controls.Add(pnlRevenueHeader);
            Name = "RevenuePage";
            Padding = new Padding(20, 18, 20, 8);
            Size = new Size(1000, 650);
            pnlRevenueHeader.ResumeLayout(false);
            pnlRevenueHeader.PerformLayout();
            pnlPeriod.ResumeLayout(false);
            pnlWeek.ResumeLayout(false);
            pnlMonth.ResumeLayout(false);
            tblCharts.ResumeLayout(false);
            pnlTrendCard.ResumeLayout(false);
            pnlTrendCard.PerformLayout();
            pnlBlendsCard.ResumeLayout(false);
            pnlBlendsCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRevenueHeader;
        private RoundedPanel pnlPeriod;
        private Label lblRevenueSub;
        private Label lblRevenueTitle;
        private RoundedPanel pnlMonth;
        private Button btnMonth;
        private RoundedPanel pnlWeek;
        private Button btnWeek;
        private TableLayoutPanel tblStats;
        private TableLayoutPanel tblCharts;
        private RoundedPanel pnlTrendCard;
        private RoundedPanel pnlBlendsCard;
        private Label lblWeekCaption;
        private Label lblTrendSub;
        private Label lblTrendTile;
        private Label lblBlendsSub;
        private Label lblBlendsTitle;
        private Label lblWeekTotal;
    }
}
