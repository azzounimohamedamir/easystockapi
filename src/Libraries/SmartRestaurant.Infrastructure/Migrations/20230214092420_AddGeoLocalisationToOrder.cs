using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddGeoLocalisationToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GeoPosition_Latitude",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeoPosition_Longitude",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeoPosition_Latitude",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "GeoPosition_Longitude",
                table: "Orders");
        }
    }
}
