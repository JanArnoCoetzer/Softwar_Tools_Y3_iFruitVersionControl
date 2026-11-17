namespace SmoothieTruckApp.Front_End
{
    partial class StatCard
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
            pnlStatIcon = new RoundedPanel();
            lblStatIcon = new Label();
            lblStatCaption = new Label();
            lblStatValue = new Label();
            flowStatSub = new FlowLayoutPanel();
            lblStatDelta = new Label();
            lblStatSub = new Label();
            pnlCard.SuspendLayout();
            pnlStatIcon.SuspendLayout();
            flowStatSub.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BorderColor = Color.FromArgb(236, 238, 242);
            pnlCard.Controls.Add(flowStatSub);
            pnlCard.Controls.Add(lblStatValue);
            pnlCard.Controls.Add(lblStatCaption);
            pnlCard.Controls.Add(pnlStatIcon);
            pnlCard.CornerRadius = 14;
            pnlCard.Dock = DockStyle.Fill;
            pnlCard.FillColor = Color.White;
            pnlCard.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlCard.GradientStart = Color.FromArgb(124, 58, 237);
            pnlCard.Location = new Point(0, 0);
            pnlCard.Name = "pnlCard";
            pnlCard.Padding = new Padding(3);
            pnlCard.ShadowSize = 3;
            pnlCard.Size = new Size(310, 86);
            pnlCard.TabIndex = 0;
            // 
            // pnlStatIcon
            // 
            pnlStatIcon.BorderColor = Color.FromArgb(229, 231, 235);
            pnlStatIcon.BorderSize = 0;
            pnlStatIcon.Controls.Add(lblStatIcon);
            pnlStatIcon.CornerRadius = 9;
            pnlStatIcon.FillColor = Color.FromArgb(237, 233, 254);
            pnlStatIcon.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlStatIcon.GradientStart = Color.FromArgb(124, 58, 237);
            pnlStatIcon.Location = new Point(14, 27);
            pnlStatIcon.Name = "pnlStatIcon";
            pnlStatIcon.Size = new Size(32, 32);
            pnlStatIcon.TabIndex = 0;
            // 
            // lblStatIcon
            // 
            lblStatIcon.BackColor = Color.Transparent;
            lblStatIcon.Dock = DockStyle.Fill;
            lblStatIcon.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatIcon.ForeColor = Color.FromArgb(124, 58, 237);
            lblStatIcon.Location = new Point(0, 0);
            lblStatIcon.Name = "lblStatIcon";
            lblStatIcon.Size = new Size(32, 32);
            lblStatIcon.TabIndex = 0;
            lblStatIcon.Text = "€";
            lblStatIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatCaption
            // 
            lblStatCaption.AutoSize = true;
            lblStatCaption.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatCaption.ForeColor = Color.FromArgb(120, 124, 145);
            lblStatCaption.Location = new Point(56, 15);
            lblStatCaption.Name = "lblStatCaption";
            lblStatCaption.Size = new Size(88, 13);
            lblStatCaption.TabIndex = 1;
            lblStatCaption.Text = "Total Daily Sales";
            // 
            // lblStatValue
            // 
            lblStatValue.AutoSize = true;
            lblStatValue.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatValue.ForeColor = Color.FromArgb(17, 17, 27);
            lblStatValue.Location = new Point(54, 28);
            lblStatValue.Name = "lblStatValue";
            lblStatValue.Size = new Size(106, 28);
            lblStatValue.TabIndex = 2;
            lblStatValue.Text = "€1,284.50";
            // 
            // flowStatSub
            // 
            flowStatSub.AutoSize = true;
            flowStatSub.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowStatSub.Controls.Add(lblStatDelta);
            flowStatSub.Controls.Add(lblStatSub);
            flowStatSub.Location = new Point(56, 58);
            flowStatSub.Margin = new Padding(0);
            flowStatSub.Name = "flowStatSub";
            flowStatSub.Size = new Size(113, 12);
            flowStatSub.TabIndex = 3;
            flowStatSub.WrapContents = false;
            // 
            // lblStatDelta
            // 
            lblStatDelta.AutoSize = true;
            lblStatDelta.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatDelta.ForeColor = Color.FromArgb(22, 163, 74);
            lblStatDelta.Location = new Point(0, 0);
            lblStatDelta.Margin = new Padding(0, 0, 3, 0);
            lblStatDelta.Name = "lblStatDelta";
            lblStatDelta.Size = new Size(36, 12);
            lblStatDelta.TabIndex = 0;
            lblStatDelta.Text = "+12.8%";
            // 
            // lblStatSub
            // 
            lblStatSub.AutoSize = true;
            lblStatSub.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatSub.ForeColor = Color.FromArgb(120, 124, 145);
            lblStatSub.Location = new Point(39, 0);
            lblStatSub.Margin = new Padding(0);
            lblStatSub.Name = "lblStatSub";
            lblStatSub.Size = new Size(74, 12);
            lblStatSub.TabIndex = 1;
            lblStatSub.Text = "from last Monday";
            // 
            // StatCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlCard);
            Name = "StatCard";
            Size = new Size(310, 86);
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            pnlStatIcon.ResumeLayout(false);
            flowStatSub.ResumeLayout(false);
            flowStatSub.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel pnlCard;
        private Label lblStatValue;
        private Label lblStatCaption;
        private RoundedPanel pnlStatIcon;
        private Label lblStatIcon;
        private FlowLayoutPanel flowStatSub;
        private Label lblStatDelta;
        private Label lblStatSub;
    }
}
