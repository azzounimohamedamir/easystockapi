using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistance.Identity.Migrations.SmartRestaurantGuestIdentityDb
{
    public partial class Addrolename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "roleName",
                table: "GuestRoles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "roleName",
                table: "GuestRoles");
        }
    }
}
