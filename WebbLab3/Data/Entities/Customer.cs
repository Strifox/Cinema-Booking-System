using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebbLab3
{
    public class Customer
    {
        public virtual Salon Salon { get; set; }


        private int id { get; set; }
        private int playerTickets { get; set; }
        private string userName { get; set; }

        public int Id { get => id; set => id = value; }
        public int PlayerTickets { get => playerTickets; set => playerTickets = value; }
        public string UserName { get => userName; set => userName = value; }
    }
}
