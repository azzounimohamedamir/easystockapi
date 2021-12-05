using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateOrderEntity_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "OrderProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "InitialPrice",
                table: "OrderProducts",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "OrderDishes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 492, DateTimeKind.Local).AddTicks(1978));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 492, DateTimeKind.Local).AddTicks(1966));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 492, DateTimeKind.Local).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 492, DateTimeKind.Local).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 492, DateTimeKind.Local).AddTicks(1943));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 492, DateTimeKind.Local).AddTicks(207));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 492, DateTimeKind.Local).AddTicks(1818));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 492, DateTimeKind.Local).AddTicks(1878));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 492, DateTimeKind.Local).AddTicks(1893));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 492, DateTimeKind.Local).AddTicks(1906));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 492, DateTimeKind.Local).AddTicks(1954));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(7707), new DateTime(2021, 12, 6, 2, 8, 2, 486, DateTimeKind.Local).AddTicks(3133) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 6, 2, 8, 2, 490, DateTimeKind.Local).AddTicks(8848), new DateTime(2021, 12, 6, 5, 8, 2, 490, DateTimeKind.Local).AddTicks(8787) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 20, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(8924), new DateTime(2021, 12, 6, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(8877) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 20, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9007), new DateTime(2026, 12, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(8941) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 5, 21, 44, 2, 490, DateTimeKind.Local).AddTicks(9035), new DateTime(2036, 12, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9025) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 4, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9074), new DateTime(2021, 12, 5, 18, 8, 2, 490, DateTimeKind.Local).AddTicks(9066) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9091), new DateTime(2021, 11, 23, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9085) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9111), new DateTime(2021, 10, 13, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9104) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9129), new DateTime(2022, 5, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9122) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9147), new DateTime(2021, 12, 6, 1, 8, 2, 490, DateTimeKind.Local).AddTicks(9141) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 6, 2, 8, 2, 490, DateTimeKind.Local).AddTicks(9163), new DateTime(2021, 12, 6, 4, 8, 2, 490, DateTimeKind.Local).AddTicks(9158) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 21, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9180), new DateTime(2021, 12, 7, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9174) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 25, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9199), new DateTime(2025, 12, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9193) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 5, 21, 44, 2, 490, DateTimeKind.Local).AddTicks(9218), new DateTime(2036, 12, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9211) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 3, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9234), new DateTime(2021, 12, 5, 17, 8, 2, 490, DateTimeKind.Local).AddTicks(9229) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9251), new DateTime(2021, 11, 22, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9246) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9268), new DateTime(2021, 10, 16, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9262) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9286), new DateTime(2022, 4, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9279) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9305), new DateTime(2021, 12, 6, 0, 8, 2, 490, DateTimeKind.Local).AddTicks(9298) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 6, 1, 8, 2, 490, DateTimeKind.Local).AddTicks(9322), new DateTime(2021, 12, 6, 3, 8, 2, 490, DateTimeKind.Local).AddTicks(9316) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 21, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9339), new DateTime(2021, 12, 6, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9333) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 29, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9356), new DateTime(2024, 12, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9349) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 5, 21, 23, 2, 490, DateTimeKind.Local).AddTicks(9373), new DateTime(2034, 12, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9367) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 2, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9390), new DateTime(2021, 12, 5, 18, 8, 2, 490, DateTimeKind.Local).AddTicks(9384) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9406), new DateTime(2021, 11, 25, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9400) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9423), new DateTime(2021, 10, 23, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9417) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9440), new DateTime(2022, 3, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9434) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9457), new DateTime(2021, 12, 5, 22, 8, 2, 490, DateTimeKind.Local).AddTicks(9451) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 5, 23, 8, 2, 490, DateTimeKind.Local).AddTicks(9474), new DateTime(2021, 12, 6, 1, 8, 2, 490, DateTimeKind.Local).AddTicks(9468) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 21, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9490), new DateTime(2021, 12, 10, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9485) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 25, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9507), new DateTime(2023, 12, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9501) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 5, 21, 51, 2, 490, DateTimeKind.Local).AddTicks(9524), new DateTime(2031, 12, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9518) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 30, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9541), new DateTime(2021, 12, 5, 9, 8, 2, 490, DateTimeKind.Local).AddTicks(9535) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9557), new DateTime(2021, 11, 28, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9551) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9573), new DateTime(2022, 1, 17, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9568) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9591), new DateTime(2022, 3, 5, 21, 8, 2, 490, DateTimeKind.Local).AddTicks(9585) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 491, DateTimeKind.Local).AddTicks(6815));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 491, DateTimeKind.Local).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 491, DateTimeKind.Local).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 491, DateTimeKind.Local).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 491, DateTimeKind.Local).AddTicks(7759));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 491, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 491, DateTimeKind.Local).AddTicks(7784));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 491, DateTimeKind.Local).AddTicks(2841));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 491, DateTimeKind.Local).AddTicks(3836));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 491, DateTimeKind.Local).AddTicks(3886));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 491, DateTimeKind.Local).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 491, DateTimeKind.Local).AddTicks(3915));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 491, DateTimeKind.Local).AddTicks(3926));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 5, 21, 8, 2, 491, DateTimeKind.Local).AddTicks(3938));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "InitialPrice",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "OrderDishes");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8968));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8923));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8934));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8827));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8874));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8888));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8899));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8946));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(6643), new DateTime(2021, 12, 1, 19, 29, 25, 829, DateTimeKind.Local).AddTicks(5006) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 19, 29, 25, 833, DateTimeKind.Local).AddTicks(7601), new DateTime(2021, 12, 1, 22, 29, 25, 833, DateTimeKind.Local).AddTicks(7545) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 16, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7673), new DateTime(2021, 12, 2, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7632) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 16, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7759), new DateTime(2026, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7690) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 15, 5, 25, 833, DateTimeKind.Local).AddTicks(7794), new DateTime(2036, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7782) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 30, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7835), new DateTime(2021, 12, 1, 11, 29, 25, 833, DateTimeKind.Local).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7852), new DateTime(2021, 11, 19, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7846) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7869), new DateTime(2021, 10, 9, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7864) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7886), new DateTime(2022, 5, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7902), new DateTime(2021, 12, 1, 18, 29, 25, 833, DateTimeKind.Local).AddTicks(7896) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 19, 29, 25, 833, DateTimeKind.Local).AddTicks(7918), new DateTime(2021, 12, 1, 21, 29, 25, 833, DateTimeKind.Local).AddTicks(7913) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7934), new DateTime(2021, 12, 3, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7928) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 21, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7951), new DateTime(2025, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7944) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 15, 5, 25, 833, DateTimeKind.Local).AddTicks(7969), new DateTime(2036, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7962) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 29, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7985), new DateTime(2021, 12, 1, 10, 29, 25, 833, DateTimeKind.Local).AddTicks(7980) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8100), new DateTime(2021, 11, 18, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8089) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8118), new DateTime(2021, 10, 12, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8112) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8134), new DateTime(2022, 4, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8129) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8151), new DateTime(2021, 12, 1, 17, 29, 25, 833, DateTimeKind.Local).AddTicks(8146) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 18, 29, 25, 833, DateTimeKind.Local).AddTicks(8167), new DateTime(2021, 12, 1, 20, 29, 25, 833, DateTimeKind.Local).AddTicks(8162) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8183), new DateTime(2021, 12, 2, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8177) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 25, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8201), new DateTime(2024, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8195) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 14, 44, 25, 833, DateTimeKind.Local).AddTicks(8220), new DateTime(2034, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8213) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8235), new DateTime(2021, 12, 1, 11, 29, 25, 833, DateTimeKind.Local).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8252), new DateTime(2021, 11, 21, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8246) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8268), new DateTime(2021, 10, 19, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8263) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8285), new DateTime(2022, 3, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8280) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8302), new DateTime(2021, 12, 1, 15, 29, 25, 833, DateTimeKind.Local).AddTicks(8296) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 16, 29, 25, 833, DateTimeKind.Local).AddTicks(8318), new DateTime(2021, 12, 1, 18, 29, 25, 833, DateTimeKind.Local).AddTicks(8312) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8336), new DateTime(2021, 12, 6, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8331) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 21, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8355), new DateTime(2023, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8349) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 15, 12, 25, 833, DateTimeKind.Local).AddTicks(8371), new DateTime(2031, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8365) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 26, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8388), new DateTime(2021, 12, 1, 2, 29, 25, 833, DateTimeKind.Local).AddTicks(8382) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8402), new DateTime(2021, 11, 24, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8397) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8418), new DateTime(2022, 1, 13, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8414) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8435), new DateTime(2022, 3, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8429) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(5027));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(5807));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(5888));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(5898));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(2159));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(2172));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(2182));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(2204));
        }
    }
}
