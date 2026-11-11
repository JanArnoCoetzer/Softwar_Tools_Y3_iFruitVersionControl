namespace SmoothieTruckApp.Front_End
{
    partial class IngredientChip
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
            pnlChip = new RoundedPanel();
            flowChipInner = new FlowLayoutPanel();
            pnlChipDot = new RoundedPanel();
            lblChipName = new Label();
            pnlChipDivider = new Panel();
            lblChipGrams = new Label();
            pnlChip.SuspendLayout();
            flowChipInner.SuspendLayout();
            SuspendLayout();
            // 
            // pnlChip
            // 
            pnlChip.BackColor = Color.Transparent;
            pnlChip.BorderColor = Color.FromArgb(229, 231, 245);
            pnlChip.Controls.Add(flowChipInner);
            pnlChip.CornerRadius = 8;
            pnlChip.Dock = DockStyle.Fill;
            pnlChip.FillColor = Color.White;
            pnlChip.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlChip.GradientStart = Color.FromArgb(124, 58, 237);
            pnlChip.Location = new Point(0, 0);
            pnlChip.Name = "pnlChip";
            pnlChip.Size = new Size(100, 26);
            pnlChip.TabIndex = 0;
            // 
            // flowChipInner
            // 
            flowChipInner.AutoSize = true;
            flowChipInner.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowChipInner.Controls.Add(pnlChipDot);
            flowChipInner.Controls.Add(lblChipName);
            flowChipInner.Controls.Add(pnlChipDivider);
            flowChipInner.Controls.Add(lblChipGrams);
            flowChipInner.Location = new Point(9, 0);
            flowChipInner.Margin = new Padding(0);
            flowChipInner.Name = "flowChipInner";
            flowChipInner.Size = new Size(93, 19);
            flowChipInner.TabIndex = 0;
            flowChipInner.WrapContents = false;
            // 
            // pnlChipDot
            // 
            pnlChipDot.BackColor = Color.Transparent;
            pnlChipDot.BorderColor = Color.FromArgb(229, 231, 235);
            pnlChipDot.BorderSize = 0;
            pnlChipDot.CornerRadius = 2;
            pnlChipDot.FillColor = Color.FromArgb(59, 130, 246);
            pnlChipDot.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlChipDot.GradientStart = Color.FromArgb(124, 58, 237);
            pnlChipDot.Location = new Point(0, 10);
            pnlChipDot.Margin = new Padding(0, 10, 6, 0);
            pnlChipDot.Name = "pnlChipDot";
            pnlChipDot.Size = new Size(5, 5);
            pnlChipDot.TabIndex = 1;
            // 
            // lblChipName
            // 
            lblChipName.AutoSize = true;
            lblChipName.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblChipName.ForeColor = Color.FromArgb(75, 85, 99);
            lblChipName.Location = new Point(11, 6);
            lblChipName.Margin = new Padding(0, 6, 6, 0);
            lblChipName.Name = "lblChipName";
            lblChipName.Size = new Size(48, 13);
            lblChipName.TabIndex = 2;
            lblChipName.Text = "Spinach";
            // 
            // pnlChipDivider
            // 
            pnlChipDivider.BackColor = Color.FromArgb(229, 231, 235);
            pnlChipDivider.Location = new Point(65, 7);
            pnlChipDivider.Margin = new Padding(0, 7, 6, 0);
            pnlChipDivider.Name = "pnlChipDivider";
            pnlChipDivider.Size = new Size(1, 12);
            pnlChipDivider.TabIndex = 3;
            // 
            // lblChipGrams
            // 
            lblChipGrams.AutoSize = true;
            lblChipGrams.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChipGrams.ForeColor = Color.FromArgb(124, 58, 237);
            lblChipGrams.Location = new Point(72, 6);
            lblChipGrams.Margin = new Padding(0, 6, 0, 0);
            lblChipGrams.Name = "lblChipGrams";
            lblChipGrams.Size = new Size(21, 12);
            lblChipGrams.TabIndex = 4;
            lblChipGrams.Text = "60g";
            // 
            // IngredientChip
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pnlChip);
            Margin = new Padding(0, 0, 6, 0);
            Name = "IngredientChip";
            Size = new Size(100, 26);
            pnlChip.ResumeLayout(false);
            pnlChip.PerformLayout();
            flowChipInner.ResumeLayout(false);
            flowChipInner.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel pnlChip;
        private RoundedPanel pnlChipDot;
        private FlowLayoutPanel flowChipInner;
        private Label lblChipGrams;
        private Panel pnlChipDivider;
        private Label lblChipName;
    }
}
