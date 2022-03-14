using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class updateSeedData_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5fe38b9a-2635-4322-b170-5f41d6dce3d4", "07d00732-f743-477f-98fb-b07261e02bc6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "147a2dfc-8890-410d-b86a-34457c5e76c5", "912dc807-aaa5-41af-9846-ce5fe87a4535" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2f83de45-c2cb-400f-ad33-06a8117d8fdd", "cb709c37-ef28-444a-951d-7495b0f744cf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "93e10f04-f018-419b-a6ab-88a01d0d2c3e", "0eba14d6-1e07-4509-b338-7b0652de3f0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "56bac56e-3277-4387-abd5-36342abb66a0", "f9be25ee-9a71-49b9-86c7-dd7624cca872" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7c2463f9-e552-435c-92a5-9c292fa74e4a", "106a6802-1b87-4206-9c6a-5b1fb3d9afc0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6193201d-8830-4ab1-b731-101e01287a59", "737da9d0-1b56-4bf7-bdc1-6a1c976af297" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0bfc1dd8-b960-452f-8649-75b45a3ae7df", "1d64c3c8-efe1-4bdd-9869-805e07674541" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "76f56d63-0b03-421d-8c06-4ae52f04d613", "40d5f5cf-22da-4301-a099-0afee9f9b77b" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FullName", "IsActive" },
                values: new object[,]
                {
                    { "08a1a626-7f8e-4b51-84fc-fc51b6302cca", 0, "5883927f-4009-495a-8020-78d89fb7d2b2", "ApplicationUser", "BigMamaFoodBusinessAdministrator@SmartRestaurant.io", true, false, null, "BIGMAMAFOODBUSINESSADMINISTRATOR@SMARTRESTAURANT.IO", "BIGMAMAFOODBUSINESSADMINISTRATOR@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "7115447b-45bb-4152-84aa-a352f312b4bb", false, "BigMamaFoodBusinessAdministrator@SmartRestaurant.io", null, true },
                    { "64fed988-6f68-49dc-ad54-0da50ec02319", 0, "86264eaa-71b6-4452-9f65-64addd94a0a7", "ApplicationUser", "BigMamaSalimFoodBusinessManager@SmartRestaurant.io", true, false, null, "BIGMAMASALIMFOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "BIGMAMASALIMFOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEO+ouwzSOa+AsCNZrVEhO6Su9q/fX/Q9c9havEvhs5QtXWA6tRdfmqOlemUQphqDnA==", null, false, "d8fd5f65-d048-47ac-96df-b69b6e89f8be", false, "BigMamaSalimFoodBusinessManager@SmartRestaurant.io", null, true }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "08a1a626-7f8e-4b51-84fc-fc51b6302cca", "5" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "64fed988-6f68-49dc-ad54-0da50ec02319", "6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "08a1a626-7f8e-4b51-84fc-fc51b6302cca", "5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "64fed988-6f68-49dc-ad54-0da50ec02319", "6" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319");

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
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7c16201a-6fdb-49a6-8e96-c69d4cbd9c25", "f3c01bef-be3f-4580-b692-c15db3eb5f5d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "432c5541-334d-4fdf-9227-4b28290abd9e", "eadab07c-b9c7-4656-b4d3-ae2ccedb9a34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f7bb134d-15fa-481d-b225-2a8ae9f8a191", "e56ca1d3-f30c-4f6b-884c-66ec4bc970b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f977933c-4505-42dc-b960-3a158321ed50", "20f5fd82-e649-4ac2-a16b-1c67053f5bc5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "68059690-929d-4bcb-97db-b31b19289707", "eeee385a-f4ae-4db7-acbc-1c6c90a6e7b3" });

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
        }
    }
}
