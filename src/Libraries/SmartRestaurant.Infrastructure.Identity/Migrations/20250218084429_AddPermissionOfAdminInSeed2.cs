using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class AddPermissionOfAdminInSeed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c57547cc-5c37-43fa-adc0-95e6b99a7d9e", "66de48cd-3cae-4e2b-bbde-17c4493d3f93" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eed390c0-759f-4daa-856c-a0433345e8cd",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4234d6cf-b56e-4502-b802-13c44b2b093c", "64515e25-3b14-4101-af52-662c5a491f1a" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("ed2bc9e3-6f4d-428a-be99-106d6e728734"),
                column: "Role",
                value: "SuperAdmin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "84eda78c-f266-49e0-87d7-aaf674fd942c", "f0886dd2-f3aa-483b-8661-314f4cdbf64a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eed390c0-759f-4daa-856c-a0433345e8cd",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9014e44f-d7dc-4a9c-9260-0d6ac5dc829b", "d99cad9e-a82b-4249-9d3e-d659e776f577" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("ed2bc9e3-6f4d-428a-be99-106d6e728734"),
                column: "Role",
                value: "Super Admin");
        }
    }
}
