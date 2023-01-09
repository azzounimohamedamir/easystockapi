using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class UpdateOrderProductTableAddSectionSubsection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SectionId",
                table: "OrderProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubSectionId",
                table: "OrderProducts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "SubSectionId",
                table: "OrderProducts");
        }
    }
}
