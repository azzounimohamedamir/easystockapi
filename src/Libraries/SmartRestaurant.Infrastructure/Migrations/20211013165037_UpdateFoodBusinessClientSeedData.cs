using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class UpdateFoodBusinessClientSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FoodBusinessClients",
                keyColumn: "FoodBusinessClientId",
                keyValue: new Guid("1eb2b784-074d-4be4-afb7-9708331c0c63"),
                column: "FoodBusinessId",
                value: new Guid("88bc7853-220f-9173-3246-afb7cf595022"));

            migrationBuilder.UpdateData(
                table: "FoodBusinessClients",
                keyColumn: "FoodBusinessClientId",
                keyValue: new Guid("e6f980ba-c381-4319-8b62-da017e116692"),
                column: "FoodBusinessId",
                value: new Guid("3cbf3570-4444-4673-8746-29b7cf568093"));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 948, DateTimeKind.Local).AddTicks(262));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 948, DateTimeKind.Local).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 948, DateTimeKind.Local).AddTicks(130));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 948, DateTimeKind.Local).AddTicks(200));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 948, DateTimeKind.Local).AddTicks(215));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 947, DateTimeKind.Local).AddTicks(9081));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 948, DateTimeKind.Local).AddTicks(49));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 948, DateTimeKind.Local).AddTicks(95));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 948, DateTimeKind.Local).AddTicks(105));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 948, DateTimeKind.Local).AddTicks(115));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 948, DateTimeKind.Local).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(4421), new DateTime(2021, 10, 13, 22, 50, 35, 943, DateTimeKind.Local).AddTicks(7244) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 22, 50, 35, 946, DateTimeKind.Local).AddTicks(5622), new DateTime(2021, 10, 14, 1, 50, 35, 946, DateTimeKind.Local).AddTicks(5524) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(5717), new DateTime(2021, 10, 14, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(5661) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(5871), new DateTime(2026, 10, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(5734) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 18, 26, 35, 946, DateTimeKind.Local).AddTicks(5896), new DateTime(2036, 10, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(5886) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 12, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(5932), new DateTime(2021, 10, 13, 14, 50, 35, 946, DateTimeKind.Local).AddTicks(5928) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(5944), new DateTime(2021, 10, 1, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(5942) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(5962), new DateTime(2021, 8, 21, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(5959) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(5980), new DateTime(2022, 3, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(5975) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(5995), new DateTime(2021, 10, 13, 21, 50, 35, 946, DateTimeKind.Local).AddTicks(5992) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 22, 50, 35, 946, DateTimeKind.Local).AddTicks(6010), new DateTime(2021, 10, 14, 0, 50, 35, 946, DateTimeKind.Local).AddTicks(6007) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 29, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6026), new DateTime(2021, 10, 15, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6023) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 3, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6043), new DateTime(2025, 10, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6039) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 18, 26, 35, 946, DateTimeKind.Local).AddTicks(6062), new DateTime(2036, 10, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6055) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6074), new DateTime(2021, 10, 13, 13, 50, 35, 946, DateTimeKind.Local).AddTicks(6072) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6089), new DateTime(2021, 9, 30, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6085) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6106), new DateTime(2021, 8, 24, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6104) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6122), new DateTime(2022, 2, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6119) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6136), new DateTime(2021, 10, 13, 20, 50, 35, 946, DateTimeKind.Local).AddTicks(6133) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 21, 50, 35, 946, DateTimeKind.Local).AddTicks(6150), new DateTime(2021, 10, 13, 23, 50, 35, 946, DateTimeKind.Local).AddTicks(6147) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 29, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6166), new DateTime(2021, 10, 14, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6161) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 7, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6183), new DateTime(2024, 10, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6179) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 18, 5, 35, 946, DateTimeKind.Local).AddTicks(6197), new DateTime(2034, 10, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6194) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 10, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6211), new DateTime(2021, 10, 13, 14, 50, 35, 946, DateTimeKind.Local).AddTicks(6208) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6225), new DateTime(2021, 10, 3, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6222) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6241), new DateTime(2021, 8, 31, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6238) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6257), new DateTime(2022, 1, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6252) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6270), new DateTime(2021, 10, 13, 18, 50, 35, 946, DateTimeKind.Local).AddTicks(6267) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 19, 50, 35, 946, DateTimeKind.Local).AddTicks(6284), new DateTime(2021, 10, 13, 21, 50, 35, 946, DateTimeKind.Local).AddTicks(6281) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 29, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6298), new DateTime(2021, 10, 18, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6295) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 2, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6318), new DateTime(2023, 10, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6313) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 18, 33, 35, 946, DateTimeKind.Local).AddTicks(6337), new DateTime(2031, 10, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6331) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 8, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6356), new DateTime(2021, 10, 13, 5, 50, 35, 946, DateTimeKind.Local).AddTicks(6348) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6377), new DateTime(2021, 10, 6, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6375) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6391), new DateTime(2021, 11, 25, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6389) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6406), new DateTime(2022, 1, 13, 17, 50, 35, 946, DateTimeKind.Local).AddTicks(6403) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 947, DateTimeKind.Local).AddTicks(5055));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 947, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 947, DateTimeKind.Local).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 947, DateTimeKind.Local).AddTicks(6118));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 947, DateTimeKind.Local).AddTicks(6129));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 947, DateTimeKind.Local).AddTicks(6138));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 947, DateTimeKind.Local).AddTicks(6151));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 947, DateTimeKind.Local).AddTicks(224));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 947, DateTimeKind.Local).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 947, DateTimeKind.Local).AddTicks(1194));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 947, DateTimeKind.Local).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 947, DateTimeKind.Local).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 947, DateTimeKind.Local).AddTicks(1230));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 17, 50, 35, 947, DateTimeKind.Local).AddTicks(1243));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FoodBusinessClients",
                keyColumn: "FoodBusinessClientId",
                keyValue: new Guid("1eb2b784-074d-4be4-afb7-9708331c0c63"),
                column: "FoodBusinessId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "FoodBusinessClients",
                keyColumn: "FoodBusinessClientId",
                keyValue: new Guid("e6f980ba-c381-4319-8b62-da017e116692"),
                column: "FoodBusinessId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6275));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6223));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6233));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6243));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(5423));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6140));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6187));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6202));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6212));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(3263), new DateTime(2021, 10, 11, 9, 54, 4, 318, DateTimeKind.Local).AddTicks(638) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 9, 54, 4, 324, DateTimeKind.Local).AddTicks(4314), new DateTime(2021, 10, 11, 12, 54, 4, 324, DateTimeKind.Local).AddTicks(4248) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 26, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4402), new DateTime(2021, 10, 12, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4351) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 26, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4490), new DateTime(2026, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4424) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 5, 30, 4, 324, DateTimeKind.Local).AddTicks(4525), new DateTime(2036, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4513) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 10, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4569), new DateTime(2021, 10, 11, 1, 54, 4, 324, DateTimeKind.Local).AddTicks(4558) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4589), new DateTime(2021, 9, 29, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4583) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4606), new DateTime(2021, 8, 19, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4601) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4625), new DateTime(2022, 3, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4619) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4645), new DateTime(2021, 10, 11, 8, 54, 4, 324, DateTimeKind.Local).AddTicks(4638) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 9, 54, 4, 324, DateTimeKind.Local).AddTicks(4665), new DateTime(2021, 10, 11, 11, 54, 4, 324, DateTimeKind.Local).AddTicks(4657) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4684), new DateTime(2021, 10, 13, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4677) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4703), new DateTime(2025, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4696) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 5, 30, 4, 324, DateTimeKind.Local).AddTicks(4720), new DateTime(2036, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4713) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 9, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4739), new DateTime(2021, 10, 11, 0, 54, 4, 324, DateTimeKind.Local).AddTicks(4733) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4756), new DateTime(2021, 9, 28, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4750) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4772), new DateTime(2021, 8, 22, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4766) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4788), new DateTime(2022, 2, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4782) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4807), new DateTime(2021, 10, 11, 7, 54, 4, 324, DateTimeKind.Local).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 8, 54, 4, 324, DateTimeKind.Local).AddTicks(4825), new DateTime(2021, 10, 11, 10, 54, 4, 324, DateTimeKind.Local).AddTicks(4818) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4841), new DateTime(2021, 10, 12, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4835) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 5, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4857), new DateTime(2024, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4851) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 5, 9, 4, 324, DateTimeKind.Local).AddTicks(4875), new DateTime(2034, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 8, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4891), new DateTime(2021, 10, 11, 1, 54, 4, 324, DateTimeKind.Local).AddTicks(4886) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5072), new DateTime(2021, 10, 1, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5088), new DateTime(2021, 8, 29, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5083) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5106), new DateTime(2022, 1, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5099) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5124), new DateTime(2021, 10, 11, 5, 54, 4, 324, DateTimeKind.Local).AddTicks(5117) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 6, 54, 4, 324, DateTimeKind.Local).AddTicks(5146), new DateTime(2021, 10, 11, 8, 54, 4, 324, DateTimeKind.Local).AddTicks(5139) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5165), new DateTime(2021, 10, 16, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5159) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 31, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5182), new DateTime(2023, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5175) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 5, 37, 4, 324, DateTimeKind.Local).AddTicks(5199), new DateTime(2031, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5217), new DateTime(2021, 10, 10, 16, 54, 4, 324, DateTimeKind.Local).AddTicks(5212) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5233), new DateTime(2021, 10, 4, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5228) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5250), new DateTime(2021, 11, 23, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5245) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5268), new DateTime(2022, 1, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5262) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(2987));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(3079));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(3089));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(8342));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(9125));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(9178));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(9192));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(9205));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(9228));
        }
    }
}
