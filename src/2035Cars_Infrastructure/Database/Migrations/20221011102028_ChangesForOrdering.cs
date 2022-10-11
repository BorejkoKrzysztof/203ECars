using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2035Cars_Infrastructure.Database.Migrations
{
    public partial class ChangesForOrdering : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishEmployeeId",
                table: "Orders");

            migrationBuilder.AlterColumn<long>(
                name: "AcceptEmployeeId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UniqueOrderNumber",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AcceptEmployeeId",
                table: "Orders",
                column: "AcceptEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employees_AcceptEmployeeId",
                table: "Orders",
                column: "AcceptEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employees_AcceptEmployeeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AcceptEmployeeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ClientId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UniqueOrderNumber",
                table: "Orders");

            migrationBuilder.AlterColumn<long>(
                name: "AcceptEmployeeId",
                table: "Orders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "PublishEmployeeId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
