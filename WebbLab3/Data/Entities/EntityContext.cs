using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebbLab3
{
    public class EntityContext : DbContext
    {
       

        public EntityContext(DbContextOptions<EntityContext> DBConnection) : base(DBConnection) { }
        public virtual DbSet<Salon> Salons { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var salonConfig = modelBuilder.Entity<Salon>();
            var customerConfig = modelBuilder.Entity<Customer>();
            var movieConfig = modelBuilder.Entity<Movie>();

            salonConfig.ToTable("Salon");
            salonConfig.HasKey(p => p.Id);

            salonConfig.Property(p => p.SalonName)
                .HasColumnName("Movie")
                .HasColumnType("int");
            salonConfig.Property(p => p.SalonSeats)
                .HasColumnName("Seats")
                .HasColumnType("int");

            //Relation 1:n
            salonConfig.HasMany(p => p.Customers)
                .WithOne(p => p.Salon);

            customerConfig.ToTable("Customer");
            customerConfig.HasKey(p => p.Id);

            customerConfig.Property(p => p.PlayerTickets)
                .HasColumnName("Tickets")
                .HasColumnType("int");
            customerConfig.Property(p => p.UserName)
                .HasColumnName("Name")
                .HasColumnType("nvarchar");

            //Relation 1:n
            customerConfig.HasOne(p => p.Salon)
                .WithMany(p => p.Customers);

            movieConfig.ToTable("Movie");
            movieConfig.HasKey(p => p.MovieName);

            movieConfig.Property(p => p.MovieName)
                .HasColumnName("MovieName")
                .HasColumnType("nvarchar");

            movieConfig.Property(p => p.MovieDateTime)
                .HasColumnName("MovieViewTime")
                .HasColumnType("DateTime");

            movieConfig.HasMany(p => p.Salons)
                .WithOne(p => p.Movie);

        }
    }
}
