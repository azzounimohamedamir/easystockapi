using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class addQuantityColumnToIngredientIllnessTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Quantity",
                table: "IngredientIllnesses",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 482, DateTimeKind.Local).AddTicks(932));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 482, DateTimeKind.Local).AddTicks(928));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 482, DateTimeKind.Local).AddTicks(911));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 482, DateTimeKind.Local).AddTicks(917));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 482, DateTimeKind.Local).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 482, DateTimeKind.Local).AddTicks(571));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 482, DateTimeKind.Local).AddTicks(882));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 482, DateTimeKind.Local).AddTicks(898));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 482, DateTimeKind.Local).AddTicks(903));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 482, DateTimeKind.Local).AddTicks(907));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 482, DateTimeKind.Local).AddTicks(924));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(3406), new DateTime(2022, 6, 2, 10, 35, 36, 480, DateTimeKind.Local).AddTicks(2082) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 10, 35, 36, 481, DateTimeKind.Local).AddTicks(3838), new DateTime(2022, 6, 2, 13, 35, 36, 481, DateTimeKind.Local).AddTicks(3814) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 18, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(3877), new DateTime(2022, 6, 3, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(3856) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 17, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(3947), new DateTime(2027, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(3882) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 6, 11, 36, 481, DateTimeKind.Local).AddTicks(3958), new DateTime(2037, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(3953) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 1, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(3976), new DateTime(2022, 6, 2, 2, 35, 36, 481, DateTimeKind.Local).AddTicks(3975) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(3981), new DateTime(2022, 5, 21, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(3980) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(3989), new DateTime(2022, 4, 10, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(3987) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(3995), new DateTime(2022, 11, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(3994) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4000), new DateTime(2022, 6, 2, 9, 35, 36, 481, DateTimeKind.Local).AddTicks(3999) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 10, 35, 36, 481, DateTimeKind.Local).AddTicks(4006), new DateTime(2022, 6, 2, 12, 35, 36, 481, DateTimeKind.Local).AddTicks(4004) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4014), new DateTime(2022, 6, 4, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4012) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 23, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4020), new DateTime(2026, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4018) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 6, 11, 36, 481, DateTimeKind.Local).AddTicks(4026), new DateTime(2037, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4025) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 31, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4033), new DateTime(2022, 6, 2, 1, 35, 36, 481, DateTimeKind.Local).AddTicks(4031) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4038), new DateTime(2022, 5, 20, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4037) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4045), new DateTime(2022, 4, 13, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4044) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4052), new DateTime(2022, 10, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4049) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4058), new DateTime(2022, 6, 2, 8, 35, 36, 481, DateTimeKind.Local).AddTicks(4056) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 9, 35, 36, 481, DateTimeKind.Local).AddTicks(4063), new DateTime(2022, 6, 2, 11, 35, 36, 481, DateTimeKind.Local).AddTicks(4061) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4069), new DateTime(2022, 6, 3, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4067) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 27, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4075), new DateTime(2025, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4074) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 5, 50, 36, 481, DateTimeKind.Local).AddTicks(4086), new DateTime(2035, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4082) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 30, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4094), new DateTime(2022, 6, 2, 2, 35, 36, 481, DateTimeKind.Local).AddTicks(4092) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4100), new DateTime(2022, 5, 23, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4099) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4106), new DateTime(2022, 4, 20, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4105) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4113), new DateTime(2022, 9, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4112) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4119), new DateTime(2022, 6, 2, 6, 35, 36, 481, DateTimeKind.Local).AddTicks(4118) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 7, 35, 36, 481, DateTimeKind.Local).AddTicks(4124), new DateTime(2022, 6, 2, 9, 35, 36, 481, DateTimeKind.Local).AddTicks(4123) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 19, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4129), new DateTime(2022, 6, 7, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4128) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 22, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4136), new DateTime(2024, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4134) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 2, 6, 18, 36, 481, DateTimeKind.Local).AddTicks(4142), new DateTime(2032, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4141) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 28, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4147), new DateTime(2022, 6, 1, 17, 35, 36, 481, DateTimeKind.Local).AddTicks(4146) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4154), new DateTime(2022, 5, 26, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4152) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4160), new DateTime(2022, 7, 15, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4158) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4167), new DateTime(2022, 9, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(4165) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(9501));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(9525));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(9528));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(9534));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(9538));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(7361));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(7379));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(7389));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(7395));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 2, 5, 35, 36, 481, DateTimeKind.Local).AddTicks(7401));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "IngredientIllnesses");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 240, DateTimeKind.Local).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 240, DateTimeKind.Local).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 240, DateTimeKind.Local).AddTicks(1423));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 240, DateTimeKind.Local).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 240, DateTimeKind.Local).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 240, DateTimeKind.Local).AddTicks(1009));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 240, DateTimeKind.Local).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 240, DateTimeKind.Local).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 240, DateTimeKind.Local).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 240, DateTimeKind.Local).AddTicks(1418));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 240, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(8770), new DateTime(2022, 5, 23, 17, 20, 7, 237, DateTimeKind.Local).AddTicks(8338) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 23, 17, 20, 7, 238, DateTimeKind.Local).AddTicks(9302), new DateTime(2022, 5, 23, 20, 20, 7, 238, DateTimeKind.Local).AddTicks(9276) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 8, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9344), new DateTime(2022, 5, 24, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9317) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 7, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9416), new DateTime(2027, 5, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9351) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 23, 12, 56, 7, 238, DateTimeKind.Local).AddTicks(9427), new DateTime(2037, 5, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9422) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 22, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9445), new DateTime(2022, 5, 23, 9, 20, 7, 238, DateTimeKind.Local).AddTicks(9444) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9451), new DateTime(2022, 5, 11, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9450) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9458), new DateTime(2022, 3, 31, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9457) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9464), new DateTime(2022, 10, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9462) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9469), new DateTime(2022, 5, 23, 16, 20, 7, 238, DateTimeKind.Local).AddTicks(9468) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 23, 17, 20, 7, 238, DateTimeKind.Local).AddTicks(9475), new DateTime(2022, 5, 23, 19, 20, 7, 238, DateTimeKind.Local).AddTicks(9473) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 9, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9479), new DateTime(2022, 5, 25, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9478) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 13, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9485), new DateTime(2026, 5, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9484) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 23, 12, 56, 7, 238, DateTimeKind.Local).AddTicks(9490), new DateTime(2037, 5, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9489) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 21, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9496), new DateTime(2022, 5, 23, 8, 20, 7, 238, DateTimeKind.Local).AddTicks(9494) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9501), new DateTime(2022, 5, 10, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9507), new DateTime(2022, 4, 3, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9506) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9513), new DateTime(2022, 9, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9511) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9518), new DateTime(2022, 5, 23, 15, 20, 7, 238, DateTimeKind.Local).AddTicks(9517) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 23, 16, 20, 7, 238, DateTimeKind.Local).AddTicks(9523), new DateTime(2022, 5, 23, 18, 20, 7, 238, DateTimeKind.Local).AddTicks(9522) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 9, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9528), new DateTime(2022, 5, 24, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9527) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 17, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9534), new DateTime(2025, 5, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9532) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 23, 12, 35, 7, 238, DateTimeKind.Local).AddTicks(9539), new DateTime(2035, 5, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9537) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 20, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9545), new DateTime(2022, 5, 23, 9, 20, 7, 238, DateTimeKind.Local).AddTicks(9543) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9549), new DateTime(2022, 5, 13, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9548) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9556), new DateTime(2022, 4, 10, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9554) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9562), new DateTime(2022, 8, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9560) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9568), new DateTime(2022, 5, 23, 13, 20, 7, 238, DateTimeKind.Local).AddTicks(9566) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 23, 14, 20, 7, 238, DateTimeKind.Local).AddTicks(9573), new DateTime(2022, 5, 23, 16, 20, 7, 238, DateTimeKind.Local).AddTicks(9571) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 9, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9577), new DateTime(2022, 5, 28, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9576) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 12, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9583), new DateTime(2024, 5, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9581) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 23, 13, 3, 7, 238, DateTimeKind.Local).AddTicks(9589), new DateTime(2032, 5, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9587) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 18, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9594), new DateTime(2022, 5, 23, 0, 20, 7, 238, DateTimeKind.Local).AddTicks(9593) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9599), new DateTime(2022, 5, 16, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9598) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9605), new DateTime(2022, 7, 5, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9604) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9612), new DateTime(2022, 8, 23, 12, 20, 7, 238, DateTimeKind.Local).AddTicks(9611) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 239, DateTimeKind.Local).AddTicks(8607));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 239, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 239, DateTimeKind.Local).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 239, DateTimeKind.Local).AddTicks(9482));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 239, DateTimeKind.Local).AddTicks(9487));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 239, DateTimeKind.Local).AddTicks(9491));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 239, DateTimeKind.Local).AddTicks(9495));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 239, DateTimeKind.Local).AddTicks(4212));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 239, DateTimeKind.Local).AddTicks(4639));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 239, DateTimeKind.Local).AddTicks(4659));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 239, DateTimeKind.Local).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 239, DateTimeKind.Local).AddTicks(4670));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 239, DateTimeKind.Local).AddTicks(4675));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 5, 23, 12, 20, 7, 239, DateTimeKind.Local).AddTicks(4680));
        }
    }
}
