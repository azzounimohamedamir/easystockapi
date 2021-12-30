using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class addCommisionConfigsToFoodbusiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActivityFrozen",
                table: "FoodBusinesses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CommissionConfigs_Type",
                table: "FoodBusinesses",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "CommissionConfigs_Value",
                table: "FoodBusinesses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommissionConfigs_WhoPay",
                table: "FoodBusinesses",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 945, DateTimeKind.Local).AddTicks(2405));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 945, DateTimeKind.Local).AddTicks(2394));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 945, DateTimeKind.Local).AddTicks(2349));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 945, DateTimeKind.Local).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 945, DateTimeKind.Local).AddTicks(2371));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 945, DateTimeKind.Local).AddTicks(1559));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 945, DateTimeKind.Local).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 945, DateTimeKind.Local).AddTicks(2310));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 945, DateTimeKind.Local).AddTicks(2325));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 945, DateTimeKind.Local).AddTicks(2337));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 945, DateTimeKind.Local).AddTicks(2382));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(8234), new DateTime(2021, 12, 31, 4, 40, 52, 939, DateTimeKind.Local).AddTicks(6332) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 31, 4, 40, 52, 943, DateTimeKind.Local).AddTicks(9142), new DateTime(2021, 12, 31, 7, 40, 52, 943, DateTimeKind.Local).AddTicks(9092) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 15, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9226), new DateTime(2021, 12, 31, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9181) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 14, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9310), new DateTime(2026, 12, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9242) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 31, 0, 16, 52, 943, DateTimeKind.Local).AddTicks(9340), new DateTime(2036, 12, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9329) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 29, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9382), new DateTime(2021, 12, 30, 20, 40, 52, 943, DateTimeKind.Local).AddTicks(9374) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9400), new DateTime(2021, 12, 18, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9394) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9418), new DateTime(2021, 11, 7, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9412) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9437), new DateTime(2022, 5, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9431) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9455), new DateTime(2021, 12, 31, 3, 40, 52, 943, DateTimeKind.Local).AddTicks(9449) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 31, 4, 40, 52, 943, DateTimeKind.Local).AddTicks(9471), new DateTime(2021, 12, 31, 6, 40, 52, 943, DateTimeKind.Local).AddTicks(9465) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 16, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9489), new DateTime(2022, 1, 1, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9483) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 19, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9506), new DateTime(2025, 12, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9499) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 31, 0, 16, 52, 943, DateTimeKind.Local).AddTicks(9529), new DateTime(2036, 12, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9518) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 28, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9546), new DateTime(2021, 12, 30, 19, 40, 52, 943, DateTimeKind.Local).AddTicks(9540) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9562), new DateTime(2021, 12, 17, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9556) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9579), new DateTime(2021, 11, 10, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9573) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9596), new DateTime(2022, 4, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9616), new DateTime(2021, 12, 31, 2, 40, 52, 943, DateTimeKind.Local).AddTicks(9608) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 31, 3, 40, 52, 943, DateTimeKind.Local).AddTicks(9633), new DateTime(2021, 12, 31, 5, 40, 52, 943, DateTimeKind.Local).AddTicks(9627) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 16, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9650), new DateTime(2021, 12, 31, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9644) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 23, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9667), new DateTime(2024, 12, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9661) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 30, 23, 55, 52, 943, DateTimeKind.Local).AddTicks(9685), new DateTime(2034, 12, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9678) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 27, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9703), new DateTime(2021, 12, 30, 20, 40, 52, 943, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9719), new DateTime(2021, 12, 20, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9714) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9738), new DateTime(2021, 11, 17, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9731) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 28, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9755), new DateTime(2022, 3, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9749) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9772), new DateTime(2021, 12, 31, 0, 40, 52, 943, DateTimeKind.Local).AddTicks(9767) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 31, 1, 40, 52, 943, DateTimeKind.Local).AddTicks(9789), new DateTime(2021, 12, 31, 3, 40, 52, 943, DateTimeKind.Local).AddTicks(9783) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 16, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9806), new DateTime(2022, 1, 4, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9800) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 19, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9823), new DateTime(2023, 12, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9816) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 31, 0, 23, 52, 943, DateTimeKind.Local).AddTicks(9840), new DateTime(2031, 12, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9833) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 25, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9858), new DateTime(2021, 12, 30, 11, 40, 52, 943, DateTimeKind.Local).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9874), new DateTime(2021, 12, 23, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9868) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9890), new DateTime(2022, 2, 11, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9885) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 28, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9908), new DateTime(2022, 3, 30, 23, 40, 52, 943, DateTimeKind.Local).AddTicks(9901) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 944, DateTimeKind.Local).AddTicks(8531));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 944, DateTimeKind.Local).AddTicks(9284));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 944, DateTimeKind.Local).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 944, DateTimeKind.Local).AddTicks(9349));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 944, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 944, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 944, DateTimeKind.Local).AddTicks(9381));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 944, DateTimeKind.Local).AddTicks(4769));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 944, DateTimeKind.Local).AddTicks(5568));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 944, DateTimeKind.Local).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 944, DateTimeKind.Local).AddTicks(5636));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 944, DateTimeKind.Local).AddTicks(5649));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 944, DateTimeKind.Local).AddTicks(5661));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 30, 23, 40, 52, 944, DateTimeKind.Local).AddTicks(5673));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActivityFrozen",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "CommissionConfigs_Type",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "CommissionConfigs_Value",
                table: "FoodBusinesses");

            migrationBuilder.DropColumn(
                name: "CommissionConfigs_WhoPay",
                table: "FoodBusinesses");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 838, DateTimeKind.Local).AddTicks(6078));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 838, DateTimeKind.Local).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 838, DateTimeKind.Local).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 838, DateTimeKind.Local).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 838, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 838, DateTimeKind.Local).AddTicks(5248));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 838, DateTimeKind.Local).AddTicks(5941));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 838, DateTimeKind.Local).AddTicks(5984));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 838, DateTimeKind.Local).AddTicks(5999));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 838, DateTimeKind.Local).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 838, DateTimeKind.Local).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(2271), new DateTime(2021, 12, 24, 19, 26, 26, 833, DateTimeKind.Local).AddTicks(357) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 24, 19, 26, 26, 837, DateTimeKind.Local).AddTicks(3183), new DateTime(2021, 12, 24, 22, 26, 26, 837, DateTimeKind.Local).AddTicks(3135) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 9, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3258), new DateTime(2021, 12, 25, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3216) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 8, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3339), new DateTime(2026, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3274) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 24, 15, 2, 26, 837, DateTimeKind.Local).AddTicks(3370), new DateTime(2036, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3358) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 23, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3411), new DateTime(2021, 12, 24, 11, 26, 26, 837, DateTimeKind.Local).AddTicks(3403) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3431), new DateTime(2021, 12, 12, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3425) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3449), new DateTime(2021, 11, 1, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3443) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3468), new DateTime(2022, 5, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3462) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3488), new DateTime(2021, 12, 24, 18, 26, 26, 837, DateTimeKind.Local).AddTicks(3482) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 24, 19, 26, 26, 837, DateTimeKind.Local).AddTicks(3505), new DateTime(2021, 12, 24, 21, 26, 26, 837, DateTimeKind.Local).AddTicks(3500) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 10, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3522), new DateTime(2021, 12, 26, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3516) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 13, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3539), new DateTime(2025, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3533) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 24, 15, 2, 26, 837, DateTimeKind.Local).AddTicks(3556), new DateTime(2036, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3549) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 22, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3573), new DateTime(2021, 12, 24, 10, 26, 26, 837, DateTimeKind.Local).AddTicks(3566) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3590), new DateTime(2021, 12, 11, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3584) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3607), new DateTime(2021, 11, 4, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3602) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3624), new DateTime(2022, 4, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3618) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3641), new DateTime(2021, 12, 24, 17, 26, 26, 837, DateTimeKind.Local).AddTicks(3635) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 24, 18, 26, 26, 837, DateTimeKind.Local).AddTicks(3657), new DateTime(2021, 12, 24, 20, 26, 26, 837, DateTimeKind.Local).AddTicks(3652) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 10, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3674), new DateTime(2021, 12, 25, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3668) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 17, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3692), new DateTime(2024, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3685) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 24, 14, 41, 26, 837, DateTimeKind.Local).AddTicks(3708), new DateTime(2034, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3702) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 21, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3725), new DateTime(2021, 12, 24, 11, 26, 26, 837, DateTimeKind.Local).AddTicks(3719) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3742), new DateTime(2021, 12, 14, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3736) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3854), new DateTime(2021, 11, 11, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3844) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3873), new DateTime(2022, 3, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3867) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3890), new DateTime(2021, 12, 24, 15, 26, 26, 837, DateTimeKind.Local).AddTicks(3884) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 24, 16, 26, 26, 837, DateTimeKind.Local).AddTicks(3908), new DateTime(2021, 12, 24, 18, 26, 26, 837, DateTimeKind.Local).AddTicks(3901) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 10, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3925), new DateTime(2021, 12, 29, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3920) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 13, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3943), new DateTime(2023, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3936) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 24, 15, 9, 26, 837, DateTimeKind.Local).AddTicks(3960), new DateTime(2031, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3954) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 19, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3977), new DateTime(2021, 12, 24, 2, 26, 26, 837, DateTimeKind.Local).AddTicks(3971) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3994), new DateTime(2021, 12, 17, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(3988) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(4017), new DateTime(2022, 2, 5, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(4011) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(4034), new DateTime(2022, 3, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(4028) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 838, DateTimeKind.Local).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 838, DateTimeKind.Local).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 838, DateTimeKind.Local).AddTicks(3056));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 838, DateTimeKind.Local).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 838, DateTimeKind.Local).AddTicks(3083));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 838, DateTimeKind.Local).AddTicks(3092));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 838, DateTimeKind.Local).AddTicks(3103));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(8598));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 24, 14, 26, 26, 837, DateTimeKind.Local).AddTicks(9533));
        }
    }
}
