using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebbLab3
{
    public static class DbInitializer
    {
        public static void Initialize(EntityContext context)
        {
            context.Database.EnsureCreated();

            if (context.Movies.Any())
            {
                return;
            }

            
            var movies = new[] //Movie Array
            {
                new Movie{MovieName = "Black Panther"},
                new Movie{MovieName = "The Avengers"},
                new Movie{MovieName = "Star Wars - Rogue One"},
                new Movie{MovieName = "Bad Boys III"}
            };

            foreach (var movie in movies)
            {
                context.Movies.Add(movie);
            }

            context.SaveChanges();

            var salons = new[] // Salons Array
            {
                new Salon{SalonName = "The Stone", SalonSeats = 50},
                new Salon{SalonName = "The Rock", SalonSeats = 100}
            };

            foreach (var salon in salons)
            {
                context.Salons.Add(salon);
            }

            context.SaveChanges();

            var showings = new[] // Showings Array
            {
                new Showing{MovieId = 1, SalonId = 1, MovieDateTime = DateTime.Parse("2018-04-01 20:20:00Z")},
                new Showing{MovieId = 2, SalonId = 2, MovieDateTime = DateTime.Parse("2018-04-01 20:20:00Z")},
                new Showing{MovieId = 3, SalonId = 1, MovieDateTime = DateTime.Parse("2018-04-02 21:20:00Z")},
                new Showing{MovieId = 4, SalonId = 2, MovieDateTime = DateTime.Parse("2018-04-02 21:20:00Z")},
                new Showing{MovieId = 1, SalonId = 1, MovieDateTime = DateTime.Parse("2018-04-01 22:20:00Z")},
                new Showing{MovieId = 2, SalonId = 2, MovieDateTime = DateTime.Parse("2018-04-01 22:20:00Z")},
                new Showing{MovieId = 3, SalonId = 1, MovieDateTime = DateTime.Parse("2018-04-02 23:20:00Z")},
                new Showing{MovieId = 4, SalonId = 2, MovieDateTime = DateTime.Parse("2018-04-02 23:20:00Z")},
            };

            foreach (var showing in showings)
            {
                context.Showings.Add(showing);
            }
            context.SaveChanges();

            var bookings = new[] // Bookings Array
            {
                new Booking{ShowingId = 1, Tickets = 300},
                new Booking{ShowingId = 2, Tickets = 300},
                new Booking{ShowingId = 3, Tickets = 300},
                new Booking{ShowingId = 4, Tickets = 300},
                new Booking{ShowingId = 5, Tickets = 300},
                new Booking{ShowingId = 6, Tickets = 300},
                new Booking{ShowingId = 7, Tickets = 300},  
                new Booking{ShowingId = 8, Tickets = 300},
            };
            foreach (var booking in bookings)
            {
                context.Bookings.Add(booking);
            }
            context.SaveChanges();
        }
    }
}
