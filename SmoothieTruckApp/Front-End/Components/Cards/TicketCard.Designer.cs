namespace SmoothieTruckApp.Front_End
{
    partial class TicketCard
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
            pnlCard = new RoundedPanel();
            pnlTicketBody = new Panel();
            flowItems = new FlowLayoutPanel();
            pnlBodyLine = new Panel();
            pnlComplete = new Panel();
            pnlCompleteFill = new RoundedPanel();
            btnComplete = new Button();
            pnlTicketHeader = new Panel();
            btnChevron = new Button();
            lblBlendCount = new Label();
            flowTitle = new FlowLayoutPanel();
            lblTicketNo = new Label();
            pnlTimer = new RoundedPanel();
            lblTimer = new Label();
            pnlCard.SuspendLayout();
            pnlTicketBody.SuspendLayout();
            pnlComplete.SuspendLayout();
            pnlCompleteFill.SuspendLayout();
            pnlTicketHeader.SuspendLayout();
            flowTitle.SuspendLayout();
            pnlTimer.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.Transparent;
            pnlCard.BorderColor = Color.FromArgb(236, 238, 242);
            pnlCard.Controls.Add(pnlTicketBody);
            pnlCard.Controls.Add(pnlTicketHeader);
            pnlCard.CornerRadius = 12;
            pnlCard.Dock = DockStyle.Fill;
            pnlCard.FillColor = Color.White;
            pnlCard.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlCard.GradientStart = Color.FromArgb(124, 58, 237);
            pnlCard.Location = new Point(0, 0);
            pnlCard.Name = "pnlCard";
            pnlCard.Padding = new Padding(3);
            pnlCard.ShadowSize = 3;
            pnlCard.Size = new Size(480, 58);
            pnlCard.TabIndex = 0;
            // 
            // pnlTicketBody
            // 
            pnlTicketBody.Controls.Add(flowItems);
            pnlTicketBody.Controls.Add(pnlBodyLine);
            pnlTicketBody.Controls.Add(pnlComplete);
            pnlTicketBody.Dock = DockStyle.Fill;
            pnlTicketBody.Location = new Point(3, 55);
            pnlTicketBody.Name = "pnlTicketBody";
            pnlTicketBody.Size = new Size(474, 0);
            pnlTicketBody.TabIndex = 1;
            // 
            // flowItems
            // 
            flowItems.Dock = DockStyle.Top;
            flowItems.FlowDirection = FlowDirection.TopDown;
            flowItems.Location = new Point(0, 1);
            flowItems.Name = "flowItems";
            flowItems.Padding = new Padding(14, 8, 14, 4);
            flowItems.Size = new Size(474, 60);
            flowItems.TabIndex = 2;
            flowItems.WrapContents = false;
            // 
            // pnlBodyLine
            // 
            pnlBodyLine.BackColor = Color.FromArgb(238, 240, 244);
            pnlBodyLine.Dock = DockStyle.Top;
            pnlBodyLine.Location = new Point(0, 0);
            pnlBodyLine.Name = "pnlBodyLine";
            pnlBodyLine.Size = new Size(474, 1);
            pnlBodyLine.TabIndex = 1;
            // 
            // pnlComplete
            // 
            pnlComplete.Controls.Add(pnlCompleteFill);
            pnlComplete.Dock = DockStyle.Bottom;
            pnlComplete.Location = new Point(0, -50);
            pnlComplete.Name = "pnlComplete";
            pnlComplete.Padding = new Padding(14, 4, 14, 10);
            pnlComplete.Size = new Size(474, 50);
            pnlComplete.TabIndex = 0;
            // 
            // pnlCompleteFill
            // 
            pnlCompleteFill.BackColor = Color.Transparent;
            pnlCompleteFill.BorderColor = Color.FromArgb(229, 231, 235);
            pnlCompleteFill.BorderSize = 0;
            pnlCompleteFill.Controls.Add(btnComplete);
            pnlCompleteFill.CornerRadius = 8;
            pnlCompleteFill.Dock = DockStyle.Fill;
            pnlCompleteFill.FillColor = Color.FromArgb(34, 197, 94);
            pnlCompleteFill.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlCompleteFill.GradientStart = Color.FromArgb(124, 58, 237);
            pnlCompleteFill.Location = new Point(14, 4);
            pnlCompleteFill.Name = "pnlCompleteFill";
            pnlCompleteFill.Size = new Size(446, 36);
            pnlCompleteFill.TabIndex = 0;
            // 
            // btnComplete
            // 
            btnComplete.Dock = DockStyle.Fill;
            btnComplete.FlatAppearance.BorderSize = 0;
            btnComplete.FlatAppearance.MouseDownBackColor = Color.FromArgb(34, 197, 94);
            btnComplete.FlatAppearance.MouseOverBackColor = Color.FromArgb(34, 197, 94);
            btnComplete.FlatStyle = FlatStyle.Flat;
            btnComplete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnComplete.ForeColor = Color.White;
            btnComplete.Location = new Point(0, 0);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(446, 36);
            btnComplete.TabIndex = 0;
            btnComplete.Text = "✓  Blends Ready — Mark Complete";
            btnComplete.UseVisualStyleBackColor = true;
            btnComplete.Click += btnComplete_Click;
            // 
            // pnlTicketHeader
            // 
            pnlTicketHeader.Controls.Add(btnChevron);
            pnlTicketHeader.Controls.Add(lblBlendCount);
            pnlTicketHeader.Controls.Add(flowTitle);
            pnlTicketHeader.Controls.Add(pnlTimer);
            pnlTicketHeader.Dock = DockStyle.Top;
            pnlTicketHeader.Location = new Point(3, 3);
            pnlTicketHeader.Name = "pnlTicketHeader";
            pnlTicketHeader.Size = new Size(474, 52);
            pnlTicketHeader.TabIndex = 0;
            // 
            // btnChevron
            // 
            btnChevron.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChevron.Cursor = Cursors.Hand;
            btnChevron.FlatAppearance.BorderSize = 0;
            btnChevron.FlatAppearance.MouseDownBackColor = Color.FromArgb(236, 238, 242);
            btnChevron.FlatAppearance.MouseOverBackColor = Color.FromArgb(243, 244, 246);
            btnChevron.FlatStyle = FlatStyle.Flat;
            btnChevron.Font = new Font("Segoe MDL2 Assets", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChevron.ForeColor = Color.FromArgb(107, 114, 128);
            btnChevron.Location = new Point(432, 12);
            btnChevron.Name = "btnChevron";
            btnChevron.Size = new Size(28, 28);
            btnChevron.TabIndex = 3;
            btnChevron.TabStop = false;
            btnChevron.UseVisualStyleBackColor = true;
            // 
            // lblBlendCount
            // 
            lblBlendCount.AutoSize = true;
            lblBlendCount.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBlendCount.ForeColor = Color.FromArgb(120, 124, 145);
            lblBlendCount.Location = new Point(82, 29);
            lblBlendCount.Name = "lblBlendCount";
            lblBlendCount.Size = new Size(51, 13);
            lblBlendCount.TabIndex = 2;
            lblBlendCount.Text = "2 blends";
            // 
            // flowTitle
            // 
            flowTitle.AutoSize = true;
            flowTitle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowTitle.Controls.Add(lblTicketNo);
            flowTitle.Location = new Point(82, 9);
            flowTitle.Margin = new Padding(0);
            flowTitle.Name = "flowTitle";
            flowTitle.Size = new Size(177, 15);
            flowTitle.TabIndex = 1;
            flowTitle.WrapContents = false;
            // 
            // lblTicketNo
            // 
            lblTicketNo.AutoSize = true;
            lblTicketNo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTicketNo.ForeColor = Color.FromArgb(17, 17, 27);
            lblTicketNo.Location = new Point(0, 0);
            lblTicketNo.Margin = new Padding(0, 0, 4, 0);
            lblTicketNo.Name = "lblTicketNo";
            lblTicketNo.Size = new Size(59, 15);
            lblTicketNo.TabIndex = 2;
            lblTicketNo.Text = "Ticket 41";
            // 
            // pnlTimer
            // 
            pnlTimer.BackColor = Color.Transparent;
            pnlTimer.BorderColor = Color.FromArgb(229, 231, 235);
            pnlTimer.BorderSize = 0;
            pnlTimer.Controls.Add(lblTimer);
            pnlTimer.CornerRadius = 11;
            pnlTimer.FillColor = Color.FromArgb(220, 252, 231);
            pnlTimer.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlTimer.GradientStart = Color.FromArgb(124, 58, 237);
            pnlTimer.Location = new Point(12, 15);
            pnlTimer.Name = "pnlTimer";
            pnlTimer.Size = new Size(58, 22);
            pnlTimer.TabIndex = 0;
            // 
            // lblTimer
            // 
            lblTimer.Dock = DockStyle.Fill;
            lblTimer.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTimer.ForeColor = Color.FromArgb(22, 163, 74);
            lblTimer.Location = new Point(0, 0);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(58, 22);
            lblTimer.TabIndex = 0;
            lblTimer.Text = "● 2 min";
            lblTimer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TicketCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pnlCard);
            Name = "TicketCard";
            Size = new Size(480, 58);
            pnlCard.ResumeLayout(false);
            pnlTicketBody.ResumeLayout(false);
            pnlComplete.ResumeLayout(false);
            pnlCompleteFill.ResumeLayout(false);
            pnlTicketHeader.ResumeLayout(false);
            pnlTicketHeader.PerformLayout();
            flowTitle.ResumeLayout(false);
            flowTitle.PerformLayout();
            pnlTimer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel pnlCard;
        private Panel pnlTicketHeader;
        private FlowLayoutPanel flowTitle;
        private RoundedPanel pnlTimer;
        private Label lblTimer;
        private Label lblTicketNo;
        private Label lblBlendCount;
        private Button btnChevron;
        private Panel pnlTicketBody;
        private FlowLayoutPanel flowItems;
        private Panel pnlBodyLine;
        private Panel pnlComplete;
        private RoundedPanel pnlCompleteFill;
        private Button btnComplete;
    }
}
