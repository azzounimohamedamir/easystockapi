using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class updateSeedData_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e602b75f-ac5a-406d-88b5-20ae6888b4eb", "02acb50e-3b1d-459d-9bac-4f34fffd8202" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7d986f97-442f-44e9-bdab-2c3d8df5984d", "87a944e3-00b6-4c51-9d7c-4ed3450cefce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f1346762-e3ba-4606-b5d0-0b1deb3e048a", "62d8e8fa-030c-43e7-960a-3d3e26b97666" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bb0fbe10-6891-4c30-9380-d1019bb9fbfe", "a38c7f00-c159-4ccd-988c-4b836caf55ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "921bf764-e49d-4d42-b076-c39471fb1b57", "54ca077c-ba02-446d-9727-9137667fc521" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FullName", "IsActive" },
                values: new object[] { "44bf3570-0d44-4673-8746-29b7cf568088", 0, "2b915cc7-4e25-474d-847d-bcd116c3a351", "ApplicationUser", "MCDONALD@SmartRestaurant.io", true, false, null, "MCDONALD@SMARTRESTAURANT.IO", "MCDONALD@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEAzFpmzMtMiw0wHV6b0aUzFLF9Pw7B2u+DswRHttAU2nH22NHBsc/hSSvKUqmRWGZA==", null, false, "59b6c506-b7cd-4413-bef6-5609d3333f72", false, "mcdonald@SmartRestaurant.io", null, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3c015167-e9f9-4f7b-ab48-029f3a941de9", "4eaf7ee9-19b1-47c7-9560-46159e6f66ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "26adf453-02d1-4e05-831c-b6d8107b9262", "b8fee18d-0f2e-4b7c-8251-e4e71718763f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ac6a9eea-db45-4474-b8af-4c6c9ad2a6a0", "133bc7ef-d14c-466a-a82a-e058354fb341" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6551b4f8-cd8b-4ae1-897d-d1278b17eb87", "11a5c9c6-d1d6-4174-811c-c52a7ef497f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f8310f9e-8aaf-4b61-9967-588eeb4a4b52", "b2092ef3-e073-4bf8-a9de-d795dc9d0fdf" });
        }
    }
}
