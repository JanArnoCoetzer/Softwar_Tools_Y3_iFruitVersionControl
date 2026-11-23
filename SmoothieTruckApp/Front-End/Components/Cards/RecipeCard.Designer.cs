namespace SmoothieTruckApp.Front_End
{
    partial class RecipeCard
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
            pnlRecipeInner = new Panel();
            pnlEditForm = new Panel();
            btnSaveChanges = new Button();
            btnAddIngredient = new Button();
            txtAmount = new TextBox();
            cboUnit = new ComboBox();
            txtPrice = new TextBox();
            lblPriceCaption = new Label();
            txtIngredientName = new TextBox();
            lblAmountCaption = new Label();
            lblIngredientCaption = new Label();
            pnlEditLine = new Panel();
            pnlRecipeTop = new Panel();
            txtCatagory = new TextBox();
            lblRecipeName = new TextBox();
            flowChips = new FlowLayoutPanel();
            btnRemoveRecipe = new Button();
            btnEditRecipe = new Button();
            lblRecipeTime = new Label();
            pnlNumber = new RoundedPanel();
            lblNumber = new Label();
            pnlCard.SuspendLayout();
            pnlRecipeInner.SuspendLayout();
            pnlEditForm.SuspendLayout();
            pnlRecipeTop.SuspendLayout();
            pnlNumber.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.Transparent;
            pnlCard.BorderColor = Color.FromArgb(236, 238, 242);
            pnlCard.Controls.Add(pnlRecipeInner);
            pnlCard.CornerRadius = 12;
            pnlCard.Dock = DockStyle.Fill;
            pnlCard.FillColor = Color.White;
            pnlCard.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlCard.GradientStart = Color.FromArgb(124, 58, 237);
            pnlCard.Location = new Point(0, 0);
            pnlCard.Name = "pnlCard";
            pnlCard.Padding = new Padding(3);
            pnlCard.ShadowSize = 3;
            pnlCard.Size = new Size(960, 96);
            pnlCard.TabIndex = 0;
            // 
            // pnlRecipeInner
            // 
            pnlRecipeInner.Controls.Add(pnlEditForm);
            pnlRecipeInner.Controls.Add(pnlRecipeTop);
            pnlRecipeInner.Dock = DockStyle.Fill;
            pnlRecipeInner.Location = new Point(3, 3);
            pnlRecipeInner.Name = "pnlRecipeInner";
            pnlRecipeInner.Size = new Size(954, 90);
            pnlRecipeInner.TabIndex = 0;
            // 
            // pnlEditForm
            // 
            pnlEditForm.Controls.Add(btnSaveChanges);
            pnlEditForm.Controls.Add(btnAddIngredient);
            pnlEditForm.Controls.Add(txtAmount);
            pnlEditForm.Controls.Add(cboUnit);
            pnlEditForm.Controls.Add(txtPrice);
            pnlEditForm.Controls.Add(lblPriceCaption);
            pnlEditForm.Controls.Add(txtIngredientName);
            pnlEditForm.Controls.Add(lblAmountCaption);
            pnlEditForm.Controls.Add(lblIngredientCaption);
            pnlEditForm.Controls.Add(pnlEditLine);
            pnlEditForm.Dock = DockStyle.Top;
            pnlEditForm.Location = new Point(0, 90);
            pnlEditForm.Name = "pnlEditForm";
            pnlEditForm.Size = new Size(954, 62);
            pnlEditForm.TabIndex = 1;
            pnlEditForm.Visible = false;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveChanges.BackColor = Color.FromArgb(124, 58, 237);
            btnSaveChanges.ForeColor = Color.White;
            btnSaveChanges.Location = new Point(772, 27);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(75, 23);
            btnSaveChanges.TabIndex = 6;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = false;
            // 
            // btnAddIngredient
            // 
            btnAddIngredient.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddIngredient.BackColor = Color.FromArgb(243, 244, 246);
            btnAddIngredient.ForeColor = Color.FromArgb(156, 163, 175);
            btnAddIngredient.Location = new Point(680, 27);
            btnAddIngredient.Name = "btnAddIngredient";
            btnAddIngredient.Size = new Size(75, 23);
            btnAddIngredient.TabIndex = 5;
            btnAddIngredient.Text = "+ Add ingredient";
            btnAddIngredient.UseVisualStyleBackColor = false;
            // 
            // txtAmount
            // 
            txtAmount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAmount.Location = new Point(584, 28);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(48, 23);
            txtAmount.TabIndex = 4;
            txtAmount.Text = "0";
            txtAmount.TextAlign = HorizontalAlignment.Right;
            //
            // cboUnit
            //
            cboUnit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUnit.Items.AddRange(new object[] { "g", "ml" });
            cboUnit.Location = new Point(636, 28);
            cboUnit.Name = "cboUnit";
            cboUnit.Size = new Size(40, 23);
            cboUnit.TabIndex = 5;
            //
            // txtPrice
            //
            txtPrice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPrice.Location = new Point(484, 28);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(92, 23);
            txtPrice.TabIndex = 2;
            txtPrice.Text = "0.00";
            txtPrice.TextAlign = HorizontalAlignment.Right;
            //
            // lblPriceCaption
            //
            lblPriceCaption.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPriceCaption.AutoSize = true;
            lblPriceCaption.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPriceCaption.ForeColor = Color.FromArgb(120, 124, 145);
            lblPriceCaption.Location = new Point(484, 10);
            lblPriceCaption.Name = "lblPriceCaption";
            lblPriceCaption.Size = new Size(34, 12);
            lblPriceCaption.TabIndex = 7;
            lblPriceCaption.Text = "PRICE";
            //
            // txtIngredientName
            // 
            txtIngredientName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtIngredientName.BorderStyle = BorderStyle.FixedSingle;
            txtIngredientName.Location = new Point(56, 28);
            txtIngredientName.Name = "txtIngredientName";
            txtIngredientName.Size = new Size(420, 23);
            txtIngredientName.TabIndex = 3;
            txtIngredientName.Text = "e.g. Chia seeds";
            // 
            // lblAmountCaption
            // 
            lblAmountCaption.AutoSize = true;
            lblAmountCaption.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAmountCaption.ForeColor = Color.FromArgb(120, 124, 145);
            lblAmountCaption.Location = new Point(584, 10);
            lblAmountCaption.Name = "lblAmountCaption";
            lblAmountCaption.Size = new Size(46, 12);
            lblAmountCaption.TabIndex = 2;
            lblAmountCaption.Text = "AMOUNT";
            // 
            // lblIngredientCaption
            // 
            lblIngredientCaption.AutoSize = true;
            lblIngredientCaption.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIngredientCaption.ForeColor = Color.FromArgb(120, 124, 145);
            lblIngredientCaption.Location = new Point(56, 10);
            lblIngredientCaption.Name = "lblIngredientCaption";
            lblIngredientCaption.Size = new Size(88, 12);
            lblIngredientCaption.TabIndex = 1;
            lblIngredientCaption.Text = "INGREDIENT NAME";
            // 
            // pnlEditLine
            // 
            pnlEditLine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlEditLine.BackColor = Color.FromArgb(236, 238, 242);
            pnlEditLine.Location = new Point(56, 0);
            pnlEditLine.Name = "pnlEditLine";
            pnlEditLine.Size = new Size(780, 1);
            pnlEditLine.TabIndex = 0;
            // 
            // pnlRecipeTop
            // 
            pnlRecipeTop.Controls.Add(txtCatagory);
            pnlRecipeTop.Controls.Add(lblRecipeName);
            pnlRecipeTop.Controls.Add(flowChips);
            pnlRecipeTop.Controls.Add(btnRemoveRecipe);
            pnlRecipeTop.Controls.Add(btnEditRecipe);
            pnlRecipeTop.Controls.Add(lblRecipeTime);
            pnlRecipeTop.Controls.Add(pnlNumber);
            pnlRecipeTop.Dock = DockStyle.Top;
            pnlRecipeTop.Location = new Point(0, 0);
            pnlRecipeTop.Name = "pnlRecipeTop";
            pnlRecipeTop.Size = new Size(954, 90);
            pnlRecipeTop.TabIndex = 0;
            // 
            // txtCatagory
            // 
            txtCatagory.BorderStyle = BorderStyle.None;
            txtCatagory.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold);
            txtCatagory.ForeColor = Color.FromArgb(124, 58, 237);
            txtCatagory.Location = new Point(56, 35);
            txtCatagory.Name = "txtCatagory";
            txtCatagory.Size = new Size(442, 12);
            txtCatagory.TabIndex = 10;
            txtCatagory.Text = "Test Catagory";
            // 
            // lblRecipeName
            // 
            lblRecipeName.BorderStyle = BorderStyle.None;
            lblRecipeName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRecipeName.Location = new Point(56, 11);
            lblRecipeName.Margin = new Padding(0);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(442, 18);
            lblRecipeName.TabIndex = 7;
            lblRecipeName.Text = "Test Name";
            // 
            // flowChips
            // 
            flowChips.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowChips.Location = new Point(56, 56);
            flowChips.Margin = new Padding(0);
            flowChips.Name = "flowChips";
            flowChips.Size = new Size(720, 28);
            flowChips.TabIndex = 6;
            flowChips.WrapContents = false;
            // 
            // btnRemoveRecipe
            // 
            btnRemoveRecipe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemoveRecipe.Cursor = Cursors.Hand;
            btnRemoveRecipe.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
            btnRemoveRecipe.FlatStyle = FlatStyle.Flat;
            btnRemoveRecipe.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoveRecipe.ForeColor = Color.FromArgb(220, 38, 38);
            btnRemoveRecipe.Location = new Point(878, 32);
            btnRemoveRecipe.Name = "btnRemoveRecipe";
            btnRemoveRecipe.Size = new Size(62, 28);
            btnRemoveRecipe.TabIndex = 5;
            btnRemoveRecipe.Text = "Remove";
            btnRemoveRecipe.UseVisualStyleBackColor = true;
            // 
            // btnEditRecipe
            // 
            btnEditRecipe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditRecipe.Cursor = Cursors.Hand;
            btnEditRecipe.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnEditRecipe.FlatStyle = FlatStyle.Flat;
            btnEditRecipe.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditRecipe.ForeColor = Color.FromArgb(75, 85, 99);
            btnEditRecipe.Location = new Point(794, 32);
            btnEditRecipe.Name = "btnEditRecipe";
            btnEditRecipe.Size = new Size(76, 28);
            btnEditRecipe.TabIndex = 4;
            btnEditRecipe.Text = "Edit Recipe";
            btnEditRecipe.UseVisualStyleBackColor = true;
            // 
            // lblRecipeTime
            // 
            lblRecipeTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRecipeTime.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRecipeTime.ForeColor = Color.FromArgb(120, 124, 145);
            lblRecipeTime.Location = new Point(622, 10);
            lblRecipeTime.Name = "lblRecipeTime";
            lblRecipeTime.Size = new Size(160, 16);
            lblRecipeTime.TabIndex = 3;
            lblRecipeTime.Text = "Today, 9:42 AM";
            lblRecipeTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlNumber
            // 
            pnlNumber.BackColor = Color.Transparent;
            pnlNumber.BorderColor = Color.FromArgb(229, 231, 235);
            pnlNumber.BorderSize = 0;
            pnlNumber.Controls.Add(lblNumber);
            pnlNumber.CornerRadius = 8;
            pnlNumber.FillColor = Color.FromArgb(237, 242, 255);
            pnlNumber.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlNumber.GradientStart = Color.FromArgb(124, 58, 237);
            pnlNumber.Location = new Point(14, 14);
            pnlNumber.Name = "pnlNumber";
            pnlNumber.Size = new Size(32, 32);
            pnlNumber.TabIndex = 0;
            // 
            // lblNumber
            // 
            lblNumber.Dock = DockStyle.Fill;
            lblNumber.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumber.ForeColor = Color.FromArgb(124, 58, 237);
            lblNumber.Location = new Point(0, 0);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(32, 32);
            lblNumber.TabIndex = 0;
            lblNumber.Text = "01";
            lblNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RecipeCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pnlCard);
            Name = "RecipeCard";
            Size = new Size(960, 96);
            pnlCard.ResumeLayout(false);
            pnlRecipeInner.ResumeLayout(false);
            pnlEditForm.ResumeLayout(false);
            pnlEditForm.PerformLayout();
            pnlRecipeTop.ResumeLayout(false);
            pnlRecipeTop.PerformLayout();
            pnlNumber.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel pnlCard;
        private Panel pnlRecipeInner;
        private Panel pnlRecipeTop;
        private RoundedPanel pnlNumber;
        private Label textBox1;
        private Label lblNumber;
        private Button btnEditRecipe;
        private Label lblRecipeTime;
        private Button btnRemoveRecipe;
        private FlowLayoutPanel flowChips;
        private Panel pnlEditForm;
        private Label lblAmountCaption;
        private Label lblIngredientCaption;
        private Panel pnlEditLine;
        private TextBox txtAmount;
        private ComboBox cboUnit;
        private TextBox txtPrice;
        private Label lblPriceCaption;
        private TextBox txtIngredientName;
        private Button btnSaveChanges;
        private Button btnAddIngredient;
        private TextBox lblRecipeName;
        private TextBox txtCatagory;
    }
}
