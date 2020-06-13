using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Migrations
{
    public partial class NewFoodsDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsIndustriel",
                table: "Foods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNatural",
                table: "Foods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UnitId",
                table: "Foods",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FoodCompositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    FoodId = table.Column<Guid>(nullable: false),
                    Quantity_Value = table.Column<decimal>(nullable: false),
                    Quantity_UnitId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCompositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodCompositions_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodCompositions_Units_Quantity_UnitId",
                        column: x => x.Quantity_UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_UnitId",
                table: "Foods",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCompositions_FoodId",
                table: "FoodCompositions",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCompositions_Quantity_UnitId",
                table: "FoodCompositions",
                column: "Quantity_UnitId");

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

            migrationBuilder.DropTable(
                name: "FoodCompositions");

            migrationBuilder.DropIndex(
                name: "IX_Foods_UnitId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "IsIndustriel",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "IsNatural",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Foods");
        }
    }
}
