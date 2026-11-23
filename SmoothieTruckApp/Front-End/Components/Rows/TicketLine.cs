using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmoothieTruckApp.Front_End
{
    public partial class TicketLine : UserControl
    {
        public TicketLine()
        {
            InitializeComponent();
        }

        private void lblLineDot_Click(object sender, EventArgs e)
        {

        }

        public void SetLine(string name, int quantity)
        {
            lblLineName.Text = name;
            lblQty.Text = $"×{quantity}";     // ×1
        }
    }
}
