using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddAllOdooMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OdooId",
                table: "Products",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "SyncFromOdoo",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "OdooId",
                table: "OrderProducts",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OdooId",
                table: "OrderDishes",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.AddColumn<long>(
                name: "OdooId",
                table: "FoodBusinessClients",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.AddColumn<long>(
                name: "OdooId",
                table: "Dishes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "SyncFromOdoo",
                table: "Dishes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OdooId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SyncFromOdoo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OdooId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "OdooId",
                table: "OrderDishes");

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
                name: "OdooId",
                table: "FoodBusinessClients");

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

            migrationBuilder.DropColumn(
                name: "OdooId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "SyncFromOdoo",
                table: "Dishes");
        }
    }
}
