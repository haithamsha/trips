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
    public partial class TripManagement : Form
    {
        public TripManagement()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFrom.Text == "" || txtTo.Text == "" || txtprice.Text == "")
            {
                MessageBox.Show("Please complete fileds first");
                return;
            }

            DataBaseContext db = new DataBaseContext();
            db.Trips.Add(new Trip {
                From = txtFrom.Text,
                To = txtTo.Text,
                ReturnDate = txtReturnDate.Value,
                ReturnTime = txtReturnTime.Value.ToString(),
                TravelDate = txtTravelDate.Value,
                TravelTime = txtTravelTime.Value.ToString(),
                Price = decimal.Parse(txtprice.Text)
            });
            db.SaveChanges();

            dataGridView1.DataSource = db.Trips.ToList();
        }

        private void TripManagement_Load(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            dataGridView1.DataSource = db.Trips.ToList(); ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
