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
    public partial class booking : Form
    {
        public static int tribNumber = 0;
        public booking()
        {
            InitializeComponent();
        }

        private void booking_Load(object sender, EventArgs e)
        {
            
            DataBaseContext db = new DataBaseContext();
            var data = db.Trips.ToList();

            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "From";
            comboBox1.ValueMember = "TripNumber";
            comboBox2.DataSource = data;
            comboBox2.DisplayMember = "To";
            comboBox2.ValueMember = "TripNumber";
            comboBox1.SelectedItem = null; 
            comboBox1.SelectedText = "Select...";
            comboBox2.SelectedItem = null;
            comboBox2.SelectedText = "Select...";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                DataBaseContext db = new DataBaseContext();
                var data = db.Trips.Find(int.Parse(comboBox1.SelectedValue.ToString()));
                dateTimePicker1.Value = data.TravelDate;
                dateTimePicker2.Value = data.ReturnDate;
                labeltraveltime.Text = data.TravelTime;
                labeltripnumber.Text = data.TripNumber.ToString();
                labelreturntime.Text = data.ReturnTime;
                tribNumber = data.TripNumber;
            }
            catch (Exception)
            {

            }
            
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            BookingDetails frm = new sourcecode.BookingDetails();
            frm.Show();
        }
    }
}
