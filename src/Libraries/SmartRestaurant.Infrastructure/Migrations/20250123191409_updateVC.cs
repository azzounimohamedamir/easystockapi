using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateVC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTransformed",
                table: "VenteComptoirs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                column: "DateEcheance",
                value: new DateTime(2035, 1, 23, 20, 14, 5, 986, DateTimeKind.Local).AddTicks(9458));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTransformed",
                table: "VenteComptoirs");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                column: "DateEcheance",
                value: new DateTime(2035, 1, 23, 18, 53, 3, 334, DateTimeKind.Local).AddTicks(8710));
        }
    }
}
