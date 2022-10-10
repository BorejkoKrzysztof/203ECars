using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2035Cars_Infrastructure.Database.Migrations
{
    public partial class AddAvailableFromToCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RentedTo",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentedTo",
                table: "Cars");
        }
    }
}
