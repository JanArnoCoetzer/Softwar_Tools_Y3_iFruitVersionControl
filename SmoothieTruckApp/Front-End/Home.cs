using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmoothieTruckApp.Front_End
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void lblClock_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("h:mm tt");
        }
    }
}
