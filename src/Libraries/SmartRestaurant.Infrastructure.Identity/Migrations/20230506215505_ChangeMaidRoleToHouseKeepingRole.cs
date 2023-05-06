using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class ChangeMaidRoleToHouseKeepingRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "HouseKeeping", "HOUSEKEEPING" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2308e4a7-d4fb-4cbd-a31e-47546496abf6", "182c9064-d859-4708-9238-65042da1e6c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "16e6dede-9520-4095-bc3a-eea4a8297138", "f7c1b6eb-5b55-466f-8ea6-a0132111d162" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a7a065eb-0ad6-446f-8545-2b6e4d39c71a", "e5014919-4cc4-42ae-9659-7799c4022c90" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9a22d0fb-f091-4a76-b0b7-1b33ab8f6deb", "438e3746-cfff-4944-979b-9fb4fe217129" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1809e9de-2cd6-4e09-a214-33b91682b244", "ab7941d0-6c5f-4de4-baff-1662bf567cfd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9ef2c3e8-9128-4335-931c-dc8f938081e8", "a9fbfabd-3cb0-4d45-a858-19276fa6d7d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c5affadf-cd00-4163-984e-001f10569b21", "acbe6e78-98b4-4e37-989c-7749bdee32ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b3c916a1-a628-487e-890e-1e27115d0d62", "adf2b787-fe73-4049-9d04-7095c67d1e89" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d33ae49-68a8-4c10-bc57-b09da6f9f016",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "20f05300-1355-4ab3-809e-355213bb1042", "42c06667-99c5-44e6-a2cf-d937ef53a7d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f332a1cb-ef2e-4e8d-ad71-6ed5c8476f29", "fd6bfa18-fa23-4674-8fd7-c7cd93187aa4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e9fe81f5-66fe-4d15-b831-9f197aa5e97f", "13a11208-8d34-4dea-bf71-d5c2353fc3fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5ac0997a-c101-4dfa-b3ac-be21fa3b5c70", "07979016-b226-45c6-95b3-0809a6ced346" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acd04fc6-99da-436f-a011-191b7e92aa23",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9ddd23cc-ecf5-4d28-a791-dbceb004c655", "a2d0a577-900f-4b74-9cda-4deeec72591e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8175f756-d001-4b91-96af-0fc4ea753bac", "77ecacba-89e5-4435-8849-caf07cb3eb92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0c9fcf94-551e-4f08-b502-d49a95dba9d3", "a22c3be3-9ccf-4d58-ae01-ad430e9b20d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "806f24ba-aedd-4466-9693-e74dee437201", "f7b8f5d6-79f1-4099-9833-731c1b5c247e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2e52f07f-e45b-4c1f-9cc0-6b5f8b379b61", "539a139c-421a-4d6d-a276-fe0b5be7b0b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ea1c0a09-3c5c-40e2-9b36-0d90a55e08ad", "9277899b-68cd-4e22-900a-e5a68f2e3e14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7fd78a48-d44f-4058-b2d8-a610c49245ea", "6d2a14ac-9ddf-4b5d-9385-c34c0ff561b9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "HotelMaid", "HOTELMAID" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3503fbac-bec0-4a27-ba86-e998571c2898", "7ded5c74-361e-449b-820e-dde97f2afbe6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "93ad1906-8a19-49d0-aa9a-afaf578c5e72", "75d061c1-12e2-498d-8582-c969d51d0dd1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "82abef8e-8021-48d3-983f-0c37f5e20b27", "ba5d4c76-7907-40d3-ae10-9f1b3e70533b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b79655ca-9eac-475e-99bf-31aaca083491", "9f2d236f-e4db-4be6-898f-c23f78df644d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c0e8525c-d77a-421e-92b4-953d2bb1f271", "da543e9a-4055-47f3-999c-415d1b12fbea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e88be4ff-e11a-44f1-952f-55753159f35e", "b49d4ead-befc-4395-9534-812f2ebe42de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1dc53e20-5c42-44f5-9fad-67d041af3043", "aa021191-6b3f-42c7-9bb6-ebca8b855ac8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6b5da8e8-990e-4d25-ac8a-62cc47e82087", "1c4095bf-d2a9-4433-8114-802e1b624465" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d33ae49-68a8-4c10-bc57-b09da6f9f016",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6a71beeb-4e0e-4c61-97f3-fe3c28e83264", "beea5d10-b694-48df-83a4-02a9ef6fed4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3f039a35-dcea-44bc-ab84-016902823086", "b49cefc7-1863-4287-8515-681a81b0ecf9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ed144e9e-711c-4111-aaef-4dc176e1588a", "1e28b23e-45e3-412a-aefd-a12a48123c12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8bf28c7d-b472-40a7-afe6-00a865087f8f", "8fdca6d5-0d7b-4a75-9b49-6b27be08cb1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acd04fc6-99da-436f-a011-191b7e92aa23",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "af236b49-2078-4566-a579-4c6bb3319fe8", "25f40b95-04c3-4c63-bea8-a98817dd2373" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1669d32a-3e90-4d97-9bc4-2fbe6288f33c", "7bcdc87e-e3d7-4572-b634-d568c7e651a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e9c4ef4b-713b-4bf8-b28c-821542533ed5", "77241fa8-9b16-4484-b8e4-90c83fa538cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e6d4f8e6-21a1-43df-99a3-a3d170d94a14", "b543da9b-3942-4f3f-8de9-cf554861e0a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f6cc7a00-7b76-4bb7-90be-e4870d251c98", "bc85b46b-799e-4685-97c0-c7da352a9e9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d6846df3-384e-48fd-aaa0-48dee02a92b1", "652a2e66-4477-41d0-b65e-bdeb07620d95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "db4a6ca0-d97f-4b7e-aa69-4c6c8fa576df", "62b4830a-4b18-45c8-a001-ac07067d7ff0" });
        }
    }
}
