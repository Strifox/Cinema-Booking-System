using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebbLab3
{
    public class Salon
    {
        //Navigation Property
        public IList<Movie> Movies { get; set; }

        private int id { get; set; }
        private string salonName { get; set; }
        private int salonSeats { get; set; }

        //public int Id { get => id; set => id = value; }
        public int Id { get => id; set => id = value; }
        public int SalonSeats { get => salonSeats; set => salonSeats = value; }
        public string SalonName { get => salonName; set => salonName = value; } // Sets SalonName to same number as ID, e.g Salon 1 & Salon 2 etc.
    }
}
