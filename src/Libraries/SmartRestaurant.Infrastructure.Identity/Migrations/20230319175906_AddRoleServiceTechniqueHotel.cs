using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class AddRoleServiceTechniqueHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18", "270b4553-f9b8-48e0-b244-af2ce4bc5ca9", "HotelServiceTechnique", "HOTELSERVICETECHNIQUE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "08cad2d0-5b48-40ef-81a6-f3a3eab1da8c", "30c70e6b-ff22-4bd8-91d7-305a647506ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c7487fc8-17fe-4d3e-8d4b-00421d8781c6", "fb41ab99-50c0-4040-87fc-1f9916b8e72a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2209d0c0-cfc9-4e51-864b-4dc7a5d30313", "f4d6ee75-f856-4f3e-b3f7-99b29c083b73" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cb0156e9-2ab4-4151-b1a9-d47ad771e713", "daec1f0f-9375-404c-be88-936ddf55ca01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "59008e07-5d5a-450b-a634-c874fc157f13", "b741923b-4dea-43ca-b521-d038ef0f26a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "89b27b7f-989b-41b6-9052-2d1214eca35f", "b4e25992-0e64-4b91-b66f-1139fa657069" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8433c781-c9ae-48d9-a0e2-b9f940edf10a", "d0c3c0c7-62be-4a28-845a-2ff3de9bc910" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "183e5354-e7dd-4c06-9654-fa40027802fe", "9cf98943-e19a-408c-ac5f-9e05aa1d444a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0cfb8444-bc20-4261-ae59-dfafdb60bde7", "981ef66e-3df8-4e34-b063-4ef4d45d71cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0ae83a25-3c54-4869-9875-7b54ad5e2952", "91054684-26d2-48c3-8cc4-e2c875270640" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ced159ce-bd9d-4db7-bd08-394c9537ece9", "a8b841f3-0769-4dde-84ac-f3d1735538e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6eba6aab-7bbd-49a8-bcf1-2838a9e63818", "8b1eef59-4b35-4148-b5c5-32022ee39e25" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1f4dae6a-92bc-491f-8a86-e0835aff5d10", "1aab371f-0ae0-4df7-9d1b-79e031d26858" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "adc1167b-e6a2-45e9-8c44-91be05305f8b", "7b197bef-c1bd-417e-920d-e2c30d29264b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e0e5323a-804b-40cc-ba2f-d929f0e7f92c", "411529a2-2dd8-4c6f-8718-2f9502bdded4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f056096b-e8a8-486b-93b9-1cf992b0bd45", "d72e0ad9-2c84-4649-bf9c-0d127b2d0eb2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "601f8eb8-ffeb-41ec-949f-08c41b7804c3", "79dc271b-016e-4aee-ad1d-a86a6736862d" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "acd04fc6-99da-436f-a011-191b7e92aa23", 0, "f42bc54e-f342-4703-aa5d-8e5eef6f7190", "HotelServiceTechnique@gmail.com", true, null, true, false, null, "HOTELSERVICETECHNIQUE@GMAIL.COM", "HOTELSERVICETECHNIQUE@GMAIL.COM", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "4b1d65c2-ae5f-41c1-9d01-58bcf77ddac7", false, "HotelServiceTechnique@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "acd04fc6-99da-436f-a011-191b7e92aa23", "18" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "acd04fc6-99da-436f-a011-191b7e92aa23", "18" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acd04fc6-99da-436f-a011-191b7e92aa23");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ce66fecc-9afe-4ec0-a531-f7413f196d5a", "36d2f55d-d564-4f25-a6fd-c45c818eca20" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aff2cb9c-c995-460e-996f-6ab5e92e882f", "af732bf3-0292-4a37-9dba-58df75e65cad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "59fbc085-fd79-4694-a309-587a26ff9b64", "66c55844-fa86-4b88-b355-3110dbd95084" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3e7411e4-6df1-4d9d-9d1b-3f0447a40c9b", "09233bd7-1df4-4216-bc8c-5284112f00a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cc4c9331-175d-43e3-8f1b-bee23ad96a31", "bb60f6a1-01ea-4426-a709-cb72bfd442eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "96509a78-63ea-4b65-978b-31490632c1da", "d42612d2-e47f-4091-b841-9e765cd49216" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b81e27ef-a5b6-4e0c-8cc1-d981a88801df", "90ed9286-99b4-4041-a875-a9f028aaf1ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "745973ee-46ad-45d3-91e7-2fe2f821413c", "236a2040-1ad3-40cc-b8ea-4c9c420c0cdf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "46911091-2fb8-4b55-91d8-bf2ddbc09ed8", "9a501432-fe51-4887-8224-80e48da76526" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dfeb268b-861a-4f97-861c-bd079c145a99", "d9996132-b26e-4fa4-b3ab-6010dbf6570f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "add9d794-6111-4588-ac2d-d530f7cf5583", "28c1aabb-4db0-4e11-89f7-12fb863fdec5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aaec72da-294a-4841-be79-da4b161ada87", "70b26dd2-6c30-42cb-8d0d-f1dbf8ee037c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "87c2e242-ddab-40d7-8cb9-42fd05c50227", "6ce32e1b-cbd2-4e61-b948-bfa773f73bb1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "23affc0d-1ba0-43b0-91a1-a865d45412c9", "8a30ce33-7525-416d-be07-070a587fd566" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f1ad899a-8b06-4939-8338-e787a1c1d12e", "9ea64682-9652-4125-a359-a9ada6aa5e24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "21a1d647-8aff-4135-abfc-fc1b741c9a7c", "7b0675bc-ba59-4e50-806a-8155cda851af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2ab7a751-e24f-4edb-8a05-faf58f8606ea", "a42e253a-c876-4f49-a5d3-cbeb7262bc98" });
        }
    }
}
