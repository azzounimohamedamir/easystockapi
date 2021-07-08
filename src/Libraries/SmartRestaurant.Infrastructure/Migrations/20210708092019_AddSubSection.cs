using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddSubSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Sections_RootSectionId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_RootSectionId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "RootSectionId",
                table: "Sections");

            migrationBuilder.CreateTable(
                name: "SubSections",
                columns: table => new
                {
                    SubSectionId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SectionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSections", x => x.SubSectionId);
                    table.ForeignKey(
                        name: "FK_SubSections_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubSections_SectionId",
                table: "SubSections",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubSections");

            migrationBuilder.AddColumn<Guid>(
                name: "RootSectionId",
                table: "Sections",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_RootSectionId",
                table: "Sections",
                column: "RootSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Sections_RootSectionId",
                table: "Sections",
                column: "RootSectionId",
                principalTable: "Sections",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
