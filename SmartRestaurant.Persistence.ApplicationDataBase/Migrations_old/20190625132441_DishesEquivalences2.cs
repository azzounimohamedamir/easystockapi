using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Migrations
{
    public partial class DishesEquivalences2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishEquivalences_Units_Quantity_UnitId",
                table: "DishEquivalences");

            migrationBuilder.RenameColumn(
                name: "Quantity_Value",
                table: "DishEquivalences",
                newName: "QuantityParent_Value");

            migrationBuilder.RenameColumn(
                name: "Quantity_UnitId",
                table: "DishEquivalences",
                newName: "QuantityParent_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_DishEquivalences_Quantity_UnitId",
                table: "DishEquivalences",
                newName: "IX_DishEquivalences_QuantityParent_UnitId");

            migrationBuilder.AddColumn<Guid>(
                name: "QuantityEquivalence_UnitId",
                table: "DishEquivalences",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "QuantityEquivalence_Value",
                table: "DishEquivalences",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_DishEquivalences_QuantityEquivalence_UnitId",
                table: "DishEquivalences",
                column: "QuantityEquivalence_UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishEquivalences_Units_QuantityEquivalence_UnitId",
                table: "DishEquivalences",
                column: "QuantityEquivalence_UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishEquivalences_Units_QuantityParent_UnitId",
                table: "DishEquivalences",
                column: "QuantityParent_UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishEquivalences_Units_QuantityEquivalence_UnitId",
                table: "DishEquivalences");

            migrationBuilder.DropForeignKey(
                name: "FK_DishEquivalences_Units_QuantityParent_UnitId",
                table: "DishEquivalences");

            migrationBuilder.DropIndex(
                name: "IX_DishEquivalences_QuantityEquivalence_UnitId",
                table: "DishEquivalences");

            migrationBuilder.DropColumn(
                name: "QuantityEquivalence_UnitId",
                table: "DishEquivalences");

            migrationBuilder.DropColumn(
                name: "QuantityEquivalence_Value",
                table: "DishEquivalences");

            migrationBuilder.RenameColumn(
                name: "QuantityParent_Value",
                table: "DishEquivalences",
                newName: "Quantity_Value");

            migrationBuilder.RenameColumn(
                name: "QuantityParent_UnitId",
                table: "DishEquivalences",
                newName: "Quantity_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_DishEquivalences_QuantityParent_UnitId",
                table: "DishEquivalences",
                newName: "IX_DishEquivalences_Quantity_UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishEquivalences_Units_Quantity_UnitId",
                table: "DishEquivalences",
                column: "Quantity_UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
