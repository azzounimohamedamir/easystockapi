using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateSeedData_07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 7, 28, 14, 54, 9, 986, DateTimeKind.Local).AddTicks(3059), "BigMama Dessert Menu" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 7, 28, 14, 54, 9, 986, DateTimeKind.Local).AddTicks(3049), "BigMama Beverage  Menu" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 986, DateTimeKind.Local).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 986, DateTimeKind.Local).AddTicks(3018));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 986, DateTimeKind.Local).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 986, DateTimeKind.Local).AddTicks(2229));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 986, DateTimeKind.Local).AddTicks(2928));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 986, DateTimeKind.Local).AddTicks(2974));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 986, DateTimeKind.Local).AddTicks(2988));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 986, DateTimeKind.Local).AddTicks(2998));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 7, 28, 14, 54, 9, 986, DateTimeKind.Local).AddTicks(3038), "BigMama Sandwiches Menu" });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(669), new DateTime(2021, 7, 28, 19, 54, 9, 980, DateTimeKind.Local).AddTicks(8961) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 19, 54, 9, 985, DateTimeKind.Local).AddTicks(1612), new DateTime(2021, 7, 28, 22, 54, 9, 985, DateTimeKind.Local).AddTicks(1561) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 13, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1692), new DateTime(2021, 7, 29, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1643) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 12, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1777), new DateTime(2026, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1709) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 15, 30, 9, 985, DateTimeKind.Local).AddTicks(1805), new DateTime(2036, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1794) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1846), new DateTime(2021, 7, 28, 11, 54, 9, 985, DateTimeKind.Local).AddTicks(1838) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1863), new DateTime(2021, 7, 16, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1857) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1881), new DateTime(2021, 6, 5, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1876) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1899), new DateTime(2021, 12, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1893) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1916), new DateTime(2021, 7, 28, 18, 54, 9, 985, DateTimeKind.Local).AddTicks(1911) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 19, 54, 9, 985, DateTimeKind.Local).AddTicks(1931), new DateTime(2021, 7, 28, 21, 54, 9, 985, DateTimeKind.Local).AddTicks(1926) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1947), new DateTime(2021, 7, 30, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1942) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 17, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1964), new DateTime(2025, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1958) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 15, 30, 9, 985, DateTimeKind.Local).AddTicks(1981), new DateTime(2036, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1974) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 26, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(1996), new DateTime(2021, 7, 28, 10, 54, 9, 985, DateTimeKind.Local).AddTicks(1991) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2012), new DateTime(2021, 7, 15, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2007) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 4, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2028), new DateTime(2021, 6, 8, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2023) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2046), new DateTime(2021, 11, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2040) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2063), new DateTime(2021, 7, 28, 17, 54, 9, 985, DateTimeKind.Local).AddTicks(2057) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 18, 54, 9, 985, DateTimeKind.Local).AddTicks(2077), new DateTime(2021, 7, 28, 20, 54, 9, 985, DateTimeKind.Local).AddTicks(2072) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2093), new DateTime(2021, 7, 29, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2088) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 21, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2110), new DateTime(2024, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2104) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 15, 9, 9, 985, DateTimeKind.Local).AddTicks(2126), new DateTime(2034, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2120) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 25, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2142), new DateTime(2021, 7, 28, 11, 54, 9, 985, DateTimeKind.Local).AddTicks(2136) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2157), new DateTime(2021, 7, 18, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2152) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2174), new DateTime(2021, 6, 15, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2169) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2191), new DateTime(2021, 10, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2185) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2209), new DateTime(2021, 7, 28, 15, 54, 9, 985, DateTimeKind.Local).AddTicks(2203) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 16, 54, 9, 985, DateTimeKind.Local).AddTicks(2224), new DateTime(2021, 7, 28, 18, 54, 9, 985, DateTimeKind.Local).AddTicks(2219) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2239), new DateTime(2021, 8, 2, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2234) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 17, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2255), new DateTime(2023, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2249) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 15, 37, 9, 985, DateTimeKind.Local).AddTicks(2271), new DateTime(2031, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2265) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 23, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2286), new DateTime(2021, 7, 28, 2, 54, 9, 985, DateTimeKind.Local).AddTicks(2280) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2301), new DateTime(2021, 7, 21, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2296) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2317), new DateTime(2021, 9, 9, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2311) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2333), new DateTime(2021, 10, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(2327) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(9870));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(9973));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(9998));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 986, DateTimeKind.Local).AddTicks(8));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 986, DateTimeKind.Local).AddTicks(22));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(5451));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(6290));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(6315));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 14, 54, 9, 985, DateTimeKind.Local).AddTicks(6337));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(2109), "Mcdonald Dessert Menu" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(2098), "Mcdonald Beverage  Menu" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(2077));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(2018));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(2046));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(2088), "Mcdonald Sandwiches Menu" });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 19, 40, 651, DateTimeKind.Local).AddTicks(9910), new DateTime(2021, 7, 28, 6, 19, 40, 647, DateTimeKind.Local).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 6, 19, 40, 652, DateTimeKind.Local).AddTicks(822), new DateTime(2021, 7, 28, 9, 19, 40, 652, DateTimeKind.Local).AddTicks(774) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 13, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(892), new DateTime(2021, 7, 29, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(851) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 12, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(973), new DateTime(2026, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(908) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 55, 40, 652, DateTimeKind.Local).AddTicks(1003), new DateTime(2036, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(991) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1043), new DateTime(2021, 7, 27, 22, 19, 40, 652, DateTimeKind.Local).AddTicks(1035) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1064), new DateTime(2021, 7, 16, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1058) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1081), new DateTime(2021, 6, 5, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1076) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1099), new DateTime(2021, 12, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1093) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1115), new DateTime(2021, 7, 28, 5, 19, 40, 652, DateTimeKind.Local).AddTicks(1110) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 6, 19, 40, 652, DateTimeKind.Local).AddTicks(1133), new DateTime(2021, 7, 28, 8, 19, 40, 652, DateTimeKind.Local).AddTicks(1127) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1149), new DateTime(2021, 7, 30, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1144) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 17, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1168), new DateTime(2025, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1163) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 55, 40, 652, DateTimeKind.Local).AddTicks(1185), new DateTime(2036, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1179) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 26, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1202), new DateTime(2021, 7, 27, 21, 19, 40, 652, DateTimeKind.Local).AddTicks(1197) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1217), new DateTime(2021, 7, 15, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1212) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 4, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1233), new DateTime(2021, 6, 8, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1228) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1250), new DateTime(2021, 11, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1244) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1265), new DateTime(2021, 7, 28, 4, 19, 40, 652, DateTimeKind.Local).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 5, 19, 40, 652, DateTimeKind.Local).AddTicks(1281), new DateTime(2021, 7, 28, 7, 19, 40, 652, DateTimeKind.Local).AddTicks(1275) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1298), new DateTime(2021, 7, 29, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1293) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 21, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1315), new DateTime(2024, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1308) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 34, 40, 652, DateTimeKind.Local).AddTicks(1330), new DateTime(2034, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1325) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 25, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1346), new DateTime(2021, 7, 27, 22, 19, 40, 652, DateTimeKind.Local).AddTicks(1341) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1362), new DateTime(2021, 7, 18, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1357) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1378), new DateTime(2021, 6, 15, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1372) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1395), new DateTime(2021, 10, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1389) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1410), new DateTime(2021, 7, 28, 2, 19, 40, 652, DateTimeKind.Local).AddTicks(1405) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 3, 19, 40, 652, DateTimeKind.Local).AddTicks(1425), new DateTime(2021, 7, 28, 5, 19, 40, 652, DateTimeKind.Local).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1444), new DateTime(2021, 8, 2, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1437) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 17, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1461), new DateTime(2023, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1455) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 2, 2, 40, 652, DateTimeKind.Local).AddTicks(1477), new DateTime(2031, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1471) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 23, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1492), new DateTime(2021, 7, 27, 13, 19, 40, 652, DateTimeKind.Local).AddTicks(1487) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1508), new DateTime(2021, 7, 21, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1502) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1523), new DateTime(2021, 9, 9, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1518) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1539), new DateTime(2021, 10, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1533) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(8915));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(8985));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(8999));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(9009));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(9019));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(9028));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(5099));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(5161));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(5172));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(5185));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(5197));
        }
    }
}
