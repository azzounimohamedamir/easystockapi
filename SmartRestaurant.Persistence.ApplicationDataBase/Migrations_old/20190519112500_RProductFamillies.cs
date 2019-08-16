using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Migrations
{
    public partial class RProductFamillies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFamilies_Restaurants_RestaurantId",
                table: "ProductFamilies");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFamilies_Restaurants_RestaurantId",
                table: "ProductFamilies",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFamilies_Restaurants_RestaurantId",
                table: "ProductFamilies");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFamilies_Restaurants_RestaurantId",
                table: "ProductFamilies",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
