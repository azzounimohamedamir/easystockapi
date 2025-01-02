using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class addNewRolesForEasyStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20", "1933aad7-120c-414f-a575-5681df13732f", "Manager", "MANAGER" },
                    { "24", "b9182488-5482-4051-af9d-5fea22182944", "GestionnaireVente", "GESTIONNAIREVENTE" },
                    { "23", "6f3d452f-28a5-42be-b474-716985d97820", "GestionnaireStock", "GESTIONNAIRESTOCK" },
                    { "25", "5050daa0-8870-4450-8004-23d11aa0cc4a", "GestionnaireAchat", "GESTIONNAIREACHAT" },
                    { "22", "0c845a63-6573-488a-9c89-a50484707e88", "CaissierFacturier", "CAISSIERFACTURIER" }
                });

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
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "96a1d3e9-9af5-43a7-ae11-c3e50f8bdb37", "3f210f69-7bee-49c6-9142-2754db20fead" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "089a1be9-5795-4e89-94d9-628ded8387b5", "a7e6c763-ea53-4bc4-a1e0-3068b7699fc8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7a012b13-c40b-4df8-94ab-5bc8f649321f", "3631400b-0c9a-4a6b-8d2d-aa870fb961d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4bd40bb7-9cdd-4e46-9227-a413ed5659ac", "88c545c3-fec2-43d5-9233-04b6bd282698" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1d9d3f82-8340-4371-9b9a-5e2c59b13364", "7b90ad26-43c0-4fa7-a4e9-a59418e97f14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f0fc3398-fc93-4112-9082-e8effb4bfd88", "7eaa18b4-8daf-485e-aabf-50b4c7f5ac13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "933e679c-97b0-4469-931d-c38475e0b772", "55c60785-8dac-474a-a214-efabb2462f94" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6c7b4408-3b11-4440-b143-d23c3004c07c", "b5d3366f-0acb-46a2-94c8-8fb0edf87b68" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b9a3be64-47e7-4fec-899d-925c19b22752", "e6fb777d-5bb3-4b31-aee4-86950dc932df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d33ae49-68a8-4c10-bc57-b09da6f9f016",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "36585e6a-b14a-4042-a6ce-7a5d1cc75979", "cbed85f8-dbcd-459b-9a48-be46ec964c36" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7040d623-69ea-4f51-baa8-a80b2cb292e7", "03e0d5d9-8785-454b-bdec-0730159e007a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1df356e7-0f86-469a-b665-f40d0f9eaece", "398cdb62-ad32-4559-a614-ddda05c24fa2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "84aad3b1-d291-4cdb-a1dd-93058077ad71", "f7782a70-2efd-44a9-a958-3d33d480ca8e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acd04fc6-99da-436f-a011-191b7e92aa23",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c5367e56-8326-4ce2-b495-50556116e7f2", "bb9069d6-e12f-4f32-b256-c5e8e81438dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "515551f3-ae7b-426d-ad65-c1b6e2d0393e", "1e71a0be-ab6b-4d2b-9732-3d1f7c1c0938" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c89a903b-304c-4096-aae7-5c6c720a23dd", "9950c1bf-3b42-4a6a-a7eb-3404aa046216" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a1b46a95-8bbd-46cf-8dba-00d8b0be14e9", "1671ae0d-fae0-4fe5-8413-7b704b3b78e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8f606bc1-28ac-457b-b9a3-2659d4365d5e", "61ff6f6d-c2b8-46a1-941a-18fd82789d9e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "33ec0018-4ad6-494a-8c13-b08aed2275e3", "b7efea43-20ea-48c6-89e5-62f2584ab7d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "258ed555-fe6f-41ea-8c70-900e3199d83e", "195f37a1-e508-4e98-aea3-bd15cf3fc685" });
        }
    }
}
