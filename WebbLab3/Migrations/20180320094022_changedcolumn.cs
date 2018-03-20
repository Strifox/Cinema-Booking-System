using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebbLab3.Migrations
{
    public partial class changedcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Movie",
                table: "Salon",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Salon",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Salon",
                newName: "Movie");

            migrationBuilder.AlterColumn<int>(
                name: "Movie",
                table: "Salon",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "nvarchar(50)");
        }
    }
}
