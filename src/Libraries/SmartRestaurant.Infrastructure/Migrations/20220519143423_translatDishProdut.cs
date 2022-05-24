using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class translatDishProdut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Names_AR",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_EN",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_FR",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_RU",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_TR",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_AR",
                table: "Dishes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_EN",
                table: "Dishes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_FR",
                table: "Dishes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_RU",
                table: "Dishes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_TR",
                table: "Dishes",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(9329));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(8964));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(9299));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(9315));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(9319));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(9324));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(9340));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(993), new DateTime(2022, 5, 19, 20, 34, 22, 682, DateTimeKind.Local).AddTicks(99) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 20, 34, 22, 683, DateTimeKind.Local).AddTicks(1494), new DateTime(2022, 5, 19, 23, 34, 22, 683, DateTimeKind.Local).AddTicks(1465) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 4, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1535), new DateTime(2022, 5, 20, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1513) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 3, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1611), new DateTime(2027, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1541) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 16, 10, 22, 683, DateTimeKind.Local).AddTicks(1621), new DateTime(2037, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1617) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 18, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1638), new DateTime(2022, 5, 19, 12, 34, 22, 683, DateTimeKind.Local).AddTicks(1636) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1644), new DateTime(2022, 5, 7, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1642) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1650), new DateTime(2022, 3, 27, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1649) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1659), new DateTime(2022, 10, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1655) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1666), new DateTime(2022, 5, 19, 19, 34, 22, 683, DateTimeKind.Local).AddTicks(1664) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 20, 34, 22, 683, DateTimeKind.Local).AddTicks(1672), new DateTime(2022, 5, 19, 22, 34, 22, 683, DateTimeKind.Local).AddTicks(1670) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 5, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1677), new DateTime(2022, 5, 21, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1676) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 9, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1684), new DateTime(2026, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1683) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 16, 10, 22, 683, DateTimeKind.Local).AddTicks(1690), new DateTime(2037, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1689) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 17, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1739), new DateTime(2022, 5, 19, 11, 34, 22, 683, DateTimeKind.Local).AddTicks(1737) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1745), new DateTime(2022, 5, 6, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1744) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1751), new DateTime(2022, 3, 30, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1749) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1756), new DateTime(2022, 9, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1755) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1762), new DateTime(2022, 5, 19, 18, 34, 22, 683, DateTimeKind.Local).AddTicks(1760) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 19, 34, 22, 683, DateTimeKind.Local).AddTicks(1767), new DateTime(2022, 5, 19, 21, 34, 22, 683, DateTimeKind.Local).AddTicks(1765) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 5, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1773), new DateTime(2022, 5, 20, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1771) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 13, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1781), new DateTime(2025, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1777) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 15, 49, 22, 683, DateTimeKind.Local).AddTicks(1787), new DateTime(2035, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1786) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 16, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1793), new DateTime(2022, 5, 19, 12, 34, 22, 683, DateTimeKind.Local).AddTicks(1792) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1798), new DateTime(2022, 5, 9, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1797) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1804), new DateTime(2022, 4, 6, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1803) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1811), new DateTime(2022, 8, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1810) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1816), new DateTime(2022, 5, 19, 16, 34, 22, 683, DateTimeKind.Local).AddTicks(1815) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 17, 34, 22, 683, DateTimeKind.Local).AddTicks(1822), new DateTime(2022, 5, 19, 19, 34, 22, 683, DateTimeKind.Local).AddTicks(1821) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 5, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1828), new DateTime(2022, 5, 24, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1826) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 8, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1835), new DateTime(2024, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1832) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 16, 17, 22, 683, DateTimeKind.Local).AddTicks(1843), new DateTime(2032, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1841) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 14, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1848), new DateTime(2022, 5, 19, 3, 34, 22, 683, DateTimeKind.Local).AddTicks(1846) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1854), new DateTime(2022, 5, 12, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1851) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1861), new DateTime(2022, 7, 1, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1859) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1866), new DateTime(2022, 8, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(1865) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(7434));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(7812));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(7841));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(5472));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(5880));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(5905));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(5911));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(5915));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 15, 34, 22, 683, DateTimeKind.Local).AddTicks(5921));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Names_AR",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Names_EN",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Names_FR",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Names_RU",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Names_TR",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Names_AR",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Names_EN",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Names_FR",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Names_RU",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Names_TR",
                table: "Dishes");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(9336));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(9341));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(9306));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(9329));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(9333));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1070), new DateTime(2022, 5, 19, 19, 43, 2, 775, DateTimeKind.Local).AddTicks(1660) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 19, 43, 2, 776, DateTimeKind.Local).AddTicks(1530), new DateTime(2022, 5, 19, 22, 43, 2, 776, DateTimeKind.Local).AddTicks(1506) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 4, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1571), new DateTime(2022, 5, 20, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1545) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 3, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1638), new DateTime(2027, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1577) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 15, 19, 2, 776, DateTimeKind.Local).AddTicks(1649), new DateTime(2037, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1645) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 18, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1667), new DateTime(2022, 5, 19, 11, 43, 2, 776, DateTimeKind.Local).AddTicks(1665) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1673), new DateTime(2022, 5, 7, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1672) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1678), new DateTime(2022, 3, 27, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1677) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1684), new DateTime(2022, 10, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1682) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1690), new DateTime(2022, 5, 19, 18, 43, 2, 776, DateTimeKind.Local).AddTicks(1689) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 19, 43, 2, 776, DateTimeKind.Local).AddTicks(1695), new DateTime(2022, 5, 19, 21, 43, 2, 776, DateTimeKind.Local).AddTicks(1694) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 5, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1701), new DateTime(2022, 5, 21, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 9, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1707), new DateTime(2026, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1705) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 15, 19, 2, 776, DateTimeKind.Local).AddTicks(1713), new DateTime(2037, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1711) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 17, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1852), new DateTime(2022, 5, 19, 10, 43, 2, 776, DateTimeKind.Local).AddTicks(1848) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1857), new DateTime(2022, 5, 6, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1856) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1862), new DateTime(2022, 3, 30, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1861) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1994), new DateTime(2022, 9, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1992) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(1999), new DateTime(2022, 5, 19, 17, 43, 2, 776, DateTimeKind.Local).AddTicks(1998) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 18, 43, 2, 776, DateTimeKind.Local).AddTicks(2005), new DateTime(2022, 5, 19, 20, 43, 2, 776, DateTimeKind.Local).AddTicks(2003) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 5, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2011), new DateTime(2022, 5, 20, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2008) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 13, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2018), new DateTime(2025, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2016) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 14, 58, 2, 776, DateTimeKind.Local).AddTicks(2030), new DateTime(2035, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2028) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 16, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2035), new DateTime(2022, 5, 19, 11, 43, 2, 776, DateTimeKind.Local).AddTicks(2033) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2040), new DateTime(2022, 5, 9, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2038) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2046), new DateTime(2022, 4, 6, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2045) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2051), new DateTime(2022, 8, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2049) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2056), new DateTime(2022, 5, 19, 15, 43, 2, 776, DateTimeKind.Local).AddTicks(2055) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 16, 43, 2, 776, DateTimeKind.Local).AddTicks(2068), new DateTime(2022, 5, 19, 18, 43, 2, 776, DateTimeKind.Local).AddTicks(2060) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 5, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2072), new DateTime(2022, 5, 24, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2071) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 8, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2082), new DateTime(2024, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2079) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 15, 26, 2, 776, DateTimeKind.Local).AddTicks(2087), new DateTime(2032, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2086) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 14, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2092), new DateTime(2022, 5, 19, 2, 43, 2, 776, DateTimeKind.Local).AddTicks(2091) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2097), new DateTime(2022, 5, 12, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2096) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2102), new DateTime(2022, 7, 1, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2101) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2108), new DateTime(2022, 8, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(2106) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(7576));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(7595));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(7599));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(7602));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(7606));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(7610));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(5033));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(5529));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(5547));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(5553));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(5557));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(5563));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 19, 14, 43, 2, 776, DateTimeKind.Local).AddTicks(5568));
        }
    }
}
