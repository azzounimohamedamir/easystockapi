using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class FoodAdministrator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "41722eae-b08f-4f60-bc82-f3fe140268c6", "e94ef1cd-2e57-418b-86d0-9163dacf6b34" });

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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FullName", "IsActive" },
                values: new object[] { "3cbf3570-4444-4444-8746-29b7cf568093", 0, "0a44e6c3-e664-489d-82d9-c029aee81075", "ApplicationUser", "FoodAdmin@SmartRestaurant.io", true, false, null, "FOODADMIN@SMARTRESTAURANT.IO", "FOODADMIN@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "b3bd4440-0ba6-44be-91da-f369b88355b3", false, "FoodAdmin@SmartRestaurant.io", null, true });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "3cbf3570-4444-4444-8746-29b7cf568093", "5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3cbf3570-4444-4444-8746-29b7cf568093", "5" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2d47a201-b677-4ba9-86b4-9c18e86026c7", "d570b997-1f97-452a-843d-d43b3976162e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7143d3b1-eb96-4034-9e83-b48899077450", "9e91619a-de13-42a6-9a35-1102a8a7bd13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ffd02f8a-3d30-4e4b-ace8-28b7a0c97585", "803ba7a6-860f-445a-9a34-5a0597d911bf" });
        }
    }
}
