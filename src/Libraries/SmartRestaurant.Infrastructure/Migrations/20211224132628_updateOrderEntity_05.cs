using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateOrderEntity_05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Discount",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "Discount",
                table: "OrderProducts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "Discount",
                table: "OrderDishes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Discount",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "Discount",
                table: "OrderProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "Discount",
                table: "OrderDishes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

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
        }
    }
}
