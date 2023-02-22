using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddIsMenuItemDetailedToFoodBusiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMenuItemDetailed",
                table: "FoodBusinesses",
                nullable: false,
                defaultValue: false);

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
         
            migrationBuilder.DropColumn(
                name: "IsMenuItemDetailed",
                table: "FoodBusinesses");
        }
    }
}
