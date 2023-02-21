using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddReclamationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reclamations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: false),
                    ReclamationDescription_AR = table.Column<string>(nullable: true),
                    ReclamationDescription_EN = table.Column<string>(nullable: true),
                    ReclamationDescription_FR = table.Column<string>(nullable: true),
                    ReclamationDescription_TR = table.Column<string>(nullable: true),
                    ReclamationDescription_RU = table.Column<string>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reclamations");
        }
    }
}
