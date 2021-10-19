using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class UpdateFoodBusinessEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultCurrencyId",
                table: "FoodBusinesses");

            migrationBuilder.AddColumn<int>(
                name: "DefaultCurrency",
                table: "FoodBusinesses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 434, DateTimeKind.Local).AddTicks(3938));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 434, DateTimeKind.Local).AddTicks(3926));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 434, DateTimeKind.Local).AddTicks(3883));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 434, DateTimeKind.Local).AddTicks(3894));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 434, DateTimeKind.Local).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 434, DateTimeKind.Local).AddTicks(3109));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 434, DateTimeKind.Local).AddTicks(3797));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 434, DateTimeKind.Local).AddTicks(3845));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 434, DateTimeKind.Local).AddTicks(3859));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 434, DateTimeKind.Local).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 434, DateTimeKind.Local).AddTicks(3916));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(1946), new DateTime(2021, 10, 19, 13, 40, 55, 429, DateTimeKind.Local).AddTicks(453) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 19, 13, 40, 55, 433, DateTimeKind.Local).AddTicks(2863), new DateTime(2021, 10, 19, 16, 40, 55, 433, DateTimeKind.Local).AddTicks(2810) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 4, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(2945), new DateTime(2021, 10, 20, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(2900) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3032), new DateTime(2026, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(2962) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 19, 9, 16, 55, 433, DateTimeKind.Local).AddTicks(3062), new DateTime(2036, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3051) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 18, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3103), new DateTime(2021, 10, 19, 5, 40, 55, 433, DateTimeKind.Local).AddTicks(3095) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3119), new DateTime(2021, 10, 7, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3114) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3142), new DateTime(2021, 8, 27, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3136) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3159), new DateTime(2022, 3, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3154) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3180), new DateTime(2021, 10, 19, 12, 40, 55, 433, DateTimeKind.Local).AddTicks(3174) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 19, 13, 40, 55, 433, DateTimeKind.Local).AddTicks(3196), new DateTime(2021, 10, 19, 15, 40, 55, 433, DateTimeKind.Local).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3213), new DateTime(2021, 10, 21, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3207) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 9, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3230), new DateTime(2025, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3224) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 19, 9, 16, 55, 433, DateTimeKind.Local).AddTicks(3248), new DateTime(2036, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3241) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 17, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3265), new DateTime(2021, 10, 19, 4, 40, 55, 433, DateTimeKind.Local).AddTicks(3259) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3281), new DateTime(2021, 10, 6, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3276) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3300), new DateTime(2021, 8, 30, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3295) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3320), new DateTime(2022, 2, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3314) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3336), new DateTime(2021, 10, 19, 11, 40, 55, 433, DateTimeKind.Local).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 19, 12, 40, 55, 433, DateTimeKind.Local).AddTicks(3351), new DateTime(2021, 10, 19, 14, 40, 55, 433, DateTimeKind.Local).AddTicks(3346) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3368), new DateTime(2021, 10, 20, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3363) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 13, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3384), new DateTime(2024, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3378) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 19, 8, 55, 55, 433, DateTimeKind.Local).AddTicks(3400), new DateTime(2034, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3394) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3415), new DateTime(2021, 10, 19, 5, 40, 55, 433, DateTimeKind.Local).AddTicks(3410) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3432), new DateTime(2021, 10, 9, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3426) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3479), new DateTime(2021, 9, 6, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3472) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3498), new DateTime(2022, 1, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3491) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3514), new DateTime(2021, 10, 19, 9, 40, 55, 433, DateTimeKind.Local).AddTicks(3509) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 19, 10, 40, 55, 433, DateTimeKind.Local).AddTicks(3530), new DateTime(2021, 10, 19, 12, 40, 55, 433, DateTimeKind.Local).AddTicks(3524) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3545), new DateTime(2021, 10, 24, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3540) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 8, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3561), new DateTime(2023, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3555) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 19, 9, 23, 55, 433, DateTimeKind.Local).AddTicks(3577), new DateTime(2031, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3571) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3592), new DateTime(2021, 10, 18, 20, 40, 55, 433, DateTimeKind.Local).AddTicks(3587) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3607), new DateTime(2021, 10, 12, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3602) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3623), new DateTime(2021, 12, 1, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3618) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3641), new DateTime(2022, 1, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(3635) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 434, DateTimeKind.Local).AddTicks(87));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 434, DateTimeKind.Local).AddTicks(843));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 434, DateTimeKind.Local).AddTicks(891));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 434, DateTimeKind.Local).AddTicks(906));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 434, DateTimeKind.Local).AddTicks(917));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 434, DateTimeKind.Local).AddTicks(928));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 434, DateTimeKind.Local).AddTicks(940));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(7192));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(7244));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(7260));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(7272));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(7283));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 19, 8, 40, 55, 433, DateTimeKind.Local).AddTicks(7295));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultCurrency",
                table: "FoodBusinesses");

            migrationBuilder.AddColumn<Guid>(
                name: "DefaultCurrencyId",
                table: "FoodBusinesses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(7125));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(7113));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(7078));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(6193));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(6892));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(7049));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(5002), new DateTime(2021, 10, 16, 23, 22, 51, 670, DateTimeKind.Local).AddTicks(5208) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 23, 22, 51, 674, DateTimeKind.Local).AddTicks(6071), new DateTime(2021, 10, 17, 2, 22, 51, 674, DateTimeKind.Local).AddTicks(6018) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 1, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6146), new DateTime(2021, 10, 17, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6100) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 31, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6234), new DateTime(2026, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6165) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 18, 58, 51, 674, DateTimeKind.Local).AddTicks(6263), new DateTime(2036, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6251) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6304), new DateTime(2021, 10, 16, 15, 22, 51, 674, DateTimeKind.Local).AddTicks(6295) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6323), new DateTime(2021, 10, 4, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6316) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6342), new DateTime(2021, 8, 24, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6336) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6360), new DateTime(2022, 3, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6354) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6378), new DateTime(2021, 10, 16, 22, 22, 51, 674, DateTimeKind.Local).AddTicks(6371) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 23, 22, 51, 674, DateTimeKind.Local).AddTicks(6398), new DateTime(2021, 10, 17, 1, 22, 51, 674, DateTimeKind.Local).AddTicks(6392) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6415), new DateTime(2021, 10, 18, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6409) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 6, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6434), new DateTime(2025, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6427) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 18, 58, 51, 674, DateTimeKind.Local).AddTicks(6453), new DateTime(2036, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6446) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6471), new DateTime(2021, 10, 16, 14, 22, 51, 674, DateTimeKind.Local).AddTicks(6465) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6488), new DateTime(2021, 10, 3, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6481) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6505), new DateTime(2021, 8, 27, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6499) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6527), new DateTime(2022, 2, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6545), new DateTime(2021, 10, 16, 21, 22, 51, 674, DateTimeKind.Local).AddTicks(6539) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 22, 22, 51, 674, DateTimeKind.Local).AddTicks(6562), new DateTime(2021, 10, 17, 0, 22, 51, 674, DateTimeKind.Local).AddTicks(6556) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6579), new DateTime(2021, 10, 17, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6573) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 10, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6597), new DateTime(2024, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6590) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 18, 37, 51, 674, DateTimeKind.Local).AddTicks(6615), new DateTime(2034, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6609) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6631), new DateTime(2021, 10, 16, 15, 22, 51, 674, DateTimeKind.Local).AddTicks(6626) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6648), new DateTime(2021, 10, 6, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6666), new DateTime(2021, 9, 3, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6660) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6686), new DateTime(2022, 1, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6680) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6703), new DateTime(2021, 10, 16, 19, 22, 51, 674, DateTimeKind.Local).AddTicks(6698) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 20, 22, 51, 674, DateTimeKind.Local).AddTicks(6719), new DateTime(2021, 10, 16, 22, 22, 51, 674, DateTimeKind.Local).AddTicks(6714) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6736), new DateTime(2021, 10, 21, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6731) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 5, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6753), new DateTime(2023, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6747) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 19, 5, 51, 674, DateTimeKind.Local).AddTicks(6771), new DateTime(2031, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6764) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6787), new DateTime(2021, 10, 16, 6, 22, 51, 674, DateTimeKind.Local).AddTicks(6781) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6803), new DateTime(2021, 10, 9, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6798) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6820), new DateTime(2021, 11, 28, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6814) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6836), new DateTime(2022, 1, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6830) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(3186));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(3943));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(3989));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(4014));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(4026));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(9533));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(345));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(358));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(370));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(382));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(395));
        }
    }
}
