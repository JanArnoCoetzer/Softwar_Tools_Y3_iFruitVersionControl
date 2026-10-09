namespace SmoothieTruckApp.Front_End
{
    partial class MenuPage
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
            pnlOrder = new RoundedPanel();
            pnlHeader = new Panel();
            lblMenuName = new Label();
            lblBlends = new Label();
            FlowMenu = new FlowLayoutPanel();
            itemCard1 = new ItemCard();
            itemCard2 = new ItemCard();
            itemCard3 = new ItemCard();
            itemCard4 = new ItemCard();
            pnlHeader.SuspendLayout();
            FlowMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlOrder
            // 
            pnlOrder.BackColor = Color.Transparent;
            pnlOrder.BorderColor = Color.FromArgb(229, 231, 235);
            pnlOrder.Dock = DockStyle.Right;
            pnlOrder.FillColor = Color.White;
            pnlOrder.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlOrder.GradientStart = Color.FromArgb(124, 58, 237);
            pnlOrder.Location = new Point(750, 60);
            pnlOrder.Name = "pnlOrder";
            pnlOrder.Size = new Size(250, 590);
            pnlOrder.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblBlends);
            pnlHeader.Controls.Add(lblMenuName);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 60);
            pnlHeader.TabIndex = 1;
            // 
            // lblMenuName
            // 
            lblMenuName.AutoSize = true;
            lblMenuName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMenuName.Location = new Point(20, 11);
            lblMenuName.Name = "lblMenuName";
            lblMenuName.Size = new Size(128, 21);
            lblMenuName.TabIndex = 0;
            lblMenuName.Text = "SmoothieMenu";
            // 
            // lblBlends
            // 
            lblBlends.AutoSize = true;
            lblBlends.Location = new Point(26, 36);
            lblBlends.Name = "lblBlends";
            lblBlends.Size = new Size(51, 15);
            lblBlends.TabIndex = 1;
            lblBlends.Text = "0 Blends";
            // 
            // FlowMenu
            // 
            FlowMenu.AutoScroll = true;
            FlowMenu.Controls.Add(itemCard1);
            FlowMenu.Controls.Add(itemCard2);
            FlowMenu.Controls.Add(itemCard3);
            FlowMenu.Controls.Add(itemCard4);
            FlowMenu.Dock = DockStyle.Fill;
            FlowMenu.Location = new Point(0, 60);
            FlowMenu.Name = "FlowMenu";
            FlowMenu.Padding = new Padding(20, 10, 20, 10);
            FlowMenu.Size = new Size(750, 590);
            FlowMenu.TabIndex = 2;
            // 
            // itemCard1
            // 
            itemCard1.Location = new Point(20, 10);
            itemCard1.Margin = new Padding(0, 0, 16, 16);
            itemCard1.Name = "itemCard1";
            itemCard1.Size = new Size(320, 290);
            itemCard1.TabIndex = 0;
            // 
            // itemCard2
            // 
            itemCard2.Location = new Point(356, 10);
            itemCard2.Margin = new Padding(0, 0, 16, 16);
            itemCard2.Name = "itemCard2";
            itemCard2.Size = new Size(320, 290);
            itemCard2.TabIndex = 1;
            // 
            // itemCard3
            // 
            itemCard3.Location = new Point(20, 316);
            itemCard3.Margin = new Padding(0, 0, 16, 16);
            itemCard3.Name = "itemCard3";
            itemCard3.Size = new Size(320, 290);
            itemCard3.TabIndex = 2;
            // 
            // itemCard4
            // 
            itemCard4.Location = new Point(356, 316);
            itemCard4.Margin = new Padding(0, 0, 16, 16);
            itemCard4.Name = "itemCard4";
            itemCard4.Size = new Size(320, 290);
            itemCard4.TabIndex = 3;
            // 
            // MenuPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 247);
            Controls.Add(FlowMenu);
            Controls.Add(pnlOrder);
            Controls.Add(pnlHeader);
            Name = "MenuPage";
            Size = new Size(1000, 650);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            FlowMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel pnlOrder;
        private Panel pnlHeader;
        private Label lblMenuName;
        private Label lblBlends;
        private FlowLayoutPanel FlowMenu;
        private ItemCard itemCard1;
        private ItemCard itemCard2;
        private ItemCard itemCard3;
        private ItemCard itemCard4;
    }
}
