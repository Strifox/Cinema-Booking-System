using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebbLab3 
{
    public class Movie
    {
        private Salon salon = new Salon();

        //Navigation Property
        public Salon Salon { get; set; }

        private string movieName { get; set; }
        private DateTime movieDateTime { get; set; }

        public string MovieName { get => movieName; set => movieName = value; }
        public DateTime MovieDateTime { get => movieDateTime; set => movieDateTime = value; }
        public int SalonId { get => salon.Id; set => salon.Id = value; }

     
    }
}
