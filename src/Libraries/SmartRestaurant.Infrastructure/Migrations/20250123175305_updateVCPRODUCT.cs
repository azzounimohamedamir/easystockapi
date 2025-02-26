using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateVCPRODUCT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Montant",
                table: "VenteComptoirProducts");

            migrationBuilder.AddColumn<decimal>(
                name: "MontantHT",
                table: "VenteComptoirProducts",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontantTTC",
                table: "VenteComptoirProducts",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontantTVA",
                table: "VenteComptoirProducts",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                column: "DateEcheance",
                value: new DateTime(2035, 1, 23, 18, 53, 3, 334, DateTimeKind.Local).AddTicks(8710));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontantHT",
                table: "VenteComptoirProducts");

            migrationBuilder.DropColumn(
                name: "MontantTTC",
                table: "VenteComptoirProducts");

            migrationBuilder.DropColumn(
                name: "MontantTVA",
                table: "VenteComptoirProducts");

            migrationBuilder.AddColumn<decimal>(
                name: "Montant",
                table: "VenteComptoirProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                column: "DateEcheance",
                value: new DateTime(2035, 1, 23, 15, 57, 41, 662, DateTimeKind.Local).AddTicks(1709));
        }
    }
}
