using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateOrderEntity_06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "TotalToPayWithoutCommissionValue",
                table: "Orders",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "CommissionConfigs_Type",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "CommissionConfigs_Value",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommissionConfigs_WhoPay",
                table: "Orders",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalToPayWithoutCommissionValue",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CommissionConfigs_Type",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CommissionConfigs_Value",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CommissionConfigs_WhoPay",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(9109));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(9068));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(9090));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(7888));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(9044));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(4154), new DateTime(2022, 1, 3, 20, 16, 37, 98, DateTimeKind.Local).AddTicks(2000) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 20, 16, 37, 104, DateTimeKind.Local).AddTicks(6005), new DateTime(2022, 1, 3, 23, 16, 37, 104, DateTimeKind.Local).AddTicks(5918) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6135), new DateTime(2022, 1, 4, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6061) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 18, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6292), new DateTime(2027, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6166) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 52, 37, 104, DateTimeKind.Local).AddTicks(6351), new DateTime(2037, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6328) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 2, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6435), new DateTime(2022, 1, 3, 12, 16, 37, 104, DateTimeKind.Local).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6468), new DateTime(2021, 12, 22, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6457) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6503), new DateTime(2021, 11, 11, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6492) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6535), new DateTime(2022, 6, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6522) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6572), new DateTime(2022, 1, 3, 19, 16, 37, 104, DateTimeKind.Local).AddTicks(6560) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 20, 16, 37, 104, DateTimeKind.Local).AddTicks(6600), new DateTime(2022, 1, 3, 22, 16, 37, 104, DateTimeKind.Local).AddTicks(6591) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 20, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6629), new DateTime(2022, 1, 5, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6618) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 23, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6656), new DateTime(2026, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6646) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 52, 37, 104, DateTimeKind.Local).AddTicks(6696), new DateTime(2037, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6680) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 1, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6729), new DateTime(2022, 1, 3, 11, 16, 37, 104, DateTimeKind.Local).AddTicks(6717) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6755), new DateTime(2021, 12, 21, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6746) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6786), new DateTime(2021, 11, 14, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6775) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6814), new DateTime(2022, 5, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6804) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6850), new DateTime(2022, 1, 3, 18, 16, 37, 104, DateTimeKind.Local).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 19, 16, 37, 104, DateTimeKind.Local).AddTicks(6877), new DateTime(2022, 1, 3, 21, 16, 37, 104, DateTimeKind.Local).AddTicks(6869) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 20, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6904), new DateTime(2022, 1, 4, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6895) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 27, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6933), new DateTime(2025, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6922) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 31, 37, 104, DateTimeKind.Local).AddTicks(6964), new DateTime(2035, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6952) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 31, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7000), new DateTime(2022, 1, 3, 12, 16, 37, 104, DateTimeKind.Local).AddTicks(6988) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7034), new DateTime(2021, 12, 24, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7022) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7066), new DateTime(2021, 11, 21, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7056) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7097), new DateTime(2022, 4, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7086) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7134), new DateTime(2022, 1, 3, 16, 16, 37, 104, DateTimeKind.Local).AddTicks(7122) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 17, 16, 37, 104, DateTimeKind.Local).AddTicks(7167), new DateTime(2022, 1, 3, 19, 16, 37, 104, DateTimeKind.Local).AddTicks(7155) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 20, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7194), new DateTime(2022, 1, 8, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7186) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 23, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7227), new DateTime(2024, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7214) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 59, 37, 104, DateTimeKind.Local).AddTicks(7258), new DateTime(2032, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7246) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 29, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7287), new DateTime(2022, 1, 3, 3, 16, 37, 104, DateTimeKind.Local).AddTicks(7277) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7317), new DateTime(2021, 12, 27, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7306) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7348), new DateTime(2022, 2, 15, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7337) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7381), new DateTime(2022, 4, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7370) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(3045));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(3964));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(3983));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(4007));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(4029));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 105, DateTimeKind.Local).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 105, DateTimeKind.Local).AddTicks(8502));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 105, DateTimeKind.Local).AddTicks(8557));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 105, DateTimeKind.Local).AddTicks(8573));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 105, DateTimeKind.Local).AddTicks(8586));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 105, DateTimeKind.Local).AddTicks(8599));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 105, DateTimeKind.Local).AddTicks(8615));
        }
    }
}
