namespace SmoothieTruckApp.Front_End
{
    partial class StockPage
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
            pnlStockHeader = new Panel();
            lblStockTitle = new Label();
            lblStockSub = new Label();
            pnlAttention = new RoundedPanel();
            pnlAttentionDot = new RoundedPanel();
            lblAttention = new Label();
            pnlStockCard = new RoundedPanel();
            pnlStockCardHead = new Panel();
            lblInventoryTitle = new Label();
            lblInventorySub = new Label();
            lblLastSynced = new Label();
            pnlColumnHeader = new Panel();
            lblColIngredient = new Label();
            lblColOnHand = new Label();
            lblColStatus = new Label();
            lblColAdjust = new Label();
            flowStock = new FlowLayoutPanel();
            pnlStockHeader.SuspendLayout();
            pnlAttention.SuspendLayout();
            pnlStockCard.SuspendLayout();
            pnlStockCardHead.SuspendLayout();
            pnlColumnHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlStockHeader
            // 
            pnlStockHeader.BackColor = Color.Transparent;
            pnlStockHeader.Controls.Add(pnlAttention);
            pnlStockHeader.Controls.Add(lblStockSub);
            pnlStockHeader.Controls.Add(lblStockTitle);
            pnlStockHeader.Dock = DockStyle.Top;
            pnlStockHeader.Location = new Point(20, 18);
            pnlStockHeader.Name = "pnlStockHeader";
            pnlStockHeader.Size = new Size(960, 62);
            pnlStockHeader.TabIndex = 0;
            // 
            // lblStockTitle
            // 
            lblStockTitle.AutoSize = true;
            lblStockTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStockTitle.ForeColor = Color.FromArgb(17, 17, 27);
            lblStockTitle.Location = new Point(0, 0);
            lblStockTitle.Name = "lblStockTitle";
            lblStockTitle.Size = new Size(155, 25);
            lblStockTitle.TabIndex = 0;
            lblStockTitle.Text = "Inventory Stock";
            // 
            // lblStockSub
            // 
            lblStockSub.AutoSize = true;
            lblStockSub.ForeColor = Color.FromArgb(120, 124, 145);
            lblStockSub.Location = new Point(0, 32);
            lblStockSub.Name = "lblStockSub";
            lblStockSub.Size = new Size(281, 15);
            lblStockSub.TabIndex = 1;
            lblStockSub.Text = "Live ingredient counts for the truck and prep station";
            // 
            // pnlAttention
            // 
            pnlAttention.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlAttention.BackColor = Color.Transparent;
            pnlAttention.BorderColor = Color.FromArgb(253, 224, 160);
            pnlAttention.Controls.Add(lblAttention);
            pnlAttention.Controls.Add(pnlAttentionDot);
            pnlAttention.CornerRadius = 10;
            pnlAttention.FillColor = Color.FromArgb(255, 247, 230);
            pnlAttention.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlAttention.GradientStart = Color.FromArgb(124, 58, 237);
            pnlAttention.Location = new Point(770, 6);
            pnlAttention.Name = "pnlAttention";
            pnlAttention.Size = new Size(190, 30);
            pnlAttention.TabIndex = 2;
            // 
            // pnlAttentionDot
            // 
            pnlAttentionDot.BackColor = Color.Transparent;
            pnlAttentionDot.BorderColor = Color.FromArgb(229, 231, 235);
            pnlAttentionDot.BorderSize = 0;
            pnlAttentionDot.CornerRadius = 3;
            pnlAttentionDot.FillColor = Color.FromArgb(245, 158, 11);
            pnlAttentionDot.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlAttentionDot.GradientStart = Color.FromArgb(124, 58, 237);
            pnlAttentionDot.Location = new Point(12, 11);
            pnlAttentionDot.Name = "pnlAttentionDot";
            pnlAttentionDot.Size = new Size(7, 7);
            pnlAttentionDot.TabIndex = 0;
            // 
            // lblAttention
            // 
            lblAttention.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAttention.ForeColor = Color.FromArgb(161, 98, 7);
            lblAttention.Location = new Point(24, 0);
            lblAttention.Name = "lblAttention";
            lblAttention.Size = new Size(160, 30);
            lblAttention.TabIndex = 1;
            lblAttention.Text = "2 items need attention";
            lblAttention.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlStockCard
            // 
            pnlStockCard.BackColor = Color.Transparent;
            pnlStockCard.BorderColor = Color.FromArgb(236, 238, 242);
            pnlStockCard.Controls.Add(flowStock);
            pnlStockCard.Controls.Add(pnlColumnHeader);
            pnlStockCard.Controls.Add(pnlStockCardHead);
            pnlStockCard.CornerRadius = 14;
            pnlStockCard.Dock = DockStyle.Fill;
            pnlStockCard.FillColor = Color.White;
            pnlStockCard.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlStockCard.GradientStart = Color.FromArgb(124, 58, 237);
            pnlStockCard.Location = new Point(20, 80);
            pnlStockCard.Name = "pnlStockCard";
            pnlStockCard.Padding = new Padding(3);
            pnlStockCard.ShadowSize = 3;
            pnlStockCard.Size = new Size(960, 562);
            pnlStockCard.TabIndex = 1;
            // 
            // pnlStockCardHead
            // 
            pnlStockCardHead.Controls.Add(lblLastSynced);
            pnlStockCardHead.Controls.Add(lblInventorySub);
            pnlStockCardHead.Controls.Add(lblInventoryTitle);
            pnlStockCardHead.Dock = DockStyle.Top;
            pnlStockCardHead.Location = new Point(3, 3);
            pnlStockCardHead.Name = "pnlStockCardHead";
            pnlStockCardHead.Size = new Size(954, 62);
            pnlStockCardHead.TabIndex = 0;
            // 
            // lblInventoryTitle
            // 
            lblInventoryTitle.AutoSize = true;
            lblInventoryTitle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInventoryTitle.ForeColor = Color.FromArgb(17, 17, 27);
            lblInventoryTitle.Location = new Point(14, 12);
            lblInventoryTitle.Name = "lblInventoryTitle";
            lblInventoryTitle.Size = new Size(136, 17);
            lblInventoryTitle.TabIndex = 0;
            lblInventoryTitle.Text = "Ingredient inventory";
            // 
            // lblInventorySub
            // 
            lblInventorySub.AutoSize = true;
            lblInventorySub.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInventorySub.ForeColor = Color.FromArgb(120, 124, 145);
            lblInventorySub.Location = new Point(14, 34);
            lblInventorySub.Name = "lblInventorySub";
            lblInventorySub.Size = new Size(289, 13);
            lblInventorySub.TabIndex = 1;
            lblInventorySub.Text = "Adjust stock as deliveries arrive or ingredients are used";
            // 
            // lblLastSynced
            // 
            lblLastSynced.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLastSynced.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastSynced.ForeColor = Color.FromArgb(120, 124, 145);
            lblLastSynced.ImageAlign = ContentAlignment.MiddleRight;
            lblLastSynced.Location = new Point(780, 14);
            lblLastSynced.Name = "lblLastSynced";
            lblLastSynced.Size = new Size(160, 16);
            lblLastSynced.TabIndex = 2;
            lblLastSynced.Text = "Last synced just now";
            // 
            // pnlColumnHeader
            // 
            pnlColumnHeader.BackColor = Color.FromArgb(249, 250, 252);
            pnlColumnHeader.Controls.Add(lblColAdjust);
            pnlColumnHeader.Controls.Add(lblColStatus);
            pnlColumnHeader.Controls.Add(lblColOnHand);
            pnlColumnHeader.Controls.Add(lblColIngredient);
            pnlColumnHeader.Dock = DockStyle.Top;
            pnlColumnHeader.Location = new Point(3, 65);
            pnlColumnHeader.Name = "pnlColumnHeader";
            pnlColumnHeader.Size = new Size(954, 30);
            pnlColumnHeader.TabIndex = 1;
            // 
            // lblColIngredient
            // 
            lblColIngredient.AutoSize = true;
            lblColIngredient.Location = new Point(14, 9);
            lblColIngredient.Name = "lblColIngredient";
            lblColIngredient.Size = new Size(73, 15);
            lblColIngredient.TabIndex = 0;
            lblColIngredient.Text = "INGREDIENT";
            // 
            // lblColOnHand
            // 
            lblColOnHand.AutoSize = true;
            lblColOnHand.Location = new Point(290, 9);
            lblColOnHand.Name = "lblColOnHand";
            lblColOnHand.Size = new Size(113, 15);
            lblColOnHand.TabIndex = 1;
            lblColOnHand.Text = "ON HAND (GRAMS)";
            // 
            // lblColStatus
            // 
            lblColStatus.AutoSize = true;
            lblColStatus.Location = new Point(430, 9);
            lblColStatus.Name = "lblColStatus";
            lblColStatus.Size = new Size(47, 15);
            lblColStatus.TabIndex = 2;
            lblColStatus.Text = "STATUS";
            // 
            // lblColAdjust
            // 
            lblColAdjust.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblColAdjust.AutoSize = true;
            lblColAdjust.Location = new Point(582, 9);
            lblColAdjust.Name = "lblColAdjust";
            lblColAdjust.Size = new Size(120, 15);
            lblColAdjust.TabIndex = 3;
            lblColAdjust.Text = "STOCK ADJUSTMENT";
            // 
            // flowStock
            // 
            flowStock.AutoScroll = true;
            flowStock.Dock = DockStyle.Fill;
            flowStock.FlowDirection = FlowDirection.TopDown;
            flowStock.Location = new Point(3, 95);
            flowStock.Name = "flowStock";
            flowStock.Size = new Size(954, 464);
            flowStock.TabIndex = 2;
            flowStock.WrapContents = false;
            // 
            // StockPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 247);
            Controls.Add(pnlStockCard);
            Controls.Add(pnlStockHeader);
            Name = "StockPage";
            Padding = new Padding(20, 18, 20, 8);
            Size = new Size(1000, 650);
            pnlStockHeader.ResumeLayout(false);
            pnlStockHeader.PerformLayout();
            pnlAttention.ResumeLayout(false);
            pnlStockCard.ResumeLayout(false);
            pnlStockCardHead.ResumeLayout(false);
            pnlStockCardHead.PerformLayout();
            pnlColumnHeader.ResumeLayout(false);
            pnlColumnHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlStockHeader;
        private Label lblStockTitle;
        private RoundedPanel pnlAttention;
        private Label lblAttention;
        private RoundedPanel pnlAttentionDot;
        private Label lblStockSub;
        private RoundedPanel pnlStockCard;
        private Panel pnlStockCardHead;
        private Label lblLastSynced;
        private Label lblInventorySub;
        private Label lblInventoryTitle;
        private Panel pnlColumnHeader;
        private Label lblColAdjust;
        private Label lblColStatus;
        private Label lblColOnHand;
        private Label lblColIngredient;
        private FlowLayoutPanel flowStock;
    }
}
