using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistance.Identity.Migrations
{
    public partial class CorrectedRestaurantField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RestuarantId",
                table: "SRUsers",
                newName: "RestaurantId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "SRUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "SRUsers");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "SRUsers",
                newName: "RestuarantId");
        }
    }
}
