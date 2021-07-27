using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateSeedData_06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FoodBusinesses",
                keyColumn: "FoodBusinessId",
                keyValue: new Guid("88bc7853-220f-9173-3246-afb7cf595022"),
                column: "Description",
                value: "ETuoYe SMdsYsup qqbdspY NEeZvsaI sUcIOE sVmPkJx RZFk FOKzUkG ffAsUB XyINU fhhIB OiIfN Antdhb XHbtaO UlStFP adgVv CRTToT Mcv FAHcd YyGH. CdDIPW TtDBaI qYg wVcSK NAXHnVC xpNBE fRufEW fggeTKc Iqq dfGZPAqoc MYxnH NCLtDA qqV TNYR LbwaYqv cvIiSvl KBTMl xAxHmu dilIqO mGM kxDhvLT PsYPdCB yZE uFfvGxQp uvoeDsAaE QQjgKs CnAnhrs qNPzSuq bvZjqMfy aaEGCqc XrvE KFXnmA mEnN uGHJt WypGwSiJDmP qBDWYau SzbxbSRUb CMwhBXiYA vQCTdtiB oVkRA XpHYTFE BYFpDTVlV zafiNugG YFyiIvYhhgyzj MihfVEqk OWlRLG YAUn sXWO jbKyczKOQfhXa qziTc xxMFCM WfVzT oPdKGSK Zz CzXeis.");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(2098));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(2077));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(2018));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(2046));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 653, DateTimeKind.Local).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 19, 40, 651, DateTimeKind.Local).AddTicks(9910), new DateTime(2021, 7, 28, 6, 19, 40, 647, DateTimeKind.Local).AddTicks(9630) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 6, 19, 40, 652, DateTimeKind.Local).AddTicks(822), new DateTime(2021, 7, 28, 9, 19, 40, 652, DateTimeKind.Local).AddTicks(774) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 13, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(892), new DateTime(2021, 7, 29, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(851) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 12, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(973), new DateTime(2026, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(908) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 55, 40, 652, DateTimeKind.Local).AddTicks(1003), new DateTime(2036, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(991) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1043), new DateTime(2021, 7, 27, 22, 19, 40, 652, DateTimeKind.Local).AddTicks(1035) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1064), new DateTime(2021, 7, 16, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1058) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1081), new DateTime(2021, 6, 5, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1076) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1099), new DateTime(2021, 12, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1093) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1115), new DateTime(2021, 7, 28, 5, 19, 40, 652, DateTimeKind.Local).AddTicks(1110) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 6, 19, 40, 652, DateTimeKind.Local).AddTicks(1133), new DateTime(2021, 7, 28, 8, 19, 40, 652, DateTimeKind.Local).AddTicks(1127) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1149), new DateTime(2021, 7, 30, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1144) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 17, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1168), new DateTime(2025, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1163) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 55, 40, 652, DateTimeKind.Local).AddTicks(1185), new DateTime(2036, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1179) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 26, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1202), new DateTime(2021, 7, 27, 21, 19, 40, 652, DateTimeKind.Local).AddTicks(1197) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1217), new DateTime(2021, 7, 15, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1212) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 4, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1233), new DateTime(2021, 6, 8, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1228) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1250), new DateTime(2021, 11, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1244) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1265), new DateTime(2021, 7, 28, 4, 19, 40, 652, DateTimeKind.Local).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 5, 19, 40, 652, DateTimeKind.Local).AddTicks(1281), new DateTime(2021, 7, 28, 7, 19, 40, 652, DateTimeKind.Local).AddTicks(1275) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1298), new DateTime(2021, 7, 29, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1293) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 21, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1315), new DateTime(2024, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1308) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 34, 40, 652, DateTimeKind.Local).AddTicks(1330), new DateTime(2034, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1325) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 25, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1346), new DateTime(2021, 7, 27, 22, 19, 40, 652, DateTimeKind.Local).AddTicks(1341) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1362), new DateTime(2021, 7, 18, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1357) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1378), new DateTime(2021, 6, 15, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1372) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1395), new DateTime(2021, 10, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1389) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1410), new DateTime(2021, 7, 28, 2, 19, 40, 652, DateTimeKind.Local).AddTicks(1405) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 3, 19, 40, 652, DateTimeKind.Local).AddTicks(1425), new DateTime(2021, 7, 28, 5, 19, 40, 652, DateTimeKind.Local).AddTicks(1420) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1444), new DateTime(2021, 8, 2, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1437) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 17, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1461), new DateTime(2023, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1455) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 2, 2, 40, 652, DateTimeKind.Local).AddTicks(1477), new DateTime(2031, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1471) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 23, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1492), new DateTime(2021, 7, 27, 13, 19, 40, 652, DateTimeKind.Local).AddTicks(1487) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1508), new DateTime(2021, 7, 21, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1502) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1523), new DateTime(2021, 9, 9, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1518) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1539), new DateTime(2021, 10, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(1533) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(8915));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(8985));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(8999));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(9009));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(9019));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(9028));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(5099));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(5161));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(5172));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(5185));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 1, 19, 40, 652, DateTimeKind.Local).AddTicks(5197));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FoodBusinesses",
                keyColumn: "FoodBusinessId",
                keyValue: new Guid("88bc7853-220f-9173-3246-afb7cf595022"),
                column: "Description",
                value: "ETuoYeSMdsYsupqqbdspYNEeZvsaIsUcIOEsVmPkJxRZFkFOKzUkGffAsUBXyINUfhhIBOiIfNAntdhbXHbtaOUlStFPadgVvCRTToTMcvFAHcdYyGHCdDIPWTtDBaIqYgwVcSKNAXHnVCxpNBEfRufEWfggeTKcIqqdfGZPAqocMYxnHNCLtDAqqVTNYRLbwaYqvcvIiSvlKBTMlxAxHmudilIqOmGMkxDhvLTPsYPdCByZEuFfvGxQpuvoeDsAaEQQjgKsCnAnhrsqNPzSuqbvZjqMfyaaEGCqcXrvEKFXnmAmEnNuGHJtWypGwSiJDmPqBDWYauSzbxbSRUbCMwhBXiYAvQCTdtiBoVkRAXpHYTFEBYFpDTVlVzafiNugGYFyiIvYhhgyzjMihfVEqkOWlRLGYAUnsXWOjbKyczKOQfhXaqziTcxxMFCMWfVzToPdKGSKZzCzXeisjsHKGUgtwjBACUhPDjcnwmbmOodlJqfyYLsa");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(973));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(958));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(803));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(815));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(826));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(6));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(716));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(781));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(792));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 730, DateTimeKind.Local).AddTicks(837));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(7483), new DateTime(2021, 7, 28, 1, 0, 36, 723, DateTimeKind.Local).AddTicks(8702) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 0, 36, 728, DateTimeKind.Local).AddTicks(8517), new DateTime(2021, 7, 28, 4, 0, 36, 728, DateTimeKind.Local).AddTicks(8457) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8599), new DateTime(2021, 7, 28, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8554) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 11, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8694), new DateTime(2026, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8617) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 20, 36, 36, 728, DateTimeKind.Local).AddTicks(8727), new DateTime(2036, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8715) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 26, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8770), new DateTime(2021, 7, 27, 17, 0, 36, 728, DateTimeKind.Local).AddTicks(8761) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8791), new DateTime(2021, 7, 15, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8786) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8959), new DateTime(2021, 6, 4, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8947) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8980), new DateTime(2021, 12, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8974) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(8997), new DateTime(2021, 7, 28, 0, 0, 36, 728, DateTimeKind.Local).AddTicks(8992) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 1, 0, 36, 728, DateTimeKind.Local).AddTicks(9017), new DateTime(2021, 7, 28, 3, 0, 36, 728, DateTimeKind.Local).AddTicks(9012) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 13, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9036), new DateTime(2021, 7, 29, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9030) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 16, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9055), new DateTime(2025, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9048) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 20, 36, 36, 728, DateTimeKind.Local).AddTicks(9076), new DateTime(2036, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9069) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 25, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9094), new DateTime(2021, 7, 27, 16, 0, 36, 728, DateTimeKind.Local).AddTicks(9088) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9110), new DateTime(2021, 7, 14, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9105) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 4, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9129), new DateTime(2021, 6, 7, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9123) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9147), new DateTime(2021, 11, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9141) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9165), new DateTime(2021, 7, 27, 23, 0, 36, 728, DateTimeKind.Local).AddTicks(9159) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 0, 0, 36, 728, DateTimeKind.Local).AddTicks(9181), new DateTime(2021, 7, 28, 2, 0, 36, 728, DateTimeKind.Local).AddTicks(9176) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 13, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9203), new DateTime(2021, 7, 28, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9193) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 20, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9226), new DateTime(2024, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9218) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 20, 15, 36, 728, DateTimeKind.Local).AddTicks(9244), new DateTime(2034, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9238) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9260), new DateTime(2021, 7, 27, 17, 0, 36, 728, DateTimeKind.Local).AddTicks(9255) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9278), new DateTime(2021, 7, 17, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9272) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9295), new DateTime(2021, 6, 14, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9289) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9312), new DateTime(2021, 10, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9306) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9331), new DateTime(2021, 7, 27, 21, 0, 36, 728, DateTimeKind.Local).AddTicks(9325) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 22, 0, 36, 728, DateTimeKind.Local).AddTicks(9349), new DateTime(2021, 7, 28, 0, 0, 36, 728, DateTimeKind.Local).AddTicks(9343) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 13, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9365), new DateTime(2021, 8, 1, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 16, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9387), new DateTime(2023, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9379) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 20, 43, 36, 728, DateTimeKind.Local).AddTicks(9406), new DateTime(2031, 7, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9400) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 22, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9423), new DateTime(2021, 7, 27, 8, 0, 36, 728, DateTimeKind.Local).AddTicks(9417) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9440), new DateTime(2021, 7, 20, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9434) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9457), new DateTime(2021, 9, 8, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9452) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9475), new DateTime(2021, 10, 27, 20, 0, 36, 728, DateTimeKind.Local).AddTicks(9469) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(7420));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(7520));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(7548));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(7559));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(3535));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(3605));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(3619));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(3631));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 20, 0, 36, 729, DateTimeKind.Local).AddTicks(3644));
        }
    }
}
