using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebbLab3
{
    public class Showing
    {
        public int Id { get; set; }
        public IList<Booking> Bookings { get; set; }
        public DateTime MovieDateTime { get; set; }
        public Movie Movie { get; set; }
        public Salon Salon { get; set; }
        public int MovieId { get; set; }
        public int SalonId { get; set; }
    }
}
