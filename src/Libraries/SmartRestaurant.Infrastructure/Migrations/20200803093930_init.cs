using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodBusinesses",
                columns: table => new
                {
                    FoodBusinessId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    NameArabic = table.Column<string>(nullable: true),
                    NameFrench = table.Column<string>(nullable: true),
                    NameEnglish = table.Column<string>(nullable: true),
                    NameTurkish = table.Column<string>(nullable: true),
                    NameChinese = table.Column<string>(nullable: true),
                    NameRussian = table.Column<string>(nullable: true),
                    NameSpanish = table.Column<string>(nullable: true),
                    NRC = table.Column<int>(nullable: false),
                    NIF = table.Column<int>(nullable: false),
                    NIS = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Address_StreetAddress = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_Country = table.Column<string>(nullable: true),
                    Address_GeoPosition_Latitude = table.Column<string>(nullable: true),
                    Address_GeoPosition_Longitude = table.Column<string>(nullable: true),
                    PhoneNumber_CountryCode = table.Column<int>(nullable: true),
                    PhoneNumber_Number = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AverageRating = table.Column<double>(nullable: false),
                    NumberRatings = table.Column<int>(nullable: false),
                    HasCarParking = table.Column<bool>(nullable: false),
                    IsHandicapFriendly = table.Column<bool>(nullable: false),
                    AcceptsCreditCards = table.Column<bool>(nullable: false),
                    AcceptTakeout = table.Column<bool>(nullable: false),
                    Tags = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    FoodBusinessAdministratorId = table.Column<string>(nullable: true),
                    FoodBusinessState = table.Column<int>(nullable: false),
                    FoodBusinessCategory = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodBusinesses", x => x.FoodBusinessId);
                });

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

            migrationBuilder.DropTable(
                name: "FoodBusinesses");
        }
    }
}
