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
    public partial class BookingDetails : Form
    {
        public static int ticketNumber = 0;
        public BookingDetails()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item.Text = txtName.Text;
            item.SubItems.Add(txtphone.Text);
            item.SubItems.Add(txtemail.Text);
            item.SubItems.Add(txtbirthdate.Value.ToString());
            item.SubItems.Add(txtnotes.Text);

            listView1.Items.Add(item);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //listView1.Items.Find()
            listView1.Items.Remove(listView1.SelectedItems[0]);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            home frm = new home();
            frm.Show();
            this.Hide();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if(listView1.Items.Count == 0)
            {
                MessageBox.Show("Please add one or more passenger first");
            }
            else
            {
                DataBaseContext db = new DataBaseContext();
               var t = db.Tickets.Add(new Ticket
                {
                    BirthDate = txtbirthdate.Value,
                    Email = txtemail.Text,
                    Note = txtnotes.Text,
                    PassengerName = txtName.Text,
                    Phone = txtphone.Text,
                    Price = decimal.Parse(labelprice.Text),
                    TripNumber = booking.tribNumber
                });
                db.SaveChanges();
                ticketNumber = t.TicketNumber;
                Confirmation frm = new Confirmation();
                frm.Show();
                this.Hide();
            }
        }

        private void BookingDetails_Load(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
           
            var data = db.Trips.Find(booking.tribNumber);
            labelprice.Text = data.Price.ToString();
        }
    }
}
