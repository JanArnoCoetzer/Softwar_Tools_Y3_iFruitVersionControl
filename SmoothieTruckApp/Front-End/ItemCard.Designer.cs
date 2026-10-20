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
            lblName = new Label();
            pnlAdd = new RoundedPanel();
            btnAdd = new Button();
            lblIngredients = new Label();
            lblPrice = new Label();
            pnlCard.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlAdd.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.Transparent;
            pnlCard.BorderColor = Color.White;
            pnlCard.Controls.Add(tableLayoutPanel1);
            pnlCard.CornerRadius = 14;
            pnlCard.Dock = DockStyle.Fill;
            pnlCard.FillColor = Color.White;
            pnlCard.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlCard.GradientStart = Color.FromArgb(124, 58, 237);
            pnlCard.Location = new Point(0, 0);
            pnlCard.Margin = new Padding(4, 5, 4, 5);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(457, 213);
            pnlCard.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 119F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(lblName, 1, 1);
            tableLayoutPanel1.Controls.Add(pnlAdd, 3, 4);
            tableLayoutPanel1.Controls.Add(lblIngredients, 1, 2);
            tableLayoutPanel1.Controls.Add(lblPrice, 1, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(457, 213);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblName, 2);
            lblName.Dock = DockStyle.Fill;
            lblName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(20, 20);
            lblName.Margin = new Padding(0);
            lblName.Name = "lblName";
            lblName.Size = new Size(377, 40);
            lblName.TabIndex = 2;
            lblName.Text = "ItemName";
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlAdd
            // 
            pnlAdd.BackColor = Color.Transparent;
            pnlAdd.BorderColor = Color.FromArgb(229, 231, 235);
            pnlAdd.BorderSize = 0;
            pnlAdd.Controls.Add(btnAdd);
            pnlAdd.CornerRadius = 8;
            pnlAdd.FillColor = Color.FromArgb(243, 238, 255);
            pnlAdd.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlAdd.GradientStart = Color.FromArgb(124, 58, 237);
            pnlAdd.Location = new Point(397, 153);
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
            // lblIngredients
            // 
            tableLayoutPanel1.SetColumnSpan(lblIngredients, 2);
            lblIngredients.Dock = DockStyle.Fill;
            lblIngredients.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIngredients.ForeColor = SystemColors.GrayText;
            lblIngredients.Location = new Point(20, 60);
            lblIngredients.Margin = new Padding(0);
            lblIngredients.Name = "lblIngredients";
            lblIngredients.Size = new Size(377, 20);
            lblIngredients.TabIndex = 3;
            lblIngredients.Text = "Item Ingredients";
            lblIngredients.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Dock = DockStyle.Fill;
            lblPrice.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.Purple;
            lblPrice.Location = new Point(20, 153);
            lblPrice.Margin = new Padding(0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(119, 40);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "$0.00";
            lblPrice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ItemCard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlCard);
            Margin = new Padding(0);
            Name = "ItemCard";
            Size = new Size(457, 213);
            pnlCard.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            pnlAdd.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel pnlCard;
        private Label lblName;
        private Label lblPrice;
        private Label lblIngredients;
        private RoundedPanel pnlAdd;
        private Button btnAdd;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
