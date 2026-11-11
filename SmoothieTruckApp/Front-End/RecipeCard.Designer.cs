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
            pnlRecipeTop = new Panel();
            flowChips = new FlowLayoutPanel();
            btnRemoveRecipe = new Button();
            btnEditRecipe = new Button();
            lblRecipeTime = new Label();
            lblRecipeCategory = new Label();
            lblRecipeName = new Label();
            pnlNumber = new RoundedPanel();
            lblNumber = new Label();
            pnlEditForm = new Panel();
            pnlEditLine = new Panel();
            lblIngredientCaption = new Label();
            lblAmountCaption = new Label();
            txtIngredientName = new TextBox();
            txtAmount = new TextBox();
            btnAddIngredient = new Button();
            btnSaveChanges = new Button();
            pnlCard.SuspendLayout();
            pnlRecipeInner.SuspendLayout();
            pnlRecipeTop.SuspendLayout();
            pnlNumber.SuspendLayout();
            pnlEditForm.SuspendLayout();
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
            // pnlRecipeTop
            // 
            pnlRecipeTop.Controls.Add(flowChips);
            pnlRecipeTop.Controls.Add(btnRemoveRecipe);
            pnlRecipeTop.Controls.Add(btnEditRecipe);
            pnlRecipeTop.Controls.Add(lblRecipeTime);
            pnlRecipeTop.Controls.Add(lblRecipeCategory);
            pnlRecipeTop.Controls.Add(lblRecipeName);
            pnlRecipeTop.Controls.Add(pnlNumber);
            pnlRecipeTop.Dock = DockStyle.Top;
            pnlRecipeTop.Location = new Point(0, 0);
            pnlRecipeTop.Name = "pnlRecipeTop";
            pnlRecipeTop.Size = new Size(954, 90);
            pnlRecipeTop.TabIndex = 0;
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
            // lblRecipeCategory
            // 
            lblRecipeCategory.AutoSize = true;
            lblRecipeCategory.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecipeCategory.ForeColor = Color.FromArgb(124, 58, 237);
            lblRecipeCategory.Location = new Point(56, 36);
            lblRecipeCategory.Name = "lblRecipeCategory";
            lblRecipeCategory.Size = new Size(34, 12);
            lblRecipeCategory.TabIndex = 2;
            lblRecipeCategory.Text = "GREEN";
            // 
            // lblRecipeName
            // 
            lblRecipeName.AutoSize = true;
            lblRecipeName.BackColor = Color.Transparent;
            lblRecipeName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecipeName.ForeColor = Color.FromArgb(17, 17, 27);
            lblRecipeName.Location = new Point(56, 14);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(100, 17);
            lblRecipeName.TabIndex = 1;
            lblRecipeName.Text = "Green Machine";
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
            // pnlEditForm
            // 
            pnlEditForm.Controls.Add(btnSaveChanges);
            pnlEditForm.Controls.Add(btnAddIngredient);
            pnlEditForm.Controls.Add(txtAmount);
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
            // pnlEditLine
            // 
            pnlEditLine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlEditLine.BackColor = Color.FromArgb(236, 238, 242);
            pnlEditLine.Location = new Point(56, 0);
            pnlEditLine.Name = "pnlEditLine";
            pnlEditLine.Size = new Size(780, 1);
            pnlEditLine.TabIndex = 0;
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
            // lblAmountCaption
            // 
            lblAmountCaption.AutoSize = true;
            lblAmountCaption.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAmountCaption.ForeColor = Color.FromArgb(120, 124, 145);
            lblAmountCaption.Location = new Point(584, 10);
            lblAmountCaption.Name = "lblAmountCaption";
            lblAmountCaption.Size = new Size(86, 12);
            lblAmountCaption.TabIndex = 2;
            lblAmountCaption.Text = "AMOUNT (GRAMS)";
            // 
            // txtIngredientName
            // 
            txtIngredientName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtIngredientName.BorderStyle = BorderStyle.FixedSingle;
            txtIngredientName.Location = new Point(56, 28);
            txtIngredientName.Name = "txtIngredientName";
            txtIngredientName.Size = new Size(520, 23);
            txtIngredientName.TabIndex = 3;
            txtIngredientName.Text = "e.g. Chia seeds";
            // 
            // txtAmount
            // 
            txtAmount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAmount.Location = new Point(584, 28);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(88, 23);
            txtAmount.TabIndex = 4;
            txtAmount.Text = "0";
            txtAmount.TextAlign = HorizontalAlignment.Right;
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
            pnlRecipeTop.ResumeLayout(false);
            pnlRecipeTop.PerformLayout();
            pnlNumber.ResumeLayout(false);
            pnlEditForm.ResumeLayout(false);
            pnlEditForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel pnlCard;
        private Panel pnlRecipeInner;
        private Panel pnlRecipeTop;
        private RoundedPanel pnlNumber;
        private Label lblRecipeName;
        private Label lblNumber;
        private Button btnEditRecipe;
        private Label lblRecipeTime;
        private Label lblRecipeCategory;
        private Button btnRemoveRecipe;
        private FlowLayoutPanel flowChips;
        private Panel pnlEditForm;
        private Label lblAmountCaption;
        private Label lblIngredientCaption;
        private Panel pnlEditLine;
        private TextBox txtAmount;
        private TextBox txtIngredientName;
        private Button btnSaveChanges;
        private Button btnAddIngredient;
    }
}
