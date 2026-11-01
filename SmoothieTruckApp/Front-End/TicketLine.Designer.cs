namespace SmoothieTruckApp.Front_End
{
    partial class TicketLine
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
            lblLineDot = new Label();
            lblLineName = new Label();
            pnlQty = new RoundedPanel();
            lblQty = new Label();
            pnlQty.SuspendLayout();
            SuspendLayout();
            // 
            // lblLineDot
            // 
            lblLineDot.AutoSize = true;
            lblLineDot.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLineDot.ForeColor = Color.FromArgb(196, 181, 253);
            lblLineDot.Location = new Point(0, 6);
            lblLineDot.Name = "lblLineDot";
            lblLineDot.Size = new Size(10, 11);
            lblLineDot.TabIndex = 0;
            lblLineDot.Text = "●";
            lblLineDot.Click += lblLineDot_Click;
            // 
            // lblLineName
            // 
            lblLineName.AutoSize = true;
            lblLineName.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLineName.ForeColor = Color.FromArgb(31, 41, 55);
            lblLineName.Location = new Point(14, 4);
            lblLineName.Name = "lblLineName";
            lblLineName.Size = new Size(60, 13);
            lblLineName.TabIndex = 1;
            lblLineName.Text = "Item name";
            // 
            // pnlQty
            // 
            pnlQty.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlQty.BackColor = Color.Transparent;
            pnlQty.BorderColor = Color.FromArgb(229, 231, 235);
            pnlQty.BorderSize = 0;
            pnlQty.Controls.Add(lblQty);
            pnlQty.CornerRadius = 5;
            pnlQty.FillColor = Color.FromArgb(243, 244, 246);
            pnlQty.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlQty.GradientStart = Color.FromArgb(124, 58, 237);
            pnlQty.Location = new Point(410, 3);
            pnlQty.Name = "pnlQty";
            pnlQty.Size = new Size(30, 18);
            pnlQty.TabIndex = 2;
            // 
            // lblQty
            // 
            lblQty.Dock = DockStyle.Fill;
            lblQty.ForeColor = Color.FromArgb(107, 114, 128);
            lblQty.Location = new Point(0, 0);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(30, 18);
            lblQty.TabIndex = 0;
            lblQty.Text = "x1";
            lblQty.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TicketLine
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pnlQty);
            Controls.Add(lblLineName);
            Controls.Add(lblLineDot);
            Name = "TicketLine";
            Size = new Size(440, 24);
            pnlQty.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLineDot;
        private Label lblLineName;
        private RoundedPanel pnlQty;
        private Label lblQty;
    }
}
