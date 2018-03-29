using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebbLab3 
{
    public class Movie
    {

        //Navigation Property
        public IList<Showing> Showings { get; set; }
        public string MovieName { get; set; }
        public int Id { get; set; }
        public int SalonId { get; set; }
    }
}
