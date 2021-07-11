using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateSeedData_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FoodBusinesses",
                columns: new[] { "FoodBusinessId", "AcceptTakeout", "AcceptsCreditCards", "AverageRating", "CreatedAt", "CreatedBy", "Description", "Email", "FoodBusinessAdministratorId", "FoodBusinessCategory", "FoodBusinessState", "HasCarParking", "IsHandicapFriendly", "LastModifiedAt", "LastModifiedBy", "NIF", "NIS", "NRC", "Name", "NumberRatings", "OffersTakeout", "Tags", "Website" },
                values: new object[] { new Guid("66bf3570-440d-4673-8746-29b7cf568099"), true, true, 4.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", null, "44bf3570-0d44-4673-8746-29b7cf568088", 0, 0, true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, 0, "Mcdonald's", 0, true, "", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodBusinesses",
                keyColumn: "FoodBusinessId",
                keyValue: new Guid("66bf3570-440d-4673-8746-29b7cf568099"));
        }
    }
}
