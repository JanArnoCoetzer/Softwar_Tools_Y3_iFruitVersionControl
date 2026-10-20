namespace SmoothieTruckApp.Front_End
{
    partial class ItemCard
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            rbCatagoryNameBackground = new RoundedPanel();
            txtCatagoryLabel = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            lblIngredients = new Label();
            lblName = new Label();
            lblPrice = new Label();
            pnlAdd = new RoundedPanel();
            btnAdd = new Button();
            CatagoryDivisionLine = new PictureBox();
            pnlCard.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            rbCatagoryNameBackground.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            pnlAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CatagoryDivisionLine).BeginInit();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.Transparent;
            pnlCard.BorderColor = Color.White;
            pnlCard.Controls.Add(tableLayoutPanel1);
            pnlCard.CornerRadius = 14;
            pnlCard.Dock = DockStyle.Fill;
            pnlCard.FillColor = Color.FromArgb(248, 248, 253);
            pnlCard.GradientAngle = 90F;
            pnlCard.GradientEnd = Color.White;
            pnlCard.GradientHardness = 1F;
            pnlCard.GradientPosition = 0.27124F;
            pnlCard.GradientStart = Color.FromArgb(246, 247, 252);
            pnlCard.Location = new Point(0, 0);
            pnlCard.Margin = new Padding(4, 5, 4, 5);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(457, 306);
            pnlCard.TabIndex = 0;
            pnlCard.UseGradient = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Controls.Add(CatagoryDivisionLine, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 3F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(457, 306);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.Transparent;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(rbCatagoryNameBackground, 1, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(457, 80);
            tableLayoutPanel2.TabIndex = 8;
            // 
            // rbCatagoryNameBackground
            // 
            rbCatagoryNameBackground.BackColor = Color.Transparent;
            rbCatagoryNameBackground.BorderColor = Color.FromArgb(229, 231, 235);
            rbCatagoryNameBackground.Controls.Add(txtCatagoryLabel);
            rbCatagoryNameBackground.CornerRadius = 8;
            rbCatagoryNameBackground.Dock = DockStyle.Fill;
            rbCatagoryNameBackground.FillColor = Color.FromArgb(146, 82, 160);
            rbCatagoryNameBackground.GradientEnd = Color.FromArgb(6, 182, 212);
            rbCatagoryNameBackground.GradientStart = Color.FromArgb(124, 58, 237);
            rbCatagoryNameBackground.Location = new Point(20, 22);
            rbCatagoryNameBackground.Margin = new Padding(0, 2, 0, 2);
            rbCatagoryNameBackground.Name = "rbCatagoryNameBackground";
            rbCatagoryNameBackground.Size = new Size(80, 36);
            rbCatagoryNameBackground.TabIndex = 0;
            // 
            // txtCatagoryLabel
            // 
            txtCatagoryLabel.Dock = DockStyle.Fill;
            txtCatagoryLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            txtCatagoryLabel.ForeColor = Color.White;
            txtCatagoryLabel.Location = new Point(0, 0);
            txtCatagoryLabel.Margin = new Padding(0);
            txtCatagoryLabel.Name = "txtCatagoryLabel";
            txtCatagoryLabel.Size = new Size(80, 36);
            txtCatagoryLabel.TabIndex = 0;
            txtCatagoryLabel.Text = "Berry";
            txtCatagoryLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Controls.Add(lblIngredients, 1, 1);
            tableLayoutPanel3.Controls.Add(lblName, 1, 0);
            tableLayoutPanel3.Controls.Add(lblPrice, 1, 3);
            tableLayoutPanel3.Controls.Add(pnlAdd, 2, 3);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 83);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 5;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(457, 223);
            tableLayoutPanel3.TabIndex = 9;
            // 
            // lblIngredients
            // 
            tableLayoutPanel3.SetColumnSpan(lblIngredients, 2);
            lblIngredients.Dock = DockStyle.Fill;
            lblIngredients.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            lblIngredients.ForeColor = Color.FromArgb(148, 147, 165);
            lblIngredients.Location = new Point(20, 40);
            lblIngredients.Margin = new Padding(0);
            lblIngredients.Name = "lblIngredients";
            lblIngredients.Size = new Size(417, 20);
            lblIngredients.TabIndex = 9;
            lblIngredients.Text = "Item Ingredients";
            lblIngredients.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            tableLayoutPanel3.SetColumnSpan(lblName, 2);
            lblName.Dock = DockStyle.Fill;
            lblName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(20, 0);
            lblName.Margin = new Padding(0);
            lblName.Name = "lblName";
            lblName.Size = new Size(417, 40);
            lblName.TabIndex = 8;
            lblName.Text = "ItemName";
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Dock = DockStyle.Fill;
            lblPrice.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.Purple;
            lblPrice.Location = new Point(20, 163);
            lblPrice.Margin = new Padding(0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(377, 40);
            lblPrice.TabIndex = 7;
            lblPrice.Text = "$0.00";
            lblPrice.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlAdd
            // 
            pnlAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pnlAdd.BackColor = Color.Transparent;
            pnlAdd.BorderColor = Color.FromArgb(229, 231, 235);
            pnlAdd.BorderSize = 0;
            pnlAdd.Controls.Add(btnAdd);
            pnlAdd.CornerRadius = 8;
            pnlAdd.FillColor = Color.FromArgb(243, 238, 255);
            pnlAdd.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlAdd.GradientStart = Color.FromArgb(124, 58, 237);
            pnlAdd.Location = new Point(397, 163);
            pnlAdd.Margin = new Padding(0);
            pnlAdd.Name = "pnlAdd";
            pnlAdd.Size = new Size(40, 40);
            pnlAdd.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatAppearance.MouseDownBackColor = Color.FromArgb(243, 238, 255);
            btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(243, 238, 255);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.FromArgb(124, 58, 237);
            btnAdd.Location = new Point(0, 0);
            btnAdd.Margin = new Padding(0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(40, 40);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "+";
            btnAdd.TextAlign = ContentAlignment.MiddleRight;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // CatagoryDivisionLine
            // 
            CatagoryDivisionLine.BackColor = Color.FromArgb(123, 45, 139);
            CatagoryDivisionLine.Dock = DockStyle.Fill;
            CatagoryDivisionLine.Location = new Point(0, 80);
            CatagoryDivisionLine.Margin = new Padding(0);
            CatagoryDivisionLine.Name = "CatagoryDivisionLine";
            CatagoryDivisionLine.Size = new Size(457, 3);
            CatagoryDivisionLine.TabIndex = 10;
            CatagoryDivisionLine.TabStop = false;
            // 
            // ItemCard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pnlCard);
            Margin = new Padding(0);
            Name = "ItemCard";
            Size = new Size(457, 306);
            pnlCard.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            rbCatagoryNameBackground.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            pnlAdd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CatagoryDivisionLine).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel pnlCard;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel3;
        private RoundedPanel pnlAdd;
        private Button btnAdd;
        private Label lblPrice;
        private Label lblIngredients;
        private Label lblName;
        private PictureBox CatagoryDivisionLine;
        private TableLayoutPanel tableLayoutPanel2;
        private RoundedPanel rbCatagoryNameBackground;
        private Label txtCatagoryLabel;
    }
}
