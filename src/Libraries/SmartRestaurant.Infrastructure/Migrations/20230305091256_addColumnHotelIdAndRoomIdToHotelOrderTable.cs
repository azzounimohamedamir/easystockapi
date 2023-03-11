using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class addColumnHotelIdAndRoomIdToHotelOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HotelId",
                table: "HotelOrders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "HotelOrders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_HotelOrders_CheckinId",
                table: "HotelOrders",
                column: "CheckinId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelOrders_HotelId",
                table: "HotelOrders",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelOrders_RoomId",
                table: "HotelOrders",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelOrders_CheckIns_CheckinId",
                table: "HotelOrders",
                column: "CheckinId",
                principalTable: "CheckIns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelOrders_Hotels_HotelId",
                table: "HotelOrders",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelOrders_Rooms_RoomId",
                table: "HotelOrders",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelOrders_CheckIns_CheckinId",
                table: "HotelOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelOrders_Hotels_HotelId",
                table: "HotelOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelOrders_Rooms_RoomId",
                table: "HotelOrders");

            migrationBuilder.DropIndex(
                name: "IX_HotelOrders_CheckinId",
                table: "HotelOrders");

            migrationBuilder.DropIndex(
                name: "IX_HotelOrders_HotelId",
                table: "HotelOrders");

            migrationBuilder.DropIndex(
                name: "IX_HotelOrders_RoomId",
                table: "HotelOrders");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "HotelOrders");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "HotelOrders");
        }
    }
}
