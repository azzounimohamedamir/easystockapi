using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class UpdateHotelOrderAndHotelServiceTabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsIncludeQuantity",
                table: "HotelServices",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "HotelServices",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "HotelOrders",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TotalToPay",
                table: "HotelOrders",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "UnitePrice",
                table: "HotelOrders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIncludeQuantity",
                table: "HotelServices");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "HotelServices");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "HotelOrders");

            migrationBuilder.DropColumn(
                name: "TotalToPay",
                table: "HotelOrders");

            migrationBuilder.DropColumn(
                name: "UnitePrice",
                table: "HotelOrders");
        }
    }
}
