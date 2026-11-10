namespace SmoothieTruckApp.Front_End
{
    partial class RecipePage
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
            pnlRecipeHeader = new Panel();
            pnlAddRecipe = new RoundedPanel();
            lblRecipeSub = new Label();
            lblRecipeTitle = new Label();
            btnAddRecipe = new Button();
            flowRecipes = new FlowLayoutPanel();
            pnlRecipeHeader.SuspendLayout();
            pnlAddRecipe.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRecipeHeader
            // 
            pnlRecipeHeader.BackColor = Color.Transparent;
            pnlRecipeHeader.Controls.Add(pnlAddRecipe);
            pnlRecipeHeader.Controls.Add(lblRecipeSub);
            pnlRecipeHeader.Controls.Add(lblRecipeTitle);
            pnlRecipeHeader.Dock = DockStyle.Top;
            pnlRecipeHeader.Location = new Point(20, 18);
            pnlRecipeHeader.Name = "pnlRecipeHeader";
            pnlRecipeHeader.Size = new Size(960, 62);
            pnlRecipeHeader.TabIndex = 0;
            // 
            // pnlAddRecipe
            // 
            pnlAddRecipe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlAddRecipe.BackColor = Color.Transparent;
            pnlAddRecipe.BorderColor = Color.FromArgb(229, 231, 235);
            pnlAddRecipe.BorderSize = 0;
            pnlAddRecipe.Controls.Add(btnAddRecipe);
            pnlAddRecipe.CornerRadius = 10;
            pnlAddRecipe.FillColor = Color.White;
            pnlAddRecipe.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlAddRecipe.GradientStart = Color.FromArgb(124, 58, 237);
            pnlAddRecipe.Location = new Point(810, 6);
            pnlAddRecipe.Name = "pnlAddRecipe";
            pnlAddRecipe.ShadowSize = 3;
            pnlAddRecipe.Size = new Size(150, 34);
            pnlAddRecipe.TabIndex = 2;
            pnlAddRecipe.UseGradient = true;
            // 
            // lblRecipeSub
            // 
            lblRecipeSub.AutoSize = true;
            lblRecipeSub.ForeColor = Color.FromArgb(120, 124, 145);
            lblRecipeSub.Location = new Point(0, 32);
            lblRecipeSub.Name = "lblRecipeSub";
            lblRecipeSub.Size = new Size(310, 15);
            lblRecipeSub.TabIndex = 1;
            lblRecipeSub.Text = "\t4 active recipes · Keep every blend consistent across shifts";
            // 
            // lblRecipeTitle
            // 
            lblRecipeTitle.AutoSize = true;
            lblRecipeTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecipeTitle.ForeColor = Color.FromArgb(17, 17, 27);
            lblRecipeTitle.Location = new Point(0, 0);
            lblRecipeTitle.Name = "lblRecipeTitle";
            lblRecipeTitle.Size = new Size(193, 25);
            lblRecipeTitle.TabIndex = 0;
            lblRecipeTitle.Text = "Recipe Management";
            // 
            // btnAddRecipe
            // 
            btnAddRecipe.Cursor = Cursors.Hand;
            btnAddRecipe.Dock = DockStyle.Fill;
            btnAddRecipe.FlatAppearance.BorderSize = 0;
            btnAddRecipe.FlatStyle = FlatStyle.Flat;
            btnAddRecipe.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddRecipe.ForeColor = Color.White;
            btnAddRecipe.Location = new Point(0, 0);
            btnAddRecipe.Name = "btnAddRecipe";
            btnAddRecipe.Size = new Size(150, 34);
            btnAddRecipe.TabIndex = 0;
            btnAddRecipe.Text = "Add New Recipe";
            btnAddRecipe.UseVisualStyleBackColor = true;
            // 
            // flowRecipes
            // 
            flowRecipes.AutoScroll = true;
            flowRecipes.BackColor = Color.Transparent;
            flowRecipes.Dock = DockStyle.Fill;
            flowRecipes.FlowDirection = FlowDirection.TopDown;
            flowRecipes.Location = new Point(20, 80);
            flowRecipes.Name = "flowRecipes";
            flowRecipes.Size = new Size(960, 562);
            flowRecipes.TabIndex = 1;
            flowRecipes.WrapContents = false;
            // 
            // RecipePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 247);
            Controls.Add(flowRecipes);
            Controls.Add(pnlRecipeHeader);
            Name = "RecipePage";
            Padding = new Padding(20, 18, 20, 8);
            Size = new Size(1000, 650);
            pnlRecipeHeader.ResumeLayout(false);
            pnlRecipeHeader.PerformLayout();
            pnlAddRecipe.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRecipeHeader;
        private Label lblRecipeTitle;
        private RoundedPanel pnlAddRecipe;
        private Label lblRecipeSub;
        private Button btnAddRecipe;
        private FlowLayoutPanel flowRecipes;
    }
}
