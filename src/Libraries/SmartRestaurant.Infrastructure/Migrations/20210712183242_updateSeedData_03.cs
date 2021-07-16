using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateSeedData_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorType",
                table: "Reservations",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 19, 32, 41, 409, DateTimeKind.Local).AddTicks(8110), "Diner", new DateTime(2021, 7, 13, 0, 32, 41, 406, DateTimeKind.Local).AddTicks(6278) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 13, 0, 32, 41, 410, DateTimeKind.Local).AddTicks(691), "Diner", new DateTime(2021, 7, 13, 3, 32, 41, 410, DateTimeKind.Local).AddTicks(573) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 27, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(791), "Diner", new DateTime(2021, 7, 13, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(735) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(930), "Diner", new DateTime(2026, 7, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(802) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 20, 8, 41, 410, DateTimeKind.Local).AddTicks(955), "Diner", new DateTime(2036, 7, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(945) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 11, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(989), "Diner", new DateTime(2021, 7, 12, 16, 32, 41, 410, DateTimeKind.Local).AddTicks(986) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(999), "Diner", new DateTime(2021, 6, 30, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(997) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1012), "Diner", new DateTime(2021, 5, 20, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1009) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1025), "Diner", new DateTime(2021, 12, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1023) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1037), "Diner", new DateTime(2021, 7, 12, 23, 32, 41, 410, DateTimeKind.Local).AddTicks(1035) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 13, 0, 32, 41, 410, DateTimeKind.Local).AddTicks(1047), "Diner", new DateTime(2021, 7, 13, 2, 32, 41, 410, DateTimeKind.Local).AddTicks(1045) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1268), "Diner", new DateTime(2021, 7, 14, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1263) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 1, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1281), "Diner", new DateTime(2025, 7, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1277) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 20, 8, 41, 410, DateTimeKind.Local).AddTicks(1293), "Diner", new DateTime(2036, 7, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1289) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 10, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1304), "Diner", new DateTime(2021, 7, 12, 15, 32, 41, 410, DateTimeKind.Local).AddTicks(1301) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1314), "Diner", new DateTime(2021, 6, 29, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1312) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 4, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1325), "Diner", new DateTime(2021, 5, 23, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1323) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1338), "Diner", new DateTime(2021, 11, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1336) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1352), "FoodBusinessManager", new DateTime(2021, 7, 12, 22, 32, 41, 410, DateTimeKind.Local).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 23, 32, 41, 410, DateTimeKind.Local).AddTicks(1362), "FoodBusinessManager", new DateTime(2021, 7, 13, 1, 32, 41, 410, DateTimeKind.Local).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1371), "FoodBusinessManager", new DateTime(2021, 7, 13, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1369) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 5, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1382), "FoodBusinessManager", new DateTime(2024, 7, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1379) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 19, 47, 41, 410, DateTimeKind.Local).AddTicks(1393), "FoodBusinessManager", new DateTime(2034, 7, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 9, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1402), "FoodBusinessManager", new DateTime(2021, 7, 12, 16, 32, 41, 410, DateTimeKind.Local).AddTicks(1400) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1412), "FoodBusinessManager", new DateTime(2021, 7, 2, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1410) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1421), "FoodBusinessManager", new DateTime(2021, 5, 30, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1419) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1434), "FoodBusinessManager", new DateTime(2021, 10, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1431) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1444), "FoodBusinessManager", new DateTime(2021, 7, 12, 20, 32, 41, 410, DateTimeKind.Local).AddTicks(1442) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 21, 32, 41, 410, DateTimeKind.Local).AddTicks(1454), "FoodBusinessManager", new DateTime(2021, 7, 12, 23, 32, 41, 410, DateTimeKind.Local).AddTicks(1452) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1465), "FoodBusinessManager", new DateTime(2021, 7, 17, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1463) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 1, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1475), "FoodBusinessManager", new DateTime(2023, 7, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1473) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 20, 15, 41, 410, DateTimeKind.Local).AddTicks(1485), "FoodBusinessManager", new DateTime(2031, 7, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1483) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 7, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1495), "FoodBusinessManager", new DateTime(2021, 7, 12, 7, 32, 41, 410, DateTimeKind.Local).AddTicks(1493) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1504), "FoodBusinessManager", new DateTime(2021, 7, 5, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1502) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1514), "FoodBusinessManager", new DateTime(2021, 8, 24, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1512) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "CreatorType", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1526), "FoodBusinessManager", new DateTime(2021, 10, 12, 19, 32, 41, 410, DateTimeKind.Local).AddTicks(1523) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorType",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(7057), new DateTime(2021, 7, 12, 4, 41, 10, 628, DateTimeKind.Local).AddTicks(635) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 4, 41, 10, 630, DateTimeKind.Local).AddTicks(8076), new DateTime(2021, 7, 12, 7, 41, 10, 630, DateTimeKind.Local).AddTicks(7983) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 26, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8141), new DateTime(2021, 7, 12, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8103) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 26, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8278), new DateTime(2026, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8155) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 0, 17, 10, 630, DateTimeKind.Local).AddTicks(8300), new DateTime(2036, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8291) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 10, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8335), new DateTime(2021, 7, 11, 20, 41, 10, 630, DateTimeKind.Local).AddTicks(8332) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8345), new DateTime(2021, 6, 29, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8343) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8357), new DateTime(2021, 5, 19, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8355) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8368), new DateTime(2021, 12, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8365) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8378), new DateTime(2021, 7, 12, 3, 41, 10, 630, DateTimeKind.Local).AddTicks(8375) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 4, 41, 10, 630, DateTimeKind.Local).AddTicks(8386), new DateTime(2021, 7, 12, 6, 41, 10, 630, DateTimeKind.Local).AddTicks(8384) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 27, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8396), new DateTime(2021, 7, 13, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8394) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 31, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8406), new DateTime(2025, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8403) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 0, 17, 10, 630, DateTimeKind.Local).AddTicks(8418), new DateTime(2036, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8415) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 9, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8427), new DateTime(2021, 7, 11, 19, 41, 10, 630, DateTimeKind.Local).AddTicks(8425) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8437), new DateTime(2021, 6, 28, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8434) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 4, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8446), new DateTime(2021, 5, 22, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8444) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8455), new DateTime(2021, 11, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8453) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8465), new DateTime(2021, 7, 12, 2, 41, 10, 630, DateTimeKind.Local).AddTicks(8463) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 3, 41, 10, 630, DateTimeKind.Local).AddTicks(8474), new DateTime(2021, 7, 12, 5, 41, 10, 630, DateTimeKind.Local).AddTicks(8472) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 27, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8486), new DateTime(2021, 7, 12, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8484) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 4, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8497), new DateTime(2024, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8494) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 11, 23, 56, 10, 630, DateTimeKind.Local).AddTicks(8509), new DateTime(2034, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8507) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 8, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8519), new DateTime(2021, 7, 11, 20, 41, 10, 630, DateTimeKind.Local).AddTicks(8516) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8527), new DateTime(2021, 7, 1, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8525) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8537), new DateTime(2021, 5, 29, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8534) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8547), new DateTime(2021, 10, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8544) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8738), new DateTime(2021, 7, 12, 0, 41, 10, 630, DateTimeKind.Local).AddTicks(8733) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 1, 41, 10, 630, DateTimeKind.Local).AddTicks(8749), new DateTime(2021, 7, 12, 3, 41, 10, 630, DateTimeKind.Local).AddTicks(8746) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 27, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8758), new DateTime(2021, 7, 16, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8756) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 31, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8769), new DateTime(2023, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8766) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 0, 24, 10, 630, DateTimeKind.Local).AddTicks(8778), new DateTime(2031, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8776) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 6, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8787), new DateTime(2021, 7, 11, 11, 41, 10, 630, DateTimeKind.Local).AddTicks(8785) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8797), new DateTime(2021, 7, 4, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8794) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8806), new DateTime(2021, 8, 23, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8804) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8817), new DateTime(2021, 10, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8814) });
        }
    }
}
