using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class changeFoodBusinessMultiNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameArabic",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "NameChinese",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "NameEnglish",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "NameFrench",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "NameRussian",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "NameSpanish",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "NameTurkish",
                table: "FoodBusinesses");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FoodBusinesses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "FoodBusinesses");

            migrationBuilder.AddColumn<string>(
                name: "NameArabic",
                table: "FoodBusinesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameChinese",
                table: "FoodBusinesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEnglish",
                table: "FoodBusinesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameFrench",
                table: "FoodBusinesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameRussian",
                table: "FoodBusinesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameSpanish",
                table: "FoodBusinesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameTurkish",
                table: "FoodBusinesses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
