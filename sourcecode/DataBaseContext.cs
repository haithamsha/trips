using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sourcecode
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext():base(@"Server=.;Database=tribdb;Trusted_Connection=True;")
        {

        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Trip> Trips { get; set; }
        public IDbSet<Ticket> Tickets { get; set; }
    }
}
