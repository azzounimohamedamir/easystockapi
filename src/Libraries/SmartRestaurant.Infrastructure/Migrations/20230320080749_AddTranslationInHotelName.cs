using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddTranslationInHotelName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Names_AR",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_EN",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_FR",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_RU",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_TR",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_AR",
                table: "FoodBusinesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_EN",
                table: "FoodBusinesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_FR",
                table: "FoodBusinesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_RU",
                table: "FoodBusinesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_TR",
                table: "FoodBusinesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_AR",
                table: "FoodBusinessClients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_EN",
                table: "FoodBusinessClients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_FR",
                table: "FoodBusinessClients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_RU",
                table: "FoodBusinessClients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_TR",
                table: "FoodBusinessClients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Names_AR",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Names_EN",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Names_FR",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Names_RU",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Names_TR",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Names_AR",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "Names_EN",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "Names_FR",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "Names_RU",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "Names_TR",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "Names_AR",
                table: "FoodBusinessClients");

            migrationBuilder.DropColumn(
                name: "Names_EN",
                table: "FoodBusinessClients");

            migrationBuilder.DropColumn(
                name: "Names_FR",
                table: "FoodBusinessClients");

            migrationBuilder.DropColumn(
                name: "Names_RU",
                table: "FoodBusinessClients");

            migrationBuilder.DropColumn(
                name: "Names_TR",
                table: "FoodBusinessClients");
        }
    }
}
