namespace SmoothieTruckApp.Front_End
{
    partial class OrdersPage
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
            pnlOrdersHeader = new Panel();
            flowLegend = new FlowLayoutPanel();
            pnlDotGreen = new RoundedPanel();
            lblTime = new Label();
            pnlDotAmber = new RoundedPanel();
            lblTime2 = new Label();
            pnlDotRed = new RoundedPanel();
            lblTime3 = new Label();
            lblStationSub = new Label();
            lblStationTitle = new Label();
            tblColumns = new TableLayoutPanel();
            pnlInProgress = new Panel();
            flowInProgress = new FlowLayoutPanel();
            pnlInProgressHead = new Panel();
            lblInProgress = new Label();
            pnlInProgressCount = new RoundedPanel();
            lblInProgressCount = new Label();
            pnlColumnLine = new Panel();
            pnlCompleted = new Panel();
            flowCompleted = new FlowLayoutPanel();
            pnlCompletedHead = new Panel();
            pnlCompletedCount = new RoundedPanel();
            lblCompletedCount = new Label();
            lblCompleted = new Label();
            pnlOrdersHeader.SuspendLayout();
            flowLegend.SuspendLayout();
            tblColumns.SuspendLayout();
            pnlInProgress.SuspendLayout();
            pnlInProgressHead.SuspendLayout();
            pnlInProgressCount.SuspendLayout();
            pnlCompleted.SuspendLayout();
            pnlCompletedHead.SuspendLayout();
            pnlCompletedCount.SuspendLayout();
            SuspendLayout();
            // 
            // pnlOrdersHeader
            // 
            pnlOrdersHeader.BackColor = Color.Transparent;
            pnlOrdersHeader.Controls.Add(flowLegend);
            pnlOrdersHeader.Controls.Add(lblStationSub);
            pnlOrdersHeader.Controls.Add(lblStationTitle);
            pnlOrdersHeader.Dock = DockStyle.Top;
            pnlOrdersHeader.Location = new Point(20, 18);
            pnlOrdersHeader.Name = "pnlOrdersHeader";
            pnlOrdersHeader.Size = new Size(960, 62);
            pnlOrdersHeader.TabIndex = 0;
            // 
            // flowLegend
            // 
            flowLegend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flowLegend.AutoSize = true;
            flowLegend.Controls.Add(pnlDotGreen);
            flowLegend.Controls.Add(lblTime);
            flowLegend.Controls.Add(pnlDotAmber);
            flowLegend.Controls.Add(lblTime2);
            flowLegend.Controls.Add(pnlDotRed);
            flowLegend.Controls.Add(lblTime3);
            flowLegend.Location = new Point(743, 8);
            flowLegend.Name = "flowLegend";
            flowLegend.Size = new Size(217, 51);
            flowLegend.TabIndex = 2;
            flowLegend.WrapContents = false;
            // 
            // pnlDotGreen
            // 
            pnlDotGreen.BackColor = Color.Transparent;
            pnlDotGreen.BorderColor = Color.FromArgb(229, 231, 235);
            pnlDotGreen.BorderSize = 0;
            pnlDotGreen.CornerRadius = 4;
            pnlDotGreen.FillColor = Color.FromArgb(34, 197, 94);
            pnlDotGreen.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlDotGreen.GradientStart = Color.FromArgb(124, 58, 237);
            pnlDotGreen.Location = new Point(8, 6);
            pnlDotGreen.Margin = new Padding(8, 6, 4, 0);
            pnlDotGreen.Name = "pnlDotGreen";
            pnlDotGreen.Size = new Size(8, 8);
            pnlDotGreen.TabIndex = 0;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.FromArgb(75, 85, 99);
            lblTime.Location = new Point(20, 0);
            lblTime.Margin = new Padding(0, 0, 6, 0);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(46, 13);
            lblTime.TabIndex = 3;
            lblTime.Text = "≤ 4 min";
            // 
            // pnlDotAmber
            // 
            pnlDotAmber.BackColor = Color.Transparent;
            pnlDotAmber.BorderColor = Color.FromArgb(229, 231, 235);
            pnlDotAmber.BorderSize = 0;
            pnlDotAmber.CornerRadius = 4;
            pnlDotAmber.FillColor = Color.FromArgb(245, 158, 11);
            pnlDotAmber.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlDotAmber.GradientStart = Color.FromArgb(124, 58, 237);
            pnlDotAmber.Location = new Point(80, 6);
            pnlDotAmber.Margin = new Padding(8, 6, 4, 0);
            pnlDotAmber.Name = "pnlDotAmber";
            pnlDotAmber.Size = new Size(8, 8);
            pnlDotAmber.TabIndex = 1;
            // 
            // lblTime2
            // 
            lblTime2.AutoSize = true;
            lblTime2.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTime2.ForeColor = Color.FromArgb(75, 85, 99);
            lblTime2.Location = new Point(92, 0);
            lblTime2.Margin = new Padding(0, 0, 6, 0);
            lblTime2.Name = "lblTime2";
            lblTime2.Size = new Size(47, 13);
            lblTime2.TabIndex = 4;
            lblTime2.Text = "5–8 min";
            // 
            // pnlDotRed
            // 
            pnlDotRed.BackColor = Color.Transparent;
            pnlDotRed.BorderColor = Color.FromArgb(229, 231, 235);
            pnlDotRed.BorderSize = 0;
            pnlDotRed.CornerRadius = 4;
            pnlDotRed.FillColor = Color.FromArgb(239, 68, 68);
            pnlDotRed.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlDotRed.GradientStart = Color.FromArgb(124, 58, 237);
            pnlDotRed.Location = new Point(153, 6);
            pnlDotRed.Margin = new Padding(8, 6, 4, 0);
            pnlDotRed.Name = "pnlDotRed";
            pnlDotRed.Size = new Size(8, 8);
            pnlDotRed.TabIndex = 2;
            // 
            // lblTime3
            // 
            lblTime3.AutoSize = true;
            lblTime3.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTime3.ForeColor = Color.FromArgb(75, 85, 99);
            lblTime3.Location = new Point(165, 0);
            lblTime3.Margin = new Padding(0, 0, 6, 0);
            lblTime3.Name = "lblTime3";
            lblTime3.Size = new Size(46, 13);
            lblTime3.TabIndex = 5;
            lblTime3.Text = "> 8 min";
            // 
            // lblStationSub
            // 
            lblStationSub.AutoSize = true;
            lblStationSub.ForeColor = Color.FromArgb(120, 124, 145);
            lblStationSub.Location = new Point(0, 32);
            lblStationSub.Name = "lblStationSub";
            lblStationSub.Size = new Size(95, 15);
            lblStationSub.TabIndex = 1;
            lblStationSub.Text = "Live order queue";
            // 
            // lblStationTitle
            // 
            lblStationTitle.AutoSize = true;
            lblStationTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStationTitle.ForeColor = Color.FromArgb(17, 17, 27);
            lblStationTitle.Location = new Point(0, 0);
            lblStationTitle.Name = "lblStationTitle";
            lblStationTitle.Size = new Size(132, 25);
            lblStationTitle.TabIndex = 0;
            lblStationTitle.Text = "Blend Station";
            // 
            // tblColumns
            // 
            tblColumns.BackColor = Color.Transparent;
            tblColumns.ColumnCount = 3;
            tblColumns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblColumns.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 41F));
            tblColumns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblColumns.Controls.Add(pnlInProgress, 0, 0);
            tblColumns.Controls.Add(pnlColumnLine, 1, 0);
            tblColumns.Controls.Add(pnlCompleted, 2, 0);
            tblColumns.Dock = DockStyle.Fill;
            tblColumns.Location = new Point(20, 80);
            tblColumns.Name = "tblColumns";
            tblColumns.RowCount = 1;
            tblColumns.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblColumns.Size = new Size(960, 562);
            tblColumns.TabIndex = 1;
            // 
            // pnlInProgress
            // 
            pnlInProgress.Controls.Add(flowInProgress);
            pnlInProgress.Controls.Add(pnlInProgressHead);
            pnlInProgress.Dock = DockStyle.Fill;
            pnlInProgress.Location = new Point(3, 3);
            pnlInProgress.Name = "pnlInProgress";
            pnlInProgress.Size = new Size(453, 556);
            pnlInProgress.TabIndex = 0;
            // 
            // flowInProgress
            // 
            flowInProgress.AutoScroll = true;
            flowInProgress.BackColor = Color.Transparent;
            flowInProgress.BackgroundImageLayout = ImageLayout.None;
            flowInProgress.Dock = DockStyle.Fill;
            flowInProgress.FlowDirection = FlowDirection.TopDown;
            flowInProgress.Location = new Point(0, 40);
            flowInProgress.Name = "flowInProgress";
            flowInProgress.Size = new Size(453, 516);
            flowInProgress.TabIndex = 2;
            flowInProgress.WrapContents = false;
            // 
            // pnlInProgressHead
            // 
            pnlInProgressHead.Controls.Add(lblInProgress);
            pnlInProgressHead.Controls.Add(pnlInProgressCount);
            pnlInProgressHead.Dock = DockStyle.Top;
            pnlInProgressHead.Location = new Point(0, 0);
            pnlInProgressHead.Name = "pnlInProgressHead";
            pnlInProgressHead.Size = new Size(453, 40);
            pnlInProgressHead.TabIndex = 0;
            // 
            // lblInProgress
            // 
            lblInProgress.AutoSize = true;
            lblInProgress.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInProgress.ForeColor = Color.FromArgb(17, 17, 27);
            lblInProgress.Location = new Point(0, 6);
            lblInProgress.Name = "lblInProgress";
            lblInProgress.Size = new Size(88, 20);
            lblInProgress.TabIndex = 0;
            lblInProgress.Text = "In Progress";
            lblInProgress.Click += lblInProgress_Click;
            // 
            // pnlInProgressCount
            // 
            pnlInProgressCount.BackColor = Color.Transparent;
            pnlInProgressCount.BorderColor = Color.FromArgb(229, 231, 235);
            pnlInProgressCount.BorderSize = 0;
            pnlInProgressCount.Controls.Add(lblInProgressCount);
            pnlInProgressCount.CornerRadius = 10;
            pnlInProgressCount.FillColor = Color.FromArgb(124, 58, 237);
            pnlInProgressCount.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlInProgressCount.GradientStart = Color.FromArgb(124, 58, 237);
            pnlInProgressCount.Location = new Point(96, 9);
            pnlInProgressCount.Name = "pnlInProgressCount";
            pnlInProgressCount.Size = new Size(26, 20);
            pnlInProgressCount.TabIndex = 1;
            // 
            // lblInProgressCount
            // 
            lblInProgressCount.Dock = DockStyle.Fill;
            lblInProgressCount.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInProgressCount.ForeColor = Color.White;
            lblInProgressCount.Location = new Point(0, 0);
            lblInProgressCount.Name = "lblInProgressCount";
            lblInProgressCount.Size = new Size(26, 20);
            lblInProgressCount.TabIndex = 0;
            lblInProgressCount.Text = "3";
            lblInProgressCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlColumnLine
            // 
            pnlColumnLine.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            pnlColumnLine.BackColor = Color.FromArgb(229, 231, 235);
            pnlColumnLine.Location = new Point(479, 3);
            pnlColumnLine.Name = "pnlColumnLine";
            pnlColumnLine.Size = new Size(1, 556);
            pnlColumnLine.TabIndex = 1;
            // 
            // pnlCompleted
            // 
            pnlCompleted.Controls.Add(flowCompleted);
            pnlCompleted.Controls.Add(pnlCompletedHead);
            pnlCompleted.Dock = DockStyle.Fill;
            pnlCompleted.Location = new Point(503, 3);
            pnlCompleted.Name = "pnlCompleted";
            pnlCompleted.Size = new Size(454, 556);
            pnlCompleted.TabIndex = 2;
            // 
            // flowCompleted
            // 
            flowCompleted.AutoScroll = true;
            flowCompleted.Dock = DockStyle.Fill;
            flowCompleted.FlowDirection = FlowDirection.TopDown;
            flowCompleted.Location = new Point(0, 40);
            flowCompleted.Name = "flowCompleted";
            flowCompleted.Size = new Size(454, 516);
            flowCompleted.TabIndex = 1;
            flowCompleted.WrapContents = false;
            // 
            // pnlCompletedHead
            // 
            pnlCompletedHead.Controls.Add(pnlCompletedCount);
            pnlCompletedHead.Controls.Add(lblCompleted);
            pnlCompletedHead.Dock = DockStyle.Top;
            pnlCompletedHead.Location = new Point(0, 0);
            pnlCompletedHead.Name = "pnlCompletedHead";
            pnlCompletedHead.Size = new Size(454, 40);
            pnlCompletedHead.TabIndex = 0;
            // 
            // pnlCompletedCount
            // 
            pnlCompletedCount.BackColor = Color.Transparent;
            pnlCompletedCount.BorderColor = Color.FromArgb(229, 231, 235);
            pnlCompletedCount.BorderSize = 0;
            pnlCompletedCount.Controls.Add(lblCompletedCount);
            pnlCompletedCount.CornerRadius = 10;
            pnlCompletedCount.FillColor = Color.FromArgb(22, 163, 74);
            pnlCompletedCount.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlCompletedCount.GradientStart = Color.FromArgb(124, 58, 237);
            pnlCompletedCount.Location = new Point(88, 9);
            pnlCompletedCount.Name = "pnlCompletedCount";
            pnlCompletedCount.Size = new Size(26, 20);
            pnlCompletedCount.TabIndex = 1;
            // 
            // lblCompletedCount
            // 
            lblCompletedCount.Dock = DockStyle.Fill;
            lblCompletedCount.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompletedCount.ForeColor = Color.White;
            lblCompletedCount.Location = new Point(0, 0);
            lblCompletedCount.Name = "lblCompletedCount";
            lblCompletedCount.Size = new Size(26, 20);
            lblCompletedCount.TabIndex = 0;
            lblCompletedCount.Text = "3";
            lblCompletedCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCompleted
            // 
            lblCompleted.AutoSize = true;
            lblCompleted.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompleted.ForeColor = Color.FromArgb(17, 17, 27);
            lblCompleted.Location = new Point(0, 6);
            lblCompleted.Name = "lblCompleted";
            lblCompleted.Size = new Size(85, 20);
            lblCompleted.TabIndex = 0;
            lblCompleted.Text = "Completed";
            // 
            // OrdersPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 247);
            Controls.Add(tblColumns);
            Controls.Add(pnlOrdersHeader);
            Name = "OrdersPage";
            Padding = new Padding(20, 18, 20, 8);
            Size = new Size(1000, 650);
            Load += OrdersPage_Load;
            pnlOrdersHeader.ResumeLayout(false);
            pnlOrdersHeader.PerformLayout();
            flowLegend.ResumeLayout(false);
            flowLegend.PerformLayout();
            tblColumns.ResumeLayout(false);
            pnlInProgress.ResumeLayout(false);
            pnlInProgressHead.ResumeLayout(false);
            pnlInProgressHead.PerformLayout();
            pnlInProgressCount.ResumeLayout(false);
            pnlCompleted.ResumeLayout(false);
            pnlCompletedHead.ResumeLayout(false);
            pnlCompletedHead.PerformLayout();
            pnlCompletedCount.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlOrdersHeader;
        private FlowLayoutPanel flowLegend;
        private Label lblStationSub;
        private Label lblStationTitle;
        private RoundedPanel pnlDotGreen;
        private RoundedPanel pnlDotAmber;
        private RoundedPanel pnlDotRed;
        private Label lblTime;
        private Label lblTime2;
        private Label lblTime3;
        private TableLayoutPanel tblColumns;
        private Panel pnlInProgress;
        private Label lblInProgress;
        private FlowLayoutPanel flowInProgress;
        private RoundedPanel pnlInProgressCount;
        private Label lblInProgressCount;
        private Panel pnlColumnLine;
        private Panel pnlInProgressHead;
        private Panel pnlCompleted;
        private Panel pnlCompletedHead;
        private RoundedPanel pnlCompletedCount;
        private Label lblCompletedCount;
        private Label lblCompleted;
        private FlowLayoutPanel flowCompleted;
    }
}
