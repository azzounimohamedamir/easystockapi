using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistance.Identity.Migrations.SmartRestaurantTeamIdentityDb
{
    public partial class addrolename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "roleName",
                table: "BaseRoles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "roleName",
                table: "BaseRoles");
        }
    }
}
