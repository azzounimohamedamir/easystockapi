using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddHotelDetailsTableAndUpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YoutubeLink",
                table: "Hotels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HotelDetailsSections",
                columns: table => new
                {
                    HotelDetailsSectionId = table.Column<Guid>(nullable: false),
                    HotelId = table.Column<Guid>(nullable: false),
                    Picture = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelDetailsSections", x => x.HotelDetailsSectionId);
                    table.ForeignKey(
                        name: "FK_HotelDetailsSections_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelDetailsSections_HotelId",
                table: "HotelDetailsSections",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelDetailsSections");

            migrationBuilder.DropColumn(
                name: "YoutubeLink",
                table: "Hotels");
        }
    }
}
