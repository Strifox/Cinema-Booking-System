using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebbLab3.Migrations
{
    public partial class addedSalongIdinMovieModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Salon",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "nvarchar(50)");

            migrationBuilder.AddColumn<int>(
                name: "SalongId",
                table: "Movie",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalongId",
                table: "Movie");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Salon",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);
        }
    }
}
