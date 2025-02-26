using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartRestaurant.Infrastructure.Identity.Migrations
{
    public partial class AddPermissionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Gds = table.Column<bool>(nullable: false),
                    Stocks = table.Column<bool>(nullable: false),
                    StockAlerte = table.Column<bool>(nullable: false),
                    Unites = table.Column<bool>(nullable: false),
                    Familles = table.Column<bool>(nullable: false),
                    Marques = table.Column<bool>(nullable: false),
                    Inventaires = table.Column<bool>(nullable: false),
                    Gdv = table.Column<bool>(nullable: false),
                    Vc = table.Column<bool>(nullable: false),
                    Bl = table.Column<bool>(nullable: false),
                    Fac = table.Column<bool>(nullable: false),
                    Facpro = table.Column<bool>(nullable: false),
                    Bcv = table.Column<bool>(nullable: false),
                    RegClients = table.Column<bool>(nullable: false),
                    FacAvoir = table.Column<bool>(nullable: false),
                    RetoursProdClient = table.Column<bool>(nullable: false),
                    CreancesAss = table.Column<bool>(nullable: false),
                    Gda = table.Column<bool>(nullable: false),
                    Ba = table.Column<bool>(nullable: false),
                    Bca = table.Column<bool>(nullable: false),
                    RegFour = table.Column<bool>(nullable: false),
                    RetoursProdFour = table.Column<bool>(nullable: false),
                    Gde = table.Column<bool>(nullable: false),
                    Clients = table.Column<bool>(nullable: false),
                    Fournisseurs = table.Column<bool>(nullable: false),
                    Inviter = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

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
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1ebd32c3-b622-407a-b824-78a94144ab60", "e254dbcb-9baf-42cd-aed9-4e7afc7d8427" });

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
    }
}
