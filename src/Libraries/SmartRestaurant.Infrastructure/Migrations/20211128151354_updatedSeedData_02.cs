using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updatedSeedData_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(4270));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(4283));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(4294));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(3392));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(4099));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(4230));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(4248));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(4259));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(4305));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(1766), new DateTime(2021, 11, 28, 21, 13, 52, 855, DateTimeKind.Local).AddTicks(7075) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 21, 13, 52, 860, DateTimeKind.Local).AddTicks(2725), new DateTime(2021, 11, 29, 0, 13, 52, 860, DateTimeKind.Local).AddTicks(2675) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 13, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(2801), new DateTime(2021, 11, 29, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(2757) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 13, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(2885), new DateTime(2026, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(2818) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 49, 52, 860, DateTimeKind.Local).AddTicks(2916), new DateTime(2036, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 27, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(2957), new DateTime(2021, 11, 28, 13, 13, 52, 860, DateTimeKind.Local).AddTicks(2949) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(2974), new DateTime(2021, 11, 16, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(2968) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(2993), new DateTime(2021, 10, 6, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(2987) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3013), new DateTime(2022, 4, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3007) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3031), new DateTime(2021, 11, 28, 20, 13, 52, 860, DateTimeKind.Local).AddTicks(3026) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 21, 13, 52, 860, DateTimeKind.Local).AddTicks(3047), new DateTime(2021, 11, 28, 23, 13, 52, 860, DateTimeKind.Local).AddTicks(3041) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 14, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3062), new DateTime(2021, 11, 30, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3057) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 18, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3079), new DateTime(2025, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3074) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 49, 52, 860, DateTimeKind.Local).AddTicks(3096), new DateTime(2036, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 26, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3112), new DateTime(2021, 11, 28, 12, 13, 52, 860, DateTimeKind.Local).AddTicks(3107) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3129), new DateTime(2021, 11, 15, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3123) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3145), new DateTime(2021, 10, 9, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3163), new DateTime(2022, 3, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3158) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3180), new DateTime(2021, 11, 28, 19, 13, 52, 860, DateTimeKind.Local).AddTicks(3175) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 20, 13, 52, 860, DateTimeKind.Local).AddTicks(3196), new DateTime(2021, 11, 28, 22, 13, 52, 860, DateTimeKind.Local).AddTicks(3191) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 14, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3212), new DateTime(2021, 11, 29, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3207) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 22, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3229), new DateTime(2024, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3223) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 28, 52, 860, DateTimeKind.Local).AddTicks(3245), new DateTime(2034, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3239) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 25, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3261), new DateTime(2021, 11, 28, 13, 13, 52, 860, DateTimeKind.Local).AddTicks(3256) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3282), new DateTime(2021, 11, 18, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3277) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3298), new DateTime(2021, 10, 16, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3292) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3316), new DateTime(2022, 2, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3310) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3332), new DateTime(2021, 11, 28, 17, 13, 52, 860, DateTimeKind.Local).AddTicks(3327) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 18, 13, 52, 860, DateTimeKind.Local).AddTicks(3346), new DateTime(2021, 11, 28, 20, 13, 52, 860, DateTimeKind.Local).AddTicks(3342) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 14, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3362), new DateTime(2021, 12, 3, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3356) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 18, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3381), new DateTime(2023, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3372) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 56, 52, 860, DateTimeKind.Local).AddTicks(3397), new DateTime(2031, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3391) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3413), new DateTime(2021, 11, 28, 4, 13, 52, 860, DateTimeKind.Local).AddTicks(3407) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3428), new DateTime(2021, 11, 21, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3423) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3443), new DateTime(2022, 1, 10, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3438) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3460), new DateTime(2022, 2, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(3454) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(294), 1 });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(1056), 2 });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(1103), 4 });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(1118), 5 });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(1129), 1 });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(1140), 2 });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(1150), 1 });

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(6411));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(7298));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(7344));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(7360));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(7372));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 860, DateTimeKind.Local).AddTicks(7396));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9321));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9311));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9271));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9282));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9291));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(8484));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9190));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9236));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9252));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9261));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9301));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(7085), new DateTime(2021, 11, 23, 16, 55, 7, 914, DateTimeKind.Local).AddTicks(7077) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 16, 55, 7, 918, DateTimeKind.Local).AddTicks(7996), new DateTime(2021, 11, 23, 19, 55, 7, 918, DateTimeKind.Local).AddTicks(7939) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 8, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8073), new DateTime(2021, 11, 24, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8028) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 8, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8160), new DateTime(2026, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8089) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 12, 31, 7, 918, DateTimeKind.Local).AddTicks(8191), new DateTime(2036, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8179) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 22, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8239), new DateTime(2021, 11, 23, 8, 55, 7, 918, DateTimeKind.Local).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8257), new DateTime(2021, 11, 11, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8252) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8273), new DateTime(2021, 10, 1, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8268) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8290), new DateTime(2022, 4, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8285) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8305), new DateTime(2021, 11, 23, 15, 55, 7, 918, DateTimeKind.Local).AddTicks(8300) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 16, 55, 7, 918, DateTimeKind.Local).AddTicks(8321), new DateTime(2021, 11, 23, 18, 55, 7, 918, DateTimeKind.Local).AddTicks(8316) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8338), new DateTime(2021, 11, 25, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8331) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8353), new DateTime(2025, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8347) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 12, 31, 7, 918, DateTimeKind.Local).AddTicks(8369), new DateTime(2036, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8363) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 21, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8384), new DateTime(2021, 11, 23, 7, 55, 7, 918, DateTimeKind.Local).AddTicks(8379) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8402), new DateTime(2021, 11, 10, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8396) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8417), new DateTime(2021, 10, 4, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8412) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8433), new DateTime(2022, 3, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8428) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8449), new DateTime(2021, 11, 23, 14, 55, 7, 918, DateTimeKind.Local).AddTicks(8443) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 15, 55, 7, 918, DateTimeKind.Local).AddTicks(8463), new DateTime(2021, 11, 23, 17, 55, 7, 918, DateTimeKind.Local).AddTicks(8458) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8478), new DateTime(2021, 11, 24, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8473) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 17, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8494), new DateTime(2024, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8488) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 12, 10, 7, 918, DateTimeKind.Local).AddTicks(8509), new DateTime(2034, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8503) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 20, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8523), new DateTime(2021, 11, 23, 8, 55, 7, 918, DateTimeKind.Local).AddTicks(8518) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8539), new DateTime(2021, 11, 13, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8533) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8555), new DateTime(2021, 10, 11, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8550) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8571), new DateTime(2022, 2, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8565) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8586), new DateTime(2021, 11, 23, 12, 55, 7, 918, DateTimeKind.Local).AddTicks(8581) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 13, 55, 7, 918, DateTimeKind.Local).AddTicks(8600), new DateTime(2021, 11, 23, 15, 55, 7, 918, DateTimeKind.Local).AddTicks(8595) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8614), new DateTime(2021, 11, 28, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8609) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 13, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8629), new DateTime(2023, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8623) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 12, 38, 7, 918, DateTimeKind.Local).AddTicks(8644), new DateTime(2031, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8639) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8658), new DateTime(2021, 11, 22, 23, 55, 7, 918, DateTimeKind.Local).AddTicks(8653) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8672), new DateTime(2021, 11, 16, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8668) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8689), new DateTime(2022, 1, 5, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8683) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8705), new DateTime(2022, 2, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(5306), 4 });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(6077), 5 });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(6129), 10 });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(6145), 7 });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(6156), 7 });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(6165), 3 });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                columns: new[] { "CreatedAt", "TableNumber" },
                values: new object[] { new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(6261), 8 });

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(2391));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(2454));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(2465));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(2475));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(2485));
        }
    }
}
