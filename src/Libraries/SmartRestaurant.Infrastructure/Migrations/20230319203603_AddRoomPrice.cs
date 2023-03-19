using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddRoomPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Rooms");
        }
    }
}
