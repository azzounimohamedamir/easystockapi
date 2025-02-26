using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class AddPermissionOfAdminInSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Ba", "Bca", "Bcv", "Bl", "Clients", "CreancesAss", "Fac", "FacAvoir", "Facpro", "Familles", "Fournisseurs", "Gda", "Gde", "Gds", "Gdv", "Inventaires", "Inviter", "Marques", "RegClients", "RegFour", "RetoursProdClient", "RetoursProdFour", "Role", "StockAlerte", "Stocks", "Unites", "Vc" },
                values: new object[] { new Guid("ed2bc9e3-6f4d-428a-be99-106d6e728734"), true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, "Super Admin", true, true, true, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("ed2bc9e3-6f4d-428a-be99-106d6e728734"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8109bcb7-20cc-4657-b854-704701a8ee95", "2a994916-2676-482c-ae69-e9342a8661d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eed390c0-759f-4daa-856c-a0433345e8cd",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4c15d5a5-48f2-4d47-9169-a82f995e5ec2", "5042ee3f-31a8-49a5-b19c-a759ad64d358" });
        }
    }
}
