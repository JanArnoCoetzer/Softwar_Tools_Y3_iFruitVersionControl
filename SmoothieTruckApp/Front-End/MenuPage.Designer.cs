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
            pnlOrderBody = new Panel();
            lblEmpty = new Label();
            flowOrder = new FlowLayoutPanel();
            pnlOrderButtons = new Panel();
            pnlButtonsInner = new Panel();
            tblButtons = new TableLayoutPanel();
            pnlButtonClear = new RoundedPanel();
            btnClearAll = new Button();
            pnlButtonRemove = new RoundedPanel();
            btnRemove = new Button();
            pnlButtonsLineBottom = new Panel();
            pnlButtonsLineTop = new Panel();
            pnlTotals = new Panel();
            pnlTotalsBox = new RoundedPanel();
            lblTotal = new Label();
            lblTotalText = new Label();
            pnlTotalsLine = new Panel();
            lblTax = new Label();
            lblTaxText = new Label();
            lblSubtotal = new Label();
            lblSubtotalText = new Label();
            pnlAddOrder = new Panel();
            pnlAddOrderFill = new RoundedPanel();
            btnAddOrder = new Button();
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
            pnlOrder.SuspendLayout();
            pnlOrderBody.SuspendLayout();
            pnlOrderButtons.SuspendLayout();
            pnlButtonsInner.SuspendLayout();
            tblButtons.SuspendLayout();
            pnlButtonClear.SuspendLayout();
            pnlButtonRemove.SuspendLayout();
            pnlTotals.SuspendLayout();
            pnlTotalsBox.SuspendLayout();
            pnlAddOrder.SuspendLayout();
            pnlAddOrderFill.SuspendLayout();
            pnlOrderHeader.SuspendLayout();
            pnlCount.SuspendLayout();
            pnlHeader.SuspendLayout();
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
            pnlOrder.Location = new Point(1072, 0);
            pnlOrder.Margin = new Padding(4, 5, 4, 5);
            pnlOrder.Name = "pnlOrder";
            pnlOrder.Padding = new Padding(17, 20, 17, 20);
            pnlOrder.ShadowSize = 12;
            pnlOrder.Size = new Size(357, 1083);
            pnlOrder.TabIndex = 0;
            // 
            // pnlOrderBody
            // 
            pnlOrderBody.Controls.Add(lblEmpty);
            pnlOrderBody.Controls.Add(flowOrder);
            pnlOrderBody.Dock = DockStyle.Fill;
            pnlOrderBody.Location = new Point(17, 120);
            pnlOrderBody.Margin = new Padding(4, 5, 4, 5);
            pnlOrderBody.Name = "pnlOrderBody";
            pnlOrderBody.Size = new Size(323, 597);
            pnlOrderBody.TabIndex = 4;
            // 
            // lblEmpty
            // 
            lblEmpty.Dock = DockStyle.Fill;
            lblEmpty.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmpty.ForeColor = Color.FromArgb(120, 124, 145);
            lblEmpty.Location = new Point(0, 0);
            lblEmpty.Margin = new Padding(0);
            lblEmpty.Name = "lblEmpty";
            lblEmpty.Size = new Size(323, 597);
            lblEmpty.TabIndex = 0;
            lblEmpty.Text = "Tap an item to add it to the order";
            lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
            lblEmpty.Click += lblEmpty_Click;
            // 
            // flowOrder
            // 
            flowOrder.AutoScroll = true;
            flowOrder.Dock = DockStyle.Fill;
            flowOrder.FlowDirection = FlowDirection.TopDown;
            flowOrder.Location = new Point(0, 0);
            flowOrder.Margin = new Padding(4, 5, 4, 5);
            flowOrder.Name = "flowOrder";
            flowOrder.Size = new Size(323, 597);
            flowOrder.TabIndex = 0;
            flowOrder.WrapContents = false;
            // 
            // pnlOrderButtons
            // 
            pnlOrderButtons.Controls.Add(pnlButtonsInner);
            pnlOrderButtons.Controls.Add(pnlButtonsLineBottom);
            pnlOrderButtons.Controls.Add(pnlButtonsLineTop);
            pnlOrderButtons.Dock = DockStyle.Bottom;
            pnlOrderButtons.Location = new Point(17, 717);
            pnlOrderButtons.Margin = new Padding(4, 5, 4, 5);
            pnlOrderButtons.Name = "pnlOrderButtons";
            pnlOrderButtons.Size = new Size(323, 73);
            pnlOrderButtons.TabIndex = 3;
            // 
            // pnlButtonsInner
            // 
            pnlButtonsInner.Controls.Add(tblButtons);
            pnlButtonsInner.Dock = DockStyle.Fill;
            pnlButtonsInner.Location = new Point(0, 2);
            pnlButtonsInner.Margin = new Padding(4, 5, 4, 5);
            pnlButtonsInner.Name = "pnlButtonsInner";
            pnlButtonsInner.Padding = new Padding(20, 12, 20, 12);
            pnlButtonsInner.Size = new Size(323, 69);
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
            tblButtons.Location = new Point(20, 12);
            tblButtons.Margin = new Padding(4, 5, 4, 5);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 1;
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblButtons.Size = new Size(283, 45);
            tblButtons.TabIndex = 0;
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
            pnlButtonClear.Location = new Point(147, 0);
            pnlButtonClear.Margin = new Padding(6, 0, 0, 0);
            pnlButtonClear.Name = "pnlButtonClear";
            pnlButtonClear.Size = new Size(136, 45);
            pnlButtonClear.TabIndex = 1;
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
            btnClearAll.Margin = new Padding(4, 5, 4, 5);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(136, 45);
            btnClearAll.TabIndex = 1;
            btnClearAll.Text = "Clear All";
            btnClearAll.UseVisualStyleBackColor = true;
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
            pnlButtonRemove.Margin = new Padding(0, 0, 6, 0);
            pnlButtonRemove.Name = "pnlButtonRemove";
            pnlButtonRemove.Size = new Size(135, 45);
            pnlButtonRemove.TabIndex = 0;
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
            btnRemove.Margin = new Padding(4, 5, 4, 5);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(135, 45);
            btnRemove.TabIndex = 0;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // pnlButtonsLineBottom
            // 
            pnlButtonsLineBottom.BackColor = Color.FromArgb(238, 240, 244);
            pnlButtonsLineBottom.Dock = DockStyle.Bottom;
            pnlButtonsLineBottom.Location = new Point(0, 71);
            pnlButtonsLineBottom.Margin = new Padding(4, 5, 4, 5);
            pnlButtonsLineBottom.Name = "pnlButtonsLineBottom";
            pnlButtonsLineBottom.Size = new Size(323, 2);
            pnlButtonsLineBottom.TabIndex = 1;
            // 
            // pnlButtonsLineTop
            // 
            pnlButtonsLineTop.BackColor = Color.FromArgb(238, 240, 244);
            pnlButtonsLineTop.Dock = DockStyle.Top;
            pnlButtonsLineTop.Location = new Point(0, 0);
            pnlButtonsLineTop.Margin = new Padding(4, 5, 4, 5);
            pnlButtonsLineTop.Name = "pnlButtonsLineTop";
            pnlButtonsLineTop.Size = new Size(323, 2);
            pnlButtonsLineTop.TabIndex = 0;
            // 
            // pnlTotals
            // 
            pnlTotals.Controls.Add(pnlTotalsBox);
            pnlTotals.Dock = DockStyle.Bottom;
            pnlTotals.Location = new Point(17, 790);
            pnlTotals.Margin = new Padding(4, 5, 4, 5);
            pnlTotals.Name = "pnlTotals";
            pnlTotals.Padding = new Padding(20, 20, 20, 0);
            pnlTotals.Size = new Size(323, 170);
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
            pnlTotalsBox.Location = new Point(20, 20);
            pnlTotalsBox.Margin = new Padding(4, 5, 4, 5);
            pnlTotalsBox.Name = "pnlTotalsBox";
            pnlTotalsBox.Size = new Size(283, 150);
            pnlTotalsBox.TabIndex = 0;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotal.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.FromArgb(124, 58, 237);
            lblTotal.Location = new Point(94, 95);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(171, 47);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "$0.00";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalText
            // 
            lblTotalText.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalText.ForeColor = Color.FromArgb(17, 17, 27);
            lblTotalText.Location = new Point(17, 103);
            lblTotalText.Margin = new Padding(4, 0, 4, 0);
            lblTotalText.Name = "lblTotalText";
            lblTotalText.Size = new Size(47, 25);
            lblTotalText.TabIndex = 5;
            lblTotalText.Text = "Total";
            // 
            // pnlTotalsLine
            // 
            pnlTotalsLine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTotalsLine.BackColor = Color.FromArgb(238, 240, 244);
            pnlTotalsLine.ForeColor = Color.FromArgb(238, 240, 244);
            pnlTotalsLine.Location = new Point(17, 83);
            pnlTotalsLine.Margin = new Padding(4, 5, 4, 5);
            pnlTotalsLine.Name = "pnlTotalsLine";
            pnlTotalsLine.Size = new Size(249, 2);
            pnlTotalsLine.TabIndex = 4;
            // 
            // lblTax
            // 
            lblTax.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTax.ForeColor = Color.FromArgb(17, 17, 27);
            lblTax.Location = new Point(151, 50);
            lblTax.Margin = new Padding(4, 0, 4, 0);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(114, 27);
            lblTax.TabIndex = 3;
            lblTax.Text = "$0.00";
            lblTax.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTaxText
            // 
            lblTaxText.AutoSize = true;
            lblTaxText.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTaxText.ForeColor = Color.FromArgb(120, 124, 145);
            lblTaxText.Location = new Point(17, 50);
            lblTaxText.Margin = new Padding(4, 0, 4, 0);
            lblTaxText.Name = "lblTaxText";
            lblTaxText.Size = new Size(72, 23);
            lblTaxText.TabIndex = 2;
            lblTaxText.Text = "Tax (8%)";
            // 
            // lblSubtotal
            // 
            lblSubtotal.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtotal.ForeColor = Color.FromArgb(17, 17, 27);
            lblSubtotal.Location = new Point(151, 17);
            lblSubtotal.Margin = new Padding(4, 0, 4, 0);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(114, 27);
            lblSubtotal.TabIndex = 1;
            lblSubtotal.Text = "$0.00";
            lblSubtotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSubtotalText
            // 
            lblSubtotalText.AutoSize = true;
            lblSubtotalText.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtotalText.ForeColor = Color.FromArgb(120, 124, 145);
            lblSubtotalText.Location = new Point(17, 17);
            lblSubtotalText.Margin = new Padding(4, 0, 4, 0);
            lblSubtotalText.Name = "lblSubtotalText";
            lblSubtotalText.Size = new Size(74, 23);
            lblSubtotalText.TabIndex = 0;
            lblSubtotalText.Text = "Subtotal";
            // 
            // pnlAddOrder
            // 
            pnlAddOrder.Controls.Add(pnlAddOrderFill);
            pnlAddOrder.Dock = DockStyle.Bottom;
            pnlAddOrder.Location = new Point(17, 960);
            pnlAddOrder.Margin = new Padding(4, 5, 4, 5);
            pnlAddOrder.Name = "pnlAddOrder";
            pnlAddOrder.Padding = new Padding(20, 17, 20, 20);
            pnlAddOrder.Size = new Size(323, 103);
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
            pnlAddOrderFill.Location = new Point(20, 17);
            pnlAddOrderFill.Margin = new Padding(4, 5, 4, 5);
            pnlAddOrderFill.Name = "pnlAddOrderFill";
            pnlAddOrderFill.Size = new Size(283, 66);
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
            btnAddOrder.Margin = new Padding(4, 5, 4, 5);
            btnAddOrder.Name = "btnAddOrder";
            btnAddOrder.Size = new Size(283, 66);
            btnAddOrder.TabIndex = 0;
            btnAddOrder.Text = "Add Order / Print Receipt";
            btnAddOrder.UseVisualStyleBackColor = true;
            // 
            // pnlOrderHeader
            // 
            pnlOrderHeader.Controls.Add(pnlHeaderLine);
            pnlOrderHeader.Controls.Add(pnlCount);
            pnlOrderHeader.Controls.Add(lblTicket);
            pnlOrderHeader.Controls.Add(lblOrderTitle);
            pnlOrderHeader.Dock = DockStyle.Top;
            pnlOrderHeader.Location = new Point(17, 20);
            pnlOrderHeader.Margin = new Padding(4, 5, 4, 5);
            pnlOrderHeader.Name = "pnlOrderHeader";
            pnlOrderHeader.Size = new Size(323, 100);
            pnlOrderHeader.TabIndex = 0;
            // 
            // pnlHeaderLine
            // 
            pnlHeaderLine.BackColor = Color.FromArgb(229, 231, 235);
            pnlHeaderLine.Dock = DockStyle.Bottom;
            pnlHeaderLine.Location = new Point(0, 98);
            pnlHeaderLine.Margin = new Padding(4, 5, 4, 5);
            pnlHeaderLine.Name = "pnlHeaderLine";
            pnlHeaderLine.Size = new Size(323, 2);
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
            pnlCount.Location = new Point(217, 13);
            pnlCount.Margin = new Padding(4, 5, 4, 5);
            pnlCount.Name = "pnlCount";
            pnlCount.Size = new Size(100, 37);
            pnlCount.TabIndex = 2;
            // 
            // lblCount
            // 
            lblCount.Dock = DockStyle.Fill;
            lblCount.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCount.ForeColor = Color.FromArgb(107, 114, 128);
            lblCount.Location = new Point(0, 0);
            lblCount.Margin = new Padding(4, 0, 4, 0);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(100, 37);
            lblCount.TabIndex = 0;
            lblCount.Text = "0 Items";
            lblCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTicket
            // 
            lblTicket.AutoSize = true;
            lblTicket.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTicket.ForeColor = Color.FromArgb(120, 124, 145);
            lblTicket.Location = new Point(7, 50);
            lblTicket.Margin = new Padding(4, 0, 4, 0);
            lblTicket.Name = "lblTicket";
            lblTicket.Size = new Size(152, 23);
            lblTicket.TabIndex = 1;
            lblTicket.Text = "Ticket #1 - Walk-in";
            // 
            // lblOrderTitle
            // 
            lblOrderTitle.AutoSize = true;
            lblOrderTitle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrderTitle.ForeColor = Color.FromArgb(17, 17, 27);
            lblOrderTitle.Location = new Point(7, 13);
            lblOrderTitle.Margin = new Padding(4, 0, 4, 0);
            lblOrderTitle.Name = "lblOrderTitle";
            lblOrderTitle.Size = new Size(143, 28);
            lblOrderTitle.TabIndex = 0;
            lblOrderTitle.Text = "Current Order";
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblBlends);
            pnlHeader.Controls.Add(lblMenuName);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(4, 5, 4, 5);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1072, 100);
            pnlHeader.TabIndex = 1;
            // 
            // lblBlends
            // 
            lblBlends.AutoSize = true;
            lblBlends.Location = new Point(37, 60);
            lblBlends.Margin = new Padding(4, 0, 4, 0);
            lblBlends.Name = "lblBlends";
            lblBlends.Size = new Size(79, 25);
            lblBlends.TabIndex = 1;
            lblBlends.Text = "0 Blends";
            // 
            // lblMenuName
            // 
            lblMenuName.AutoSize = true;
            lblMenuName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMenuName.Location = new Point(29, 18);
            lblMenuName.Margin = new Padding(4, 0, 4, 0);
            lblMenuName.Name = "lblMenuName";
            lblMenuName.Size = new Size(188, 32);
            lblMenuName.TabIndex = 0;
            lblMenuName.Text = "SmoothieMenu";
            // 
            // FlowMenu
            // 
            FlowMenu.AutoScroll = true;
            FlowMenu.BackColor = Color.FromArgb(232, 234, 242);
            FlowMenu.Dock = DockStyle.Fill;
            FlowMenu.Location = new Point(0, 100);
            FlowMenu.Margin = new Padding(4, 5, 4, 5);
            FlowMenu.Name = "FlowMenu";
            FlowMenu.Padding = new Padding(29, 17, 29, 17);
            FlowMenu.Size = new Size(1072, 983);
            FlowMenu.TabIndex = 2;
            // 
            // MenuPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 247);
            Controls.Add(FlowMenu);
            Controls.Add(pnlHeader);
            Controls.Add(pnlOrder);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MenuPage";
            Size = new Size(1429, 1083);
            pnlOrder.ResumeLayout(false);
            pnlOrderBody.ResumeLayout(false);
            pnlOrderButtons.ResumeLayout(false);
            pnlButtonsInner.ResumeLayout(false);
            tblButtons.ResumeLayout(false);
            pnlButtonClear.ResumeLayout(false);
            pnlButtonRemove.ResumeLayout(false);
            pnlTotals.ResumeLayout(false);
            pnlTotalsBox.ResumeLayout(false);
            pnlTotalsBox.PerformLayout();
            pnlAddOrder.ResumeLayout(false);
            pnlAddOrderFill.ResumeLayout(false);
            pnlOrderHeader.ResumeLayout(false);
            pnlOrderHeader.PerformLayout();
            pnlCount.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel pnlOrder;
        private Panel pnlHeader;
        private Label lblMenuName;
        private Label lblBlends;
        private FlowLayoutPanel FlowMenu;
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
