using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class updateSeedData_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "44bf3570-0d44-4673-8746-29b7cf568088", "5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e0c6c45c-4ae9-48aa-ba22-92bb39ed6660", "de755128-7287-43d9-859c-c5a951587388" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e04246dc-7c76-47b1-a5e4-0db2dc0ad9a0", "d10ff52d-e5e0-4020-8c68-b29402ab048c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "7c16201a-6fdb-49a6-8e96-c69d4cbd9c25", "McdonaldFoodAdmin@SmartRestaurant.io", "MCDONALDFOODADMIN@SMARTRESTAURANT.IO", "MCDONALDFOODADMIN@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", "f3c01bef-be3f-4580-b692-c15db3eb5f5d", "McdonaldFoodAdmin@SmartRestaurant.io" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "f977933c-4505-42dc-b960-3a158321ed50", "TajMhalFoodBusinessManager@SmartRestaurant.io", "TAJMHALFOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "TAJMHALFOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "20f5fd82-e649-4ac2-a16b-1c67053f5bc5", "TajMhalFoodBusinessManager@SmartRestaurant.io" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fbaece1e-509e-41e0-9ee0-12f4f4846400", "00d3d97f-3281-4331-8b0e-5733a51007af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c13d9fe3-185a-4511-9923-4b07915d1779", "114e9481-c503-45db-a9d1-d1d26022252b" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FullName", "IsActive" },
                values: new object[,]
                {
                    { "b2207466-ceda-4b50-b18d-0ac4f4102caa", 0, "68059690-929d-4bcb-97db-b31b19289707", "ApplicationUser", "McdonaldFoodBusinessManager@SmartRestaurant.io", true, false, null, "MCDONALDFOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "MCDONALDFOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "eeee385a-f4ae-4db7-acbc-1c6c90a6e7b3", false, "McdonaldFoodBusinessManager@SmartRestaurant.io", null, true },
                    { "5a84cd00-59f0-4b22-bfce-07c080829118", 0, "432c5541-334d-4fdf-9227-4b28290abd9e", "ApplicationUser", "Diner_01@SmartRestaurant.io", true, false, null, "DINER_01@SMARTRESTAURANT.IO", "DINER_01@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEJFZbbuBIpvoyXKwrceuNsU4cXZ18LLAl8g7s48Pye4EAEXwA2hswtnLMhMS9Q7Cjw ==", null, false, "eadab07c-b9c7-4656-b4d3-ae2ccedb9a34", false, "Diner_01@SmartRestaurant.io", null, true },
                    { "6b14cd00-59f0-4422-bfce-07c080829987", 0, "f7bb134d-15fa-481d-b225-2a8ae9f8a191", "ApplicationUser", "Diner_02@SmartRestaurant.io", true, false, null, "DINER_02@SMARTRESTAURANT.IO", "DINER_02@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEJFZbbuBIpvoyXKwrceuNsU4cXZ18LLAl8g7s48Pye4EAEXwA2hswtnLMhMS9Q7Cjw ==", null, false, "e56ca1d3-f30c-4f6b-884c-66ec4bc970b1", false, "Diner_02@SmartRestaurant.io", null, true }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b2207466-ceda-4b50-b18d-0ac4f4102caa", "6" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "5a84cd00-59f0-4b22-bfce-07c080829118", "11" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "6b14cd00-59f0-4422-bfce-07c080829987", "11" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "44bf3570-0d44-4673-8746-29b7cf568088", "5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "5a84cd00-59f0-4b22-bfce-07c080829118", "11" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "6b14cd00-59f0-4422-bfce-07c080829987", "11" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "b2207466-ceda-4b50-b18d-0ac4f4102caa", "6" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa");

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
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "2b915cc7-4e25-474d-847d-bcd116c3a351", "MCDONALD@SmartRestaurant.io", "MCDONALD@SMARTRESTAURANT.IO", "MCDONALD@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEAzFpmzMtMiw0wHV6b0aUzFLF9Pw7B2u+DswRHttAU2nH22NHBsc/hSSvKUqmRWGZA==", "59b6c506-b7cd-4413-bef6-5609d3333f72", "mcdonald@SmartRestaurant.io" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "f1346762-e3ba-4606-b5d0-0b1deb3e048a", "FoodBusinessManager@SmartRestaurant.io", "FOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "FOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "62d8e8fa-030c-43e7-960a-3d3e26b97666", "FoodBusinessManager@SmartRestaurant.io" });

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
        }
    }
}
