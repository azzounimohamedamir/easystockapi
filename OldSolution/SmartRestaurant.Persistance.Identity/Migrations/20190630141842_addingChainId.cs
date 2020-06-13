using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistance.Identity.Migrations
{
    public partial class addingChainId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChainId",
                table: "SRUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RestuarantId",
                table: "SRUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChainId",
                table: "SRUsers");

            migrationBuilder.DropColumn(
                name: "RestuarantId",
                table: "SRUsers");
        }
    }
}
