using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class updateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6551b4f8-cd8b-4ae1-897d-d1278b17eb87", "11a5c9c6-d1d6-4174-811c-c52a7ef497f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f8310f9e-8aaf-4b61-9967-588eeb4a4b52", "b2092ef3-e073-4bf8-a9de-d795dc9d0fdf" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FullName", "IsActive" },
                values: new object[] { "a1997466-cedc-4850-b18d-0ac4f4102cff", 0, "ac6a9eea-db45-4474-b8af-4c6c9ad2a6a0", "ApplicationUser", "FoodBusinessManager@SmartRestaurant.io", true, false, null, "FOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "FOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "133bc7ef-d14c-466a-a82a-e058354fb341", false, "FoodBusinessManager@SmartRestaurant.io", null, true });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a1997466-cedc-4850-b18d-0ac4f4102cff", "6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a1997466-cedc-4850-b18d-0ac4f4102cff", "6" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "41722eae-b08f-4f60-bc82-f3fe140268c6", "e94ef1cd-2e57-418b-86d0-9163dacf6b34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0a44e6c3-e664-489d-82d9-c029aee81075", "b3bd4440-0ba6-44be-91da-f369b88355b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "896ab300-ccca-43a0-8960-449329729fbf", "e6338d6f-b4a5-4d5e-ab42-4a8077be0a01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c780c49b-50f3-425e-9406-5ff90bd56c5a", "5d7b0fa7-cecf-454b-a240-de304ce30fe7" });
        }
    }
}
