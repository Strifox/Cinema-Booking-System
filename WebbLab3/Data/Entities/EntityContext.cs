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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var salonConfig = modelBuilder.Entity<Salon>();
            var customerConfig = modelBuilder.Entity<Customer>();
            var movieConfig = modelBuilder.Entity<Movie>();

            salonConfig.ToTable("Salon");
            salonConfig.HasKey(p => p.Id);

            customerConfig.ToTable("Customer");
            customerConfig.HasKey(p => p.Id);
          
            movieConfig.ToTable("Movie");
            movieConfig.HasKey(p => p.MovieName);


        }
    }
}
