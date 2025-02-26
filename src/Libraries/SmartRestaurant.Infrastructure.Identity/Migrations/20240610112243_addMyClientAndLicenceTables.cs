using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class addMyClientAndLicenceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicenceKeys",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LicenceKey = table.Column<string>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: false),
                    ClientName = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    ExpDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenceKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    MacAdresse = table.Column<string>(nullable: true),
                    LicenceStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyClients", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a1a626-7f8e-4b51-84fc-fc51b6302cca",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "da83d7c0-213a-48c2-89ad-dd435fd5b2b2", "6ad47f3e-0bd4-47cf-ba81-563f2a148636" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-0d44-4673-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8ca5ec59-3a33-453a-beaa-aa9accaee29e", "04e7a503-5ffb-417d-881a-4871e4acedfd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cbf3570-4444-4444-8746-29b7cf568093",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "427f3b86-f8b0-4143-a1eb-46811e024340", "ce692fab-5870-4d48-9773-51441ab2e226" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44bf3570-0d44-4673-8746-29b7cf568088",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3ee53c9a-67df-41ad-bb49-ebde3201327c", "e4604a4a-b009-43a3-8dad-9492dca8af85" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a84cd00-59f0-4b22-bfce-07c080829118",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8b9dde9a-8186-47ba-87be-e8275ec18af4", "7fff4d3e-85b2-4b4d-94ea-382d6c4d0069" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64fed988-6f68-49dc-ad54-0da50ec02319",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6701e37d-5fe2-4a89-915c-664ffc5bb55f", "53028de7-62cc-465b-885a-d4361da31181" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b14cd00-59f0-4422-bfce-07c080829987",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "65c76457-39ff-4578-a47e-865f2ba2e35a", "7bb157d8-768c-4842-b1de-7c439db0d933" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d215fd5-e7b4-4afd-aa6c-334a37d3874d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d8d17be7-c8bb-4775-9525-36d40c55df6d", "397580be-5991-4a82-b5e9-700b081d0373" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d33ae49-68a8-4c10-bc57-b09da6f9f016",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "643d7a45-9595-48f4-a45d-3597e2831ca2", "18bc96b5-d045-4f46-8114-7b3f6fd8b841" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83e72357-25b8-4e2a-8728-3e25365608e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d449979c-9741-48be-a0f8-ddf1b288e8be", "d0808247-399f-4d9f-8710-fbbe80bade7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1997466-cedc-4850-b18d-0ac4f4102cff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1b9cda06-db24-41df-b822-331816b1d365", "c4c4f216-739a-4f40-ac32-5ffffea22b9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3dbd500-eab0-4233-86fd-7f1a4195f9a9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "af8b2ca5-c329-41c1-b4d8-a1ddd786ede0", "c736ab42-035f-4b4d-95b9-0e80415d3660" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acd04fc6-99da-436f-a011-191b7e92aa23",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cb3efbba-bcd0-4163-91de-2dc9d881ff0f", "48be9603-cdec-4bf0-aeb1-4ae1cf078f35" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2207466-ceda-4b50-b18d-0ac4f4102caa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b1135f91-5251-4164-b48d-b98fae48a839", "7c2dd9b7-d5f0-4657-b7ae-f59f1d562dd4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba89dc5f-dfd1-4c87-9372-233c611cc756",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "129ebfd9-6e44-4b31-bb78-e900b33de525", "609eb8d4-9ec8-4148-8aa3-b25f2abec2e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C4EAACBE-A5C5-47E8-8DED-508709D7A50F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2b8b9efe-0793-44e4-a019-6d898c6b6dbd", "6e544a04-2c99-47d5-aeec-44471c1fcf56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b016f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9d2c0713-517f-47c3-b8c4-83626a3b1405", "d14ac469-1e92-4772-a2dc-ffa528333e9a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d466ef00-61f1-4e77-801a-b516f0f12323",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "61eab3ea-570d-4abc-85ca-a1eec66265bb", "aa2a72b4-4e6f-4d06-b36e-dd3071b3d3a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "FB8EC84D-3A8F-4FC6-B21E-7141B48A164D",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8fe0b46f-4a4d-4d8b-b672-8c938785e983", "93799947-29d6-4c81-8a43-d70466e55db2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicenceKeys");

            migrationBuilder.DropTable(
                name: "MyClients");

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
    }
}
