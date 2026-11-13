namespace SmoothieTruckApp.Front_End
{
    partial class CompletedCard
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
            pnlDoneInner = new Panel();
            pnlCheck = new RoundedPanel();
            lblCheck = new Label();
            flowDoneTitle = new FlowLayoutPanel();
            lblDoneTicket = new Label();
            lblDoneItems = new Label();
            lblDoneTime = new Label();
            lblDoneWait = new Label();
            pnlCard.SuspendLayout();
            pnlDoneInner.SuspendLayout();
            pnlCheck.SuspendLayout();
            flowDoneTitle.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.Transparent;
            pnlCard.BorderColor = Color.FromArgb(236, 238, 242);
            pnlCard.Controls.Add(pnlDoneInner);
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
            // pnlDoneInner
            // 
            pnlDoneInner.Controls.Add(lblDoneWait);
            pnlDoneInner.Controls.Add(lblDoneTime);
            pnlDoneInner.Controls.Add(lblDoneItems);
            pnlDoneInner.Controls.Add(flowDoneTitle);
            pnlDoneInner.Controls.Add(pnlCheck);
            pnlDoneInner.Dock = DockStyle.Fill;
            pnlDoneInner.Location = new Point(3, 3);
            pnlDoneInner.Name = "pnlDoneInner";
            pnlDoneInner.Size = new Size(474, 52);
            pnlDoneInner.TabIndex = 0;
            // 
            // pnlCheck
            // 
            pnlCheck.BackColor = Color.Transparent;
            pnlCheck.BorderColor = Color.FromArgb(229, 231, 235);
            pnlCheck.BorderSize = 0;
            pnlCheck.Controls.Add(lblCheck);
            pnlCheck.CornerRadius = 16;
            pnlCheck.FillColor = Color.FromArgb(220, 252, 231);
            pnlCheck.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlCheck.GradientStart = Color.FromArgb(124, 58, 237);
            pnlCheck.Location = new Point(12, 10);
            pnlCheck.Name = "pnlCheck";
            pnlCheck.Size = new Size(32, 32);
            pnlCheck.TabIndex = 0;
            // 
            // lblCheck
            // 
            lblCheck.Dock = DockStyle.Fill;
            lblCheck.Font = new Font("Segoe MDL2 Assets", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCheck.ForeColor = Color.FromArgb(22, 163, 74);
            lblCheck.Location = new Point(0, 0);
            lblCheck.Name = "lblCheck";
            lblCheck.Size = new Size(32, 32);
            lblCheck.TabIndex = 0;
            lblCheck.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowDoneTitle
            // 
            flowDoneTitle.AutoSize = true;
            flowDoneTitle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowDoneTitle.Controls.Add(lblDoneTicket);
            flowDoneTitle.Location = new Point(56, 9);
            flowDoneTitle.Margin = new Padding(0);
            flowDoneTitle.Name = "flowDoneTitle";
            flowDoneTitle.Size = new Size(120, 15);
            flowDoneTitle.TabIndex = 1;
            flowDoneTitle.WrapContents = false;
            // 
            // lblDoneTicket
            // 
            lblDoneTicket.AutoSize = true;
            lblDoneTicket.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDoneTicket.ForeColor = Color.FromArgb(17, 17, 27);
            lblDoneTicket.Location = new Point(0, 0);
            lblDoneTicket.Margin = new Padding(0, 0, 4, 0);
            lblDoneTicket.Name = "lblDoneTicket";
            lblDoneTicket.Size = new Size(59, 15);
            lblDoneTicket.TabIndex = 2;
            lblDoneTicket.Text = "Ticket 39";
            // 
            // lblDoneItems
            // 
            lblDoneItems.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDoneItems.AutoEllipsis = true;
            lblDoneItems.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDoneItems.ForeColor = Color.FromArgb(120, 124, 145);
            lblDoneItems.Location = new Point(56, 29);
            lblDoneItems.Name = "lblDoneItems";
            lblDoneItems.Size = new Size(280, 16);
            lblDoneItems.TabIndex = 2;
            lblDoneItems.Text = "Tropical Sunrise ×2, Green Machine";
            // 
            // lblDoneTime
            // 
            lblDoneTime.AutoSize = true;
            lblDoneTime.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDoneTime.ForeColor = Color.FromArgb(22, 163, 74);
            lblDoneTime.Location = new Point(370, 9);
            lblDoneTime.Name = "lblDoneTime";
            lblDoneTime.Size = new Size(55, 13);
            lblDoneTime.TabIndex = 3;
            lblDoneTime.Text = "12:44 PM";
            // 
            // lblDoneWait
            // 
            lblDoneWait.AutoSize = true;
            lblDoneWait.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDoneWait.ForeColor = Color.FromArgb(120, 124, 145);
            lblDoneWait.Location = new Point(370, 29);
            lblDoneWait.Name = "lblDoneWait";
            lblDoneWait.Size = new Size(51, 12);
            lblDoneWait.TabIndex = 4;
            lblDoneWait.Text = "19 min wait";
            // 
            // CompletedCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pnlCard);
            Name = "CompletedCard";
            Size = new Size(480, 58);
            pnlCard.ResumeLayout(false);
            pnlDoneInner.ResumeLayout(false);
            pnlDoneInner.PerformLayout();
            pnlCheck.ResumeLayout(false);
            flowDoneTitle.ResumeLayout(false);
            flowDoneTitle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel pnlCard;
        private Panel pnlDoneInner;
        private RoundedPanel pnlCheck;
        private Label lblDoneTicket;
        private FlowLayoutPanel flowDoneTitle;
        private Label lblCheck;
        private Label lblDoneTime;
        private Label lblDoneItems;
        private Label lblDoneWait;
    }
}
