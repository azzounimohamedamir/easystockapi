using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "88f0dec2-5364-4881-4817-1f2a135a8641", "SuperAdmin", "SUPERADMIN" },
                    { "2", "emec7115-422c-487d-65b0-58cfa8e66a94", "SupportAgent", "SUPPORTAGENT" },
                    { "3", "emrc7115-422c-487d-75b0-58cfa8e66a94", "SalesMan", "SALESMAN" },
                    { "4", "emtc7115-422c-487d-85b0-58cfa8e66a94", "Photograph", "PHOTOGRAPH" },
                    { "5", "5719c2b8-22fd-4eee-9c21-4bfbd2ce18d2", "FoodBusinessAdministrator", "FOODBUSINESSADMINISTRATOR" },
                    { "6", "emcc7115-422c-487d-95b0-58cfa8e66a94", "FoodBusinessManager", "FOODBUSINESSMANAGER" },
                    { "7", "emcb7115-422c-487d-95c0-58cfa8m66a94", "FoodBusinessOwner", "FOODBUSINESSOWNER" },
                    { "9", "encc7115-422c-487d-95b0-58cfa8e66a95", "Cashier", "CASHIER" },
                    { "8", "elcc7115-422c-487d-95b0-58cfa8e66a96", "Chef", "CHEF" },
                    { "10", "ekcc7115-422c-487d-95b0-58cfa8e66a97", "Waiter", "WAITER" },
                    { "11", "edcc7115-422c-487d-95b0-58cfa8e66a98", "Diner", "DINER" },
                    { "12", "educ7115-422c-487d-25b0-58cfa8e66a98", "Anounymous", "ANOUNYMOUS" },
                    { "13", "edpc7115-422c-487d-15b0-58cfa8e66a98", "Organization", "ORGANIZATION" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FullName" },
                values: new object[,]
                {
                    { "3cbf3570-0d44-4673-8746-29b7cf568093", 0, "5b56feff-98c9-4d44-944b-f095c5613058", "ApplicationUser", "SuperAdmin@SmartRestaurant.io", true, false, null, "SUPERADMIN@SMARTRESTAURANT.IO", "SUPERADMIN@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEAzFpmzMtMiw0wHV6b0aUzFLF9Pw7B2u+DswRHttAU2nH22NHBsc/hSSvKUqmRWGZA==", null, false, "99751beb-d974-4da6-abe8-fdab219d5e8d", false, "SuperAdmin@SmartRestaurant.io", null },
                    { "d466ef00-61f1-4e77-801a-b016f0f12323", 0, "3dc769a8-0906-4725-92c2-286e2f973209", "ApplicationUser", "SupportAgent@SmartRestaurant.io", true, false, null, "SUPERADMIN@SMARTRESTAURANT.IO", "SSUPERADMIN@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "f1c8aa01-041e-454f-88fb-5ee4089881b9", false, "SupportAgent@SmartRestaurant.io", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "3cbf3570-0d44-4673-8746-29b7cf568093", "1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d466ef00-61f1-4e77-801a-b016f0f12323", "2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3cbf3570-0d44-4673-8746-29b7cf568093", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d466ef00-61f1-4e77-801a-b016f0f12323", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bd401f84-93f7-4a11-a9ba-e82d30fbcd30", "88f0dec2-5364-4881-9817-1f2a135a8649", "SuperAdmin", "SUPERADMIN" },
                    { "bbccc53c-4463-42f6-a3fe-34fb277697c7", "5719c2b8-22fd-4eee-9c21-4bfbd2ce18d7", "Admin", "ADMIN" },
                    { "b66e0e1b-b318-42f1-9a7a-a112fe51ad86", "eccc7115-422c-487d-95b0-58cfa8e66a94", "User", "USER" },
                    { "9953a9a3-db01-47e0-bb06-f57f709198af", "dfea2e8e-efb4-41ec-9418-28abb5ae04cc", "RestaurantAdministrator", "USER" }
                });
        }
    }
}
