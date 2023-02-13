using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class UpdateDishAndProductTableAddIsQuantityCheckedQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        

                migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Dishes",
                nullable: true,
                defaultValue: 0);

                migrationBuilder.AddColumn<bool>(
                name: "IsQuantityChecked",
                table: "Dishes",
                defaultValue: true);

                migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                nullable: true,
                defaultValue: 0);

                migrationBuilder.AddColumn<bool>(
                name: "IsQuantityChecked",
                table: "Products",
                defaultValue: true);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Dishes"
              );

                migrationBuilder.DropColumn(
                name: "IsQuantityChecked",
                table: "Dishes");

               migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

                migrationBuilder.DropColumn(
                name: "IsQuantityChecked",
                table: "Products");

        }
    }
}
