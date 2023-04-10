using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class AddIsShowPhoneNumberInOdoo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShowPhoneNumberInOdoo",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "3503fbac-bec0-4a27-ba86-e998571c2898", false, "7ded5c74-361e-449b-820e-dde97f2afbe6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "93ad1906-8a19-49d0-aa9a-afaf578c5e72", false, "75d061c1-12e2-498d-8582-c969d51d0dd1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "82abef8e-8021-48d3-983f-0c37f5e20b27", false, "ba5d4c76-7907-40d3-ae10-9f1b3e70533b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "b79655ca-9eac-475e-99bf-31aaca083491", false, "9f2d236f-e4db-4be6-898f-c23f78df644d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "c0e8525c-d77a-421e-92b4-953d2bb1f271", false, "da543e9a-4055-47f3-999c-415d1b12fbea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "e88be4ff-e11a-44f1-952f-55753159f35e", false, "b49d4ead-befc-4395-9534-812f2ebe42de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "1dc53e20-5c42-44f5-9fad-67d041af3043", false, "aa021191-6b3f-42c7-9bb6-ebca8b855ac8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "6b5da8e8-990e-4d25-ac8a-62cc47e82087", false, "1c4095bf-d2a9-4433-8114-802e1b624465" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d33ae49-68a8-4c10-bc57-b09da6f9f016",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "6a71beeb-4e0e-4c61-97f3-fe3c28e83264", false, "beea5d10-b694-48df-83a4-02a9ef6fed4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "3f039a35-dcea-44bc-ab84-016902823086", false, "b49cefc7-1863-4287-8515-681a81b0ecf9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "ed144e9e-711c-4111-aaef-4dc176e1588a", false, "1e28b23e-45e3-412a-aefd-a12a48123c12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "8bf28c7d-b472-40a7-afe6-00a865087f8f", false, "8fdca6d5-0d7b-4a75-9b49-6b27be08cb1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acd04fc6-99da-436f-a011-191b7e92aa23",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "af236b49-2078-4566-a579-4c6bb3319fe8", false, "25f40b95-04c3-4c63-bea8-a98817dd2373" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "1669d32a-3e90-4d97-9bc4-2fbe6288f33c", false, "7bcdc87e-e3d7-4572-b634-d568c7e651a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "e9c4ef4b-713b-4bf8-b28c-821542533ed5", false, "77241fa8-9b16-4484-b8e4-90c83fa538cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "e6d4f8e6-21a1-43df-99a3-a3d170d94a14", false, "b543da9b-3942-4f3f-8de9-cf554861e0a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "f6cc7a00-7b76-4bb7-90be-e4870d251c98", false, "bc85b46b-799e-4685-97c0-c7da352a9e9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "d6846df3-384e-48fd-aaa0-48dee02a92b1", false, "652a2e66-4477-41d0-b65e-bdeb07620d95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D",
                columns: new[] { "ConcurrencyStamp", "IsShowPhoneNumberInOdoo", "SecurityStamp" },
                values: new object[] { "db4a6ca0-d97f-4b7e-aa69-4c6c8fa576df", false, "62b4830a-4b18-45c8-a001-ac07067d7ff0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShowPhoneNumberInOdoo",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "534d5e83-98a8-44c7-92c8-4775cd5ca94b", "be39f8c3-b21f-4137-b862-dedf7ae3fb79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3b1b4261-fee3-46c0-aca5-6719599def1a", "ebfa9395-1578-434a-aaee-0e4aa9d43fbd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a49ae4bb-6113-4aa8-bf89-9c37a484e38a", "e79d7724-96d5-48e3-9b5c-1c5c94fa1f54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5bef545b-93a6-4a1d-9aae-b7e93900f275", "07dc73c1-af54-4055-a6e1-00f82aabe827" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2b1f9c93-4472-4187-b260-83d57d7960d8", "315d7068-4a4e-4feb-b103-590dc266a959" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fe7d37da-4907-429b-a1a1-322f4f9852d6", "26cda717-6bc1-45a5-8e8f-f0a5711faa6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3be5bd13-d867-4dc2-b187-4ab3590d1542", "cc0e864d-78d2-4602-aff2-1830a63ce256" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bc03333a-4364-401b-92eb-1f5102056aea", "4a7b0d58-287f-4e59-b6e5-1d6171ff7241" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d33ae49-68a8-4c10-bc57-b09da6f9f016",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "45dfe0e2-2c52-4839-92c0-4374145f6d80", "e89ebfb4-eb14-4e6f-b64e-2728d840f7f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "13bbc039-b5fd-4e4e-8a26-db12704f0707", "1ad98f0a-bb41-4a44-a84c-7a42a6aff08c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cc1ec999-0408-4c16-838a-ecd6873e175d", "08a62726-9ef3-4f38-9a31-a57c121198eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bfa584bb-bdfd-43ed-b7cf-69a05c9100c1", "5cb1357c-cf6f-4cc1-be63-01741bae3c92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acd04fc6-99da-436f-a011-191b7e92aa23",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "39061645-3541-4a20-bed3-00c9db30ca62", "64fe566a-681e-445f-b257-214dd9418dbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c01ba71b-3e94-4964-bd56-43a0d1dd6849", "e62ee506-e1d3-4a28-b25f-1144d7045765" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b20d8865-05bb-4809-bf68-6492dc71cdac", "c3c59c56-1d8b-4f8c-8fa0-17936a6d263f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6387cf54-06fd-44fd-89b1-497c1b1eccce", "0d722ccd-af3e-45d6-93a7-743d85c34dea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0cdea4da-2b3f-4880-893e-efeb470b6ef8", "6b5b2151-2b50-4f2c-8d15-07a815430434" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "01094871-4385-476c-8c8a-1746e202aa6f", "910db962-e306-48bb-9bf7-bb2c870c8c83" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4fb60bc6-5236-496c-b6f3-c8f933d64955", "e14d1ec3-b423-437a-b02d-8202afedd5e3" });
        }
    }
}
