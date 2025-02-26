using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                columns: new[] { "Addresse", "DateEcheance" },
                values: new object[] { "Adresse", new DateTime(2035, 2, 20, 14, 9, 54, 694, DateTimeKind.Local).AddTicks(1942) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                columns: new[] { "Addresse", "DateEcheance" },
                values: new object[] { "", new DateTime(2035, 1, 23, 20, 14, 5, 986, DateTimeKind.Local).AddTicks(9458) });
        }
    }
}
