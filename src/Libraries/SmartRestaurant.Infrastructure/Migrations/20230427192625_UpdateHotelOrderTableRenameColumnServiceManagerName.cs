using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class UpdateHotelOrderTableRenameColumnServiceManagerName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceManagerName",
                table: "HotelOrders");

            migrationBuilder.AddColumn<string>(
                name: "OrderDestinationId",
                table: "HotelOrders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDestinationId",
                table: "HotelOrders");

            migrationBuilder.AddColumn<string>(
                name: "ServiceManagerName",
                table: "HotelOrders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
