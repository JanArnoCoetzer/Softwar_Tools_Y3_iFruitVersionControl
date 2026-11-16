namespace SmoothieTruckApp.Front_End
{
    partial class StockRow
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
            pnlRowLine = new Panel();
            lblStockName = new Label();
            lblStockCategory = new Label();
            lblStockGrams = new Label();
            pnlStatus = new RoundedPanel();
            lblStatus = new Label();
            btnRemoveStock = new Button();
            btnAddStock = new Button();
            lblStockStep = new Label();
            pnlStatus.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRowLine
            // 
            pnlRowLine.BackColor = Color.FromArgb(243, 244, 246);
            pnlRowLine.Dock = DockStyle.Bottom;
            pnlRowLine.Location = new Point(0, 45);
            pnlRowLine.Name = "pnlRowLine";
            pnlRowLine.Size = new Size(954, 1);
            pnlRowLine.TabIndex = 0;
            // 
            // lblStockName
            // 
            lblStockName.AutoSize = true;
            lblStockName.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStockName.ForeColor = Color.FromArgb(17, 17, 27);
            lblStockName.Location = new Point(14, 8);
            lblStockName.Name = "lblStockName";
            lblStockName.Size = new Size(48, 13);
            lblStockName.TabIndex = 1;
            lblStockName.Text = "Spinach";
            // 
            // lblStockCategory
            // 
            lblStockCategory.AutoSize = true;
            lblStockCategory.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStockCategory.ForeColor = Color.FromArgb(120, 124, 145);
            lblStockCategory.Location = new Point(14, 24);
            lblStockCategory.Name = "lblStockCategory";
            lblStockCategory.Size = new Size(55, 12);
            lblStockCategory.TabIndex = 2;
            lblStockCategory.Text = "Fresh greens";
            // 
            // lblStockGrams
            // 
            lblStockGrams.AutoSize = true;
            lblStockGrams.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStockGrams.ForeColor = Color.FromArgb(17, 17, 27);
            lblStockGrams.Location = new Point(290, 11);
            lblStockGrams.Name = "lblStockGrams";
            lblStockGrams.Size = new Size(62, 20);
            lblStockGrams.TabIndex = 3;
            lblStockGrams.Text = "1,350 g";
            // 
            // pnlStatus
            // 
            pnlStatus.BackColor = Color.Transparent;
            pnlStatus.BorderColor = Color.FromArgb(229, 231, 235);
            pnlStatus.BorderSize = 0;
            pnlStatus.Controls.Add(lblStatus);
            pnlStatus.CornerRadius = 10;
            pnlStatus.FillColor = Color.FromArgb(220, 252, 231);
            pnlStatus.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlStatus.GradientStart = Color.FromArgb(124, 58, 237);
            pnlStatus.Location = new Point(430, 13);
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Size = new Size(80, 20);
            pnlStatus.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.FromArgb(22, 163, 74);
            lblStatus.Location = new Point(0, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(80, 20);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "● In Stock";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnRemoveStock
            // 
            btnRemoveStock.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemoveStock.BackColor = Color.White;
            btnRemoveStock.Cursor = Cursors.Hand;
            btnRemoveStock.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnRemoveStock.FlatStyle = FlatStyle.Flat;
            btnRemoveStock.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoveStock.ForeColor = Color.FromArgb(185, 28, 28);
            btnRemoveStock.Location = new Point(582, 8);
            btnRemoveStock.Name = "btnRemoveStock";
            btnRemoveStock.Size = new Size(158, 30);
            btnRemoveStock.TabIndex = 5;
            btnRemoveStock.Text = "−  Remove Stock";
            btnRemoveStock.UseVisualStyleBackColor = false;
            // 
            // btnAddStock
            // 
            btnAddStock.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddStock.BackColor = Color.White;
            btnAddStock.Cursor = Cursors.Hand;
            btnAddStock.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnAddStock.FlatStyle = FlatStyle.Flat;
            btnAddStock.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddStock.ForeColor = Color.FromArgb(109, 40, 217);
            btnAddStock.Location = new Point(782, 8);
            btnAddStock.Name = "btnAddStock";
            btnAddStock.Size = new Size(158, 30);
            btnAddStock.TabIndex = 6;
            btnAddStock.Text = "+  Add Stock";
            btnAddStock.UseVisualStyleBackColor = false;
            // 
            // lblStockStep
            // 
            lblStockStep.BackColor = Color.Transparent;
            lblStockStep.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStockStep.ForeColor = Color.FromArgb(17, 17, 27);
            lblStockStep.Location = new Point(746, 15);
            lblStockStep.Name = "lblStockStep";
            lblStockStep.Size = new Size(30, 16);
            lblStockStep.TabIndex = 7;
            lblStockStep.Text = "100g";
            lblStockStep.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StockRow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblStockStep);
            Controls.Add(btnAddStock);
            Controls.Add(btnRemoveStock);
            Controls.Add(pnlStatus);
            Controls.Add(lblStockGrams);
            Controls.Add(lblStockCategory);
            Controls.Add(lblStockName);
            Controls.Add(pnlRowLine);
            Name = "StockRow";
            Size = new Size(954, 46);
            pnlStatus.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlRowLine;
        private Label lblStockName;
        private Label lblStockCategory;
        private Label lblStockGrams;
        private RoundedPanel pnlStatus;
        private Label lblStatus;
        private Button btnRemoveStock;
        private Button btnAddStock;
        private Label lblStockStep;
    }
}
