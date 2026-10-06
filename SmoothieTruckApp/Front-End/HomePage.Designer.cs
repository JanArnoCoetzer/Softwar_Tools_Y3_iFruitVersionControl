namespace SmoothieTruckApp.Front_End
{
    partial class HomePage
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
            lblSubtitle = new Label();
            lblBrandTitle = new Label();
            roundedPanel1 = new RoundedPanel();
            Logo = new PictureBox();
            pnlCard.SuspendLayout();
            roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Logo).BeginInit();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.Anchor = AnchorStyles.None;
            pnlCard.BackColor = Color.Transparent;
            pnlCard.BorderColor = Color.FromArgb(229, 231, 235);
            pnlCard.Controls.Add(lblSubtitle);
            pnlCard.Controls.Add(lblBrandTitle);
            pnlCard.Controls.Add(roundedPanel1);
            pnlCard.CornerRadius = 24;
            pnlCard.FillColor = Color.White;
            pnlCard.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlCard.GradientStart = Color.FromArgb(124, 58, 237);
            pnlCard.Location = new Point(81, 74);
            pnlCard.Name = "pnlCard";
            pnlCard.ShadowSize = 20;
            pnlCard.Size = new Size(410, 380);
            pnlCard.TabIndex = 2;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = Color.FromArgb(120, 124, 145);
            lblSubtitle.Location = new Point(10, 178);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.RightToLeft = RightToLeft.No;
            lblSubtitle.Size = new Size(390, 24);
            lblSubtitle.TabIndex = 3;
            lblSubtitle.Text = "Smoothie stand & truck management";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            lblSubtitle.UseMnemonic = false;
            // 
            // lblBrandTitle
            // 
            lblBrandTitle.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBrandTitle.ForeColor = Color.FromArgb(17, 17, 27);
            lblBrandTitle.Location = new Point(10, 132);
            lblBrandTitle.Name = "lblBrandTitle";
            lblBrandTitle.Size = new Size(390, 44);
            lblBrandTitle.TabIndex = 2;
            lblBrandTitle.Text = "iBlendit";
            lblBrandTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // roundedPanel1
            // 
            roundedPanel1.BackColor = Color.Transparent;
            roundedPanel1.BorderColor = Color.FromArgb(229, 231, 235);
            roundedPanel1.BorderSize = 0;
            roundedPanel1.Controls.Add(Logo);
            roundedPanel1.CornerRadius = 18;
            roundedPanel1.FillColor = Color.White;
            roundedPanel1.GradientEnd = Color.FromArgb(6, 182, 212);
            roundedPanel1.GradientStart = Color.FromArgb(124, 58, 237);
            roundedPanel1.Location = new Point(172, 40);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Padding = new Padding(12);
            roundedPanel1.ShadowSize = 1;
            roundedPanel1.Size = new Size(66, 66);
            roundedPanel1.TabIndex = 1;
            roundedPanel1.UseGradient = true;
            // 
            // Logo
            // 
            Logo.Dock = DockStyle.Fill;
            Logo.Image = Properties.Resources.iblendfinal;
            Logo.Location = new Point(12, 12);
            Logo.Name = "Logo";
            Logo.Size = new Size(42, 42);
            Logo.SizeMode = PictureBoxSizeMode.Zoom;
            Logo.TabIndex = 0;
            Logo.TabStop = false;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 247);
            Controls.Add(pnlCard);
            Name = "HomePage";
            Size = new Size(580, 528);
            pnlCard.ResumeLayout(false);
            roundedPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Logo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel pnlCard;
        private Label lblSubtitle;
        private Label lblBrandTitle;
        private RoundedPanel roundedPanel1;
        private PictureBox Logo;
    }
}
