using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class UpdateOrderDishTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SectionId",
                table: "OrderDishes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubSectionId",
                table: "OrderDishes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "OrderDishes");

            migrationBuilder.DropColumn(
                name: "SubSectionId",
                table: "OrderDishes");
        }
    }
}
