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
            pnlOrderHeader = new Panel();
            pnlHeaderLine = new Panel();
            pnlCount = new RoundedPanel();
            lblCount = new Label();
            lblTicket = new Label();
            lblOrderTitle = new Label();
            pnlHeader = new Panel();
            lblBlends = new Label();
            lblMenuName = new Label();
            FlowMenu = new FlowLayoutPanel();
            itemCard1 = new ItemCard();
            itemCard2 = new ItemCard();
            itemCard3 = new ItemCard();
            itemCard4 = new ItemCard();
            pnlAddOrder = new Panel();
            pnlAddOrderFill = new RoundedPanel();
            btnAddOrder = new Button();
            pnlTotals = new Panel();
            pnlTotalsBox = new RoundedPanel();
            lblSubtotalText = new Label();
            lblSubtotal = new Label();
            lblTaxText = new Label();
            lblTax = new Label();
            pnlTotalsLine = new Panel();
            lblTotalText = new Label();
            lblTotal = new Label();
            pnlOrderButtons = new Panel();
            pnlButtonsLineTop = new Panel();
            pnlButtonsLineBottom = new Panel();
            pnlButtonsInner = new Panel();
            tblButtons = new TableLayoutPanel();
            pnlButtonRemove = new RoundedPanel();
            pnlButtonClear = new RoundedPanel();
            btnRemove = new Button();
            btnClearAll = new Button();
            pnlOrderBody = new Panel();
            flowOrder = new FlowLayoutPanel();
            lblEmpty = new Label();
            pnlOrder.SuspendLayout();
            pnlOrderHeader.SuspendLayout();
            pnlCount.SuspendLayout();
            pnlHeader.SuspendLayout();
            FlowMenu.SuspendLayout();
            pnlAddOrder.SuspendLayout();
            pnlAddOrderFill.SuspendLayout();
            pnlTotals.SuspendLayout();
            pnlTotalsBox.SuspendLayout();
            pnlOrderButtons.SuspendLayout();
            pnlButtonsInner.SuspendLayout();
            tblButtons.SuspendLayout();
            pnlButtonRemove.SuspendLayout();
            pnlButtonClear.SuspendLayout();
            pnlOrderBody.SuspendLayout();
            flowOrder.SuspendLayout();
            SuspendLayout();
            // 
            // pnlOrder
            // 
            pnlOrder.BackColor = Color.Transparent;
            pnlOrder.BorderColor = Color.FromArgb(229, 231, 235);
            pnlOrder.BorderSize = 0;
            pnlOrder.Controls.Add(pnlOrderBody);
            pnlOrder.Controls.Add(pnlOrderButtons);
            pnlOrder.Controls.Add(pnlTotals);
            pnlOrder.Controls.Add(pnlAddOrder);
            pnlOrder.Controls.Add(pnlOrderHeader);
            pnlOrder.CornerRadius = 16;
            pnlOrder.Dock = DockStyle.Right;
            pnlOrder.FillColor = Color.White;
            pnlOrder.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlOrder.GradientStart = Color.FromArgb(124, 58, 237);
            pnlOrder.Location = new Point(750, 0);
            pnlOrder.Name = "pnlOrder";
            pnlOrder.Padding = new Padding(12);
            pnlOrder.ShadowSize = 12;
            pnlOrder.Size = new Size(250, 650);
            pnlOrder.TabIndex = 0;
            // 
            // pnlOrderHeader
            // 
            pnlOrderHeader.Controls.Add(pnlHeaderLine);
            pnlOrderHeader.Controls.Add(pnlCount);
            pnlOrderHeader.Controls.Add(lblTicket);
            pnlOrderHeader.Controls.Add(lblOrderTitle);
            pnlOrderHeader.Dock = DockStyle.Top;
            pnlOrderHeader.Location = new Point(12, 12);
            pnlOrderHeader.Name = "pnlOrderHeader";
            pnlOrderHeader.Size = new Size(226, 60);
            pnlOrderHeader.TabIndex = 0;
            // 
            // pnlHeaderLine
            // 
            pnlHeaderLine.BackColor = Color.FromArgb(229, 231, 235);
            pnlHeaderLine.Dock = DockStyle.Bottom;
            pnlHeaderLine.Location = new Point(0, 59);
            pnlHeaderLine.Name = "pnlHeaderLine";
            pnlHeaderLine.Size = new Size(226, 1);
            pnlHeaderLine.TabIndex = 3;
            // 
            // pnlCount
            // 
            pnlCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlCount.BackColor = Color.Transparent;
            pnlCount.BorderColor = Color.FromArgb(229, 231, 235);
            pnlCount.BorderSize = 0;
            pnlCount.Controls.Add(lblCount);
            pnlCount.CornerRadius = 11;
            pnlCount.FillColor = Color.FromArgb(238, 240, 244);
            pnlCount.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlCount.GradientStart = Color.FromArgb(124, 58, 237);
            pnlCount.Location = new Point(152, 8);
            pnlCount.Name = "pnlCount";
            pnlCount.Size = new Size(70, 22);
            pnlCount.TabIndex = 2;
            // 
            // lblCount
            // 
            lblCount.Dock = DockStyle.Fill;
            lblCount.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCount.ForeColor = Color.FromArgb(107, 114, 128);
            lblCount.Location = new Point(0, 0);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(70, 22);
            lblCount.TabIndex = 0;
            lblCount.Text = "0 Items";
            lblCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTicket
            // 
            lblTicket.AutoSize = true;
            lblTicket.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTicket.ForeColor = Color.FromArgb(120, 124, 145);
            lblTicket.Location = new Point(5, 30);
            lblTicket.Name = "lblTicket";
            lblTicket.Size = new Size(102, 13);
            lblTicket.TabIndex = 1;
            lblTicket.Text = "Ticket #1 - Walk-in";
            // 
            // lblOrderTitle
            // 
            lblOrderTitle.AutoSize = true;
            lblOrderTitle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrderTitle.ForeColor = Color.FromArgb(17, 17, 27);
            lblOrderTitle.Location = new Point(5, 8);
            lblOrderTitle.Name = "lblOrderTitle";
            lblOrderTitle.Size = new Size(93, 17);
            lblOrderTitle.TabIndex = 0;
            lblOrderTitle.Text = "Current Order";
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblBlends);
            pnlHeader.Controls.Add(lblMenuName);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(750, 60);
            pnlHeader.TabIndex = 1;
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
            // pnlAddOrder
            // 
            pnlAddOrder.Controls.Add(pnlAddOrderFill);
            pnlAddOrder.Dock = DockStyle.Bottom;
            pnlAddOrder.Location = new Point(12, 576);
            pnlAddOrder.Name = "pnlAddOrder";
            pnlAddOrder.Padding = new Padding(14, 10, 14, 12);
            pnlAddOrder.Size = new Size(226, 62);
            pnlAddOrder.TabIndex = 1;
            // 
            // pnlAddOrderFill
            // 
            pnlAddOrderFill.BackColor = Color.Transparent;
            pnlAddOrderFill.BorderColor = Color.FromArgb(229, 231, 235);
            pnlAddOrderFill.BorderSize = 0;
            pnlAddOrderFill.Controls.Add(btnAddOrder);
            pnlAddOrderFill.CornerRadius = 10;
            pnlAddOrderFill.Dock = DockStyle.Fill;
            pnlAddOrderFill.FillColor = Color.FromArgb(236, 232, 252);
            pnlAddOrderFill.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlAddOrderFill.GradientStart = Color.FromArgb(124, 58, 237);
            pnlAddOrderFill.Location = new Point(14, 10);
            pnlAddOrderFill.Name = "pnlAddOrderFill";
            pnlAddOrderFill.Size = new Size(198, 40);
            pnlAddOrderFill.TabIndex = 0;
            // 
            // btnAddOrder
            // 
            btnAddOrder.Cursor = Cursors.Hand;
            btnAddOrder.Dock = DockStyle.Fill;
            btnAddOrder.FlatAppearance.BorderSize = 0;
            btnAddOrder.FlatAppearance.MouseDownBackColor = Color.FromArgb(236, 232, 252);
            btnAddOrder.FlatAppearance.MouseOverBackColor = Color.FromArgb(236, 232, 252);
            btnAddOrder.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddOrder.ForeColor = Color.FromArgb(176, 165, 220);
            btnAddOrder.Location = new Point(0, 0);
            btnAddOrder.Name = "btnAddOrder";
            btnAddOrder.Size = new Size(198, 40);
            btnAddOrder.TabIndex = 0;
            btnAddOrder.Text = "Add Order / Print Receipt";
            btnAddOrder.UseVisualStyleBackColor = true;
            // 
            // pnlTotals
            // 
            pnlTotals.Controls.Add(pnlTotalsBox);
            pnlTotals.Dock = DockStyle.Bottom;
            pnlTotals.Location = new Point(12, 474);
            pnlTotals.Name = "pnlTotals";
            pnlTotals.Padding = new Padding(14, 12, 14, 0);
            pnlTotals.Size = new Size(226, 102);
            pnlTotals.TabIndex = 2;
            // 
            // pnlTotalsBox
            // 
            pnlTotalsBox.BackColor = Color.Transparent;
            pnlTotalsBox.BorderColor = Color.FromArgb(229, 231, 235);
            pnlTotalsBox.Controls.Add(lblTotal);
            pnlTotalsBox.Controls.Add(lblTotalText);
            pnlTotalsBox.Controls.Add(pnlTotalsLine);
            pnlTotalsBox.Controls.Add(lblTax);
            pnlTotalsBox.Controls.Add(lblTaxText);
            pnlTotalsBox.Controls.Add(lblSubtotal);
            pnlTotalsBox.Controls.Add(lblSubtotalText);
            pnlTotalsBox.CornerRadius = 10;
            pnlTotalsBox.Dock = DockStyle.Fill;
            pnlTotalsBox.FillColor = Color.White;
            pnlTotalsBox.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlTotalsBox.GradientStart = Color.FromArgb(124, 58, 237);
            pnlTotalsBox.Location = new Point(14, 12);
            pnlTotalsBox.Name = "pnlTotalsBox";
            pnlTotalsBox.Size = new Size(198, 90);
            pnlTotalsBox.TabIndex = 0;
            // 
            // lblSubtotalText
            // 
            lblSubtotalText.AutoSize = true;
            lblSubtotalText.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtotalText.ForeColor = Color.FromArgb(120, 124, 145);
            lblSubtotalText.Location = new Point(12, 10);
            lblSubtotalText.Name = "lblSubtotalText";
            lblSubtotalText.Size = new Size(51, 13);
            lblSubtotalText.TabIndex = 0;
            lblSubtotalText.Text = "Subtotal";
            // 
            // lblSubtotal
            // 
            lblSubtotal.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtotal.ForeColor = Color.FromArgb(17, 17, 27);
            lblSubtotal.Location = new Point(106, 10);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(80, 16);
            lblSubtotal.TabIndex = 1;
            lblSubtotal.Text = "$0.00";
            lblSubtotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTaxText
            // 
            lblTaxText.AutoSize = true;
            lblTaxText.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTaxText.ForeColor = Color.FromArgb(120, 124, 145);
            lblTaxText.Location = new Point(12, 30);
            lblTaxText.Name = "lblTaxText";
            lblTaxText.Size = new Size(46, 13);
            lblTaxText.TabIndex = 2;
            lblTaxText.Text = "Tax (8%)";
            // 
            // lblTax
            // 
            lblTax.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTax.ForeColor = Color.FromArgb(17, 17, 27);
            lblTax.Location = new Point(106, 30);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(80, 16);
            lblTax.TabIndex = 3;
            lblTax.Text = "$0.00";
            lblTax.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlTotalsLine
            // 
            pnlTotalsLine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTotalsLine.BackColor = Color.FromArgb(238, 240, 244);
            pnlTotalsLine.ForeColor = Color.FromArgb(238, 240, 244);
            pnlTotalsLine.Location = new Point(12, 50);
            pnlTotalsLine.Name = "pnlTotalsLine";
            pnlTotalsLine.Size = new Size(174, 1);
            pnlTotalsLine.TabIndex = 4;
            // 
            // lblTotalText
            // 
            lblTotalText.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalText.ForeColor = Color.FromArgb(17, 17, 27);
            lblTotalText.Location = new Point(12, 62);
            lblTotalText.Name = "lblTotalText";
            lblTotalText.Size = new Size(33, 15);
            lblTotalText.TabIndex = 5;
            lblTotalText.Text = "Total";
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotal.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.FromArgb(124, 58, 237);
            lblTotal.Location = new Point(66, 57);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(120, 28);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "$0.00";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlOrderButtons
            // 
            pnlOrderButtons.Controls.Add(pnlButtonsInner);
            pnlOrderButtons.Controls.Add(pnlButtonsLineBottom);
            pnlOrderButtons.Controls.Add(pnlButtonsLineTop);
            pnlOrderButtons.Dock = DockStyle.Bottom;
            pnlOrderButtons.Location = new Point(12, 430);
            pnlOrderButtons.Name = "pnlOrderButtons";
            pnlOrderButtons.Size = new Size(226, 44);
            pnlOrderButtons.TabIndex = 3;
            // 
            // pnlButtonsLineTop
            // 
            pnlButtonsLineTop.BackColor = Color.FromArgb(238, 240, 244);
            pnlButtonsLineTop.Dock = DockStyle.Top;
            pnlButtonsLineTop.Location = new Point(0, 0);
            pnlButtonsLineTop.Name = "pnlButtonsLineTop";
            pnlButtonsLineTop.Size = new Size(226, 1);
            pnlButtonsLineTop.TabIndex = 0;
            // 
            // pnlButtonsLineBottom
            // 
            pnlButtonsLineBottom.BackColor = Color.FromArgb(238, 240, 244);
            pnlButtonsLineBottom.Dock = DockStyle.Bottom;
            pnlButtonsLineBottom.Location = new Point(0, 43);
            pnlButtonsLineBottom.Name = "pnlButtonsLineBottom";
            pnlButtonsLineBottom.Size = new Size(226, 1);
            pnlButtonsLineBottom.TabIndex = 1;
            // 
            // pnlButtonsInner
            // 
            pnlButtonsInner.Controls.Add(tblButtons);
            pnlButtonsInner.Dock = DockStyle.Fill;
            pnlButtonsInner.Location = new Point(0, 1);
            pnlButtonsInner.Name = "pnlButtonsInner";
            pnlButtonsInner.Padding = new Padding(14, 7, 14, 7);
            pnlButtonsInner.Size = new Size(226, 42);
            pnlButtonsInner.TabIndex = 2;
            // 
            // tblButtons
            // 
            tblButtons.ColumnCount = 2;
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblButtons.Controls.Add(pnlButtonClear, 1, 0);
            tblButtons.Controls.Add(pnlButtonRemove, 0, 0);
            tblButtons.Dock = DockStyle.Fill;
            tblButtons.Location = new Point(14, 7);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 1;
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblButtons.Size = new Size(198, 28);
            tblButtons.TabIndex = 0;
            // 
            // pnlButtonRemove
            // 
            pnlButtonRemove.BackColor = Color.Transparent;
            pnlButtonRemove.BorderColor = Color.FromArgb(229, 231, 235);
            pnlButtonRemove.Controls.Add(btnRemove);
            pnlButtonRemove.CornerRadius = 8;
            pnlButtonRemove.Dock = DockStyle.Fill;
            pnlButtonRemove.FillColor = Color.FromArgb(247, 248, 250);
            pnlButtonRemove.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlButtonRemove.GradientStart = Color.FromArgb(124, 58, 237);
            pnlButtonRemove.Location = new Point(0, 0);
            pnlButtonRemove.Margin = new Padding(0, 0, 4, 0);
            pnlButtonRemove.Name = "pnlButtonRemove";
            pnlButtonRemove.Size = new Size(95, 28);
            pnlButtonRemove.TabIndex = 0;
            // 
            // pnlButtonClear
            // 
            pnlButtonClear.BackColor = Color.Transparent;
            pnlButtonClear.BorderColor = Color.FromArgb(229, 231, 235);
            pnlButtonClear.Controls.Add(btnClearAll);
            pnlButtonClear.CornerRadius = 8;
            pnlButtonClear.Dock = DockStyle.Fill;
            pnlButtonClear.FillColor = Color.FromArgb(247, 248, 250);
            pnlButtonClear.GradientEnd = Color.FromArgb(6, 182, 212);
            pnlButtonClear.GradientStart = Color.FromArgb(124, 58, 237);
            pnlButtonClear.Location = new Point(103, 0);
            pnlButtonClear.Margin = new Padding(4, 0, 0, 0);
            pnlButtonClear.Name = "pnlButtonClear";
            pnlButtonClear.Size = new Size(95, 28);
            pnlButtonClear.TabIndex = 1;
            // 
            // btnRemove
            // 
            btnRemove.Cursor = Cursors.Hand;
            btnRemove.Dock = DockStyle.Fill;
            btnRemove.FlatAppearance.MouseDownBackColor = Color.FromArgb(247, 248, 250);
            btnRemove.FlatAppearance.MouseOverBackColor = Color.FromArgb(247, 248, 250);
            btnRemove.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRemove.ForeColor = Color.FromArgb(170, 175, 190);
            btnRemove.Location = new Point(0, 0);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(95, 28);
            btnRemove.TabIndex = 0;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnClearAll
            // 
            btnClearAll.Cursor = Cursors.Hand;
            btnClearAll.Dock = DockStyle.Fill;
            btnClearAll.FlatAppearance.MouseDownBackColor = Color.FromArgb(247, 248, 250);
            btnClearAll.FlatAppearance.MouseOverBackColor = Color.FromArgb(247, 248, 250);
            btnClearAll.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClearAll.ForeColor = Color.FromArgb(170, 175, 190);
            btnClearAll.Location = new Point(0, 0);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(95, 28);
            btnClearAll.TabIndex = 1;
            btnClearAll.Text = "Clear All";
            btnClearAll.UseVisualStyleBackColor = true;
            // 
            // pnlOrderBody
            // 
            pnlOrderBody.Controls.Add(flowOrder);
            pnlOrderBody.Dock = DockStyle.Fill;
            pnlOrderBody.Location = new Point(12, 72);
            pnlOrderBody.Name = "pnlOrderBody";
            pnlOrderBody.Size = new Size(226, 358);
            pnlOrderBody.TabIndex = 4;
            // 
            // flowOrder
            // 
            flowOrder.AutoScroll = true;
            flowOrder.Controls.Add(lblEmpty);
            flowOrder.Dock = DockStyle.Fill;
            flowOrder.FlowDirection = FlowDirection.TopDown;
            flowOrder.Location = new Point(0, 0);
            flowOrder.Name = "flowOrder";
            flowOrder.Size = new Size(226, 358);
            flowOrder.TabIndex = 0;
            flowOrder.WrapContents = false;
            // 
            // lblEmpty
            // 
            lblEmpty.Dock = DockStyle.Fill;
            lblEmpty.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmpty.ForeColor = Color.FromArgb(120, 124, 145);
            lblEmpty.Location = new Point(3, 0);
            lblEmpty.Name = "lblEmpty";
            lblEmpty.Size = new Size(0, 15);
            lblEmpty.TabIndex = 0;
            lblEmpty.Text = "Tap an item to add it to the order";
            // 
            // MenuPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 247);
            Controls.Add(FlowMenu);
            Controls.Add(pnlHeader);
            Controls.Add(pnlOrder);
            Name = "MenuPage";
            Size = new Size(1000, 650);
            pnlOrder.ResumeLayout(false);
            pnlOrderHeader.ResumeLayout(false);
            pnlOrderHeader.PerformLayout();
            pnlCount.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            FlowMenu.ResumeLayout(false);
            pnlAddOrder.ResumeLayout(false);
            pnlAddOrderFill.ResumeLayout(false);
            pnlTotals.ResumeLayout(false);
            pnlTotalsBox.ResumeLayout(false);
            pnlTotalsBox.PerformLayout();
            pnlOrderButtons.ResumeLayout(false);
            pnlButtonsInner.ResumeLayout(false);
            tblButtons.ResumeLayout(false);
            pnlButtonRemove.ResumeLayout(false);
            pnlButtonClear.ResumeLayout(false);
            pnlOrderBody.ResumeLayout(false);
            flowOrder.ResumeLayout(false);
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
        private Panel pnlOrderHeader;
        private Label lblOrderTitle;
        private Label lblTicket;
        private RoundedPanel pnlCount;
        private Label lblCount;
        private Panel pnlHeaderLine;
        private Panel pnlAddOrder;
        private RoundedPanel pnlAddOrderFill;
        private Button btnAddOrder;
        private Panel pnlTotals;
        private RoundedPanel pnlTotalsBox;
        private Label lblSubtotalText;
        private Label lblTax;
        private Label lblTaxText;
        private Label lblSubtotal;
        private Panel pnlTotalsLine;
        private Label lblTotalText;
        private Panel pnlOrderButtons;
        private Panel pnlButtonsLineTop;
        private Label lblTotal;
        private Panel pnlButtonsInner;
        private TableLayoutPanel tblButtons;
        private RoundedPanel pnlButtonRemove;
        private Panel pnlButtonsLineBottom;
        private RoundedPanel pnlButtonClear;
        private Button btnClearAll;
        private Button btnRemove;
        private Panel pnlOrderBody;
        private FlowLayoutPanel flowOrder;
        private Label lblEmpty;
    }
}
