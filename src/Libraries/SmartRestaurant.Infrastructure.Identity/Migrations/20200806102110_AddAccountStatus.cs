using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class AddAccountStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "IsActive" },
                values: new object[] { "c3d94224-048f-456c-9617-5b1e8a9f0feb", "f1d37fc8-8c51-437e-a34b-103ed1d4836a", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "IsActive" },
                values: new object[] { "93ed44de-a300-4c8d-9d4c-37ba7bc0d261", "98390c03-b81e-4374-a199-ebdd50bbd698", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5b56feff-98c9-4d44-944b-f095c5613058", "99751beb-d974-4da6-abe8-fdab219d5e8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3dc769a8-0906-4725-92c2-286e2f973209", "f1c8aa01-041e-454f-88fb-5ee4089881b9" });
        }
    }
}
