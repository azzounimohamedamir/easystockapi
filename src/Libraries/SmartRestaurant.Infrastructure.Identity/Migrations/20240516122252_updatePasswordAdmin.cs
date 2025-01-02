using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class updatePasswordAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8ccf397b-1a27-4bba-b088-692ac1e29e42", "9d6b4e41-1242-487a-8244-27838d5b0d97" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ec47812-b9c0-41b2-96e2-4cdf87819b2c", "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==", "1c75da9a-98eb-4421-a974-e52068d696f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b9f2c515-2586-4773-9569-832195bbeaf0", "a5f06b8a-8ad1-479e-9a7a-e3677dfa9bee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ece60d12-a8d9-4e28-9388-321179890297", "eb88f2c8-297a-42aa-93b9-c126f8cd3a49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2d0a66a7-1e7f-44fe-a5e4-476c1c0726c4", "60bcafb1-9473-4921-ab17-0c8e488282f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "62544137-1ba2-42c3-be0f-d53059b9261a", "9329e883-6a2c-4f23-ac13-3eb6202a1409" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fcf391e0-4c85-490e-b799-6095cb5dc4c6", "edca089c-b0fd-48a1-8236-4776e3357081" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5c95c7e4-01c9-40cc-95ac-81c4de2d61d0", "b8f88132-bcd9-44c0-bd16-a88e22ea257c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d33ae49-68a8-4c10-bc57-b09da6f9f016",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "56c38e60-c1e8-4f82-ac95-60d5daac65d9", "e9adfd2c-e12f-4461-b7f7-453030584da5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e6485290-fc0a-428a-ace9-7f52ddc7fdcb", "d3326807-504a-4fed-b8d7-33390c3ad6db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1dc591af-e75a-4880-bfbb-8a59eb74a43b", "b759aa37-deb7-4913-b53f-29ebd5377790" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1ca209ec-fcb8-4025-b986-02d58eb4bb60", "9d444b2b-e562-4757-96c3-c0fc3bbe9c06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acd04fc6-99da-436f-a011-191b7e92aa23",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b09eeb68-0533-4690-8aef-0fa28f6fe9a1", "6a08da29-df8a-4cb3-b364-ec4bd62944f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ad4094cb-49af-4789-b2a2-c383652d216e", "ad825088-8e77-4f5a-847c-82a41f40290a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2bcc63c7-bbc4-4d0f-842b-3c4b17c42da0", "da59995b-c251-46c5-8346-514571e211b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "520aef52-b2f4-40ec-91fa-2d4e883e5ebc", "37fdfc1b-125e-428a-a796-f8c5274213bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6707a284-7234-42d0-a931-78971fb5b769", "92ff1327-fe8b-446c-9acf-7a29e4b453e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ec83dce1-51e9-4400-a06e-536531832c45", "b1ae981a-e7dd-4efc-835b-c7e0b0580928" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a963828f-b9ff-4fac-90d2-984993f8a98f", "01f58d3a-fb35-4ec7-8bfe-881040f95221" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a276898f-0be7-474d-8f0f-016c0e904d50", "AQAAAAEAACcQAAAAEAzFpmzMtMiw0wHV6b0aUzFLF9Pw7B2u+DswRHttAU2nH22NHBsc/hSSvKUqmRWGZA==", "73c55bf1-7ed6-4708-aa62-78355092e2fe" });

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
    }
}
