using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Migrations
{
    public partial class DisheAccompanying : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishAccompanying_Restaurants_RestaurantId",
                table: "DishAccompanying");

            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Ingredient_IngredientId",
                table: "DishIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Ingredient_IngredientId",
                table: "Foods");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Foods_IngredientId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_DishIngredients_IngredientId",
                table: "DishIngredients");

            migrationBuilder.DropIndex(
                name: "IX_DishAccompanying_RestaurantId",
                table: "DishAccompanying");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "DishAccompanying");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IngredientId",
                table: "Foods",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IngredientId",
                table: "DishIngredients",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "DishAccompanying",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PictureId = table.Column<Guid>(nullable: true),
                    RestaurantId = table.Column<Guid>(nullable: false),
                    SlugUrl = table.Column<string>(nullable: true),
                    UnitId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredient_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingredient_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredient_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_IngredientId",
                table: "Foods",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_IngredientId",
                table: "DishIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_DishAccompanying_RestaurantId",
                table: "DishAccompanying",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_PictureId",
                table: "Ingredient",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RestaurantId",
                table: "Ingredient",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_UnitId",
                table: "Ingredient",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishAccompanying_Restaurants_RestaurantId",
                table: "DishAccompanying",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Ingredient_IngredientId",
                table: "DishIngredients",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Ingredient_IngredientId",
                table: "Foods",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
