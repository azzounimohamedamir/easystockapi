using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class changeStockTableShema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Categories_CategoryId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_CategoryId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Stocks");

            migrationBuilder.AddColumn<string>(
                name: "ProductAttributeValues",
                table: "Stocks",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                column: "DateEcheance",
                value: new DateTime(2035, 1, 8, 13, 9, 22, 549, DateTimeKind.Local).AddTicks(8126));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductAttributeValues",
                table: "Stocks");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Stocks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                column: "DateEcheance",
                value: new DateTime(2035, 1, 6, 9, 6, 31, 164, DateTimeKind.Local).AddTicks(7816));

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_CategoryId",
                table: "Stocks",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Categories_CategoryId",
                table: "Stocks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
