using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class addedfileentreprisetohotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("06c996cf-949b-49bf-849f-bf4f7f466132"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("461b8d1f-bc06-489d-b6dc-2a2ecda89474"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("abc43ab1-3c8c-483f-9687-9374c20c49de"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Hotels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                table: "Hotels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NIF",
                table: "Hotels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NIS",
                table: "Hotels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NRC",
                table: "Hotels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_StreetAddress",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_GeoPosition_Latitude",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_GeoPosition_Longitude",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber_CountryCode",
                table: "Hotels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber_Number",
                table: "Hotels",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Email", "FoodBusinessAdministratorId", "ImagUrl", "LastModifiedAt", "LastModifiedBy", "NIF", "NIS", "NRC", "Name", "Picture", "Website" },
                values: new object[,]
                {
                    { new Guid("44bf3570-0d44-4673-8746-29b7cf568088"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "3cbf3570-4444-4444-8746-29b7cf568093", "assets/hotels/aurassi.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, 0, "Aurassi", null, null },
                    { new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "3cbf3570-4444-4444-8746-29b7cf568093", "assets/hotels/sofitel.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, 0, "Sofitel", null, null },
                    { new Guid("08a1a626-7f8e-4b51-84fc-fc51b6302cca"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "3cbf3570-4444-4444-8746-29b7cf568093", "assets/hotels/tulip.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, 0, "Tulip", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(2143));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(2102));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(2115));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(648));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(1982));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(2042));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(2060));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(2074));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(2130));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(2850), new DateTime(2022, 10, 4, 19, 46, 4, 724, DateTimeKind.Local).AddTicks(1701) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 19, 46, 4, 729, DateTimeKind.Local).AddTicks(4660), new DateTime(2022, 10, 4, 22, 46, 4, 729, DateTimeKind.Local).AddTicks(4545) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 19, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(4797), new DateTime(2022, 10, 5, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(4715) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 19, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5039), new DateTime(2027, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(4824) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 15, 22, 4, 729, DateTimeKind.Local).AddTicks(5091), new DateTime(2037, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5072) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 3, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5161), new DateTime(2022, 10, 4, 11, 46, 4, 729, DateTimeKind.Local).AddTicks(5153) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5182), new DateTime(2022, 9, 22, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5178) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5205), new DateTime(2022, 8, 12, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5201) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 2, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5228), new DateTime(2023, 3, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5223) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5249), new DateTime(2022, 10, 4, 18, 46, 4, 729, DateTimeKind.Local).AddTicks(5245) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 19, 46, 4, 729, DateTimeKind.Local).AddTicks(5267), new DateTime(2022, 10, 4, 21, 46, 4, 729, DateTimeKind.Local).AddTicks(5262) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 20, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5284), new DateTime(2022, 10, 6, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5280) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 24, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5305), new DateTime(2026, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5298) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 15, 22, 4, 729, DateTimeKind.Local).AddTicks(5327), new DateTime(2037, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5321) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 2, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5345), new DateTime(2022, 10, 4, 10, 46, 4, 729, DateTimeKind.Local).AddTicks(5341) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5370), new DateTime(2022, 9, 21, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5365) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5391), new DateTime(2022, 8, 15, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5387) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 1, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5412), new DateTime(2023, 2, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5406) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5433), new DateTime(2022, 10, 4, 17, 46, 4, 729, DateTimeKind.Local).AddTicks(5427) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 18, 46, 4, 729, DateTimeKind.Local).AddTicks(5451), new DateTime(2022, 10, 4, 20, 46, 4, 729, DateTimeKind.Local).AddTicks(5446) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 20, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5471), new DateTime(2022, 10, 5, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5467) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 28, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5490), new DateTime(2025, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5485) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 15, 1, 4, 729, DateTimeKind.Local).AddTicks(5509), new DateTime(2035, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5504) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 1, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5528), new DateTime(2022, 10, 4, 11, 46, 4, 729, DateTimeKind.Local).AddTicks(5524) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5547), new DateTime(2022, 9, 24, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5543) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5569), new DateTime(2022, 8, 22, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5562) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5587), new DateTime(2023, 1, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5582) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5606), new DateTime(2022, 10, 4, 15, 46, 4, 729, DateTimeKind.Local).AddTicks(5601) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 16, 46, 4, 729, DateTimeKind.Local).AddTicks(5623), new DateTime(2022, 10, 4, 18, 46, 4, 729, DateTimeKind.Local).AddTicks(5619) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 20, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5641), new DateTime(2022, 10, 9, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5637) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 24, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5664), new DateTime(2024, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5657) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 15, 29, 4, 729, DateTimeKind.Local).AddTicks(5684), new DateTime(2032, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5678) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 29, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5704), new DateTime(2022, 10, 4, 2, 46, 4, 729, DateTimeKind.Local).AddTicks(5699) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5722), new DateTime(2022, 9, 27, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5718) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5743), new DateTime(2022, 11, 16, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5738) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5763), new DateTime(2023, 1, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5757) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 731, DateTimeKind.Local).AddTicks(4674));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 731, DateTimeKind.Local).AddTicks(6038));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 731, DateTimeKind.Local).AddTicks(6104));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 731, DateTimeKind.Local).AddTicks(6119));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 731, DateTimeKind.Local).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 731, DateTimeKind.Local).AddTicks(6148));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 731, DateTimeKind.Local).AddTicks(6164));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 730, DateTimeKind.Local).AddTicks(6122));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 730, DateTimeKind.Local).AddTicks(7630));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 730, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 730, DateTimeKind.Local).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 730, DateTimeKind.Local).AddTicks(7817));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 730, DateTimeKind.Local).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 730, DateTimeKind.Local).AddTicks(7850));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("08a1a626-7f8e-4b51-84fc-fc51b6302cca"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("3cbf3570-4444-4673-8746-29b7cf568093"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("44bf3570-0d44-4673-8746-29b7cf568088"));

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "NIF",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "NIS",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "NRC",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Address_StreetAddress",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Address_GeoPosition_Latitude",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Address_GeoPosition_Longitude",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "PhoneNumber_CountryCode",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "PhoneNumber_Number",
                table: "Hotels");

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "FoodBusinessAdministratorId", "ImagUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("461b8d1f-bc06-489d-b6dc-2a2ecda89474"), "3cbf3570-4444-4444-8746-29b7cf568093", "assets/hotels/aurassi.jpg", "Aurassi" },
                    { new Guid("abc43ab1-3c8c-483f-9687-9374c20c49de"), "3cbf3570-4444-4444-8746-29b7cf568093", "assets/hotels/sofitel.jpg", "Sofitel" },
                    { new Guid("06c996cf-949b-49bf-849f-bf4f7f466132"), "3cbf3570-4444-4444-8746-29b7cf568093", "assets/hotels/tulip.jpg", "Tulip" }
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(4117));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(4074));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(2553));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(3936));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(4014));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(4030));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(4088));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(6705), new DateTime(2022, 9, 28, 14, 25, 2, 16, DateTimeKind.Local).AddTicks(5496) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 14, 25, 2, 20, DateTimeKind.Local).AddTicks(8463), new DateTime(2022, 9, 28, 17, 25, 2, 20, DateTimeKind.Local).AddTicks(8354) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 13, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8598), new DateTime(2022, 9, 29, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8516) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 13, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8821), new DateTime(2027, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8618) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 10, 1, 2, 20, DateTimeKind.Local).AddTicks(8861), new DateTime(2037, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8844) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8927), new DateTime(2022, 9, 28, 6, 25, 2, 20, DateTimeKind.Local).AddTicks(8920) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8945), new DateTime(2022, 9, 16, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8941) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8967), new DateTime(2022, 8, 6, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8963) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 1, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8988), new DateTime(2023, 2, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8982) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9007), new DateTime(2022, 9, 28, 13, 25, 2, 20, DateTimeKind.Local).AddTicks(9002) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 14, 25, 2, 20, DateTimeKind.Local).AddTicks(9025), new DateTime(2022, 9, 28, 16, 25, 2, 20, DateTimeKind.Local).AddTicks(9021) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 14, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9044), new DateTime(2022, 9, 30, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9039) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 18, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9064), new DateTime(2026, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9058) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 10, 1, 2, 20, DateTimeKind.Local).AddTicks(9083), new DateTime(2037, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9078) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 26, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9105), new DateTime(2022, 9, 28, 5, 25, 2, 20, DateTimeKind.Local).AddTicks(9100) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9124), new DateTime(2022, 9, 15, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9119) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9143), new DateTime(2022, 8, 9, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9139) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9163), new DateTime(2023, 1, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9157) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9182), new DateTime(2022, 9, 28, 12, 25, 2, 20, DateTimeKind.Local).AddTicks(9177) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 13, 25, 2, 20, DateTimeKind.Local).AddTicks(9446), new DateTime(2022, 9, 28, 15, 25, 2, 20, DateTimeKind.Local).AddTicks(9437) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 14, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9464), new DateTime(2022, 9, 29, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9459) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 22, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9484), new DateTime(2025, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9477) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 9, 40, 2, 20, DateTimeKind.Local).AddTicks(9503), new DateTime(2035, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9498) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 25, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9523), new DateTime(2022, 9, 28, 6, 25, 2, 20, DateTimeKind.Local).AddTicks(9518) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9541), new DateTime(2022, 9, 18, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9536) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9559), new DateTime(2022, 8, 16, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9555) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9581), new DateTime(2022, 12, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9576) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9602), new DateTime(2022, 9, 28, 10, 25, 2, 20, DateTimeKind.Local).AddTicks(9597) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 11, 25, 2, 20, DateTimeKind.Local).AddTicks(9620), new DateTime(2022, 9, 28, 13, 25, 2, 20, DateTimeKind.Local).AddTicks(9616) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 14, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9639), new DateTime(2022, 10, 3, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9634) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 18, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9661), new DateTime(2024, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9653) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 10, 8, 2, 20, DateTimeKind.Local).AddTicks(9683), new DateTime(2032, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9676) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 23, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9701), new DateTime(2022, 9, 27, 21, 25, 2, 20, DateTimeKind.Local).AddTicks(9696) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9721), new DateTime(2022, 9, 21, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9716) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9743), new DateTime(2022, 11, 10, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9737) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9763), new DateTime(2022, 12, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9758) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(8025));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(8086));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(8114));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 21, DateTimeKind.Local).AddTicks(8815));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(381));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(449));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(469));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(486));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(502));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(517));
        }
    }
}
