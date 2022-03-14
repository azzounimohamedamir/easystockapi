using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddArchivedPropertyToFoodBusinessClientSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "FoodBusinessClients",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1763));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1755));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1731));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(736));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1649));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1692));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1702));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1712));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1746));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(7105), new DateTime(2021, 10, 15, 23, 43, 58, 649, DateTimeKind.Local).AddTicks(6191) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 23, 43, 58, 652, DateTimeKind.Local).AddTicks(8222), new DateTime(2021, 10, 16, 2, 43, 58, 652, DateTimeKind.Local).AddTicks(8154) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8301), new DateTime(2021, 10, 16, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8247) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 30, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8448), new DateTime(2026, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8313) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 19, 19, 58, 652, DateTimeKind.Local).AddTicks(8470), new DateTime(2036, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8460) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8502), new DateTime(2021, 10, 15, 15, 43, 58, 652, DateTimeKind.Local).AddTicks(8498) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8515), new DateTime(2021, 10, 3, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8513) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8530), new DateTime(2021, 8, 23, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8528) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8541), new DateTime(2022, 3, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8538) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8554), new DateTime(2021, 10, 15, 22, 43, 58, 652, DateTimeKind.Local).AddTicks(8550) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 23, 43, 58, 652, DateTimeKind.Local).AddTicks(8567), new DateTime(2021, 10, 16, 1, 43, 58, 652, DateTimeKind.Local).AddTicks(8564) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 1, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8579), new DateTime(2021, 10, 17, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8577) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 5, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8591), new DateTime(2025, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8588) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 19, 19, 58, 652, DateTimeKind.Local).AddTicks(8605), new DateTime(2036, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8601) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8618), new DateTime(2021, 10, 15, 14, 43, 58, 652, DateTimeKind.Local).AddTicks(8615) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8630), new DateTime(2021, 10, 2, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8628) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8644), new DateTime(2021, 8, 26, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8641) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8656), new DateTime(2022, 2, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8653) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8671), new DateTime(2021, 10, 15, 21, 43, 58, 652, DateTimeKind.Local).AddTicks(8668) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 22, 43, 58, 652, DateTimeKind.Local).AddTicks(8683), new DateTime(2021, 10, 16, 0, 43, 58, 652, DateTimeKind.Local).AddTicks(8680) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 1, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8694), new DateTime(2021, 10, 16, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8692) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 9, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8708), new DateTime(2024, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8705) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 18, 58, 58, 652, DateTimeKind.Local).AddTicks(8721), new DateTime(2034, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8718) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 12, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8734), new DateTime(2021, 10, 15, 15, 43, 58, 652, DateTimeKind.Local).AddTicks(8731) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8745), new DateTime(2021, 10, 5, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8743) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8759), new DateTime(2021, 9, 2, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8756) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8774), new DateTime(2022, 1, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8770) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8788), new DateTime(2021, 10, 15, 19, 43, 58, 652, DateTimeKind.Local).AddTicks(8785) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 20, 43, 58, 652, DateTimeKind.Local).AddTicks(8799), new DateTime(2021, 10, 15, 22, 43, 58, 652, DateTimeKind.Local).AddTicks(8797) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 1, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8811), new DateTime(2021, 10, 20, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8808) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 4, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8825), new DateTime(2023, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8819) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 19, 26, 58, 652, DateTimeKind.Local).AddTicks(8836), new DateTime(2031, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8833) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 10, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8850), new DateTime(2021, 10, 15, 6, 43, 58, 652, DateTimeKind.Local).AddTicks(8846) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(9047), new DateTime(2021, 10, 8, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(9043) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(9062), new DateTime(2021, 11, 27, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(9059) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(9078), new DateTime(2022, 1, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(9074) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(7347));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(8231));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(8261));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(8269));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(3350));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(4271));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(4283));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(4293));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(4303));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archived",
                table: "FoodBusinessClients");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(4036));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(4032));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(4015));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(4019));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(3632));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(3985));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(4002));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(4011));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(4028));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(7705), new DateTime(2021, 10, 14, 17, 52, 15, 312, DateTimeKind.Local).AddTicks(5841) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 17, 52, 15, 313, DateTimeKind.Local).AddTicks(8194), new DateTime(2021, 10, 14, 20, 52, 15, 313, DateTimeKind.Local).AddTicks(8164) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 29, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8228), new DateTime(2021, 10, 15, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8208) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 29, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8301), new DateTime(2026, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8235) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 13, 28, 15, 313, DateTimeKind.Local).AddTicks(8313), new DateTime(2036, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8307) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8333), new DateTime(2021, 10, 14, 9, 52, 15, 313, DateTimeKind.Local).AddTicks(8331) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8340), new DateTime(2021, 10, 2, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8338) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8346), new DateTime(2021, 8, 22, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8345) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8435), new DateTime(2022, 3, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8432) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8442), new DateTime(2021, 10, 14, 16, 52, 15, 313, DateTimeKind.Local).AddTicks(8440) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 17, 52, 15, 313, DateTimeKind.Local).AddTicks(8448), new DateTime(2021, 10, 14, 19, 52, 15, 313, DateTimeKind.Local).AddTicks(8447) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 30, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8455), new DateTime(2021, 10, 16, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8453) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 4, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8462), new DateTime(2025, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8460) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 13, 28, 15, 313, DateTimeKind.Local).AddTicks(8472), new DateTime(2036, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8478), new DateTime(2021, 10, 14, 8, 52, 15, 313, DateTimeKind.Local).AddTicks(8477) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8484), new DateTime(2021, 10, 1, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8483) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8491), new DateTime(2021, 8, 25, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8490) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8498), new DateTime(2022, 2, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8496) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8504), new DateTime(2021, 10, 14, 15, 52, 15, 313, DateTimeKind.Local).AddTicks(8502) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 16, 52, 15, 313, DateTimeKind.Local).AddTicks(8511), new DateTime(2021, 10, 14, 18, 52, 15, 313, DateTimeKind.Local).AddTicks(8509) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 30, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8516), new DateTime(2021, 10, 15, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8515) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 8, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8523), new DateTime(2024, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8521) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 13, 7, 15, 313, DateTimeKind.Local).AddTicks(8529), new DateTime(2034, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8527) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8536), new DateTime(2021, 10, 14, 9, 52, 15, 313, DateTimeKind.Local).AddTicks(8534) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8542), new DateTime(2021, 10, 4, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8540) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8549), new DateTime(2021, 9, 1, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8548) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8556), new DateTime(2022, 1, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8554) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8562), new DateTime(2021, 10, 14, 13, 52, 15, 313, DateTimeKind.Local).AddTicks(8560) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 14, 52, 15, 313, DateTimeKind.Local).AddTicks(8567), new DateTime(2021, 10, 14, 16, 52, 15, 313, DateTimeKind.Local).AddTicks(8566) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 30, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8573), new DateTime(2021, 10, 19, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8572) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8579), new DateTime(2023, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8577) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 13, 35, 15, 313, DateTimeKind.Local).AddTicks(8585), new DateTime(2031, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8583) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 9, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8591), new DateTime(2021, 10, 14, 0, 52, 15, 313, DateTimeKind.Local).AddTicks(8589) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8597), new DateTime(2021, 10, 7, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8595) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8603), new DateTime(2021, 11, 26, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8601) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8609), new DateTime(2022, 1, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8607) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(1954));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(2403));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(2427));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(2431));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(2436));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(70));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(462));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(485));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(490));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(495));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(502));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(506));
        }
    }
}
