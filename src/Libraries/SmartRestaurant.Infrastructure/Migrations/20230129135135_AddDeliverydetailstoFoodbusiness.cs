using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddDeliverydetailstoFoodbusiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClosingTime",
                table: "FoodBusinesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FarLocationDescription",
                table: "FoodBusinesses",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FarLocationPrice",
                table: "FoodBusinesses",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "NearbyLocationDescription",
                table: "FoodBusinesses",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NearbyLocationPrice",
                table: "FoodBusinesses",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "OpeningTime",
                table: "FoodBusinesses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosingTime",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "FarLocationDescription",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "FarLocationPrice",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "NearbyLocationDescription",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "NearbyLocationPrice",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "OpeningTime",
                table: "FoodBusinesses");
        }
    }
}
