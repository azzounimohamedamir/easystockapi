using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class OverrideApplicationUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4462fa28-f0a0-44fb-bd1f-94867f057c3f", "342e3290-f013-4832-bd4c-c38efac37f22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5361c915-565b-4f3f-b38c-2863706b8b99", "9334de22-2d6a-4b6c-8a3a-c2ae94f9dde4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a7c66fbb-a5d8-4c8a-a90e-d2b507dca9da", "f72eb15e-836a-448a-b03d-eaea5e57ff5c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0a7657cb-06d3-40d6-bf10-cdf179520f19", "be047568-33ee-471f-8a16-3e70d8f4828e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2a19c0e6-0cb9-46dc-8f48-f9a1b0cc68bd", "694c9d9e-d935-46f9-a404-fae2dde76c38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1b1eab1a-a6e6-4dea-b76f-63dfb111845d", "31279ef7-d433-417b-af80-28d2a837c40e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1b46c7e2-a36c-4f07-b88c-02ef612e7a92", "6af53c3c-2951-46cf-a26e-5184c8ef7c07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "218ba603-8207-4efe-a75d-7d58e4e9f34f", "a248f81c-f0a1-46a0-86d3-128a2e163c35" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ddfaf599-629c-4185-a294-d70e76fe8188", "b2eebe96-d6e1-4f07-8ad6-f5b9cf1fe7ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "89d77901-7c9a-4f25-b6d6-e66eae29aeac", "6c3498ae-e40f-4a7c-b005-27682222cdbf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "14b9aad3-2bd4-49fb-b9fb-8d50874caa4d", "d573531b-0493-4bdb-ba68-a1c8243ed586" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                type: "nvarchar(max)",
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
    }
}
