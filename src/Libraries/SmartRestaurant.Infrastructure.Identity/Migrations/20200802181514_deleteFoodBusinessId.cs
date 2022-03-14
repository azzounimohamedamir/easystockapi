using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class deleteFoodBusinessId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1be6e704-c26e-40c8-9bd0-8c094fb9f103");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f862c1b-99b8-4596-b363-f1133c2b8522");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a528d63f-5907-44e4-ac62-f963dc6e7b42");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8c28517-b118-41a8-add6-1cdb0490b2ce");

            migrationBuilder.DropColumn(
                name: "FoodBusinessId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bd401f84-93f7-4a11-a9ba-e82d30fbcd30", "88f0dec2-5364-4881-9817-1f2a135a8649", "SuperAdmin", "SUPERADMIN" },
                    { "bbccc53c-4463-42f6-a3fe-34fb277697c7", "5719c2b8-22fd-4eee-9c21-4bfbd2ce18d7", "Admin", "ADMIN" },
                    { "b66e0e1b-b318-42f1-9a7a-a112fe51ad86", "eccc7115-422c-487d-95b0-58cfa8e66a94", "User", "USER" },
                    { "9953a9a3-db01-47e0-bb06-f57f709198af", "dfea2e8e-efb4-41ec-9418-28abb5ae04cc", "FoodBusinessAdministrator", "FOODBUSINESSADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9953a9a3-db01-47e0-bb06-f57f709198af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b66e0e1b-b318-42f1-9a7a-a112fe51ad86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbccc53c-4463-42f6-a3fe-34fb277697c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd401f84-93f7-4a11-a9ba-e82d30fbcd30");

            migrationBuilder.AddColumn<Guid>(
                name: "FoodBusinessId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f862c1b-99b8-4596-b363-f1133c2b8522", "88f0dec2-5364-4881-9817-1f2a135a8649", "SuperAdmin", "SUPERADMIN" },
                    { "e8c28517-b118-41a8-add6-1cdb0490b2ce", "5719c2b8-22fd-4eee-9c21-4bfbd2ce18d7", "Admin", "ADMIN" },
                    { "a528d63f-5907-44e4-ac62-f963dc6e7b42", "eccc7115-422c-487d-95b0-58cfa8e66a94", "User", "USER" },
                    { "1be6e704-c26e-40c8-9bd0-8c094fb9f103", "5de5ee9b-7f2a-4a99-b0dc-dfd235f15a63", "FoodBusinessAdministrator", "FOODBUSINESSADMINISTRATOR" }
                });
        }
    }
}
