using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class AddWaiter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "7143d3b1-eb96-4034-9e83-b48899077450", "SUPPORTAGENT@SMARTRESTAURANT.IO", "SUPPORTAGENT@SMARTRESTAURANT.IO", "9e91619a-de13-42a6-9a35-1102a8a7bd13" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FullName", "IsActive" },
                values: new object[] { "d466ef00-61f1-4e77-801a-b516f0f12323", 0, "ffd02f8a-3d30-4e4b-ace8-28b7a0c97585", "ApplicationUser", "Waiter@SmartRestaurant.io", true, false, null, "WAITER@SMARTRESTAURANT.IO", "WAITER@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "803ba7a6-860f-445a-9a34-5a0597d911bf", false, "Waiter@SmartRestaurant.io", null, true });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d466ef00-61f1-4e77-801a-b516f0f12323", "10" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d466ef00-61f1-4e77-801a-b516f0f12323", "10" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c3d94224-048f-456c-9617-5b1e8a9f0feb", "f1d37fc8-8c51-437e-a34b-103ed1d4836a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "93ed44de-a300-4c8d-9d4c-37ba7bc0d261", "SUPERADMIN@SMARTRESTAURANT.IO", "SSUPERADMIN@SMARTRESTAURANT.IO", "98390c03-b81e-4374-a199-ebdd50bbd698" });
        }
    }
}
