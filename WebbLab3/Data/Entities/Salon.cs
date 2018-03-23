using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebbLab3
{
    public class Salon
    {
        //Navigation Property
        public IList<Showing> Showings { get; set; }


        public int Id { get; set; }
        public int SalonSeats { get; set; }
        public string SalonName { get; set; } // Sets SalonName to same number as ID, e.g Salon 1 & Salon 2 etc.
    }
}
