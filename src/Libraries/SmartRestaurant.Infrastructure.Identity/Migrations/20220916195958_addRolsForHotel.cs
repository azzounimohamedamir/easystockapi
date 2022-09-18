using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class addRolsForHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14", "edpc7115-422c-487d-15b0-58cfa8e66a98", "HotelManager", "HOTELMANAGER" },
                    { "15", "edpc7115-422c-487d-15b0-58cfa8e66a98", "HotelReceptionist", "HOTELRECEPTIONIST" },
                    { "16", "edpc7115-422c-487d-15b0-58cfa8e66a98", "HotelServiceAdmin", "HOTELSERVICEADMIN" },
                    { "17", "edpc7115-422c-487d-15b0-58cfa8e66a98", "HotelClient", "HOTELCLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3c3f82f3-c303-4a9c-a32e-3e6b8f08833a", "59db171f-d311-4e2a-8a51-af79e382a4e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "55b65889-c521-44fd-a535-ed7d26753544", "ae66e06d-0d30-41d7-be85-7961c3b9c82f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "124d877b-610f-4f15-8a68-ff01aad8ede6", "ddf6c560-a62d-4705-8c66-7792e5897470" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c00c8278-7044-4c64-bfde-e5f4d0b2af35", "e2b677d6-9ba9-47ac-bf60-a6bfae489e60" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d451e632-5900-4b7b-80f7-f0e3d7805cec", "3b26ceea-5a1c-41ef-a57e-d2febef7da02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "30782c4a-210c-480c-bdbd-66b773d52bda", "ccc723f9-4de1-4d54-86c7-921cc8b5a753" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "829999fd-4445-4df2-a4e2-269aecbe1b54", "c33b7fe1-770a-4e27-a142-5664afeb3792" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7801c133-0a6b-4d3d-a0b3-143602783f32", "488282f7-81b2-4331-be6c-9531b542fda8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "255997c6-9c1c-46d6-9485-14bfd6a466d7", "949c2c2b-be59-4318-9df0-4308a1a8585f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1867d6c6-daac-46dd-ba8d-718eb4a6ff54", "c97d16cf-107f-4343-9a0a-4c59c46f3c09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6e6e87e2-ffc6-4731-948c-52d44dc937d0", "339026af-bd34-49e5-b395-bdd828a800ef" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d215fd5-e7b4-4afd-aa6c-334a37d3874d", 0, "99410dd7-84fc-42cc-bdcf-491b42b1a5a0", "HotelManager@gmail.com", true, null, true, false, null, "HOTELMANAGER@GMAIL.COM", "HOTELMANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "a54a4beb-8a6b-4fe9-a0f7-be613ce3f86b", false, "HotelManager@gmail.com" },
                    { "83e72357-25b8-4e2a-8728-3e25365608e2", 0, "2cb1c725-76bc-4c09-9ff1-12b8034f7f79", "HotelReceptionist@gmail.com", true, null, true, false, null, "HOTELRECEPTIONIST@GMAIL.COM", "HOTELRECEPTIONIST@GMAIL.COM", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "303db0a7-3fca-4162-941f-307cea63df47", false, "HotelReceptionist@gmail.com" },
                    { "C4EAACBE-A5C5-47E8-8DED-508709D7A50F", 0, "f7fe7dc2-7c28-4cdc-9025-fab4311bc56f", "HotelServiceAdmin@gmail.com", true, null, true, false, null, "HOTELSERVICEADMIN@GMAIL.COM", "HOTELSERVICEADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "8266828b-09a8-456c-abc7-ab04d9164323", false, "HotelServiceAdmin@gmail.com" },
                    { "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D", 0, "1691d1d2-6f13-44c9-805d-991d1b9dc36f", "ClientHotel@gmail.com", true, null, true, false, null, "CLIENTHOTEL@GMAIL.COM", "CLIENTHOTEL@GMAIL.COM", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "0a8b78f7-d74a-4dbf-a8c7-56888bf87fb4", false, "ClientHotel@gmail.com" },
                    { "a3dbd500-eab0-4233-86fd-7f1a4195f9a9", 0, "820972b4-f134-42e3-931a-81abe4c6bf2b", "manager@sonatrach.com", true, null, true, false, null, "MANAGER@SONATRACH.COM", "MANAGER@SONATRACH.COM", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "e35e5b06-c21c-4a23-971b-a1cefcd96e36", false, "manager@sonatrach.com" },
                    { "ba89dc5f-dfd1-4c87-9372-233c611cc756", 0, "4fa1ead0-ab50-44f1-9269-c0e329068388", "manager@cevital.com", true, null, true, false, null, "MANAGER@CEVITAL.COM", "MANAGER@CEVITAL.COM", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "8d2d065b-cad8-4c16-a1f4-d380505d50d4", false, "manager@cevital.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "6d215fd5-e7b4-4afd-aa6c-334a37d3874d", "14" },
                    { "83e72357-25b8-4e2a-8728-3e25365608e2", "15" },
                    { "C4EAACBE-A5C5-47E8-8DED-508709D7A50F", "16" },
                    { "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D", "17" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "6d215fd5-e7b4-4afd-aa6c-334a37d3874d", "14" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "83e72357-25b8-4e2a-8728-3e25365608e2", "15" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "C4EAACBE-A5C5-47E8-8DED-508709D7A50F", "16" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D", "17" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D");

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
    }
}
