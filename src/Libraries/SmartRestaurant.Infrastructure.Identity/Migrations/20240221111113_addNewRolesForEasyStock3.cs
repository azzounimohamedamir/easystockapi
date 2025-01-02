using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class addNewRolesForEasyStock3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d5f887e5-69fb-490b-99da-41805f441d4a", "2846cb0b-2f41-4636-b21e-a9661261c36a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "1ebd32c3-b622-407a-b824-78a94144ab60", "admin@EASYSTOCK.COM", "admin@EASYSTOCK.COM", "e254dbcb-9baf-42cd-aed9-4e7afc7d8427", "admin@easystock.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a9ff37bf-2231-4a26-a4ea-f2b52b12ee02", "7569b9d5-6db0-46fa-973a-0dbbf0bc350b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ff8ab892-cc8d-46fe-9a8b-1abab030d57c", "47eff69b-6ab4-4012-ae52-3332425283a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c579bed4-00c4-4131-a579-f28d654a2b9c", "1dcf5157-f3f1-476c-bf59-1a5701ec96cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5ae342d8-550f-47a1-8a88-f3c030b12fb1", "d94d91ed-9581-4b15-8883-7b4eaa6b0455" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e2492aca-ffce-451a-a1d1-37c2de341f7b", "57c38b03-0511-4104-8967-2f5bca3d4734" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "156321a6-6d38-4818-b0d0-5e7461185165", "47296449-42f1-473d-8f90-a28e9424c356" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d33ae49-68a8-4c10-bc57-b09da6f9f016",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7dc1064c-c782-4e11-a364-11871acb7459", "d65ca1ee-0fcf-4bf7-9b9c-0ae7b948a83b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "08eb4ba1-129c-4c29-9d80-4a6f9968889c", "c587eac6-85a5-4583-9643-41691cc57419" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a939c252-7be3-4dc4-bc2f-3271897bd9da", "e541f4aa-2fdc-474d-948a-89b74b9d764d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f9c8cb7f-fa9d-4269-b85a-fff8a878b969", "b4b96a78-96a1-4233-9f38-4c504ea98be3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acd04fc6-99da-436f-a011-191b7e92aa23",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d1cb09fe-5377-42e6-86f4-8e0ae9751c4f", "bda58a7d-accd-48e0-a07b-10b58a70862c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9a2ffe80-c46a-47cf-9d7b-31f2a3130f61", "5857914c-9b7e-4a95-89d7-ebf65f4095c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5124cc1c-0a43-4446-9667-342f73a505a6", "e1237d6b-15a8-466e-9dcb-f27cd8722038" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "09a0e191-2b4c-407e-9a35-7a2f1f383474", "a47460da-a4cb-4dc1-9213-1d353ac32189" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b6dd62a2-79b5-44f1-b718-acd5437e4650", "8ee48bca-ea13-41c7-894a-2b2b2e3231c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "43a341d9-d298-4172-9b83-cdb56569956a", "acfd57ea-9689-4824-a242-b707a114b600" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "607265ba-0e3a-477a-b614-1011f4004f1e", "19b65ad0-cf47-4c82-bc96-c0d671e97d2d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "14e1baf2-db59-47c5-abac-5dab5df3cec7", "SUPERADMIN@EASYSTOCK.COM", "SUPERADMIN@EASYSTOCK.COM", "83d0c45e-8b54-4643-8355-4d766c45bbc5", "superadmin@easystock.com" });

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
    }
}
