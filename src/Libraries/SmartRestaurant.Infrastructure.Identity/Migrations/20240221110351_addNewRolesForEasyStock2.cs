using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class addNewRolesForEasyStock2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9dc1321b-8ec1-421d-9861-f9b77e9ef3d0", "debb2988-770e-4742-8ba9-e8933eb77eb7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "14e1baf2-db59-47c5-abac-5dab5df3cec7", "admin@easystock.com", "SUPERADMIN@EASYSTOCK.COM", "SUPERADMIN@EASYSTOCK.COM", "83d0c45e-8b54-4643-8355-4d766c45bbc5", "superadmin@easystock.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7026815e-439b-4836-8d4d-35b2df54d032", "f466d316-0cc2-43f5-b096-7fd2aadf6013" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "75cccca7-0d8c-43d4-9dcd-3e78b1e1050b", "9c55a945-fc92-4ef8-bbe7-420419f5d0cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "41e8d8bb-92e1-48ba-83ee-e7387cf35c55", "e792bdba-8a04-43e9-b984-4a0b9294e143" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "43daafd0-eb40-40ca-bb9e-d66514d661d4", "2e18fa40-349b-4c29-a4e0-da24815203c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cb93881e-a6bd-497a-b75a-8c99d738e9ca", "77edec0d-eaaf-43db-8191-60ce55b3f18d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "72df3305-f8f7-4802-a2db-9652e4b9e7a5", "369c913e-9ec4-4f27-8c20-650ac0337682" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d33ae49-68a8-4c10-bc57-b09da6f9f016",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ea95608e-41a4-49be-a1e4-5672c58a978e", "4dfe13d5-c8a6-4214-a8a4-c7468608c4cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "83533e52-43da-4f75-8779-b74d9dc68d80", "5cdf03c0-52cb-456a-b23a-bdadde699527" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4fbbf991-3331-4d9d-a54c-d4f2a26381be", "8d7f6f0e-c260-4fbb-8d3a-f0870ff58a5c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "369a9493-ba19-40c8-83d9-5968b7ac4bb3", "bf938178-0524-4a2a-98bc-1b8255e3b26a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acd04fc6-99da-436f-a011-191b7e92aa23",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "be986da8-d553-4316-be31-e56c8ac577e9", "70c955db-d2e5-4f41-8d25-6f774790c42d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1f8023e7-5a75-4126-9449-407dc705b3a7", "60d1626e-e4a3-4328-bc37-ea78acf39956" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1fabd873-9d37-4db9-b628-8d3aabccf587", "6a3fa5a9-f7c0-4076-8b64-5c3a9139bec6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f5027d87-20ef-4371-b61b-c2a3c6da5397", "262a5a6a-c0df-4dc3-9e1b-cb7cc1e22aff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5c3b175c-e07f-4b32-988e-84aecdfc95a5", "17b9c731-4797-4090-80a1-571bb211729c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8d65f1a3-dc90-4ba0-b9d7-165faca898f0", "a606dcd9-54dc-481a-b8dd-c93825643c30" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "333c8c9c-b641-4b21-b82a-2e8cdc7fc145", "888cd73f-93db-472f-8d16-fc1807dede52" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "229a87d5-ebf2-4721-94b1-7cf62814b7a2", "c296f1f0-2b6f-46a4-a46f-bd82cf8599e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "96a1d3e9-9af5-43a7-ae11-c3e50f8bdb37", "SuperAdmin@SmartRestaurant.io", "SUPERADMIN@SMARTRESTAURANT.IO", "SUPERADMIN@SMARTRESTAURANT.IO", "3f210f69-7bee-49c6-9142-2754db20fead", "SuperAdmin@SmartRestaurant.io" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b6cccc99-49a5-4a89-b34e-4bad58715a72", "25d84161-a3d8-42e7-9f5e-1ceffadd4433" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a4bb7127-32af-4bab-83c5-6a961c89e83f", "46bf5976-4310-4b73-869f-eabfd8fa840f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d9e8aba7-7410-4cc1-a77b-d316540db851", "7654c567-89c9-42b4-9521-45a7abffef75" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "78435d35-6718-4f06-a116-4ac8f76e5d05", "4f70b1c6-e58c-498c-9f33-3702e62899da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "60d3697b-b12e-419b-a480-8fe24a014953", "51130ab0-5a4a-4d9a-ba85-ccb411592482" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9e1ad7da-73e8-4f8a-892b-ff5e27ea3c60", "df9d8e56-ec83-482a-8ebf-5b8f3be63203" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d33ae49-68a8-4c10-bc57-b09da6f9f016",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "23b30fa0-f9ee-497b-b988-7a9ad955738b", "eafe581b-52ac-4ee5-a528-3cbd87e2dfd4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "66045c86-5134-49d1-847f-e9e0b5126a38", "413d3184-f67b-4e0f-b1be-b5c3f588419d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9d751091-213a-49fc-9ba0-fdc09266be95", "2499a770-46ac-4003-aea4-e6ebaf5ead21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "70d64003-60b9-4fd5-a6fb-7e31601e5761", "51a1c08b-d5b7-4984-ad09-7b64bbd4718b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acd04fc6-99da-436f-a011-191b7e92aa23",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "076c455d-140f-47ed-887f-163bd51fa893", "f2e054d5-69a5-44a1-be0d-d7856df0ce7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3057abb3-f6b9-423f-bed5-26685af472c2", "8b5bc13b-44f2-48f4-b6a0-d2d182b7bbd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8c07904b-a948-4736-8bbe-a1f0e0febff8", "a1290764-c3c0-4005-ae12-60d21f886a40" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c0343ac5-10f5-46f7-b211-484aac4824da", "ffe1cc15-dcd2-4976-ba37-c131cf05297b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e0a57961-cd23-49de-bbcc-3f5fdfb86c1e", "887866b3-f8ae-47d6-b8a4-9af4a4b80a0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0bbe5e30-9e88-4358-bfb0-b8d41e67d2c2", "2140aa67-f060-4e0a-87a6-e8d12a82b1d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "679f0801-84b5-4243-a74d-3351d19ac957", "101627e6-45b7-48e6-830b-72c8a05a1661" });
        }
    }
}
