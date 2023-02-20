using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class UpdateMenuQuantityChecked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int),
                defaultValue:0,
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Dishes",
                nullable: true,
                oldClrType: typeof(int),
                defaultValue:0,
                oldType: "int");

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Dishes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
