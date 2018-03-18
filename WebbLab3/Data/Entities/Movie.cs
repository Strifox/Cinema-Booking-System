using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebbLab3
{
    public class Movie
    {
        public  IList<Salon> Salons { get; set; }
        private string movieName { get; set; }
        private DateTime movieDateTime { get; set; }

        public string MovieName { get => movieName; set => movieName = value; }
        public DateTime MovieDateTime { get => movieDateTime; set => movieDateTime = value; }

    }
}
