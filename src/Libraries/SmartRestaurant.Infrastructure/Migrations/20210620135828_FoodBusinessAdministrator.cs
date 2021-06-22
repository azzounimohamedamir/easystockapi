using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class FoodBusinessAdministrator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OffersTakeout",
                table: "FoodBusinesses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "FoodBusinesses",
                columns: new[] { "FoodBusinessId", "AcceptTakeout", "AcceptsCreditCards", "AverageRating", "CreatedAt", "CreatedBy", "Description", "Email", "FoodBusinessAdministratorId", "FoodBusinessCategory", "FoodBusinessState", "HasCarParking", "IsHandicapFriendly", "LastModifiedAt", "LastModifiedBy", "NIF", "NIS", "NRC", "Name", "NumberRatings", "OffersTakeout", "Tags", "Website" },
                values: new object[] { new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), true, true, 4.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", null, "3cbf3570-4444-4444-8746-29b7cf568093", 0, 0, true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, 0, "Taj mahal", 0, true, "", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodBusinesses",
                keyColumn: "FoodBusinessId",
                keyValue: new Guid("3cbf3570-4444-4673-8746-29b7cf568093"));

            migrationBuilder.DropColumn(
                name: "OffersTakeout",
                table: "FoodBusinesses");
        }
    }
}
