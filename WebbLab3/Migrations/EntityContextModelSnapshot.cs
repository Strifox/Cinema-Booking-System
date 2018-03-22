﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebbLab3;

namespace WebbLab3.Migrations
{
    [DbContext(typeof(EntityContext))]
    partial class EntityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebbLab3.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PlayerTickets");

                    b.Property<int?>("SalonId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("SalonId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("WebbLab3.Movie", b =>
                {
                    b.Property<string>("MovieName")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("MovieDateTime");

                    b.Property<int>("SalonId");

                    b.HasKey("MovieName");

                    b.HasIndex("SalonId");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("WebbLab3.Salon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SalonName");

                    b.Property<int>("SalonSeats");

                    b.HasKey("Id");

                    b.ToTable("Salon");
                });

            modelBuilder.Entity("WebbLab3.Customer", b =>
                {
                    b.HasOne("WebbLab3.Salon", "Salon")
                        .WithMany()
                        .HasForeignKey("SalonId");
                });

            modelBuilder.Entity("WebbLab3.Movie", b =>
                {
                    b.HasOne("WebbLab3.Salon", "Salon")
                        .WithMany("Movies")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
