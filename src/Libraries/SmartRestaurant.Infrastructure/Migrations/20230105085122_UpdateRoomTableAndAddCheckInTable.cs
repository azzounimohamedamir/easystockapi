using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class UpdateRoomTableAndAddCheckInTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isBooked",
                table: "Rooms",
                newName: "IsBooked");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Rooms",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "checkIns",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IsActivate = table.Column<bool>(nullable: false),
                    hotelId = table.Column<Guid>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    LengthOfStay = table.Column<int>(nullable: false),
                    Startdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkIns", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "checkIns");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "IsBooked",
                table: "Rooms",
                newName: "isBooked");
        }
    }
}
