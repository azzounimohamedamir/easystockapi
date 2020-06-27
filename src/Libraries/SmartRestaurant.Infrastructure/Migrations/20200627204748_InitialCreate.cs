using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    RestaurantId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    NameArabic = table.Column<string>(nullable: true),
                    NameFrench = table.Column<string>(nullable: true),
                    NameEnglish = table.Column<string>(nullable: true),
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
                    IsHandicapFreindly = table.Column<bool>(nullable: false),
                    AcceptsCreditCards = table.Column<bool>(nullable: false),
                    AcceptTakeout = table.Column<bool>(nullable: false),
                    Tags = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    RestaurantState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.RestaurantId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
