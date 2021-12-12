using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateOrderEntity_04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TVA",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(9906));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(9895));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(9850));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(9861));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(9873));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(9827));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(9883));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(5396), new DateTime(2021, 12, 12, 2, 48, 57, 32, DateTimeKind.Local).AddTicks(655) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 12, 2, 48, 57, 36, DateTimeKind.Local).AddTicks(6368), new DateTime(2021, 12, 12, 5, 48, 57, 36, DateTimeKind.Local).AddTicks(6315) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 26, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6448), new DateTime(2021, 12, 12, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6403) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 26, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6533), new DateTime(2026, 12, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6465) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 11, 22, 24, 57, 36, DateTimeKind.Local).AddTicks(6565), new DateTime(2036, 12, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6552) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 10, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6607), new DateTime(2021, 12, 11, 18, 48, 57, 36, DateTimeKind.Local).AddTicks(6598) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6626), new DateTime(2021, 11, 29, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6620) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6645), new DateTime(2021, 10, 19, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6639) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6664), new DateTime(2022, 5, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6657) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6682), new DateTime(2021, 12, 12, 1, 48, 57, 36, DateTimeKind.Local).AddTicks(6675) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 12, 2, 48, 57, 36, DateTimeKind.Local).AddTicks(6699), new DateTime(2021, 12, 12, 4, 48, 57, 36, DateTimeKind.Local).AddTicks(6693) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 27, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6718), new DateTime(2021, 12, 13, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6710) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 31, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6737), new DateTime(2025, 12, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6730) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 11, 22, 24, 57, 36, DateTimeKind.Local).AddTicks(6755), new DateTime(2036, 12, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6749) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 9, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6772), new DateTime(2021, 12, 11, 17, 48, 57, 36, DateTimeKind.Local).AddTicks(6766) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6789), new DateTime(2021, 11, 28, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6783) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6807), new DateTime(2021, 10, 22, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6801) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6825), new DateTime(2022, 4, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6819) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6843), new DateTime(2021, 12, 12, 0, 48, 57, 36, DateTimeKind.Local).AddTicks(6836) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 12, 1, 48, 57, 36, DateTimeKind.Local).AddTicks(6860), new DateTime(2021, 12, 12, 3, 48, 57, 36, DateTimeKind.Local).AddTicks(6854) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 27, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6877), new DateTime(2021, 12, 12, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6871) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 4, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6899), new DateTime(2024, 12, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6892) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 11, 22, 3, 57, 36, DateTimeKind.Local).AddTicks(6916), new DateTime(2034, 12, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6909) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 8, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6936), new DateTime(2021, 12, 11, 18, 48, 57, 36, DateTimeKind.Local).AddTicks(6930) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6952), new DateTime(2021, 12, 1, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6946) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6969), new DateTime(2021, 10, 29, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6963) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6988), new DateTime(2022, 3, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(6981) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(7005), new DateTime(2021, 12, 11, 22, 48, 57, 36, DateTimeKind.Local).AddTicks(6999) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 11, 23, 48, 57, 36, DateTimeKind.Local).AddTicks(7022), new DateTime(2021, 12, 12, 1, 48, 57, 36, DateTimeKind.Local).AddTicks(7017) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 27, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(7040), new DateTime(2021, 12, 16, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(7034) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 31, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(7058), new DateTime(2023, 12, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(7051) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 11, 22, 31, 57, 36, DateTimeKind.Local).AddTicks(7078), new DateTime(2031, 12, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(7072) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 6, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(7094), new DateTime(2021, 12, 11, 9, 48, 57, 36, DateTimeKind.Local).AddTicks(7089) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(7111), new DateTime(2021, 12, 4, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(7105) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(7228), new DateTime(2022, 1, 23, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(7217) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(7246), new DateTime(2022, 3, 11, 21, 48, 57, 36, DateTimeKind.Local).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(6587));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(6664));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(6675));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(6686));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(2025));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(2834));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(2886));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(2903));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(2916));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(2929));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 11, 21, 48, 57, 37, DateTimeKind.Local).AddTicks(2942));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Zones_ZoneId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_ZoneId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "TVA",
                table: "Orders");

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
    }
}
