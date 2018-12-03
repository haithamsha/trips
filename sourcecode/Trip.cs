using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sourcecode
{
    public class Trip
    {
        [Key]
        public int TripNumber { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime TravelDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string TravelTime { get; set; }
        public string ReturnTime { get; set; }
        public decimal Price { get; set; }
    }
}
