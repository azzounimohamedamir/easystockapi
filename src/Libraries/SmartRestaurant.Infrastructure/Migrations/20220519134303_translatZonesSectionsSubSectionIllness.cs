using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class translatZonesSectionsSubSectionIllness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Names_AR",
                table: "Zones",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_EN",
                table: "Zones",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_FR",
                table: "Zones",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_RU",
                table: "Zones",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_TR",
                table: "Zones",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_AR",
                table: "SubSections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_EN",
                table: "SubSections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_FR",
                table: "SubSections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_RU",
                table: "SubSections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_TR",
                table: "SubSections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_AR",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_EN",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_FR",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_RU",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_TR",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_AR",
                table: "Illnesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_EN",
                table: "Illnesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_FR",
                table: "Illnesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_RU",
                table: "Illnesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_TR",
                table: "Illnesses",
                nullable: true);

         
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Names_AR",
                table: "Zones");

            migrationBuilder.DropColumn(
                name: "Names_EN",
                table: "Zones");

            migrationBuilder.DropColumn(
                name: "Names_FR",
                table: "Zones");

            migrationBuilder.DropColumn(
                name: "Names_RU",
                table: "Zones");

            migrationBuilder.DropColumn(
                name: "Names_TR",
                table: "Zones");

            migrationBuilder.DropColumn(
                name: "Names_AR",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "Names_EN",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "Names_FR",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "Names_RU",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "Names_TR",
                table: "SubSections");

            migrationBuilder.DropColumn(
                name: "Names_AR",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Names_EN",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Names_FR",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Names_RU",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Names_TR",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Names_AR",
                table: "Illnesses");

            migrationBuilder.DropColumn(
                name: "Names_EN",
                table: "Illnesses");

            migrationBuilder.DropColumn(
                name: "Names_FR",
                table: "Illnesses");

            migrationBuilder.DropColumn(
                name: "Names_RU",
                table: "Illnesses");

            migrationBuilder.DropColumn(
                name: "Names_TR",
                table: "Illnesses");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 548, DateTimeKind.Local).AddTicks(2702));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 548, DateTimeKind.Local).AddTicks(2675));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 548, DateTimeKind.Local).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 548, DateTimeKind.Local).AddTicks(2653));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 548, DateTimeKind.Local).AddTicks(2662));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 548, DateTimeKind.Local).AddTicks(1782));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 548, DateTimeKind.Local).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 548, DateTimeKind.Local).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 548, DateTimeKind.Local).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 548, DateTimeKind.Local).AddTicks(2500));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 548, DateTimeKind.Local).AddTicks(2669));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 20, 5, 58, 41, 546, DateTimeKind.Local).AddTicks(9487), new DateTime(2022, 1, 20, 10, 58, 41, 545, DateTimeKind.Local).AddTicks(4771) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 20, 10, 58, 41, 547, DateTimeKind.Local).AddTicks(315), new DateTime(2022, 1, 20, 13, 58, 41, 547, DateTimeKind.Local).AddTicks(274) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 5, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(374), new DateTime(2022, 1, 21, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(339) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 4, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(489), new DateTime(2027, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(384) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 20, 6, 34, 41, 547, DateTimeKind.Local).AddTicks(510), new DateTime(2037, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(502) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 19, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(542), new DateTime(2022, 1, 20, 2, 58, 41, 547, DateTimeKind.Local).AddTicks(539) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(654), new DateTime(2022, 1, 8, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(650) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(665), new DateTime(2021, 11, 28, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(663) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(676), new DateTime(2022, 6, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(674) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(687), new DateTime(2022, 1, 20, 9, 58, 41, 547, DateTimeKind.Local).AddTicks(685) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 20, 10, 58, 41, 547, DateTimeKind.Local).AddTicks(697), new DateTime(2022, 1, 20, 12, 58, 41, 547, DateTimeKind.Local).AddTicks(695) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 6, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(707), new DateTime(2022, 1, 22, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(705) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 12, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(717), new DateTime(2026, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(715) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 20, 6, 34, 41, 547, DateTimeKind.Local).AddTicks(729), new DateTime(2037, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(725) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 18, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(739), new DateTime(2022, 1, 20, 1, 58, 41, 547, DateTimeKind.Local).AddTicks(737) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(748), new DateTime(2022, 1, 7, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(746) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(758), new DateTime(2021, 12, 1, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(756) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(769), new DateTime(2022, 5, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(767) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(779), new DateTime(2022, 1, 20, 8, 58, 41, 547, DateTimeKind.Local).AddTicks(777) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 20, 9, 58, 41, 547, DateTimeKind.Local).AddTicks(789), new DateTime(2022, 1, 20, 11, 58, 41, 547, DateTimeKind.Local).AddTicks(787) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 6, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(798), new DateTime(2022, 1, 21, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(796) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 16, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(808), new DateTime(2025, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(805) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 20, 6, 13, 41, 547, DateTimeKind.Local).AddTicks(818), new DateTime(2035, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(815) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 17, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(828), new DateTime(2022, 1, 20, 2, 58, 41, 547, DateTimeKind.Local).AddTicks(826) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(838), new DateTime(2022, 1, 10, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(835) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(848), new DateTime(2021, 12, 8, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(846) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(859), new DateTime(2022, 4, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(856) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(871), new DateTime(2022, 1, 20, 6, 58, 41, 547, DateTimeKind.Local).AddTicks(869) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 20, 7, 58, 41, 547, DateTimeKind.Local).AddTicks(880), new DateTime(2022, 1, 20, 9, 58, 41, 547, DateTimeKind.Local).AddTicks(878) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 6, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(889), new DateTime(2022, 1, 25, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(887) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 9, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(900), new DateTime(2024, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(897) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 20, 6, 41, 41, 547, DateTimeKind.Local).AddTicks(911), new DateTime(2032, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(908) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 15, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(921), new DateTime(2022, 1, 19, 17, 58, 41, 547, DateTimeKind.Local).AddTicks(918) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(931), new DateTime(2022, 1, 13, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(929) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(941), new DateTime(2022, 3, 4, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(939) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(951), new DateTime(2022, 4, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(949) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(8793));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(9526));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(9560));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(9568));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(9575));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(9583));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(5317));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(6096));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(6105));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(6113));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 20, 5, 58, 41, 547, DateTimeKind.Local).AddTicks(6123));
        }
    }
}
