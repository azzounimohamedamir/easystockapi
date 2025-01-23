using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class addTotalBenificeToStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalBenifice",
                table: "Stocks",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                column: "DateEcheance",
                value: new DateTime(2035, 1, 23, 8, 27, 54, 637, DateTimeKind.Local).AddTicks(8136));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalBenifice",
                table: "Stocks");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                column: "DateEcheance",
                value: new DateTime(2035, 1, 22, 9, 2, 23, 675, DateTimeKind.Local).AddTicks(7706));
        }
    }
}
