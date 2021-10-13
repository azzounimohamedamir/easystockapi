using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class UpdateFoodBusinessClientEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FoodBusinessId",
                table: "FoodBusinessClients",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 124, DateTimeKind.Local).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 124, DateTimeKind.Local).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 124, DateTimeKind.Local).AddTicks(2985));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 124, DateTimeKind.Local).AddTicks(2994));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 124, DateTimeKind.Local).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 124, DateTimeKind.Local).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 124, DateTimeKind.Local).AddTicks(2923));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 124, DateTimeKind.Local).AddTicks(2955));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 124, DateTimeKind.Local).AddTicks(2965));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 124, DateTimeKind.Local).AddTicks(2975));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 124, DateTimeKind.Local).AddTicks(3013));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 13, 2, 19, 122, DateTimeKind.Local).AddTicks(9570), new DateTime(2021, 10, 13, 18, 2, 19, 120, DateTimeKind.Local).AddTicks(5746) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 18, 2, 19, 123, DateTimeKind.Local).AddTicks(506), new DateTime(2021, 10, 13, 21, 2, 19, 123, DateTimeKind.Local).AddTicks(442) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(581), new DateTime(2021, 10, 14, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(540) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(713), new DateTime(2026, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(593) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 13, 38, 19, 123, DateTimeKind.Local).AddTicks(739), new DateTime(2036, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(727) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 12, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(780), new DateTime(2021, 10, 13, 10, 2, 19, 123, DateTimeKind.Local).AddTicks(770) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(792), new DateTime(2021, 10, 1, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(790) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(805), new DateTime(2021, 8, 21, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(802) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(821), new DateTime(2022, 3, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(816) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(835), new DateTime(2021, 10, 13, 17, 2, 19, 123, DateTimeKind.Local).AddTicks(832) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 18, 2, 19, 123, DateTimeKind.Local).AddTicks(850), new DateTime(2021, 10, 13, 20, 2, 19, 123, DateTimeKind.Local).AddTicks(847) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(861), new DateTime(2021, 10, 15, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(859) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 3, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(874), new DateTime(2025, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(871) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 13, 38, 19, 123, DateTimeKind.Local).AddTicks(892), new DateTime(2036, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(888) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(905), new DateTime(2021, 10, 13, 9, 2, 19, 123, DateTimeKind.Local).AddTicks(903) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(925), new DateTime(2021, 9, 30, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(922) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(937), new DateTime(2021, 8, 24, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(935) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1111), new DateTime(2022, 2, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1106) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1125), new DateTime(2021, 10, 13, 16, 2, 19, 123, DateTimeKind.Local).AddTicks(1120) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 17, 2, 19, 123, DateTimeKind.Local).AddTicks(1135), new DateTime(2021, 10, 13, 19, 2, 19, 123, DateTimeKind.Local).AddTicks(1133) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1148), new DateTime(2021, 10, 14, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1146) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 7, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1160), new DateTime(2024, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 13, 17, 19, 123, DateTimeKind.Local).AddTicks(1176), new DateTime(2034, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1173) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 10, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1190), new DateTime(2021, 10, 13, 10, 2, 19, 123, DateTimeKind.Local).AddTicks(1188) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1208), new DateTime(2021, 10, 3, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1206) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1221), new DateTime(2021, 8, 31, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1217) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1235), new DateTime(2022, 1, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1231) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1247), new DateTime(2021, 10, 13, 14, 2, 19, 123, DateTimeKind.Local).AddTicks(1244) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 15, 2, 19, 123, DateTimeKind.Local).AddTicks(1258), new DateTime(2021, 10, 13, 17, 2, 19, 123, DateTimeKind.Local).AddTicks(1255) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 29, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1272), new DateTime(2021, 10, 18, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1268) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 2, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1284), new DateTime(2023, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1282) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 13, 45, 19, 123, DateTimeKind.Local).AddTicks(1296), new DateTime(2031, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1294) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 8, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1310), new DateTime(2021, 10, 13, 1, 2, 19, 123, DateTimeKind.Local).AddTicks(1306) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1329), new DateTime(2021, 10, 6, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1323) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1341), new DateTime(2021, 11, 25, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1338) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1354), new DateTime(2022, 1, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(1351) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(8652));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(9408));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(9457));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(9473));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(9483));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(4852));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(5591));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(5636));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(5644));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(5653));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 13, 2, 19, 123, DateTimeKind.Local).AddTicks(5662));

            migrationBuilder.CreateIndex(
                name: "IX_FoodBusinessClients_FoodBusinessId",
                table: "FoodBusinessClients",
                column: "FoodBusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodBusinessClients_FoodBusinesses_FoodBusinessId",
                table: "FoodBusinessClients",
                column: "FoodBusinessId",
                principalTable: "FoodBusinesses",
                principalColumn: "FoodBusinessId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodBusinessClients_FoodBusinesses_FoodBusinessId",
                table: "FoodBusinessClients");

            migrationBuilder.DropIndex(
                name: "IX_FoodBusinessClients_FoodBusinessId",
                table: "FoodBusinessClients");

            migrationBuilder.DropColumn(
                name: "FoodBusinessId",
                table: "FoodBusinessClients");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 584, DateTimeKind.Local).AddTicks(865));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 584, DateTimeKind.Local).AddTicks(859));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 584, DateTimeKind.Local).AddTicks(837));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 584, DateTimeKind.Local).AddTicks(843));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 584, DateTimeKind.Local).AddTicks(849));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 584, DateTimeKind.Local).AddTicks(43));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 584, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 584, DateTimeKind.Local).AddTicks(820));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 584, DateTimeKind.Local).AddTicks(827));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 584, DateTimeKind.Local).AddTicks(832));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 584, DateTimeKind.Local).AddTicks(854));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(308), new DateTime(2021, 10, 13, 17, 35, 42, 580, DateTimeKind.Local).AddTicks(6148) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 17, 35, 42, 583, DateTimeKind.Local).AddTicks(1067), new DateTime(2021, 10, 13, 20, 35, 42, 583, DateTimeKind.Local).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1115), new DateTime(2021, 10, 14, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1088) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1204), new DateTime(2026, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1121) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 13, 11, 42, 583, DateTimeKind.Local).AddTicks(1219), new DateTime(2036, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1211) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1240), new DateTime(2021, 10, 13, 9, 35, 42, 583, DateTimeKind.Local).AddTicks(1238) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1248), new DateTime(2021, 10, 1, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1246) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1257), new DateTime(2021, 8, 21, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1255) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1266), new DateTime(2022, 3, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1264) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1274), new DateTime(2021, 10, 13, 16, 35, 42, 583, DateTimeKind.Local).AddTicks(1272) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 17, 35, 42, 583, DateTimeKind.Local).AddTicks(1280), new DateTime(2021, 10, 13, 19, 35, 42, 583, DateTimeKind.Local).AddTicks(1279) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 29, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1287), new DateTime(2021, 10, 15, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1285) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 3, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1295), new DateTime(2025, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1292) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 13, 11, 42, 583, DateTimeKind.Local).AddTicks(1303), new DateTime(2036, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1301) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1311), new DateTime(2021, 10, 13, 8, 35, 42, 583, DateTimeKind.Local).AddTicks(1309) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1317), new DateTime(2021, 9, 30, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1316) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1324), new DateTime(2021, 8, 24, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1323) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1335), new DateTime(2022, 2, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1333) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1343), new DateTime(2021, 10, 13, 15, 35, 42, 583, DateTimeKind.Local).AddTicks(1341) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 16, 35, 42, 583, DateTimeKind.Local).AddTicks(1351), new DateTime(2021, 10, 13, 18, 35, 42, 583, DateTimeKind.Local).AddTicks(1349) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 29, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1502), new DateTime(2021, 10, 14, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1499) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 7, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1510), new DateTime(2024, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1507) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 50, 42, 583, DateTimeKind.Local).AddTicks(1517), new DateTime(2034, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1515) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 10, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1525), new DateTime(2021, 10, 13, 9, 35, 42, 583, DateTimeKind.Local).AddTicks(1524) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1533), new DateTime(2021, 10, 3, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1532) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1541), new DateTime(2021, 8, 31, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1539) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1549), new DateTime(2022, 1, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1547) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1556), new DateTime(2021, 10, 13, 13, 35, 42, 583, DateTimeKind.Local).AddTicks(1554) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 14, 35, 42, 583, DateTimeKind.Local).AddTicks(1563), new DateTime(2021, 10, 13, 16, 35, 42, 583, DateTimeKind.Local).AddTicks(1561) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 29, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1570), new DateTime(2021, 10, 18, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1569) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 2, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1578), new DateTime(2023, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1576) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 13, 18, 42, 583, DateTimeKind.Local).AddTicks(1585), new DateTime(2031, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1583) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1594), new DateTime(2021, 10, 13, 0, 35, 42, 583, DateTimeKind.Local).AddTicks(1592) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1602), new DateTime(2021, 10, 6, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1600) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1611), new DateTime(2021, 11, 25, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1609) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1620), new DateTime(2022, 1, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(1616) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(7741));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(7762));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(7768));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(7774));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(7779));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(4822));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(4853));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 13, 12, 35, 42, 583, DateTimeKind.Local).AddTicks(4868));
        }
    }
}
