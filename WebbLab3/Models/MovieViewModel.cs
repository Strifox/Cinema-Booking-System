using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebbLab3
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public IList<Salon> Salons { get; set; }
    }
}
