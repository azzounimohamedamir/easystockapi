using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddOdooConfigAttributeToHotelAndFoodBusiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Odoo_Db",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Odoo_Password",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Odoo_Url",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Odoo_Username",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Odoo_Db",
                table: "FoodBusinesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Odoo_Password",
                table: "FoodBusinesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Odoo_Url",
                table: "FoodBusinesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Odoo_Username",
                table: "FoodBusinesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Odoo_Db",
                table: "FoodBusinessClients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Odoo_Password",
                table: "FoodBusinessClients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Odoo_Url",
                table: "FoodBusinessClients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Odoo_Username",
                table: "FoodBusinessClients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Odoo_Db",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Odoo_Password",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Odoo_Url",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Odoo_Username",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Odoo_Db",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "Odoo_Password",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "Odoo_Url",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "Odoo_Username",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "Odoo_Db",
                table: "FoodBusinessClients");

            migrationBuilder.DropColumn(
                name: "Odoo_Password",
                table: "FoodBusinessClients");

            migrationBuilder.DropColumn(
                name: "Odoo_Url",
                table: "FoodBusinessClients");

            migrationBuilder.DropColumn(
                name: "Odoo_Username",
                table: "FoodBusinessClients");
        }
    }
}
