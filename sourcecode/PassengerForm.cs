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
    public partial class PassengerForm : Form
    {
        public PassengerForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();
            int number = int.Parse(txtNO.Text);
            var data = db.Tickets.Where(t => t.TicketNumber == number && t.PassengerName == txtName.Text).FirstOrDefault();
            lblBirthDate.Text = data.BirthDate.ToShortDateString();
            lblEmail.Text = data.Email;
            lblName.Text = data.PassengerName;
            lblNotes.Text = data.Note;
            lblPhone.Text = data.Phone;
            lblPrice.Text = data.Price.ToString();
            lblTripNumber.Text = data.TripNumber.ToString();
            
        }
        Bitmap bmp;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(groupBox1.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Hide();
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
