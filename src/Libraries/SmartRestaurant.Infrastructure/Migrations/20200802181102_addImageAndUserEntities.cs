using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class addImageAndUserEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodBusinessImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    FoodBusinessId = table.Column<Guid>(nullable: false),
                    ImageBytes = table.Column<byte[]>(nullable: true),
                    ImageTitle = table.Column<string>(nullable: true),
                    IsLogo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodBusinessImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodBusinessImages_FoodBusinesses_FoodBusinessId",
                        column: x => x.FoodBusinessId,
                        principalTable: "FoodBusinesses",
                        principalColumn: "FoodBusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodBusinessUsers",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    FoodBusinessId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodBusinessUsers", x => new { x.ApplicationUserId, x.FoodBusinessId });
                    table.ForeignKey(
                        name: "FK_FoodBusinessUsers_FoodBusinesses_FoodBusinessId",
                        column: x => x.FoodBusinessId,
                        principalTable: "FoodBusinesses",
                        principalColumn: "FoodBusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodBusinessImages_FoodBusinessId",
                table: "FoodBusinessImages",
                column: "FoodBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodBusinessUsers_FoodBusinessId",
                table: "FoodBusinessUsers",
                column: "FoodBusinessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodBusinessImages");

            migrationBuilder.DropTable(
                name: "FoodBusinessUsers");
        }
    }
}
