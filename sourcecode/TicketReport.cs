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
    public partial class TicketReport : Form
    {
        public TicketReport()
        {
            InitializeComponent();
        }

        private void TicketReport_Load(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();

            dataGridView1.DataSource = db.Tickets.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();

            var data = db.Tickets.GroupBy(t => t.TripNumber).OrderByDescending(tt => tt.Count()).Select(g =>  new { TripNumber =  g.Key });
            dataGridView1.DataSource = data.Take(1).ToList();

            lbl1.Visible = false;
            lbl2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataBaseContext db = new DataBaseContext();

            var data = db.Tickets.GroupBy(t => t.SalesMan).OrderByDescending(tt => tt.Count()).Select(g => new { SalesMan = g.Key });
            dataGridView1.DataSource = data.Take(1).ToList();

            lbl1.Visible = true;
            lbl2.Visible = true;

            decimal total = db.Tickets.Sum(t => t.Price);

            decimal x = 0.30m;

            lbl2.Text = (total * x).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
