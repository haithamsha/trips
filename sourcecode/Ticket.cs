using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sourcecode
{
    public class Ticket
    {
        [Key]
        public int TicketNumber { get; set; }
        public string PassengerName { get; set; }
        public string Note { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int TripNumber { get; set; }
        public decimal Price { get; set; }
        public string SalesMan { get; set; }

    }
}
