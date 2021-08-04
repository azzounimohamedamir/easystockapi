using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class OverrideIdentityRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "08a1a626-7f8e-4b51-84fc-fc51b6302cca", "5" },
                column: "Discriminator",
                value: "ApplicationUserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3cbf3570-0d44-4673-8746-29b7cf568093", "1" },
                column: "Discriminator",
                value: "ApplicationUserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3cbf3570-4444-4444-8746-29b7cf568093", "5" },
                column: "Discriminator",
                value: "ApplicationUserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "44bf3570-0d44-4673-8746-29b7cf568088", "5" },
                column: "Discriminator",
                value: "ApplicationUserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "5a84cd00-59f0-4b22-bfce-07c080829118", "11" },
                column: "Discriminator",
                value: "ApplicationUserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "64fed988-6f68-49dc-ad54-0da50ec02319", "6" },
                column: "Discriminator",
                value: "ApplicationUserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "6b14cd00-59f0-4422-bfce-07c080829987", "11" },
                column: "Discriminator",
                value: "ApplicationUserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a1997466-cedc-4850-b18d-0ac4f4102cff", "6" },
                column: "Discriminator",
                value: "ApplicationUserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "b2207466-ceda-4b50-b18d-0ac4f4102caa", "6" },
                column: "Discriminator",
                value: "ApplicationUserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d466ef00-61f1-4e77-801a-b016f0f12323", "2" },
                column: "Discriminator",
                value: "ApplicationUserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d466ef00-61f1-4e77-801a-b516f0f12323", "10" },
                column: "Discriminator",
                value: "ApplicationUserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fbf229c8-fbae-4a38-9486-a850df86ca9e", "4baf185a-acd6-4c94-80ab-63af3420ce2b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e08e4ce3-5b3f-4d4f-893a-7da74be189e7", "cb5c24aa-a7c7-4930-a078-a948b39e61c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b41297e9-2a83-44fb-af44-15cae286b9bc", "03c16f2c-ed94-4fe0-96c5-e44a99d09aad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b91a6d3c-4281-48ff-8411-0c94343f094a", "b1c2f7ac-3d0d-4c02-86fe-8db2565d2354" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c9d487a0-2139-4ca2-8447-0e8120b0f8fe", "61cbdddc-b087-49e0-9dc8-f13db2d54cf5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a7009b9e-5c5d-48e7-b0b0-481db69e2626", "481d54ee-f947-44c6-9078-f2230169c0dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "99ddbf04-fb2d-453b-ac2c-cc7e2009956b", "a74adb75-1110-4812-b41a-bebf2a0fc4c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "69aa72f2-c6bd-4777-af87-426933638cca", "ec4721b7-45af-4ec6-829b-15910907d324" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "87a5a27f-d52e-47b5-984f-202182587fb5", "4f62afd9-d1c4-4ca4-bb5b-504fb0589399" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4b2bc124-4828-4a08-adb9-e4320006932d", "151e477f-dcc5-4715-878f-b719fc9164ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2952a61a-70fc-484f-b2be-a24274bbf5c6", "6dee18ea-5a5d-41ce-a8f5-1cddc0d0d0dd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "Discriminator", "SecurityStamp" },
                values: new object[] { "5883927f-4009-495a-8020-78d89fb7d2b2", "ApplicationUser", "7115447b-45bb-4152-84aa-a352f312b4bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "Discriminator", "SecurityStamp" },
                values: new object[] { "5fe38b9a-2635-4322-b170-5f41d6dce3d4", "ApplicationUser", "07d00732-f743-477f-98fb-b07261e02bc6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "Discriminator", "SecurityStamp" },
                values: new object[] { "147a2dfc-8890-410d-b86a-34457c5e76c5", "ApplicationUser", "912dc807-aaa5-41af-9846-ce5fe87a4535" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "Discriminator", "SecurityStamp" },
                values: new object[] { "2f83de45-c2cb-400f-ad33-06a8117d8fdd", "ApplicationUser", "cb709c37-ef28-444a-951d-7495b0f744cf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "Discriminator", "SecurityStamp" },
                values: new object[] { "93e10f04-f018-419b-a6ab-88a01d0d2c3e", "ApplicationUser", "0eba14d6-1e07-4509-b338-7b0652de3f0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "Discriminator", "SecurityStamp" },
                values: new object[] { "86264eaa-71b6-4452-9f65-64addd94a0a7", "ApplicationUser", "d8fd5f65-d048-47ac-96df-b69b6e89f8be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "Discriminator", "SecurityStamp" },
                values: new object[] { "56bac56e-3277-4387-abd5-36342abb66a0", "ApplicationUser", "f9be25ee-9a71-49b9-86c7-dd7624cca872" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "Discriminator", "SecurityStamp" },
                values: new object[] { "7c2463f9-e552-435c-92a5-9c292fa74e4a", "ApplicationUser", "106a6802-1b87-4206-9c6a-5b1fb3d9afc0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "Discriminator", "SecurityStamp" },
                values: new object[] { "6193201d-8830-4ab1-b731-101e01287a59", "ApplicationUser", "737da9d0-1b56-4bf7-bdc1-6a1c976af297" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "Discriminator", "SecurityStamp" },
                values: new object[] { "0bfc1dd8-b960-452f-8649-75b45a3ae7df", "ApplicationUser", "1d64c3c8-efe1-4bdd-9869-805e07674541" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "Discriminator", "SecurityStamp" },
                values: new object[] { "76f56d63-0b03-421d-8c06-4ae52f04d613", "ApplicationUser", "40d5f5cf-22da-4301-a099-0afee9f9b77b" });
        }
    }
}
