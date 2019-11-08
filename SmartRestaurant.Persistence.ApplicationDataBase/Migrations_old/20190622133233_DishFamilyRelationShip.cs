using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Migrations
{
    public partial class DishFamilyRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DishFamillies_FamilyId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_FamilyId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "Dishes");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_FamillyId",
                table: "Dishes",
                column: "FamillyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DishFamillies_FamillyId",
                table: "Dishes",
                column: "FamillyId",
                principalTable: "DishFamillies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DishFamillies_FamillyId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_FamillyId",
                table: "Dishes");

            migrationBuilder.AddColumn<Guid>(
                name: "FamilyId",
                table: "Dishes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_FamilyId",
                table: "Dishes",
                column: "FamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DishFamillies_FamilyId",
                table: "Dishes",
                column: "FamilyId",
                principalTable: "DishFamillies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
