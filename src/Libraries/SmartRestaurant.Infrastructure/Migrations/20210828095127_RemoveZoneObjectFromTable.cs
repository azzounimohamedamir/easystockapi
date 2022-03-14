using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class RemoveZoneObjectFromTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Zones_ZoneId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_ZoneId",
                table: "Tables");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2301));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2298));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2284));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2259));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2273));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(4709), new DateTime(2021, 8, 28, 15, 51, 26, 390, DateTimeKind.Local).AddTicks(2065) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 15, 51, 26, 402, DateTimeKind.Local).AddTicks(5248), new DateTime(2021, 8, 28, 18, 51, 26, 402, DateTimeKind.Local).AddTicks(5216) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 13, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5287), new DateTime(2021, 8, 29, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5262) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 12, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5372), new DateTime(2026, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5294) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 11, 27, 26, 402, DateTimeKind.Local).AddTicks(5379), new DateTime(2036, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5375) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 27, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5400), new DateTime(2021, 8, 28, 7, 51, 26, 402, DateTimeKind.Local).AddTicks(5400) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5407), new DateTime(2021, 8, 16, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5407) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5410), new DateTime(2021, 7, 6, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5410) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5417), new DateTime(2022, 1, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5414) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5421), new DateTime(2021, 8, 28, 14, 51, 26, 402, DateTimeKind.Local).AddTicks(5421) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 15, 51, 26, 402, DateTimeKind.Local).AddTicks(5424), new DateTime(2021, 8, 28, 17, 51, 26, 402, DateTimeKind.Local).AddTicks(5424) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 14, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5428), new DateTime(2021, 8, 30, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5428) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 18, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5431), new DateTime(2025, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5431) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 11, 27, 26, 402, DateTimeKind.Local).AddTicks(5439), new DateTime(2036, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5435) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 26, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5442), new DateTime(2021, 8, 28, 6, 51, 26, 402, DateTimeKind.Local).AddTicks(5442) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5446), new DateTime(2021, 8, 15, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5446) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5449), new DateTime(2021, 7, 9, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5449) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5456), new DateTime(2021, 12, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5453) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5460), new DateTime(2021, 8, 28, 13, 51, 26, 402, DateTimeKind.Local).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 14, 51, 26, 402, DateTimeKind.Local).AddTicks(5463), new DateTime(2021, 8, 28, 16, 51, 26, 402, DateTimeKind.Local).AddTicks(5463) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 14, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5470), new DateTime(2021, 8, 29, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5467) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 22, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5474), new DateTime(2024, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 11, 6, 26, 402, DateTimeKind.Local).AddTicks(5477), new DateTime(2034, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5477) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 25, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5481), new DateTime(2021, 8, 28, 7, 51, 26, 402, DateTimeKind.Local).AddTicks(5481) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5484), new DateTime(2021, 8, 18, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5484) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5491), new DateTime(2021, 7, 16, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5488) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5495), new DateTime(2021, 11, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5495) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5498), new DateTime(2021, 8, 28, 11, 51, 26, 402, DateTimeKind.Local).AddTicks(5498) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 12, 51, 26, 402, DateTimeKind.Local).AddTicks(5502), new DateTime(2021, 8, 28, 14, 51, 26, 402, DateTimeKind.Local).AddTicks(5502) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 14, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5506), new DateTime(2021, 9, 2, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5506) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 17, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5509), new DateTime(2023, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5509) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 11, 34, 26, 402, DateTimeKind.Local).AddTicks(5513), new DateTime(2031, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5513) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 23, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5516), new DateTime(2021, 8, 27, 22, 51, 26, 402, DateTimeKind.Local).AddTicks(5516) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5520), new DateTime(2021, 8, 21, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5520) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5527), new DateTime(2021, 10, 10, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5523) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5530), new DateTime(2021, 11, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5530) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(9804));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(206));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(209));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(213));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(216));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(7924));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(7928));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(7932));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(7935));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(7939));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 91, DateTimeKind.Local).AddTicks(1857));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 91, DateTimeKind.Local).AddTicks(1845));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 91, DateTimeKind.Local).AddTicks(1801));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 91, DateTimeKind.Local).AddTicks(1812));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 91, DateTimeKind.Local).AddTicks(1823));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 91, DateTimeKind.Local).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 91, DateTimeKind.Local).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 91, DateTimeKind.Local).AddTicks(1766));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 91, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 91, DateTimeKind.Local).AddTicks(1791));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 91, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 26, 1, 25, 6, 89, DateTimeKind.Local).AddTicks(9600), new DateTime(2021, 8, 26, 6, 25, 6, 85, DateTimeKind.Local).AddTicks(5040) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 26, 6, 25, 6, 90, DateTimeKind.Local).AddTicks(536), new DateTime(2021, 8, 26, 9, 25, 6, 90, DateTimeKind.Local).AddTicks(487) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 11, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(608), new DateTime(2021, 8, 27, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(567) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 10, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(686), new DateTime(2026, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(624) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 26, 2, 1, 6, 90, DateTimeKind.Local).AddTicks(715), new DateTime(2036, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(704) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 25, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(755), new DateTime(2021, 8, 25, 22, 25, 6, 90, DateTimeKind.Local).AddTicks(746) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(772), new DateTime(2021, 8, 14, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(767) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(790), new DateTime(2021, 7, 4, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(785) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(809), new DateTime(2022, 1, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(803) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(827), new DateTime(2021, 8, 26, 5, 25, 6, 90, DateTimeKind.Local).AddTicks(822) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 26, 6, 25, 6, 90, DateTimeKind.Local).AddTicks(845), new DateTime(2021, 8, 26, 8, 25, 6, 90, DateTimeKind.Local).AddTicks(840) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 12, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(863), new DateTime(2021, 8, 28, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(857) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(880), new DateTime(2025, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(874) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 26, 2, 1, 6, 90, DateTimeKind.Local).AddTicks(897), new DateTime(2036, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(891) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 24, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(914), new DateTime(2021, 8, 25, 21, 25, 6, 90, DateTimeKind.Local).AddTicks(908) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(932), new DateTime(2021, 8, 13, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(926) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(949), new DateTime(2021, 7, 7, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(943) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(966), new DateTime(2021, 12, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(959) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(984), new DateTime(2021, 8, 26, 4, 25, 6, 90, DateTimeKind.Local).AddTicks(978) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 26, 5, 25, 6, 90, DateTimeKind.Local).AddTicks(1001), new DateTime(2021, 8, 26, 7, 25, 6, 90, DateTimeKind.Local).AddTicks(996) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 12, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1018), new DateTime(2021, 8, 27, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1013) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 20, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1035), new DateTime(2024, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1028) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 26, 1, 40, 6, 90, DateTimeKind.Local).AddTicks(1051), new DateTime(2034, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1045) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 23, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1067), new DateTime(2021, 8, 25, 22, 25, 6, 90, DateTimeKind.Local).AddTicks(1061) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1084), new DateTime(2021, 8, 16, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1079) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1101), new DateTime(2021, 7, 14, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1095) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1118), new DateTime(2021, 11, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1112) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1134), new DateTime(2021, 8, 26, 2, 25, 6, 90, DateTimeKind.Local).AddTicks(1129) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 26, 3, 25, 6, 90, DateTimeKind.Local).AddTicks(1151), new DateTime(2021, 8, 26, 5, 25, 6, 90, DateTimeKind.Local).AddTicks(1145) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 12, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1167), new DateTime(2021, 8, 31, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1162) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 15, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1184), new DateTime(2023, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1178) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 26, 2, 8, 6, 90, DateTimeKind.Local).AddTicks(1202), new DateTime(2031, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1196) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 21, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1223), new DateTime(2021, 8, 25, 13, 25, 6, 90, DateTimeKind.Local).AddTicks(1217) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1239), new DateTime(2021, 8, 19, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1233) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1257), new DateTime(2021, 10, 8, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1252) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1275), new DateTime(2021, 11, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(1269) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(7838));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(8592));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(8696));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(8707));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(8717));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(8728));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(4930));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 26, 1, 25, 6, 90, DateTimeKind.Local).AddTicks(4942));

            migrationBuilder.CreateIndex(
                name: "IX_Tables_ZoneId",
                table: "Tables",
                column: "ZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Zones_ZoneId",
                table: "Tables",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "ZoneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
