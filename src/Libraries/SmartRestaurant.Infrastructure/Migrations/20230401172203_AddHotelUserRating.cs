using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddHotelUserRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AverageRating",
                table: "Hotels",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "HotelUserRatings",
                columns: table => new
                {
                    HotelId = table.Column<Guid>(nullable: false),
                    ApplicationUserId = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelUserRatings", x => new { x.HotelId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_HotelUserRatings_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelUserRatings");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Hotels");
        }
    }
}
