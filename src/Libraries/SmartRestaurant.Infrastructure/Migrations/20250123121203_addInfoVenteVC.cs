using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class addInfoVenteVC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConditionDePaiment",
                table: "VenteComptoirs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Conducteur",
                table: "VenteComptoirs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LieuLivraison",
                table: "VenteComptoirs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatriculeVeh",
                table: "VenteComptoirs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomVehicule",
                table: "VenteComptoirs",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                column: "DateEcheance",
                value: new DateTime(2035, 1, 23, 13, 12, 1, 191, DateTimeKind.Local).AddTicks(2058));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConditionDePaiment",
                table: "VenteComptoirs");

            migrationBuilder.DropColumn(
                name: "Conducteur",
                table: "VenteComptoirs");

            migrationBuilder.DropColumn(
                name: "LieuLivraison",
                table: "VenteComptoirs");

            migrationBuilder.DropColumn(
                name: "MatriculeVeh",
                table: "VenteComptoirs");

            migrationBuilder.DropColumn(
                name: "NomVehicule",
                table: "VenteComptoirs");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                column: "DateEcheance",
                value: new DateTime(2035, 1, 23, 8, 27, 54, 637, DateTimeKind.Local).AddTicks(8136));
        }
    }
}
