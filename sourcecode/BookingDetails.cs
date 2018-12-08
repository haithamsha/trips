using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            if(listView1.Items.Count == 0)
            {
                MessageBox.Show("There is no items to remove");
            }
            else
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
            
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
                    TripNumber = booking.tribNumber,
                    SalesMan = home.userName
                });
                db.SaveChanges();
                ticketNumber = t.TicketNumber;

               if(txtemail.Text != "")
                {
                    string body = "<p>Thanks for your booking</p><p>Ticket Number: " + t.TicketNumber + "</p><p>Name: " + txtName.Text + "</p><p>Trip Number: " + booking.tribNumber + "</p><p>Price: " + labelprice.Text + "</p>";
                    sendEmail(txtemail.Text, "Ticket Confirmation", body);
                }

                Confirmation frm = new Confirmation();
                frm.Show();
                this.Hide();
            }
        }
        
        public void sendEmail(string to, string subject, string body)
        {
            MailMessage ms = new MailMessage("Csharpproject2019@gmail.com", to);
            ms.Subject = subject;
            ms.Body = body;
            ms.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            NetworkCredential netWorkCard = new NetworkCredential("Csharpproject2019@gmail.com", "11223344mmc");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = netWorkCard;
            smtpClient.Port = 587;
            smtpClient.Send(ms);
        }

        private void BookingDetails_Load(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
           
            var data = db.Trips.Find(booking.tribNumber);
            labelprice.Text = data.Price.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
