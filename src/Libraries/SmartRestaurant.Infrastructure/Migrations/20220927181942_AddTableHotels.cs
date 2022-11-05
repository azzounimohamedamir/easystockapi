using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddTableHotels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ImagUrl = table.Column<string>(nullable: true),
                    FoodBusinessAdministratorId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "FoodBusinessAdministratorId", "ImagUrl", "Name" },
                values: new object[] { new Guid("88bc7853-220f-9173-3246-afb7cf595022"), "amir", "assets/hotels/aurassi.jpg", "Aurassi" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2537));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2496));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2517));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2415));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2528));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 19, 19, 38, 981, DateTimeKind.Local).AddTicks(7765), new DateTime(2022, 9, 28, 0, 19, 38, 977, DateTimeKind.Local).AddTicks(5920) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 0, 19, 38, 982, DateTimeKind.Local).AddTicks(951), new DateTime(2022, 9, 28, 3, 19, 38, 982, DateTimeKind.Local).AddTicks(828) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 12, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1107), new DateTime(2022, 9, 28, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1017) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 12, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1406), new DateTime(2027, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1137) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 19, 55, 38, 982, DateTimeKind.Local).AddTicks(1465), new DateTime(2037, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1441) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 26, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1553), new DateTime(2022, 9, 27, 16, 19, 38, 982, DateTimeKind.Local).AddTicks(1544) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1581), new DateTime(2022, 9, 15, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1575) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1614), new DateTime(2022, 8, 5, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1607) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 1, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1645), new DateTime(2023, 2, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1637) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1675), new DateTime(2022, 9, 27, 23, 19, 38, 982, DateTimeKind.Local).AddTicks(1669) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 0, 19, 38, 982, DateTimeKind.Local).AddTicks(1705), new DateTime(2022, 9, 28, 2, 19, 38, 982, DateTimeKind.Local).AddTicks(1699) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 13, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1734), new DateTime(2022, 9, 29, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1728) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 17, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1767), new DateTime(2026, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1758) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 19, 55, 38, 982, DateTimeKind.Local).AddTicks(2012), new DateTime(2037, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2000) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 25, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2041), new DateTime(2022, 9, 27, 15, 19, 38, 982, DateTimeKind.Local).AddTicks(2035) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2071), new DateTime(2022, 9, 14, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2064) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2101), new DateTime(2022, 8, 8, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2095) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2133), new DateTime(2023, 1, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2125) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2163), new DateTime(2022, 9, 27, 22, 19, 38, 982, DateTimeKind.Local).AddTicks(2157) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 23, 19, 38, 982, DateTimeKind.Local).AddTicks(2190), new DateTime(2022, 9, 28, 1, 19, 38, 982, DateTimeKind.Local).AddTicks(2184) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 13, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2220), new DateTime(2022, 9, 28, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2214) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 21, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2250), new DateTime(2025, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2242) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 19, 34, 38, 982, DateTimeKind.Local).AddTicks(2282), new DateTime(2035, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2273) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 24, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2310), new DateTime(2022, 9, 27, 16, 19, 38, 982, DateTimeKind.Local).AddTicks(2304) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2339), new DateTime(2022, 9, 17, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2333) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2368), new DateTime(2022, 8, 15, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2362) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2399), new DateTime(2022, 12, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2391) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2429), new DateTime(2022, 9, 27, 20, 19, 38, 982, DateTimeKind.Local).AddTicks(2423) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 21, 19, 38, 982, DateTimeKind.Local).AddTicks(2457), new DateTime(2022, 9, 27, 23, 19, 38, 982, DateTimeKind.Local).AddTicks(2449) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 13, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2484), new DateTime(2022, 10, 2, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2478) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 17, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2514), new DateTime(2024, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2504) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 20, 2, 38, 982, DateTimeKind.Local).AddTicks(2544), new DateTime(2032, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2535) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 22, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2571), new DateTime(2022, 9, 27, 7, 19, 38, 982, DateTimeKind.Local).AddTicks(2565) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2597), new DateTime(2022, 9, 20, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2591) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2625), new DateTime(2022, 11, 9, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2619) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2652), new DateTime(2022, 12, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2644) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(6828));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(7997));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(8011));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(8021));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(2362));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(2441));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(2453));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(2465));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(8686));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(8678));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(8638));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(8654));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(8663));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(8682));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(1437), new DateTime(2022, 6, 30, 15, 46, 40, 838, DateTimeKind.Local).AddTicks(869) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 15, 46, 40, 839, DateTimeKind.Local).AddTicks(1971), new DateTime(2022, 6, 30, 18, 46, 40, 839, DateTimeKind.Local).AddTicks(1949) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 15, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2001), new DateTime(2022, 7, 1, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(1984) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2068), new DateTime(2027, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2007) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 11, 22, 40, 839, DateTimeKind.Local).AddTicks(2077), new DateTime(2037, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2073) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 29, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2093), new DateTime(2022, 6, 30, 7, 46, 40, 839, DateTimeKind.Local).AddTicks(2091) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2098), new DateTime(2022, 6, 18, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2096) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2103), new DateTime(2022, 5, 8, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2102) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2108), new DateTime(2022, 11, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2107) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2113), new DateTime(2022, 6, 30, 14, 46, 40, 839, DateTimeKind.Local).AddTicks(2112) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 15, 46, 40, 839, DateTimeKind.Local).AddTicks(2118), new DateTime(2022, 6, 30, 17, 46, 40, 839, DateTimeKind.Local).AddTicks(2117) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 16, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2123), new DateTime(2022, 7, 2, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2122) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 20, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2129), new DateTime(2026, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2128) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 11, 22, 40, 839, DateTimeKind.Local).AddTicks(2134), new DateTime(2037, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2133) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 28, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2142), new DateTime(2022, 6, 30, 6, 46, 40, 839, DateTimeKind.Local).AddTicks(2140) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2147), new DateTime(2022, 6, 17, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2146) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2152), new DateTime(2022, 5, 11, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2150) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2157), new DateTime(2022, 10, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2156) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2162), new DateTime(2022, 6, 30, 13, 46, 40, 839, DateTimeKind.Local).AddTicks(2161) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 14, 46, 40, 839, DateTimeKind.Local).AddTicks(2167), new DateTime(2022, 6, 30, 16, 46, 40, 839, DateTimeKind.Local).AddTicks(2166) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 16, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2172), new DateTime(2022, 7, 1, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2171) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 24, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2177), new DateTime(2025, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2176) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 11, 1, 40, 839, DateTimeKind.Local).AddTicks(2182), new DateTime(2035, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2181) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 27, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2187), new DateTime(2022, 6, 30, 7, 46, 40, 839, DateTimeKind.Local).AddTicks(2186) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2193), new DateTime(2022, 6, 20, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2192) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2198), new DateTime(2022, 5, 18, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2197) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2204), new DateTime(2022, 9, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2202) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2209), new DateTime(2022, 6, 30, 11, 46, 40, 839, DateTimeKind.Local).AddTicks(2207) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 12, 46, 40, 839, DateTimeKind.Local).AddTicks(2213), new DateTime(2022, 6, 30, 14, 46, 40, 839, DateTimeKind.Local).AddTicks(2212) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 16, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2218), new DateTime(2022, 7, 5, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2217) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 20, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2224), new DateTime(2024, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2221) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 11, 29, 40, 839, DateTimeKind.Local).AddTicks(2229), new DateTime(2032, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2227) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 25, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2234), new DateTime(2022, 6, 29, 22, 46, 40, 839, DateTimeKind.Local).AddTicks(2232) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2238), new DateTime(2022, 6, 23, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2237) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2244), new DateTime(2022, 8, 12, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2242) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2249), new DateTime(2022, 9, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(2248) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(6458));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(6796));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(6800));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(6804));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(6808));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(6813));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(4695));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(5168));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(5184));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(5189));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(5194));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(5198));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 46, 40, 839, DateTimeKind.Local).AddTicks(5203));
        }
    }
}
