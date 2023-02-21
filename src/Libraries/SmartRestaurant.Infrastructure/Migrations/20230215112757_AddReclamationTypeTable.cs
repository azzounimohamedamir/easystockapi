using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddReclamationTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeReclamations",
                columns: table => new
                {
                    TypeReclamationId = table.Column<Guid>(nullable: false),
                    HotelId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Names_AR = table.Column<string>(nullable: true),
                    Names_EN = table.Column<string>(nullable: true),
                    Names_FR = table.Column<string>(nullable: true),
                    Names_TR = table.Column<string>(nullable: true),
                    Names_RU = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeReclamations", x => x.TypeReclamationId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FoodBusinessUserRatings_FoodBusinesses_FoodBusinessId",
                table: "FoodBusinessUserRatings",
                column: "FoodBusinessId",
                principalTable: "FoodBusinesses",
                principalColumn: "FoodBusinessId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodBusinessUserRatings_FoodBusinesses_FoodBusinessId",
                table: "FoodBusinessUserRatings");

            migrationBuilder.DropTable(
                name: "TypeReclamations");
        }
    }
}
