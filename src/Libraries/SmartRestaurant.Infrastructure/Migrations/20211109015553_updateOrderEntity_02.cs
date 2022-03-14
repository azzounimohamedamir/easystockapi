using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateOrderEntity_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TakeoutDetails_DeliveryTime",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TakeoutDetails_Type",
                table: "Orders",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6852));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6830));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6786));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(5462));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6589));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6668));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6696));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6719));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6807));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(8069), new DateTime(2021, 11, 9, 7, 55, 52, 24, DateTimeKind.Local).AddTicks(2558) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 7, 55, 52, 29, DateTimeKind.Local).AddTicks(9454), new DateTime(2021, 11, 9, 10, 55, 52, 29, DateTimeKind.Local).AddTicks(9372) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9573), new DateTime(2021, 11, 10, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9508) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 24, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9719), new DateTime(2026, 11, 9, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9606) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 3, 31, 52, 29, DateTimeKind.Local).AddTicks(9773), new DateTime(2036, 11, 9, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9753) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 8, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9851), new DateTime(2021, 11, 8, 23, 55, 52, 29, DateTimeKind.Local).AddTicks(9834) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 9, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9881), new DateTime(2021, 10, 28, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9870) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 9, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9914), new DateTime(2021, 9, 17, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9903) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 9, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9946), new DateTime(2022, 4, 9, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9935) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9981), new DateTime(2021, 11, 9, 6, 55, 52, 29, DateTimeKind.Local).AddTicks(9969) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 7, 55, 52, 30, DateTimeKind.Local).AddTicks(11), new DateTime(2021, 11, 9, 9, 55, 52, 30, DateTimeKind.Local).AddTicks(1) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 26, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(41), new DateTime(2021, 11, 11, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(31) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 30, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(72), new DateTime(2025, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(61) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 3, 31, 52, 30, DateTimeKind.Local).AddTicks(151), new DateTime(2036, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(135) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(189), new DateTime(2021, 11, 8, 22, 55, 52, 30, DateTimeKind.Local).AddTicks(179) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(218), new DateTime(2021, 10, 27, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(209) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(250), new DateTime(2021, 9, 20, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(281), new DateTime(2022, 3, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(270) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(312), new DateTime(2021, 11, 9, 5, 55, 52, 30, DateTimeKind.Local).AddTicks(302) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 6, 55, 52, 30, DateTimeKind.Local).AddTicks(342), new DateTime(2021, 11, 9, 8, 55, 52, 30, DateTimeKind.Local).AddTicks(332) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 26, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(374), new DateTime(2021, 11, 10, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(364) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(407), new DateTime(2024, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(396) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 3, 10, 52, 30, DateTimeKind.Local).AddTicks(438), new DateTime(2034, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(427) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 6, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(468), new DateTime(2021, 11, 8, 23, 55, 52, 30, DateTimeKind.Local).AddTicks(457) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(499), new DateTime(2021, 10, 30, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(489) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(531), new DateTime(2021, 9, 27, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(519) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(566), new DateTime(2022, 2, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(554) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(598), new DateTime(2021, 11, 9, 3, 55, 52, 30, DateTimeKind.Local).AddTicks(587) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 4, 55, 52, 30, DateTimeKind.Local).AddTicks(627), new DateTime(2021, 11, 9, 6, 55, 52, 30, DateTimeKind.Local).AddTicks(618) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 26, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(658), new DateTime(2021, 11, 14, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 29, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(691), new DateTime(2023, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(679) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 3, 38, 52, 30, DateTimeKind.Local).AddTicks(725), new DateTime(2031, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(713) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 4, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(757), new DateTime(2021, 11, 8, 14, 55, 52, 30, DateTimeKind.Local).AddTicks(746) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(792), new DateTime(2021, 11, 2, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(781) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(825), new DateTime(2021, 12, 22, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(814) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(859), new DateTime(2022, 2, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(846) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(568));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(1856));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(2034));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(6110));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(6142));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(6215));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TakeoutDetails_DeliveryTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TakeoutDetails_Type",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(530));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(519));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(478));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(489));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(499));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(9645));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(396));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(444));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(468));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(7625), new DateTime(2021, 11, 7, 8, 50, 43, 835, DateTimeKind.Local).AddTicks(4784) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 8, 50, 43, 839, DateTimeKind.Local).AddTicks(8815), new DateTime(2021, 11, 7, 11, 50, 43, 839, DateTimeKind.Local).AddTicks(8761) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 23, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(8892), new DateTime(2021, 11, 8, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(8843) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 22, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(8982), new DateTime(2026, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(8910) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 4, 26, 43, 839, DateTimeKind.Local).AddTicks(9010), new DateTime(2036, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9000) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 6, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9050), new DateTime(2021, 11, 7, 0, 50, 43, 839, DateTimeKind.Local).AddTicks(9042) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9069), new DateTime(2021, 10, 26, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9063) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9087), new DateTime(2021, 9, 15, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9081) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9104), new DateTime(2022, 4, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9098) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9122), new DateTime(2021, 11, 7, 7, 50, 43, 839, DateTimeKind.Local).AddTicks(9116) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 8, 50, 43, 839, DateTimeKind.Local).AddTicks(9139), new DateTime(2021, 11, 7, 10, 50, 43, 839, DateTimeKind.Local).AddTicks(9133) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 24, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9154), new DateTime(2021, 11, 9, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9149) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 28, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9171), new DateTime(2025, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9165) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 4, 26, 43, 839, DateTimeKind.Local).AddTicks(9188), new DateTime(2036, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9182) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 5, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9203), new DateTime(2021, 11, 6, 23, 50, 43, 839, DateTimeKind.Local).AddTicks(9198) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9219), new DateTime(2021, 10, 25, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9213) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9235), new DateTime(2021, 9, 18, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9229) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9251), new DateTime(2022, 3, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9245) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9472), new DateTime(2021, 11, 7, 6, 50, 43, 839, DateTimeKind.Local).AddTicks(9458) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 7, 50, 43, 839, DateTimeKind.Local).AddTicks(9491), new DateTime(2021, 11, 7, 9, 50, 43, 839, DateTimeKind.Local).AddTicks(9485) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 24, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9507), new DateTime(2021, 11, 8, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9501) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 1, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9524), new DateTime(2024, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9517) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 4, 5, 43, 839, DateTimeKind.Local).AddTicks(9541), new DateTime(2034, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9535) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 4, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9557), new DateTime(2021, 11, 7, 0, 50, 43, 839, DateTimeKind.Local).AddTicks(9551) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9574), new DateTime(2021, 10, 28, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9568) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9591), new DateTime(2021, 9, 25, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9586) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9608), new DateTime(2022, 2, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9602) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9625), new DateTime(2021, 11, 7, 4, 50, 43, 839, DateTimeKind.Local).AddTicks(9619) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 5, 50, 43, 839, DateTimeKind.Local).AddTicks(9643), new DateTime(2021, 11, 7, 7, 50, 43, 839, DateTimeKind.Local).AddTicks(9637) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 24, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9685), new DateTime(2021, 11, 12, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9680) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 27, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9703), new DateTime(2023, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9696) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 4, 33, 43, 839, DateTimeKind.Local).AddTicks(9718), new DateTime(2031, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9713) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 2, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9734), new DateTime(2021, 11, 6, 15, 50, 43, 839, DateTimeKind.Local).AddTicks(9729) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9749), new DateTime(2021, 10, 31, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9744) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9765), new DateTime(2021, 12, 20, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9759) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9780), new DateTime(2022, 2, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9775) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(6437));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(7254));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(7303));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(7317));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(7338));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(7348));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(3614));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(3642));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(3655));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(3666));
        }
    }
}
