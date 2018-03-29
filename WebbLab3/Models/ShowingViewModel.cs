using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebbLab3
{
    public class ShowingViewModel
    {

        public int Id { get; set; }

        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string SalonName { get; set; }
        public int Tickets { get; set; }
        public DateTime MovieDateTime { get; set; }
    }
}
