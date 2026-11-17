namespace SmoothieTruckApp.Front_End
{
    partial class BlendRankRow
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
            pnlRank = new RoundedPanel();
            lblRank = new Label();
            lblBlendName = new Label();
            lblBlendSold = new Label();
            lblRevenue = new Label();
            pnlBarTrack = new RoundedPanel();
            pnlBarFill = new RoundedPanel();
            pnlRank.SuspendLayout();
            pnlBarTrack.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRank
            // 
            pnlRank.BorderColor = Color.FromArgb(229, 231, 235);
            pnlRank.BorderSize = 0;
            pnlRank.Controls.Add(lblRank);
            pnlRank.CornerRadius = 6;
            pnlRank.FillColor = Color.FromArgb(243, 240, 255);
            pnlRank.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlRank.GradientStart = Color.FromArgb(124, 58, 237);
            pnlRank.Location = new Point(14, 6);
            pnlRank.Name = "pnlRank";
            pnlRank.Size = new Size(22, 22);
            pnlRank.TabIndex = 0;
            // 
            // lblRank
            // 
            lblRank.Dock = DockStyle.Fill;
            lblRank.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRank.ForeColor = Color.FromArgb(124, 58, 237);
            lblRank.Location = new Point(0, 0);
            lblRank.Name = "lblRank";
            lblRank.Size = new Size(22, 22);
            lblRank.TabIndex = 0;
            lblRank.Text = "1";
            lblRank.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBlendName
            // 
            lblBlendName.AutoSize = true;
            lblBlendName.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBlendName.ForeColor = Color.FromArgb(17, 17, 27);
            lblBlendName.Location = new Point(42, 3);
            lblBlendName.Name = "lblBlendName";
            lblBlendName.Size = new Size(62, 13);
            lblBlendName.TabIndex = 1;
            lblBlendName.Text = "Berry Blast";
            // 
            // lblBlendSold
            // 
            lblBlendSold.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBlendSold.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBlendSold.ForeColor = Color.FromArgb(120, 124, 145);
            lblBlendSold.Location = new Point(70, 4);
            lblBlendSold.Name = "lblBlendSold";
            lblBlendSold.Size = new Size(100, 23);
            lblBlendSold.TabIndex = 2;
            lblBlendSold.Text = "24 sold";
            lblBlendSold.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblRevenue
            // 
            lblRevenue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRevenue.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRevenue.Location = new Point(256, 9);
            lblRevenue.Name = "lblRevenue";
            lblRevenue.Size = new Size(56, 16);
            lblRevenue.TabIndex = 3;
            lblRevenue.Text = "€210.00";
            lblRevenue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlBarTrack
            // 
            pnlBarTrack.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlBarTrack.BorderColor = Color.FromArgb(229, 231, 235);
            pnlBarTrack.BorderSize = 0;
            pnlBarTrack.Controls.Add(pnlBarFill);
            pnlBarTrack.CornerRadius = 2;
            pnlBarTrack.FillColor = Color.FromArgb(237, 238, 244);
            pnlBarTrack.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlBarTrack.GradientStart = Color.FromArgb(124, 58, 237);
            pnlBarTrack.Location = new Point(42, 22);
            pnlBarTrack.Name = "pnlBarTrack";
            pnlBarTrack.Size = new Size(206, 5);
            pnlBarTrack.TabIndex = 4;
            // 
            // pnlBarFill
            // 
            pnlBarFill.BorderColor = Color.FromArgb(229, 231, 235);
            pnlBarFill.BorderSize = 0;
            pnlBarFill.CornerRadius = 2;
            pnlBarFill.FillColor = Color.FromArgb(124, 58, 237);
            pnlBarFill.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlBarFill.GradientStart = Color.FromArgb(124, 58, 237);
            pnlBarFill.Location = new Point(0, 0);
            pnlBarFill.Name = "pnlBarFill";
            pnlBarFill.Size = new Size(206, 5);
            pnlBarFill.TabIndex = 0;
            // 
            // BlendRankRow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pnlBarTrack);
            Controls.Add(lblRevenue);
            Controls.Add(lblBlendSold);
            Controls.Add(lblBlendName);
            Controls.Add(pnlRank);
            Name = "BlendRankRow";
            Size = new Size(326, 34);
            pnlRank.ResumeLayout(false);
            pnlBarTrack.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundedPanel pnlRank;
        private Label lblRank;
        private Label lblBlendName;
        private Label lblBlendSold;
        private Label lblRevenue;
        private RoundedPanel pnlBarTrack;
        private RoundedPanel pnlBarFill;
    }
}
