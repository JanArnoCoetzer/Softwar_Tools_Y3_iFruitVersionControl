namespace SmoothieTruckApp.Front_End
{
    partial class OrdersPage
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
            ticketCard1 = new TicketCard();
            completedCard1 = new CompletedCard();
            SuspendLayout();
            // 
            // ticketCard1
            // 
            ticketCard1.BackColor = Color.Transparent;
            ticketCard1.Location = new Point(120, 144);
            ticketCard1.Name = "ticketCard1";
            ticketCard1.Size = new Size(480, 58);
            ticketCard1.TabIndex = 0;
            // 
            // completedCard1
            // 
            completedCard1.BackColor = Color.Transparent;
            completedCard1.Location = new Point(687, 144);
            completedCard1.Name = "completedCard1";
            completedCard1.Size = new Size(480, 58);
            completedCard1.TabIndex = 1;
            // 
            // OrdersPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 245, 247);
            Controls.Add(completedCard1);
            Controls.Add(ticketCard1);
            Name = "OrdersPage";
            Size = new Size(1304, 630);
            ResumeLayout(false);
        }

        #endregion

        private TicketCard ticketCard1;
        private CompletedCard completedCard1;
    }
}
