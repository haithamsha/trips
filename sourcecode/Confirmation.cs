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
    public partial class Confirmation : Form
    {
        public Confirmation()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            home frm = new home();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        Bitmap bmp;
        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            button1.Visible = false;
            button2.Visible = false;
            btnHome.Visible = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Hide();
            printPreviewDialog1.ShowDialog();
            
        }

        private void Confirmation_Load(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            var data = db.Tickets.Find(BookingDetails.ticketNumber);
            labelticketno.Text = data.TicketNumber.ToString();
            labelprice.Text = data.Price.ToString();
            labelname.Text = data.PassengerName;
            labeltripnum.Text = data.TripNumber.ToString();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
