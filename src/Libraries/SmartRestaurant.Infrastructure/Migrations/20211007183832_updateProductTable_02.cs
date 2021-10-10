using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateProductTable_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FoodBusinessId",
                table: "Products",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3262));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3252));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3207));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3228));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(2358));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3116));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3167));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3182));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3193));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3239));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 20, 38, 30, 812, DateTimeKind.Local).AddTicks(8889), new DateTime(2021, 10, 8, 1, 38, 30, 807, DateTimeKind.Local).AddTicks(612) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 8, 1, 38, 30, 812, DateTimeKind.Local).AddTicks(9769), new DateTime(2021, 10, 8, 4, 38, 30, 812, DateTimeKind.Local).AddTicks(9717) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 22, 20, 38, 30, 812, DateTimeKind.Local).AddTicks(9841), new DateTime(2021, 10, 8, 20, 38, 30, 812, DateTimeKind.Local).AddTicks(9798) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 22, 20, 38, 30, 812, DateTimeKind.Local).AddTicks(9926), new DateTime(2026, 10, 7, 20, 38, 30, 812, DateTimeKind.Local).AddTicks(9859) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 21, 14, 30, 812, DateTimeKind.Local).AddTicks(9958), new DateTime(2036, 10, 7, 20, 38, 30, 812, DateTimeKind.Local).AddTicks(9944) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 20, 38, 30, 812, DateTimeKind.Local).AddTicks(9999), new DateTime(2021, 10, 7, 17, 38, 30, 812, DateTimeKind.Local).AddTicks(9990) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(14), new DateTime(2021, 9, 25, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(9) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(32), new DateTime(2021, 8, 15, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(27) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(48), new DateTime(2022, 3, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(43) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(65), new DateTime(2021, 10, 8, 0, 38, 30, 813, DateTimeKind.Local).AddTicks(60) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 8, 1, 38, 30, 813, DateTimeKind.Local).AddTicks(82), new DateTime(2021, 10, 8, 3, 38, 30, 813, DateTimeKind.Local).AddTicks(76) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(98), new DateTime(2021, 10, 9, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(93) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 27, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(115), new DateTime(2025, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(109) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 21, 14, 30, 813, DateTimeKind.Local).AddTicks(133), new DateTime(2036, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(127) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(148), new DateTime(2021, 10, 7, 16, 38, 30, 813, DateTimeKind.Local).AddTicks(143) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(164), new DateTime(2021, 9, 24, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(159) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(180), new DateTime(2021, 8, 18, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(175) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(197), new DateTime(2022, 2, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(191) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(213), new DateTime(2021, 10, 7, 23, 38, 30, 813, DateTimeKind.Local).AddTicks(207) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 8, 0, 38, 30, 813, DateTimeKind.Local).AddTicks(228), new DateTime(2021, 10, 8, 2, 38, 30, 813, DateTimeKind.Local).AddTicks(223) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(243), new DateTime(2021, 10, 8, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(238) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(259), new DateTime(2024, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(253) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 20, 53, 30, 813, DateTimeKind.Local).AddTicks(280), new DateTime(2034, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(275) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 4, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(296), new DateTime(2021, 10, 7, 17, 38, 30, 813, DateTimeKind.Local).AddTicks(291) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(311), new DateTime(2021, 9, 27, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(306) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(327), new DateTime(2021, 8, 25, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(322) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(343), new DateTime(2022, 1, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(337) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(358), new DateTime(2021, 10, 7, 21, 38, 30, 813, DateTimeKind.Local).AddTicks(353) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 22, 38, 30, 813, DateTimeKind.Local).AddTicks(373), new DateTime(2021, 10, 8, 0, 38, 30, 813, DateTimeKind.Local).AddTicks(368) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(390), new DateTime(2021, 10, 12, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(383) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(406), new DateTime(2023, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(400) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 21, 21, 30, 813, DateTimeKind.Local).AddTicks(423), new DateTime(2031, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(417) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(440), new DateTime(2021, 10, 7, 8, 38, 30, 813, DateTimeKind.Local).AddTicks(435) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(460), new DateTime(2021, 9, 30, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(455) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(475), new DateTime(2021, 11, 19, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(470) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(492), new DateTime(2022, 1, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(486) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(9948));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(15));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(26));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(36));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(48));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(5556));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(5642));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(5655));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(5667));

            migrationBuilder.CreateIndex(
                name: "IX_Products_FoodBusinessId",
                table: "Products",
                column: "FoodBusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FoodBusinesses_FoodBusinessId",
                table: "Products",
                column: "FoodBusinessId",
                principalTable: "FoodBusinesses",
                principalColumn: "FoodBusinessId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_FoodBusinesses_FoodBusinessId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FoodBusinessId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FoodBusinessId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(5101));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(5002));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(5028));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(3620));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(6042), new DateTime(2021, 10, 6, 18, 54, 3, 15, DateTimeKind.Local).AddTicks(1264) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 18, 54, 3, 22, DateTimeKind.Local).AddTicks(7539), new DateTime(2021, 10, 6, 21, 54, 3, 22, DateTimeKind.Local).AddTicks(7454) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 21, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(7671), new DateTime(2021, 10, 7, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(7593) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 21, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(7831), new DateTime(2026, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(7702) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 14, 30, 3, 22, DateTimeKind.Local).AddTicks(7893), new DateTime(2036, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(7867) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(7980), new DateTime(2021, 10, 6, 10, 54, 3, 22, DateTimeKind.Local).AddTicks(7960) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8016), new DateTime(2021, 9, 24, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8004) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8055), new DateTime(2021, 8, 14, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8041) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8092), new DateTime(2022, 3, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8079) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8129), new DateTime(2021, 10, 6, 17, 54, 3, 22, DateTimeKind.Local).AddTicks(8117) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 18, 54, 3, 22, DateTimeKind.Local).AddTicks(8162), new DateTime(2021, 10, 6, 20, 54, 3, 22, DateTimeKind.Local).AddTicks(8150) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 22, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8195), new DateTime(2021, 10, 8, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8183) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 26, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8234), new DateTime(2025, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8219) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 14, 30, 3, 22, DateTimeKind.Local).AddTicks(8272), new DateTime(2036, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8258) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 4, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8305), new DateTime(2021, 10, 6, 9, 54, 3, 22, DateTimeKind.Local).AddTicks(8295) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8338), new DateTime(2021, 9, 23, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8327) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8373), new DateTime(2021, 8, 17, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8362) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8406), new DateTime(2022, 2, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8395) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8442), new DateTime(2021, 10, 6, 16, 54, 3, 22, DateTimeKind.Local).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 17, 54, 3, 22, DateTimeKind.Local).AddTicks(8474), new DateTime(2021, 10, 6, 19, 54, 3, 22, DateTimeKind.Local).AddTicks(8462) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 22, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8506), new DateTime(2021, 10, 7, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8495) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 30, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8540), new DateTime(2024, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8527) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 14, 9, 3, 22, DateTimeKind.Local).AddTicks(8573), new DateTime(2034, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8561) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 3, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8605), new DateTime(2021, 10, 6, 10, 54, 3, 22, DateTimeKind.Local).AddTicks(8595) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8640), new DateTime(2021, 9, 26, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8629) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8673), new DateTime(2021, 8, 24, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8661) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8708), new DateTime(2022, 1, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8696) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8740), new DateTime(2021, 10, 6, 14, 54, 3, 22, DateTimeKind.Local).AddTicks(8729) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 15, 54, 3, 22, DateTimeKind.Local).AddTicks(8777), new DateTime(2021, 10, 6, 17, 54, 3, 22, DateTimeKind.Local).AddTicks(8764) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 22, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8811), new DateTime(2021, 10, 11, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 26, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8845), new DateTime(2023, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8833) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 14, 37, 3, 22, DateTimeKind.Local).AddTicks(8877), new DateTime(2031, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8865) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 1, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8908), new DateTime(2021, 10, 6, 1, 54, 3, 22, DateTimeKind.Local).AddTicks(8898) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8944), new DateTime(2021, 9, 29, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8932) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8976), new DateTime(2021, 11, 18, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8964) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(9010), new DateTime(2022, 1, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8997) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 23, DateTimeKind.Local).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(18));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(90));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(103));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(114));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(124));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 23, DateTimeKind.Local).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 23, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 23, DateTimeKind.Local).AddTicks(4716));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 23, DateTimeKind.Local).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 23, DateTimeKind.Local).AddTicks(4769));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 23, DateTimeKind.Local).AddTicks(4793));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 23, DateTimeKind.Local).AddTicks(4818));
        }
    }
}
