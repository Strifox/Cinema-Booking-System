using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebbLab3
{
    public class Booking
    {
        public int Id { get; set; }
        public Showing Showing { get; set; }
        public int ShowingId { get; set; }
        public int Tickets { get; set; }
    }
}
