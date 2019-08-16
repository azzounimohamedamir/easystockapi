using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Migrations
{
    public partial class FoodUnitRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Units_UnitId",
                table: "Foods");

            migrationBuilder.AlterColumn<Guid>(
                name: "UnitId",
                table: "Foods",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Units_UnitId",
                table: "Foods",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Units_UnitId",
                table: "Foods");

            migrationBuilder.AlterColumn<Guid>(
                name: "UnitId",
                table: "Foods",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Units_UnitId",
                table: "Foods",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
