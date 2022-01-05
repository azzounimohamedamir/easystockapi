using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class addMonthlyCommissionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlyCommission",
                columns: table => new
                {
                    MonthlyCommissionId = table.Column<Guid>(nullable: false),
                    TotalToPay = table.Column<float>(nullable: false),
                    numberOfOrdersOrPersons = table.Column<int>(nullable: false),
                    Month = table.Column<DateTime>(nullable: false),
                    CommissionConfigs_Value = table.Column<float>(nullable: true),
                    CommissionConfigs_Type = table.Column<int>(nullable: true),
                    CommissionConfigs_WhoPay = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    FoodBusinessId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyCommission", x => x.MonthlyCommissionId);
                    table.ForeignKey(
                        name: "FK_MonthlyCommission_FoodBusinesses_FoodBusinessId",
                        column: x => x.FoodBusinessId,
                        principalTable: "FoodBusinesses",
                        principalColumn: "FoodBusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(9109));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(9068));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(9090));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(7888));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(9044));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(4154), new DateTime(2022, 1, 3, 20, 16, 37, 98, DateTimeKind.Local).AddTicks(2000) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 20, 16, 37, 104, DateTimeKind.Local).AddTicks(6005), new DateTime(2022, 1, 3, 23, 16, 37, 104, DateTimeKind.Local).AddTicks(5918) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 19, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6135), new DateTime(2022, 1, 4, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6061) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 18, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6292), new DateTime(2027, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6166) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 52, 37, 104, DateTimeKind.Local).AddTicks(6351), new DateTime(2037, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6328) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 2, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6435), new DateTime(2022, 1, 3, 12, 16, 37, 104, DateTimeKind.Local).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6468), new DateTime(2021, 12, 22, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6457) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6503), new DateTime(2021, 11, 11, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6492) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6535), new DateTime(2022, 6, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6522) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6572), new DateTime(2022, 1, 3, 19, 16, 37, 104, DateTimeKind.Local).AddTicks(6560) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 20, 16, 37, 104, DateTimeKind.Local).AddTicks(6600), new DateTime(2022, 1, 3, 22, 16, 37, 104, DateTimeKind.Local).AddTicks(6591) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 20, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6629), new DateTime(2022, 1, 5, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6618) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 23, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6656), new DateTime(2026, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6646) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 52, 37, 104, DateTimeKind.Local).AddTicks(6696), new DateTime(2037, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6680) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 1, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6729), new DateTime(2022, 1, 3, 11, 16, 37, 104, DateTimeKind.Local).AddTicks(6717) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6755), new DateTime(2021, 12, 21, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6746) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6786), new DateTime(2021, 11, 14, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6775) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6814), new DateTime(2022, 5, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6804) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6850), new DateTime(2022, 1, 3, 18, 16, 37, 104, DateTimeKind.Local).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 19, 16, 37, 104, DateTimeKind.Local).AddTicks(6877), new DateTime(2022, 1, 3, 21, 16, 37, 104, DateTimeKind.Local).AddTicks(6869) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 20, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6904), new DateTime(2022, 1, 4, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6895) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 27, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6933), new DateTime(2025, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6922) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 31, 37, 104, DateTimeKind.Local).AddTicks(6964), new DateTime(2035, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(6952) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 31, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7000), new DateTime(2022, 1, 3, 12, 16, 37, 104, DateTimeKind.Local).AddTicks(6988) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7034), new DateTime(2021, 12, 24, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7022) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7066), new DateTime(2021, 11, 21, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7056) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7097), new DateTime(2022, 4, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7086) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7134), new DateTime(2022, 1, 3, 16, 16, 37, 104, DateTimeKind.Local).AddTicks(7122) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 17, 16, 37, 104, DateTimeKind.Local).AddTicks(7167), new DateTime(2022, 1, 3, 19, 16, 37, 104, DateTimeKind.Local).AddTicks(7155) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 20, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7194), new DateTime(2022, 1, 8, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7186) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 23, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7227), new DateTime(2024, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7214) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 15, 59, 37, 104, DateTimeKind.Local).AddTicks(7258), new DateTime(2032, 1, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7246) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 29, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7287), new DateTime(2022, 1, 3, 3, 16, 37, 104, DateTimeKind.Local).AddTicks(7277) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7317), new DateTime(2021, 12, 27, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7306) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7348), new DateTime(2022, 2, 15, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7337) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7381), new DateTime(2022, 4, 3, 15, 16, 37, 104, DateTimeKind.Local).AddTicks(7370) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(3045));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(3964));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(3983));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(4007));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(4029));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 106, DateTimeKind.Local).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 105, DateTimeKind.Local).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 105, DateTimeKind.Local).AddTicks(8502));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 105, DateTimeKind.Local).AddTicks(8557));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 105, DateTimeKind.Local).AddTicks(8573));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 105, DateTimeKind.Local).AddTicks(8586));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 105, DateTimeKind.Local).AddTicks(8599));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 1, 3, 15, 16, 37, 105, DateTimeKind.Local).AddTicks(8615));

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyCommission_FoodBusinessId",
                table: "MonthlyCommission",
                column: "FoodBusinessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlyCommission");

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
    }
}
