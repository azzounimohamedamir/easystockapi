using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateSectionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "HasSubSection",
                table: "Sections",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5687));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5677));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5636));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5647));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5657));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5555));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5600));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5625));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5667));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(3431), new DateTime(2021, 10, 27, 11, 8, 57, 47, DateTimeKind.Local).AddTicks(8323) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 11, 8, 57, 52, DateTimeKind.Local).AddTicks(4353), new DateTime(2021, 10, 27, 14, 8, 57, 52, DateTimeKind.Local).AddTicks(4303) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 12, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4423), new DateTime(2021, 10, 28, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4382) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 11, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4511), new DateTime(2026, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4439) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 6, 44, 57, 52, DateTimeKind.Local).AddTicks(4542), new DateTime(2036, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4531) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 26, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4585), new DateTime(2021, 10, 27, 3, 8, 57, 52, DateTimeKind.Local).AddTicks(4577) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4602), new DateTime(2021, 10, 15, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4597) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4765), new DateTime(2021, 9, 4, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4754) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4783), new DateTime(2022, 3, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4777) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4800), new DateTime(2021, 10, 27, 10, 8, 57, 52, DateTimeKind.Local).AddTicks(4795) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 11, 8, 57, 52, DateTimeKind.Local).AddTicks(4817), new DateTime(2021, 10, 27, 13, 8, 57, 52, DateTimeKind.Local).AddTicks(4812) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4833), new DateTime(2021, 10, 29, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4827) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 17, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4850), new DateTime(2025, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4844) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 6, 44, 57, 52, DateTimeKind.Local).AddTicks(4868), new DateTime(2036, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4861) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4885), new DateTime(2021, 10, 27, 2, 8, 57, 52, DateTimeKind.Local).AddTicks(4880) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4902), new DateTime(2021, 10, 14, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4895) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4918), new DateTime(2021, 9, 7, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4913) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4934), new DateTime(2022, 2, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4929) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4951), new DateTime(2021, 10, 27, 9, 8, 57, 52, DateTimeKind.Local).AddTicks(4945) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 10, 8, 57, 52, DateTimeKind.Local).AddTicks(4966), new DateTime(2021, 10, 27, 12, 8, 57, 52, DateTimeKind.Local).AddTicks(4961) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4982), new DateTime(2021, 10, 28, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4976) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 21, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5002), new DateTime(2024, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4996) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 6, 23, 57, 52, DateTimeKind.Local).AddTicks(5019), new DateTime(2034, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5013) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 24, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5034), new DateTime(2021, 10, 27, 3, 8, 57, 52, DateTimeKind.Local).AddTicks(5029) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5052), new DateTime(2021, 10, 17, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5046) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5069), new DateTime(2021, 9, 14, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5064) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5086), new DateTime(2022, 1, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5080) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5102), new DateTime(2021, 10, 27, 7, 8, 57, 52, DateTimeKind.Local).AddTicks(5096) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 8, 8, 57, 52, DateTimeKind.Local).AddTicks(5117), new DateTime(2021, 10, 27, 10, 8, 57, 52, DateTimeKind.Local).AddTicks(5112) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5133), new DateTime(2021, 11, 1, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5127) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 16, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5149), new DateTime(2023, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5144) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 6, 51, 57, 52, DateTimeKind.Local).AddTicks(5165), new DateTime(2031, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5160) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 22, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5181), new DateTime(2021, 10, 26, 18, 8, 57, 52, DateTimeKind.Local).AddTicks(5176) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5197), new DateTime(2021, 10, 20, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5191) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5213), new DateTime(2021, 12, 9, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5207) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5229), new DateTime(2022, 1, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5224) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(2538));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(2586));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(2601));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(2613));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(2624));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(2635));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(8105));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(8881));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(8929));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(8943));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(8955));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(8978));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "HasSubSection",
                table: "Sections",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1713));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1658));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1669));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(829));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1577));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1622));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1690));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 17, 28, 19, 32, DateTimeKind.Local).AddTicks(9464), new DateTime(2021, 10, 25, 22, 28, 19, 27, DateTimeKind.Local).AddTicks(9768) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 22, 28, 19, 33, DateTimeKind.Local).AddTicks(405), new DateTime(2021, 10, 26, 1, 28, 19, 33, DateTimeKind.Local).AddTicks(354) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 10, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(473), new DateTime(2021, 10, 26, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(432) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(554), new DateTime(2026, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(489) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 18, 4, 19, 33, DateTimeKind.Local).AddTicks(583), new DateTime(2036, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(572) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 24, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(627), new DateTime(2021, 10, 25, 14, 28, 19, 33, DateTimeKind.Local).AddTicks(618) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(644), new DateTime(2021, 10, 13, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(639) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(663), new DateTime(2021, 9, 2, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(657) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(680), new DateTime(2022, 3, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(674) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(696), new DateTime(2021, 10, 25, 21, 28, 19, 33, DateTimeKind.Local).AddTicks(691) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 22, 28, 19, 33, DateTimeKind.Local).AddTicks(713), new DateTime(2021, 10, 26, 0, 28, 19, 33, DateTimeKind.Local).AddTicks(707) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(729), new DateTime(2021, 10, 27, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(723) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 15, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(746), new DateTime(2025, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(740) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 18, 4, 19, 33, DateTimeKind.Local).AddTicks(764), new DateTime(2036, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(757) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 23, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(781), new DateTime(2021, 10, 25, 13, 28, 19, 33, DateTimeKind.Local).AddTicks(776) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(799), new DateTime(2021, 10, 12, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(793) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(814), new DateTime(2021, 9, 5, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(832), new DateTime(2022, 2, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(826) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(849), new DateTime(2021, 10, 25, 20, 28, 19, 33, DateTimeKind.Local).AddTicks(843) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 21, 28, 19, 33, DateTimeKind.Local).AddTicks(914), new DateTime(2021, 10, 25, 23, 28, 19, 33, DateTimeKind.Local).AddTicks(907) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(930), new DateTime(2021, 10, 26, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(924) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 19, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(946), new DateTime(2024, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(940) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 17, 43, 19, 33, DateTimeKind.Local).AddTicks(963), new DateTime(2034, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(957) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 22, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(979), new DateTime(2021, 10, 25, 14, 28, 19, 33, DateTimeKind.Local).AddTicks(974) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(996), new DateTime(2021, 10, 15, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(991) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1014), new DateTime(2021, 9, 12, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1008) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1031), new DateTime(2022, 1, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1025) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1047), new DateTime(2021, 10, 25, 18, 28, 19, 33, DateTimeKind.Local).AddTicks(1042) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 19, 28, 19, 33, DateTimeKind.Local).AddTicks(1064), new DateTime(2021, 10, 25, 21, 28, 19, 33, DateTimeKind.Local).AddTicks(1058) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1080), new DateTime(2021, 10, 30, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1074) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 14, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1207), new DateTime(2023, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1195) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 18, 11, 19, 33, DateTimeKind.Local).AddTicks(1224), new DateTime(2031, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1218) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 20, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1242), new DateTime(2021, 10, 25, 5, 28, 19, 33, DateTimeKind.Local).AddTicks(1236) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1258), new DateTime(2021, 10, 18, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1252) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1277), new DateTime(2021, 12, 7, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1271) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1294), new DateTime(2022, 1, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1288) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(8582));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(8628));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(8644));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(8656));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(4108));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(4885));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(4983));
        }
    }
}
