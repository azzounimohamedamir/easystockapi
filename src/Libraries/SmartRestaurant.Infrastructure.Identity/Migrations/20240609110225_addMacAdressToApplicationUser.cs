using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class addMacAdressToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mac",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "01d23074-d485-4b9b-9447-e34acdf788ec", "6d22e5de-e7c5-4604-9f0f-08efeeef0ebe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c1a5c0c7-c8f5-4f11-b786-6ad95b88a102", "de96efb2-48c6-4f4f-b484-97d241fddb53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a7dd8ad5-6bef-4d14-b55f-cbf5246c79e2", "4c4b5bce-7fa3-4e8f-a208-2e64333286a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9d8b5b86-20a4-45a9-91d9-d29b5ce47ca4", "04c21f1b-8356-4f64-8cc7-6a1e157bb4c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "663a6c3a-00e2-4eaa-b583-ae70f2f14d4f", "ce66c6a7-7c58-4372-92b4-653ef9d51010" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fa5c6726-3770-4f99-8224-6e0a2119b577", "c3993271-907d-44a4-892d-6c0083bcea24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "460dc7ff-7a0a-4b71-913c-55a71c3b4ca2", "38da445d-f3ce-4505-9deb-6a38ae6e641f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "862c3e47-1298-4a3d-8df1-99463a8b18c1", "20733c1e-e307-46cb-89b3-c7bf60f0e205" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d33ae49-68a8-4c10-bc57-b09da6f9f016",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "41780c16-524a-4467-b8fb-424c3c335421", "08549002-22a3-4cf5-b7a4-b6153c2fd22c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9042a03c-8dd9-4d93-b490-536791f1002a", "271be52c-839c-44f0-b799-9f5af17310cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "107f41de-1157-4bbd-8ef2-33d9b010d22f", "6ee85396-872d-4a44-ba86-88ca53e02b88" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c1efa974-0155-4e7a-9fb4-34233d5ddcdb", "dfedafce-bb87-49b8-b343-cf99a5c9eda9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acd04fc6-99da-436f-a011-191b7e92aa23",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9da3f5ff-595c-4309-b77f-ab7ddd0f857c", "484e7e13-7d5e-43a0-a8bc-6f1b7966c647" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "af345353-f17f-40b3-95be-34ebc81411df", "281d4845-b130-44ca-9725-5decf5eee3a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b765ce08-513f-4ef6-9c88-5efdc680b594", "f6566eb8-c91b-4e10-9fd9-4fb3d6a77cf7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "514b27ee-5b15-4dab-877e-e5ddf6d03eba", "5081bb56-df6b-4e9d-bb18-ac529e76945f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9e018b48-49f3-4ac4-9573-1d11eb29748c", "13e5c1ed-a25e-40ea-bd6a-a3879a46f88c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8cc3448b-e44c-4278-b569-d9c5b2e42a0f", "6ed1f664-71a4-4704-9a38-d7afbc334cdf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "94e28fbf-5a12-4e66-8367-be2ec69b4721", "c8ea998a-4829-4c6a-9f4c-eb8baaae911e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mac",
                table: "AspNetUsers");

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
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5ec47812-b9c0-41b2-96e2-4cdf87819b2c", "1c75da9a-98eb-4421-a974-e52068d696f9" });

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
    }
}
