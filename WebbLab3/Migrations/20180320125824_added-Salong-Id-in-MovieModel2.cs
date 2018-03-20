using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebbLab3.Migrations
{
    public partial class addedSalongIdinMovieModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Salon_SalonId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "SalongId",
                table: "Movie");

            migrationBuilder.AlterColumn<int>(
                name: "SalonId",
                table: "Movie",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Salon_SalonId",
                table: "Movie",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Salon_SalonId",
                table: "Movie");

            migrationBuilder.AlterColumn<int>(
                name: "SalonId",
                table: "Movie",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SalongId",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Salon_SalonId",
                table: "Movie",
                column: "SalonId",
                principalTable: "Salon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
