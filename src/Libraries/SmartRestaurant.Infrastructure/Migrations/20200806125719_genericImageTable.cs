using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class genericImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodBusinessImages_FoodBusinesses_FoodBusinessId",
                table: "FoodBusinessImages");

            migrationBuilder.DropIndex(
                name: "IX_FoodBusinessImages_FoodBusinessId",
                table: "FoodBusinessImages");

            migrationBuilder.DropColumn(
                name: "FoodBusinessId",
                table: "FoodBusinessImages");

            migrationBuilder.AddColumn<Guid>(
                name: "EntityId",
                table: "FoodBusinessImages",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "FoodBusinessImages");

            migrationBuilder.AddColumn<Guid>(
                name: "FoodBusinessId",
                table: "FoodBusinessImages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_FoodBusinessImages_FoodBusinessId",
                table: "FoodBusinessImages",
                column: "FoodBusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodBusinessImages_FoodBusinesses_FoodBusinessId",
                table: "FoodBusinessImages",
                column: "FoodBusinessId",
                principalTable: "FoodBusinesses",
                principalColumn: "FoodBusinessId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
