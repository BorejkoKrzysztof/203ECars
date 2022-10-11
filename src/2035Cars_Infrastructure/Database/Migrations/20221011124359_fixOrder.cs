using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2035Cars_Infrastructure.Database.Migrations
{
    public partial class fixOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employees_AcceptEmployeeId",
                table: "Orders");

            migrationBuilder.AlterColumn<long>(
                name: "AcceptEmployeeId",
                table: "Orders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarId",
                table: "Orders",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cars_CarId",
                table: "Orders",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employees_AcceptEmployeeId",
                table: "Orders",
                column: "AcceptEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cars_CarId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employees_AcceptEmployeeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CarId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employees_AcceptEmployeeId",
                table: "Orders",
                column: "AcceptEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
