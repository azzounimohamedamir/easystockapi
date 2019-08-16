using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Migrations
{
    public partial class RDishes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishFamillies_Restaurants_RestaurantId",
                table: "DishFamillies");

            migrationBuilder.AddForeignKey(
                name: "FK_DishFamillies_Restaurants_RestaurantId",
                table: "DishFamillies",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishFamillies_Restaurants_RestaurantId",
                table: "DishFamillies");

            migrationBuilder.AddForeignKey(
                name: "FK_DishFamillies_Restaurants_RestaurantId",
                table: "DishFamillies",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
