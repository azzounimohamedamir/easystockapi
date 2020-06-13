using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Migrations
{
    public partial class DishesEquivalences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Ingredient_IngredientId",
                table: "DishIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishAccompanying",
                table: "DishAccompanying");

            migrationBuilder.DropIndex(
                name: "IX_DishAccompanying_ParentId",
                table: "DishAccompanying");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DishAccompanying");

            migrationBuilder.DropColumn(
                name: "Alias",
                table: "DishAccompanying");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "DishAccompanying");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DishAccompanying");

            migrationBuilder.DropColumn(
                name: "SlugUrl",
                table: "DishAccompanying");

            migrationBuilder.AlterColumn<Guid>(
                name: "IngredientId",
                table: "DishIngredients",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "FoodId",
                table: "DishIngredients",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishAccompanying",
                table: "DishAccompanying",
                columns: new[] { "ParentId", "AccompanyingId" });

            migrationBuilder.CreateTable(
                name: "DishEquivalences",
                columns: table => new
                {
                    ParentId = table.Column<Guid>(nullable: false),
                    EquivalenceId = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Quantity_Value = table.Column<decimal>(nullable: false),
                    Quantity_UnitId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishEquivalences", x => new { x.ParentId, x.EquivalenceId });
                    table.ForeignKey(
                        name: "FK_DishEquivalences_Dishes_EquivalenceId",
                        column: x => x.EquivalenceId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishEquivalences_Dishes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DishEquivalences_Units_Quantity_UnitId",
                        column: x => x.Quantity_UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_FoodId",
                table: "DishIngredients",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_DishEquivalences_EquivalenceId",
                table: "DishEquivalences",
                column: "EquivalenceId");

            migrationBuilder.CreateIndex(
                name: "IX_DishEquivalences_Quantity_UnitId",
                table: "DishEquivalences",
                column: "Quantity_UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Foods_FoodId",
                table: "DishIngredients",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Ingredient_IngredientId",
                table: "DishIngredients",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Foods_FoodId",
                table: "DishIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Ingredient_IngredientId",
                table: "DishIngredients");

            migrationBuilder.DropTable(
                name: "DishEquivalences");

            migrationBuilder.DropIndex(
                name: "IX_DishIngredients_FoodId",
                table: "DishIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishAccompanying",
                table: "DishAccompanying");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "DishIngredients");

            migrationBuilder.AlterColumn<Guid>(
                name: "IngredientId",
                table: "DishIngredients",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "DishAccompanying",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "DishAccompanying",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DishAccompanying",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DishAccompanying",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SlugUrl",
                table: "DishAccompanying",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishAccompanying",
                table: "DishAccompanying",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DishAccompanying_ParentId",
                table: "DishAccompanying",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Ingredient_IngredientId",
                table: "DishIngredients",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
