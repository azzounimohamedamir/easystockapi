using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class removeUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "08a1a626-7f8e-4b51-84fc-fc51b6302cca", "5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3cbf3570-4444-4444-8746-29b7cf568093", "5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "44bf3570-0d44-4673-8746-29b7cf568088", "5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "5a84cd00-59f0-4b22-bfce-07c080829118", "11" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "64fed988-6f68-49dc-ad54-0da50ec02319", "6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "6b14cd00-59f0-4422-bfce-07c080829987", "11" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "6d215fd5-e7b4-4afd-aa6c-334a37d3874d", "14" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "7d33ae49-68a8-4c10-bc57-b09da6f9f016", "19" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "83e72357-25b8-4e2a-8728-3e25365608e2", "15" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a1997466-cedc-4850-b18d-0ac4f4102cff", "6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a3dbd500-eab0-4233-86fd-7f1a4195f9a9", "13" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "acd04fc6-99da-436f-a011-191b7e92aa23", "18" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "b2207466-ceda-4b50-b18d-0ac4f4102caa", "6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ba89dc5f-dfd1-4c87-9372-233c611cc756", "13" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "C4EAACBE-A5C5-47E8-8DED-508709D7A50F", "16" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d466ef00-61f1-4e77-801a-b016f0f12323", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d466ef00-61f1-4e77-801a-b516f0f12323", "10" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D", "17" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d33ae49-68a8-4c10-bc57-b09da6f9f016");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acd04fc6-99da-436f-a011-191b7e92aa23");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8109bcb7-20cc-4657-b854-704701a8ee95", "2a994916-2676-482c-ae69-e9342a8661d8" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsActive", "IsShowPhoneNumberInOdoo", "LockoutEnabled", "LockoutEnd", "Mac", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eed390c0-759f-4daa-856c-a0433345e8cd", 0, "4c15d5a5-48f2-4d47-9169-a82f995e5ec2", "caisse01@easystock.com", true, null, true, false, false, null, null, "caisse01@EASYSTOCK.COM", "caisse01@EASYSTOCK.COM", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "5042ee3f-31a8-49a5-b19c-a759ad64d358", false, "caisse01@easystock.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "eed390c0-759f-4daa-856c-a0433345e8cd", "21" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "eed390c0-759f-4daa-856c-a0433345e8cd", "21" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eed390c0-759f-4daa-856c-a0433345e8cd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8ca5ec59-3a33-453a-beaa-aa9accaee29e", "04e7a503-5ffb-417d-881a-4871e4acedfd" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "IsActive", "IsShowPhoneNumberInOdoo", "LockoutEnabled", "LockoutEnd", "Mac", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "acd04fc6-99da-436f-a011-191b7e92aa23", 0, "cb3efbba-bcd0-4163-91de-2dc9d881ff0f", "HotelServiceTechnique@gmail.com", true, null, true, false, false, null, null, "HOTELSERVICETECHNIQUE@GMAIL.COM", "HOTELSERVICETECHNIQUE@GMAIL.COM", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "48be9603-cdec-4bf0-aeb1-4ae1cf078f35", false, "HotelServiceTechnique@gmail.com" },
                    { "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D", 0, "8fe0b46f-4a4d-4d8b-b672-8c938785e983", "ClientHotel@gmail.com", true, null, true, false, false, null, null, "CLIENTHOTEL@GMAIL.COM", "CLIENTHOTEL@GMAIL.COM", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "93799947-29d6-4c81-8a43-d70466e55db2", false, "ClientHotel@gmail.com" },
                    { "C4EAACBE-A5C5-47E8-8DED-508709D7A50F", 0, "2b8b9efe-0793-44e4-a019-6d898c6b6dbd", "HotelServiceAdmin@gmail.com", true, null, true, false, false, null, null, "HOTELSERVICEADMIN@GMAIL.COM", "HOTELSERVICEADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "6e544a04-2c99-47d5-aeec-44471c1fcf56", false, "HotelServiceAdmin@gmail.com" },
                    { "83e72357-25b8-4e2a-8728-3e25365608e2", 0, "d449979c-9741-48be-a0f8-ddf1b288e8be", "HotelReceptionist@gmail.com", true, null, true, false, false, null, null, "HOTELRECEPTIONIST@GMAIL.COM", "HOTELRECEPTIONIST@GMAIL.COM", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "d0808247-399f-4d9f-8710-fbbe80bade7a", false, "HotelReceptionist@gmail.com" },
                    { "6d215fd5-e7b4-4afd-aa6c-334a37d3874d", 0, "d8d17be7-c8bb-4775-9525-36d40c55df6d", "HotelManager@gmail.com", true, null, true, false, false, null, null, "HOTELMANAGER@GMAIL.COM", "HOTELMANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "397580be-5991-4a82-b5e9-700b081d0373", false, "HotelManager@gmail.com" },
                    { "ba89dc5f-dfd1-4c87-9372-233c611cc756", 0, "129ebfd9-6e44-4b31-bb78-e900b33de525", "manager@cevital.com", true, null, true, false, false, null, null, "MANAGER@CEVITAL.COM", "MANAGER@CEVITAL.COM", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "609eb8d4-9ec8-4148-8aa3-b25f2abec2e1", false, "manager@cevital.com" },
                    { "a3dbd500-eab0-4233-86fd-7f1a4195f9a9", 0, "af8b2ca5-c329-41c1-b4d8-a1ddd786ede0", "manager@sonatrach.com", true, null, true, false, false, null, null, "MANAGER@SONATRACH.COM", "MANAGER@SONATRACH.COM", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "c736ab42-035f-4b4d-95b9-0e80415d3660", false, "manager@sonatrach.com" },
                    { "7d33ae49-68a8-4c10-bc57-b09da6f9f016", 0, "643d7a45-9595-48f4-a45d-3597e2831ca2", "HotelMaid@gmail.com", true, null, true, false, false, null, null, "HOTELMAID@GMAIL.COM", "HOTELMAID@GMAIL.COM", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "18bc96b5-d045-4f46-8114-7b3f6fd8b841", false, "HotelMaid@gmail.com" },
                    { "6b14cd00-59f0-4422-bfce-07c080829987", 0, "65c76457-39ff-4578-a47e-865f2ba2e35a", "Diner_02@SmartRestaurant.io", true, null, true, false, false, null, null, "DINER_02@SMARTRESTAURANT.IO", "DINER_02@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEJFZbbuBIpvoyXKwrceuNsU4cXZ18LLAl8g7s48Pye4EAEXwA2hswtnLMhMS9Q7Cjw ==", null, false, "7bb157d8-768c-4842-b1de-7c439db0d933", false, "Diner_02@SmartRestaurant.io" },
                    { "64fed988-6f68-49dc-ad54-0da50ec02319", 0, "6701e37d-5fe2-4a89-915c-664ffc5bb55f", "BigMamaSalimFoodBusinessManager@SmartRestaurant.io", true, null, true, false, false, null, null, "BIGMAMASALIMFOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "BIGMAMASALIMFOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEO+ouwzSOa+AsCNZrVEhO6Su9q/fX/Q9c9havEvhs5QtXWA6tRdfmqOlemUQphqDnA==", null, false, "53028de7-62cc-465b-885a-d4361da31181", false, "BigMamaSalimFoodBusinessManager@SmartRestaurant.io" },
                    { "b2207466-ceda-4b50-b18d-0ac4f4102caa", 0, "b1135f91-5251-4164-b48d-b98fae48a839", "McdonaldFoodBusinessManager@SmartRestaurant.io", true, null, true, false, false, null, null, "MCDONALDFOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "MCDONALDFOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "7c2dd9b7-d5f0-4657-b7ae-f59f1d562dd4", false, "McdonaldFoodBusinessManager@SmartRestaurant.io" },
                    { "a1997466-cedc-4850-b18d-0ac4f4102cff", 0, "1b9cda06-db24-41df-b822-331816b1d365", "TajMhalFoodBusinessManager@SmartRestaurant.io", true, null, true, false, false, null, null, "TAJMHALFOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "TAJMHALFOODBUSINESSMANAGER@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==", null, false, "c4c4f216-739a-4f40-ac32-5ffffea22b9c", false, "TajMhalFoodBusinessManager@SmartRestaurant.io" },
                    { "08a1a626-7f8e-4b51-84fc-fc51b6302cca", 0, "da83d7c0-213a-48c2-89ad-dd435fd5b2b2", "BigMamaFoodBusinessAdministrator@SmartRestaurant.io", true, null, true, false, false, null, null, "BIGMAMAFOODBUSINESSADMINISTRATOR@SMARTRESTAURANT.IO", "BIGMAMAFOODBUSINESSADMINISTRATOR@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "6ad47f3e-0bd4-47cf-ba81-563f2a148636", false, "BigMamaFoodBusinessAdministrator@SmartRestaurant.io" },
                    { "44bf3570-0d44-4673-8746-29b7cf568088", 0, "3ee53c9a-67df-41ad-bb49-ebde3201327c", "McdonaldFoodAdmin@SmartRestaurant.io", true, null, true, false, false, null, null, "MCDONALDFOODADMIN@SMARTRESTAURANT.IO", "MCDONALDFOODADMIN@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "e4604a4a-b009-43a3-8dad-9492dca8af85", false, "McdonaldFoodAdmin@SmartRestaurant.io" },
                    { "3cbf3570-4444-4444-8746-29b7cf568093", 0, "427f3b86-f8b0-4143-a1eb-46811e024340", "FoodAdmin@SmartRestaurant.io", true, null, true, false, false, null, null, "FOODADMIN@SMARTRESTAURANT.IO", "FOODADMIN@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "ce692fab-5870-4d48-9773-51441ab2e226", false, "FoodAdmin@SmartRestaurant.io" },
                    { "d466ef00-61f1-4e77-801a-b516f0f12323", 0, "61eab3ea-570d-4abc-85ca-a1eec66265bb", "Waiter@SmartRestaurant.io", true, null, true, false, false, null, null, "WAITER@SMARTRESTAURANT.IO", "WAITER@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "aa2a72b4-4e6f-4d06-b36e-dd3071b3d3a3", false, "Waiter@SmartRestaurant.io" },
                    { "5a84cd00-59f0-4b22-bfce-07c080829118", 0, "8b9dde9a-8186-47ba-87be-e8275ec18af4", "Diner_01@SmartRestaurant.io", true, null, true, false, false, null, null, "DINER_01@SMARTRESTAURANT.IO", "DINER_01@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEJFZbbuBIpvoyXKwrceuNsU4cXZ18LLAl8g7s48Pye4EAEXwA2hswtnLMhMS9Q7Cjw ==", null, false, "7fff4d3e-85b2-4b4d-94ea-382d6c4d0069", false, "Diner_01@SmartRestaurant.io" },
                    { "d466ef00-61f1-4e77-801a-b016f0f12323", 0, "9d2c0713-517f-47c3-b8c4-83626a3b1405", "SupportAgent@SmartRestaurant.io", true, null, true, false, false, null, null, "SUPPORTAGENT@SMARTRESTAURANT.IO", "SUPPORTAGENT@SMARTRESTAURANT.IO", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", null, false, "d14ac469-1e92-4772-a2dc-ffa528333e9a", false, "SupportAgent@SmartRestaurant.io" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "d466ef00-61f1-4e77-801a-b016f0f12323", "2" },
                    { "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D", "17" },
                    { "C4EAACBE-A5C5-47E8-8DED-508709D7A50F", "16" },
                    { "83e72357-25b8-4e2a-8728-3e25365608e2", "15" },
                    { "6d215fd5-e7b4-4afd-aa6c-334a37d3874d", "14" },
                    { "ba89dc5f-dfd1-4c87-9372-233c611cc756", "13" },
                    { "a3dbd500-eab0-4233-86fd-7f1a4195f9a9", "13" },
                    { "6b14cd00-59f0-4422-bfce-07c080829987", "11" },
                    { "5a84cd00-59f0-4b22-bfce-07c080829118", "11" },
                    { "64fed988-6f68-49dc-ad54-0da50ec02319", "6" },
                    { "b2207466-ceda-4b50-b18d-0ac4f4102caa", "6" },
                    { "a1997466-cedc-4850-b18d-0ac4f4102cff", "6" },
                    { "08a1a626-7f8e-4b51-84fc-fc51b6302cca", "5" },
                    { "44bf3570-0d44-4673-8746-29b7cf568088", "5" },
                    { "3cbf3570-4444-4444-8746-29b7cf568093", "5" },
                    { "d466ef00-61f1-4e77-801a-b516f0f12323", "10" },
                    { "acd04fc6-99da-436f-a011-191b7e92aa23", "18" },
                    { "7d33ae49-68a8-4c10-bc57-b09da6f9f016", "19" }
                });
        }
    }
}
