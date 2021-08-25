using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateSeedData_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodBusinessUsers",
                keyColumns: new[] { "ApplicationUserId", "FoodBusinessId" },
                keyValues: new object[] { "08a1a626-7f8e-4b51-84fc-fc51b6302cca", new Guid("88bc7853-220f-9173-3246-afb7cf595022") });

            migrationBuilder.DeleteData(
                table: "FoodBusinessUsers",
                keyColumns: new[] { "ApplicationUserId", "FoodBusinessId" },
                keyValues: new object[] { "3cbf3570-4444-4444-8746-29b7cf568093", new Guid("3cbf3570-4444-4673-8746-29b7cf568093") });

            migrationBuilder.DeleteData(
                table: "FoodBusinessUsers",
                keyColumns: new[] { "ApplicationUserId", "FoodBusinessId" },
                keyValues: new object[] { "44bf3570-0d44-4673-8746-29b7cf568088", new Guid("66bf3570-440d-4673-8746-29b7cf568099") });

            migrationBuilder.InsertData(
                table: "FoodBusinessUsers",
                columns: new[] { "ApplicationUserId", "FoodBusinessId" },
                values: new object[] { "d466ef00-61f1-4e77-801a-b516f0f12323", new Guid("3cbf3570-4444-4673-8746-29b7cf568093") });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodBusinessUsers",
                keyColumns: new[] { "ApplicationUserId", "FoodBusinessId" },
                keyValues: new object[] { "d466ef00-61f1-4e77-801a-b516f0f12323", new Guid("3cbf3570-4444-4673-8746-29b7cf568093") });

            migrationBuilder.InsertData(
                table: "FoodBusinessUsers",
                columns: new[] { "ApplicationUserId", "FoodBusinessId" },
                values: new object[,]
                {
                    { "3cbf3570-4444-4444-8746-29b7cf568093", new Guid("3cbf3570-4444-4673-8746-29b7cf568093") },
                    { "44bf3570-0d44-4673-8746-29b7cf568088", new Guid("66bf3570-440d-4673-8746-29b7cf568099") },
                    { "08a1a626-7f8e-4b51-84fc-fc51b6302cca", new Guid("88bc7853-220f-9173-3246-afb7cf595022") }
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8826));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8803));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8808));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8814));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8228));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8758));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8785));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8797));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(8820));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(7839), new DateTime(2021, 8, 22, 23, 2, 23, 938, DateTimeKind.Local).AddTicks(1975) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 22, 23, 2, 23, 939, DateTimeKind.Local).AddTicks(8600), new DateTime(2021, 8, 23, 2, 2, 23, 939, DateTimeKind.Local).AddTicks(8560) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 7, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8652), new DateTime(2021, 8, 23, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8622) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 6, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8762), new DateTime(2026, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8668) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 22, 18, 38, 23, 939, DateTimeKind.Local).AddTicks(8780), new DateTime(2036, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8773) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 21, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8812), new DateTime(2021, 8, 22, 15, 2, 23, 939, DateTimeKind.Local).AddTicks(8809) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8823), new DateTime(2021, 8, 10, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8821) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8833), new DateTime(2021, 6, 30, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8831) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8844), new DateTime(2022, 1, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8842) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8854), new DateTime(2021, 8, 22, 22, 2, 23, 939, DateTimeKind.Local).AddTicks(8852) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 22, 23, 2, 23, 939, DateTimeKind.Local).AddTicks(8863), new DateTime(2021, 8, 23, 1, 2, 23, 939, DateTimeKind.Local).AddTicks(8861) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 8, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8872), new DateTime(2021, 8, 24, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8869) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 12, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8881), new DateTime(2025, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(8878) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 22, 18, 38, 23, 939, DateTimeKind.Local).AddTicks(9076), new DateTime(2036, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9070) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 20, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9086), new DateTime(2021, 8, 22, 14, 2, 23, 939, DateTimeKind.Local).AddTicks(9085) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9097), new DateTime(2021, 8, 9, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9095) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9106), new DateTime(2021, 7, 3, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9104) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9114), new DateTime(2021, 12, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9112) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9125), new DateTime(2021, 8, 22, 21, 2, 23, 939, DateTimeKind.Local).AddTicks(9122) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 22, 22, 2, 23, 939, DateTimeKind.Local).AddTicks(9133), new DateTime(2021, 8, 23, 0, 2, 23, 939, DateTimeKind.Local).AddTicks(9131) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 8, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9141), new DateTime(2021, 8, 23, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9139) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9150), new DateTime(2024, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9148) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 22, 18, 17, 23, 939, DateTimeKind.Local).AddTicks(9160), new DateTime(2034, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9158) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 19, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9171), new DateTime(2021, 8, 22, 15, 2, 23, 939, DateTimeKind.Local).AddTicks(9169) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9180), new DateTime(2021, 8, 12, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9178) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9189), new DateTime(2021, 7, 10, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9187) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9198), new DateTime(2021, 11, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9196) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9206), new DateTime(2021, 8, 22, 19, 2, 23, 939, DateTimeKind.Local).AddTicks(9204) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 22, 20, 2, 23, 939, DateTimeKind.Local).AddTicks(9213), new DateTime(2021, 8, 22, 22, 2, 23, 939, DateTimeKind.Local).AddTicks(9211) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 8, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9219), new DateTime(2021, 8, 27, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9218) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 11, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9227), new DateTime(2023, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9225) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 22, 18, 45, 23, 939, DateTimeKind.Local).AddTicks(9234), new DateTime(2031, 8, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9232) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 17, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9244), new DateTime(2021, 8, 22, 6, 2, 23, 939, DateTimeKind.Local).AddTicks(9239) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9252), new DateTime(2021, 8, 15, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9250) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9259), new DateTime(2021, 10, 4, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9258) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9268), new DateTime(2021, 11, 22, 18, 2, 23, 939, DateTimeKind.Local).AddTicks(9266) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(5803));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(6387));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(6448));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(6462));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(6468));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(6473));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(2597));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(3239));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(3266));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(3275));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(3282));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(3287));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 22, 18, 2, 23, 940, DateTimeKind.Local).AddTicks(3295));
        }
    }
}
