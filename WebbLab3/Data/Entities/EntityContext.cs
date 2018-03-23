using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebbLab3
{
    public class EntityContext : DbContext
    {

        public EntityContext(DbContextOptions<EntityContext> options) : base(options) { }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Showing> Showings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Salon>().ToTable("Salon");
            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<Booking>().ToTable("Booking");
            modelBuilder.Entity<Showing>().ToTable("Showing");

        }
    }
}
