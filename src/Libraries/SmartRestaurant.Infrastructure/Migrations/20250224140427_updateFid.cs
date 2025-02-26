using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateFid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientFidelites_NiveauFidelites_NiveauFideliteId",
                table: "ClientFidelites");

            migrationBuilder.DropIndex(
                name: "IX_ClientFidelites_NiveauFideliteId",
                table: "ClientFidelites");

            migrationBuilder.DropColumn(
                name: "NiveauFideliteId",
                table: "ClientFidelites");

            migrationBuilder.AlterColumn<decimal>(
                name: "SommeFacture",
                table: "DefaultConfigLogs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PointsGagner",
                table: "DefaultConfigLogs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MinimumPointsToWithdraw",
                table: "DefaultConfigLogs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                column: "DateEcheance",
                value: new DateTime(2035, 2, 24, 15, 4, 25, 416, DateTimeKind.Local).AddTicks(9201));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinimumPointsToWithdraw",
                table: "DefaultConfigLogs");

            migrationBuilder.AlterColumn<string>(
                name: "SommeFacture",
                table: "DefaultConfigLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "PointsGagner",
                table: "DefaultConfigLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<Guid>(
                name: "NiveauFideliteId",
                table: "ClientFidelites",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                column: "DateEcheance",
                value: new DateTime(2035, 2, 24, 13, 7, 5, 820, DateTimeKind.Local).AddTicks(6514));

            migrationBuilder.CreateIndex(
                name: "IX_ClientFidelites_NiveauFideliteId",
                table: "ClientFidelites",
                column: "NiveauFideliteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientFidelites_NiveauFidelites_NiveauFideliteId",
                table: "ClientFidelites",
                column: "NiveauFideliteId",
                principalTable: "NiveauFidelites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
