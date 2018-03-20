using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebbLab3
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Salon> Salons { get; set; }
    }
}
