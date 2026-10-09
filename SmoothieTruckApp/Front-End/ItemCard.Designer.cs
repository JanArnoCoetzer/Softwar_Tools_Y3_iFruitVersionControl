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
            picPhoto = new PictureBox();
            lblTag = new Label();
            lblName = new Label();
            lblIngredients = new Label();
            lblPrice = new Label();
            pnlAdd = new RoundedPanel();
            btnAdd = new Button();
            pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPhoto).BeginInit();
            pnlAdd.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.Transparent;
            pnlCard.BorderColor = Color.White;
            pnlCard.Controls.Add(pnlAdd);
            pnlCard.Controls.Add(lblPrice);
            pnlCard.Controls.Add(lblIngredients);
            pnlCard.Controls.Add(lblName);
            pnlCard.Controls.Add(lblTag);
            pnlCard.Controls.Add(picPhoto);
            pnlCard.CornerRadius = 14;
            pnlCard.Dock = DockStyle.Fill;
            pnlCard.FillColor = Color.White;
            pnlCard.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlCard.GradientStart = Color.FromArgb(124, 58, 237);
            pnlCard.Location = new Point(0, 0);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(320, 290);
            pnlCard.TabIndex = 0;
            // 
            // picPhoto
            // 
            picPhoto.Dock = DockStyle.Top;
            picPhoto.Location = new Point(0, 0);
            picPhoto.Name = "picPhoto";
            picPhoto.Size = new Size(320, 150);
            picPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            picPhoto.TabIndex = 0;
            picPhoto.TabStop = false;
            // 
            // lblTag
            // 
            lblTag.AutoSize = true;
            lblTag.BackColor = Color.Blue;
            lblTag.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTag.ForeColor = Color.White;
            lblTag.Location = new Point(15, 14);
            lblTag.Name = "lblTag";
            lblTag.Size = new Size(53, 15);
            lblTag.TabIndex = 1;
            lblTag.Text = "ItemTag";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(14, 163);
            lblName.Name = "lblName";
            lblName.Size = new Size(72, 17);
            lblName.TabIndex = 2;
            lblName.Text = "ItemName";
            // 
            // lblIngredients
            // 
            lblIngredients.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIngredients.ForeColor = SystemColors.GrayText;
            lblIngredients.Location = new Point(14, 191);
            lblIngredients.Name = "lblIngredients";
            lblIngredients.Size = new Size(97, 35);
            lblIngredients.TabIndex = 3;
            lblIngredients.Text = "Item Ingredients";
            // 
            // lblPrice
            // 
            lblPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.Purple;
            lblPrice.Location = new Point(14, 255);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(55, 23);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "$0.00";
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
            pnlAdd.Location = new Point(270, 250);
            pnlAdd.Name = "pnlAdd";
            pnlAdd.Size = new Size(28, 28);
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
            btnAdd.Size = new Size(28, 28);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // ItemCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlCard);
            Name = "ItemCard";
            Size = new Size(320, 290);
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPhoto).EndInit();
            pnlAdd.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel pnlCard;
        private Label lblTag;
        private PictureBox picPhoto;
        private Label lblName;
        private Label lblPrice;
        private Label lblIngredients;
        private RoundedPanel pnlAdd;
        private Button btnAdd;
    }
}
