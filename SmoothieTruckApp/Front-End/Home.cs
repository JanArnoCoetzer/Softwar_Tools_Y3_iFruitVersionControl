using SmoothieTruckApp.DataBaseContext;
using SmoothieTruckApp.DataBaseContext.TableDefinitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmoothieTruckApp.Front_End
{
    public partial class Home : Form
    {
        // Remembers which nav button is currently selected
        private Button? activeButton;

        public Home()
        {
            InitializeComponent();

            NavButton_Click(btnHome, EventArgs.Empty);
            
            //expected result should be Success - DataBaseContext.TableDefinitions.DbResultEnum.Success;
            //DataBaseContext.DataBaseSetup.InitializeDatabase();
            /*
            RowValue[] testdata = new RowValue[]
            {
             new RowValue(DataType.STRING, "Test"),
             new RowValue(DataType.DECIMAL, "1"),
             new RowValue(DataType.STRING,"kg")
            };

            Debug.WriteLine(DataBase.add_new_row_at_index("stock_table",testdata,2));
            */
        }

        private void lblClock_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("h:mm tt");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Returns the coloured (hover) icon or the normal icon for a given button
        private Image GetIcon(Button b, bool coloured)
        {
            if (b == btnHome) return coloured ? Properties.Resources.Home_Hover : Properties.Resources.Home_Icon;
            if (b == btnMenu) return coloured ? Properties.Resources.Menu_Hover : Properties.Resources.Menu_Icon;
            return coloured ? Properties.Resources.Order_Hover : Properties.Resources.Order_Icon;
        }

        private void NavButton_Click(object sender, EventArgs e)
        {
            activeButton = (Button)sender;

            foreach (var b in new[] { btnHome, btnMenu, btnOrders })
            {
                bool isActive = b == activeButton;

                b.Image = GetIcon(b, isActive);
                b.BackColor = isActive ? Color.FromArgb(28, 22, 48) : Color.FromArgb(13, 15, 20);
                b.ForeColor = isActive ? Color.FromArgb(167, 139, 250) : Color.FromArgb(150, 154, 175);
            }

            pnlAccent.Top = activeButton.Top + (activeButton.Height - pnlAccent.Height) / 2;
        }

        private void NavButton_MouseEnter(object sender, EventArgs e)
        {
            var b = (Button)sender;
            b.Image = GetIcon(b, true);
        }

        private void NavButton_MouseLeave(object sender, EventArgs e)
        {
            var b = (Button)sender;
            b.Image = GetIcon(b, b == activeButton);   // stays coloured only if it's the active one
        }

        private void Logo_Click(object sender, EventArgs e)
        {

        }

        private void lblBrand_Click(object sender, EventArgs e)
        {

        }
    }
}