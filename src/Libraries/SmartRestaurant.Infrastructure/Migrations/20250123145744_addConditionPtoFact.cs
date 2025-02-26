using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class addConditionPtoFact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConditionPaiement",
                table: "Factures",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VcId",
                table: "Factures",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "VcId",
                table: "Bls",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                column: "DateEcheance",
                value: new DateTime(2035, 1, 23, 15, 57, 41, 662, DateTimeKind.Local).AddTicks(1709));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConditionPaiement",
                table: "Factures");

            migrationBuilder.DropColumn(
                name: "VcId",
                table: "Factures");

            migrationBuilder.DropColumn(
                name: "VcId",
                table: "Bls");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                column: "DateEcheance",
                value: new DateTime(2035, 1, 23, 13, 12, 1, 191, DateTimeKind.Local).AddTicks(2058));
        }
    }
}
