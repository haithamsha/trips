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
    }
}
