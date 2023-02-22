using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class addReclamationAndTypeReclamationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Dishes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Reclamations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CheckinId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: false),
                    ReclamationDescription_AR = table.Column<string>(nullable: true),
                    ReclamationDescription_EN = table.Column<string>(nullable: true),
                    ReclamationDescription_FR = table.Column<string>(nullable: true),
                    ReclamationDescription_TR = table.Column<string>(nullable: true),
                    ReclamationDescription_RU = table.Column<string>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamations", x => x.Id);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reclamations");

            migrationBuilder.DropTable(
                name: "TypeReclamations");

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
