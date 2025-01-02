using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class AddrOLECaissier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "21", "27dcec7a-0048-4e46-9cf5-292a4a59c171", "Caissier", "CAISSIER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a370bf3a-1985-4d36-9848-7fd2342404d9", "d61559ec-a187-4e0a-b5c2-9d9f9a74ac36" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a276898f-0be7-474d-8f0f-016c0e904d50", "73c55bf1-7ed6-4708-aa62-78355092e2fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bb4fae67-a506-488a-bc7d-60a9ba8e8fbf", "492e6338-da17-4c61-bd4a-ca2f70f9846f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dc373fd6-87ff-4b15-84a2-bcd30820aef1", "ef9af9c0-13df-4b9b-8cfc-9f2a011fab7f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0581a114-9cc8-44fe-aa45-d5f6ab721715", "14e40536-940c-420a-aecf-e833b77b5678" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "84f2114e-5d76-48d5-86f3-f5ce454fbe14", "6c87dd21-f2d7-4b99-ba6e-9d8a5cc2a21f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c08ae075-8722-4e4b-bde4-5cfc8ca2f379", "c71dccb1-905a-4aae-a957-617489cd9f4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3f066fd8-6bc5-4c62-a371-7c0d03605801", "7b3063cc-fd15-4e32-9935-6b3ba1cbf9dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d33ae49-68a8-4c10-bc57-b09da6f9f016",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fdfa3c8f-dfc3-4b44-b9fe-ff7838d1ffe3", "2053991b-12fc-4b23-b7d1-91b30257c838" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f1fa1ae3-676f-464b-8c04-431cdf40b11d", "0a26ebfc-4c66-45ce-bd5b-f99aa35f8b55" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0431bf57-fa52-4b7e-88c8-4fe5f5d8f1f5", "3f7a93de-84ab-4883-a6cc-84e9fcc9d549" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ab81c93a-9d3d-46e1-861c-385b8bdaaf7e", "a2c4197d-2719-42be-90b0-0fd61d8b7fcb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acd04fc6-99da-436f-a011-191b7e92aa23",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ef892423-b943-4971-8035-7b75ab4f01ce", "1cbcf090-2c46-4c64-a931-a94c6d151cca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "65aa85cf-bc58-4605-82a6-462d423f76b7", "d9f1d266-4986-44aa-8110-577af20423b0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "767eae63-86b1-4d67-b721-8d7a17768362", "3d973f1a-a82f-43b6-927e-f6e60b9cac3b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "00b90009-d21a-4c7b-aabc-779bc12a82a9", "3922ef86-b07d-4d06-9c6d-230e6dccbae9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b49e213e-a89e-498c-a7f2-84fc71a4d533", "df91be97-03b9-4ced-b744-46600318bd79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "564e5eeb-00bf-4f88-aae2-b958a97e6acc", "44cdb1f6-5334-4b76-9b9f-35fdef6ed9ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7c4386d8-6b26-4096-acae-2edfdb7e5bfb", "7cba9a52-b14c-440e-a144-36be7b2d8059" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6d714df7-1d9c-450f-b642-4d919d55c13d", "9342894c-ed2b-4519-b833-b0e71920e359" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b80ae221-8000-4bdd-be39-032ac039fbe9", "aa4a0a81-d67f-4fcb-9a6d-57da9c866e71" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "822a3407-0ff0-4eea-bdf5-0430b50f6bfa", "b2a3aaa6-8ca7-42f5-ba13-2bdfc0d1239a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "59af6a3f-dae3-48d7-ba85-3322a64e3f65", "69e15d8a-51a8-4118-a2ec-f0e9debbd474" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6dc0e92e-78a3-477f-ad92-47f58d0bca55", "03f8cb83-5ab5-4ca2-a957-3a6441e09c03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e3e9fa86-49ca-439b-8dc4-d76c6a304a7a", "297ce76e-6982-4e3f-837a-bea2c4304e66" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2da3aca2-b525-4945-b556-e84a3ece07f5", "b7532d64-ca42-4bac-a16d-230109984a24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c38c4567-a883-46a0-9bb3-b6c296bb0582", "84a9ca8e-da62-4ddc-b528-23eddda197d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d33ae49-68a8-4c10-bc57-b09da6f9f016",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "55e17a88-4f76-430a-8b1d-8fc1dde7e539", "ae675e9b-f4e0-4a6b-8328-2eaeb3aa8085" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fa34bc01-fbc3-4617-81fe-0384d5d50e47", "8338478f-8f20-4349-bc96-d0a2b0a86596" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4ed67c6d-e303-4f4f-97bf-4eb8c4b7eedd", "f2ad24ff-8d49-47b7-9da8-ca2c95b69ac6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5b674c66-4ac8-4bb8-b10a-3ce6850ae451", "236fdf01-279a-4bf6-bfb4-b927743f89c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acd04fc6-99da-436f-a011-191b7e92aa23",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "64882f98-153d-4acb-a334-4de159b14330", "7bbbbdc6-b709-4ac9-8c4a-2b5b85cab1e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "57fcb131-2b5a-455f-9ca4-25be4184d716", "f78b86e8-de91-41a5-aeeb-fe0bad4607b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "877909b7-94c5-4f13-a40a-c59419553531", "b284f9d5-89cc-4829-a8c6-52d705d719fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f3494c90-8064-499c-b8fb-dbb53e9ed592", "3e67c1b2-02b0-4b40-b621-7d1c3aabaff8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a738f311-5334-4c68-9144-cf26614bcd2d", "6e302c4a-5b75-4782-aac9-047d7e6d4c1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "30e68507-22dc-4374-8b2c-78b7b9b13ef2", "68bb16af-ae15-462b-a1cd-16b5c9367078" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9388f4bf-8e56-44f7-b83b-f97b359efd7e", "16702783-9b3a-4784-954c-ba2c5acc869b" });
        }
    }
}
