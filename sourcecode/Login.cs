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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            home frm = new home();
            frm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();

            if(txtName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please insert user name and password");
            }
            else
            {
                var data = db.Users.Where(u => u.Name == txtName.Text && u.Password == txtPassword.Text).FirstOrDefault();

                if(data == null)
                {
                    MessageBox.Show("Invalid user name or password");
                }
                else
                {
                    if(data.Type == "salesman")
                    {
                        booking frmb = new booking();
                        frmb.Show();
                    }
                    

                    home frm = new home();
                    frm.userName = data.Name;
                    frm.userType = data.Type;
                    this.Hide();
                    frm.Show();
                   
                }
            }
        }
    }
}
