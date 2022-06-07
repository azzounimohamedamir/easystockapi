using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class addOrderColumnInSectionAndSubSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "SubSections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Sections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7881));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7877));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7864));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7867));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7870));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7839));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7857));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7874));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(1456), new DateTime(2022, 6, 7, 4, 37, 24, 174, DateTimeKind.Local).AddTicks(2083) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 7, 4, 37, 24, 175, DateTimeKind.Local).AddTicks(1875), new DateTime(2022, 6, 7, 7, 37, 24, 175, DateTimeKind.Local).AddTicks(1855) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 22, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(1907), new DateTime(2022, 6, 7, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(1886) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 21, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(1995), new DateTime(2027, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(1912) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 7, 0, 13, 24, 175, DateTimeKind.Local).AddTicks(2004), new DateTime(2037, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2000) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 5, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2024), new DateTime(2022, 6, 6, 20, 37, 24, 175, DateTimeKind.Local).AddTicks(2023) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2030), new DateTime(2022, 5, 25, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2029) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2037), new DateTime(2022, 4, 14, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2036) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2042), new DateTime(2022, 11, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2041) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2047), new DateTime(2022, 6, 7, 3, 37, 24, 175, DateTimeKind.Local).AddTicks(2046) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 7, 4, 37, 24, 175, DateTimeKind.Local).AddTicks(2051), new DateTime(2022, 6, 7, 6, 37, 24, 175, DateTimeKind.Local).AddTicks(2050) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 23, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2056), new DateTime(2022, 6, 8, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2055) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 27, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2061), new DateTime(2026, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2059) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 7, 0, 13, 24, 175, DateTimeKind.Local).AddTicks(2066), new DateTime(2037, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2064) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 4, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2070), new DateTime(2022, 6, 6, 19, 37, 24, 175, DateTimeKind.Local).AddTicks(2069) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2076), new DateTime(2022, 5, 24, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2075) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2084), new DateTime(2022, 4, 17, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2083) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2089), new DateTime(2022, 10, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2087) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2093), new DateTime(2022, 6, 7, 2, 37, 24, 175, DateTimeKind.Local).AddTicks(2092) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 7, 3, 37, 24, 175, DateTimeKind.Local).AddTicks(2098), new DateTime(2022, 6, 7, 5, 37, 24, 175, DateTimeKind.Local).AddTicks(2097) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 23, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2102), new DateTime(2022, 6, 7, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2101) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 31, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2107), new DateTime(2025, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2105) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 6, 23, 52, 24, 175, DateTimeKind.Local).AddTicks(2111), new DateTime(2035, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2110) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 3, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2116), new DateTime(2022, 6, 6, 20, 37, 24, 175, DateTimeKind.Local).AddTicks(2114) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2120), new DateTime(2022, 5, 27, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2119) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2124), new DateTime(2022, 4, 24, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2123) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2130), new DateTime(2022, 9, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2129) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2135), new DateTime(2022, 6, 7, 0, 37, 24, 175, DateTimeKind.Local).AddTicks(2134) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 7, 1, 37, 24, 175, DateTimeKind.Local).AddTicks(2139), new DateTime(2022, 6, 7, 3, 37, 24, 175, DateTimeKind.Local).AddTicks(2138) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 23, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2144), new DateTime(2022, 6, 11, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2143) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 26, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2150), new DateTime(2024, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2147) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 7, 0, 20, 24, 175, DateTimeKind.Local).AddTicks(2156), new DateTime(2032, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2154) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 1, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2160), new DateTime(2022, 6, 6, 11, 37, 24, 175, DateTimeKind.Local).AddTicks(2159) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2164), new DateTime(2022, 5, 30, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2163) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2169), new DateTime(2022, 7, 19, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2168) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2175), new DateTime(2022, 9, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2173) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(5837));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(6555));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(6569));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(6573));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(6578));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(6585));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(4221));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(4541));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(4570));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(4574));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Sections");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 981, DateTimeKind.Local).AddTicks(2892));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 981, DateTimeKind.Local).AddTicks(2888));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 981, DateTimeKind.Local).AddTicks(2872));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 981, DateTimeKind.Local).AddTicks(2876));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 981, DateTimeKind.Local).AddTicks(2880));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 981, DateTimeKind.Local).AddTicks(2523));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 981, DateTimeKind.Local).AddTicks(2843));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 981, DateTimeKind.Local).AddTicks(2859));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 981, DateTimeKind.Local).AddTicks(2864));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 981, DateTimeKind.Local).AddTicks(2868));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 981, DateTimeKind.Local).AddTicks(2884));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(5577), new DateTime(2022, 6, 2, 10, 37, 21, 978, DateTimeKind.Local).AddTicks(8758) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 10, 37, 21, 980, DateTimeKind.Local).AddTicks(6056), new DateTime(2022, 6, 2, 13, 37, 21, 980, DateTimeKind.Local).AddTicks(6031) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 18, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6094), new DateTime(2022, 6, 3, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6071) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 17, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6162), new DateTime(2027, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6100) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 6, 13, 21, 980, DateTimeKind.Local).AddTicks(6172), new DateTime(2037, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6167) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 1, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6190), new DateTime(2022, 6, 2, 2, 37, 21, 980, DateTimeKind.Local).AddTicks(6188) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6196), new DateTime(2022, 5, 21, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6195) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6203), new DateTime(2022, 4, 10, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6201) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6209), new DateTime(2022, 11, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6208) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6215), new DateTime(2022, 6, 2, 9, 37, 21, 980, DateTimeKind.Local).AddTicks(6214) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 10, 37, 21, 980, DateTimeKind.Local).AddTicks(6221), new DateTime(2022, 6, 2, 12, 37, 21, 980, DateTimeKind.Local).AddTicks(6219) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6228), new DateTime(2022, 6, 4, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6227) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 23, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6234), new DateTime(2026, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6232) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 6, 13, 21, 980, DateTimeKind.Local).AddTicks(6240), new DateTime(2037, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6238) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 31, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6245), new DateTime(2022, 6, 2, 1, 37, 21, 980, DateTimeKind.Local).AddTicks(6244) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6251), new DateTime(2022, 5, 20, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6249) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6256), new DateTime(2022, 4, 13, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6255) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6262), new DateTime(2022, 10, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6268), new DateTime(2022, 6, 2, 8, 37, 21, 980, DateTimeKind.Local).AddTicks(6266) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 9, 37, 21, 980, DateTimeKind.Local).AddTicks(6273), new DateTime(2022, 6, 2, 11, 37, 21, 980, DateTimeKind.Local).AddTicks(6271) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6278), new DateTime(2022, 6, 3, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6277) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 27, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6283), new DateTime(2025, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6282) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 5, 52, 21, 980, DateTimeKind.Local).AddTicks(6289), new DateTime(2035, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6287) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 30, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6294), new DateTime(2022, 6, 2, 2, 37, 21, 980, DateTimeKind.Local).AddTicks(6293) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6300), new DateTime(2022, 5, 23, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6298) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6306), new DateTime(2022, 4, 20, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6304) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6312), new DateTime(2022, 9, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6318), new DateTime(2022, 6, 2, 6, 37, 21, 980, DateTimeKind.Local).AddTicks(6316) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 7, 37, 21, 980, DateTimeKind.Local).AddTicks(6323), new DateTime(2022, 6, 2, 9, 37, 21, 980, DateTimeKind.Local).AddTicks(6322) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6329), new DateTime(2022, 6, 7, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6327) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 22, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6335), new DateTime(2024, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6333) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 6, 20, 21, 980, DateTimeKind.Local).AddTicks(6342), new DateTime(2032, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6340) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 28, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6348), new DateTime(2022, 6, 1, 17, 37, 21, 980, DateTimeKind.Local).AddTicks(6346) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6353), new DateTime(2022, 5, 26, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6352) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6359), new DateTime(2022, 7, 15, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6358) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6366), new DateTime(2022, 9, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(6364) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 981, DateTimeKind.Local).AddTicks(1052));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 981, DateTimeKind.Local).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 981, DateTimeKind.Local).AddTicks(1428));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 981, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 981, DateTimeKind.Local).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 981, DateTimeKind.Local).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 981, DateTimeKind.Local).AddTicks(1445));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(9028));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(9410));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(9428));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(9435));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(9440));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(9445));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 37, 21, 980, DateTimeKind.Local).AddTicks(9606));
        }
    }
}
