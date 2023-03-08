using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddOdooIdToMenuItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OdooId",
                table: "Products",
                nullable: false,
                defaultValue: -1);

            migrationBuilder.AddColumn<long>(
                name: "OdooId",
                table: "Dishes",
                nullable: false,
                defaultValue: -1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OdooId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OdooId",
                table: "Dishes");
        }
    }
}
