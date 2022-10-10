using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2035Cars_Infrastructure.Database.Migrations
{
    public partial class FixArchitecture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Person_FirstName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Person_LastName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Person_PhoneNumber = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublishEmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    AcceptEmployeeId = table.Column<long>(type: "bigint", nullable: true),
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    CarId = table.Column<long>(type: "bigint", nullable: false),
                    FromRentalId = table.Column<long>(type: "bigint", nullable: false),
                    ToRentalId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CostOfRental = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Finished = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Address_Number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CarType = table.Column<int>(type: "int", nullable: false),
                    Equipment_HasAirCooling = table.Column<bool>(type: "bit", nullable: false),
                    Equipment_HasHeatingSeat = table.Column<bool>(type: "bit", nullable: false),
                    Equipment_HasAutomaticGearBox = table.Column<bool>(type: "bit", nullable: false),
                    Equipment_HasBuildInNavigation = table.Column<bool>(type: "bit", nullable: false),
                    DriveType = table.Column<int>(type: "int", nullable: false),
                    AmountOfDoor = table.Column<int>(type: "int", nullable: false),
                    AmountOfSeats = table.Column<int>(type: "int", nullable: false),
                    PriceForOneHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsRented = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RentalId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Rentals_RentalId",
                        column: x => x.RentalId,
                        principalTable: "Rentals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Person_FirstName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Person_LastName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Person_PhoneNumber = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Address_Number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Account_EmailAddress = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Account_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    LastLoggedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Rentals_RentalId",
                        column: x => x.RentalId,
                        principalTable: "Rentals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RentalId",
                table: "Cars",
                column: "RentalId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RentalId",
                table: "Employees",
                column: "RentalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Rentals");
        }
    }
}
