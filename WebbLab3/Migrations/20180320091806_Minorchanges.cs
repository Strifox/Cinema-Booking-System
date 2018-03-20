using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebbLab3.Migrations
{
    public partial class Minorchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salon_Movie_MovieName",
                table: "Salon");

            migrationBuilder.DropIndex(
                name: "IX_Salon_MovieName",
                table: "Salon");

            migrationBuilder.DropColumn(
                name: "MovieName",
                table: "Salon");

            migrationBuilder.AddColumn<int>(
                name: "SalonId",
                table: "Movie",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_SalonId",
                table: "Movie",
                column: "SalonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Salon_SalonId",
                table: "Movie",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Salon_SalonId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_SalonId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "SalonId",
                table: "Movie");

            migrationBuilder.AddColumn<string>(
                name: "MovieName",
                table: "Salon",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salon_MovieName",
                table: "Salon",
                column: "MovieName");

            migrationBuilder.AddForeignKey(
                name: "FK_Salon_Movie_MovieName",
                table: "Salon",
                column: "MovieName",
                principalTable: "Movie",
                principalColumn: "MovieName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
