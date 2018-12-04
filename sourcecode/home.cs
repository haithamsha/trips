using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sourcecode
{
    public partial class home : Form
    {
        public static string userName = "";
        public static string userType = "";
        public home()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TripManagement frm = new TripManagement();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PassengerForm frm = new PassengerForm();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            booking frm = new booking();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.Show();
            this.Hide();
        }

        private void home_Load(object sender, EventArgs e)
        {
            lblUserName.Text = userName;
            if(userType == "manager")
            {
                button3.Visible = true;
                button4.Visible = true;
                button2.Visible = false;
                button1.Visible = false;
            }
            else if(userType == "salesman")
            {
                button6.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TicketReport frm = new TicketReport();
            frm.Show();
        }
    }
}
