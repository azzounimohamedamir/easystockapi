using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddServiceTechniqueTableAndUpdateReclamationAndTypeReclamation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReclamationDescription_AR",
                table: "Reclamations");

            migrationBuilder.DropColumn(
                name: "ReclamationDescription_EN",
                table: "Reclamations");

            migrationBuilder.DropColumn(
                name: "ReclamationDescription_FR",
                table: "Reclamations");

            migrationBuilder.DropColumn(
                name: "ReclamationDescription_RU",
                table: "Reclamations");

            migrationBuilder.DropColumn(
                name: "ReclamationDescription_TR",
                table: "Reclamations");

            migrationBuilder.AddColumn<int>(
                name: "Delai",
                table: "TypeReclamations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceTechniqueId",
                table: "TypeReclamations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DelaiExpiredAt",
                table: "Reclamations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InProgressBeginAt",
                table: "Reclamations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "Reclamations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TypeReclamationId",
                table: "Reclamations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ServiceTechniques",
                columns: table => new
                {
                    ServiceTechniqueId = table.Column<Guid>(nullable: false),
                    HotelId = table.Column<Guid>(nullable: false),
                    Names_AR = table.Column<string>(nullable: true),
                    Names_EN = table.Column<string>(nullable: true),
                    Names_FR = table.Column<string>(nullable: true),
                    Names_TR = table.Column<string>(nullable: true),
                    Names_RU = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTechniques", x => x.ServiceTechniqueId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceTechniques");

            migrationBuilder.DropColumn(
                name: "Delai",
                table: "TypeReclamations");

            migrationBuilder.DropColumn(
                name: "ServiceTechniqueId",
                table: "TypeReclamations");

            migrationBuilder.DropColumn(
                name: "DelaiExpiredAt",
                table: "Reclamations");

            migrationBuilder.DropColumn(
                name: "InProgressBeginAt",
                table: "Reclamations");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "Reclamations");

            migrationBuilder.DropColumn(
                name: "TypeReclamationId",
                table: "Reclamations");

            migrationBuilder.AddColumn<string>(
                name: "ReclamationDescription_AR",
                table: "Reclamations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReclamationDescription_EN",
                table: "Reclamations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReclamationDescription_FR",
                table: "Reclamations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReclamationDescription_RU",
                table: "Reclamations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReclamationDescription_TR",
                table: "Reclamations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
