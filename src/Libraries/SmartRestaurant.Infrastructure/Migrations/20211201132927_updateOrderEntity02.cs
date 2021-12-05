using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateOrderEntity02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TableId",
                table: "OrderProducts",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "InitialPrice",
                table: "OrderDishes",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "TableId",
                table: "OrderDishes",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8968));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8923));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8934));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8827));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8874));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8888));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8899));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(8946));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(6643), new DateTime(2021, 12, 1, 19, 29, 25, 829, DateTimeKind.Local).AddTicks(5006) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 19, 29, 25, 833, DateTimeKind.Local).AddTicks(7601), new DateTime(2021, 12, 1, 22, 29, 25, 833, DateTimeKind.Local).AddTicks(7545) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 16, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7673), new DateTime(2021, 12, 2, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7632) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 16, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7759), new DateTime(2026, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7690) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 15, 5, 25, 833, DateTimeKind.Local).AddTicks(7794), new DateTime(2036, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7782) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 30, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7835), new DateTime(2021, 12, 1, 11, 29, 25, 833, DateTimeKind.Local).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7852), new DateTime(2021, 11, 19, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7846) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7869), new DateTime(2021, 10, 9, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7864) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7886), new DateTime(2022, 5, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7902), new DateTime(2021, 12, 1, 18, 29, 25, 833, DateTimeKind.Local).AddTicks(7896) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 19, 29, 25, 833, DateTimeKind.Local).AddTicks(7918), new DateTime(2021, 12, 1, 21, 29, 25, 833, DateTimeKind.Local).AddTicks(7913) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7934), new DateTime(2021, 12, 3, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7928) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 21, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7951), new DateTime(2025, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7944) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 15, 5, 25, 833, DateTimeKind.Local).AddTicks(7969), new DateTime(2036, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7962) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 29, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(7985), new DateTime(2021, 12, 1, 10, 29, 25, 833, DateTimeKind.Local).AddTicks(7980) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8100), new DateTime(2021, 11, 18, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8089) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8118), new DateTime(2021, 10, 12, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8112) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8134), new DateTime(2022, 4, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8129) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8151), new DateTime(2021, 12, 1, 17, 29, 25, 833, DateTimeKind.Local).AddTicks(8146) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 18, 29, 25, 833, DateTimeKind.Local).AddTicks(8167), new DateTime(2021, 12, 1, 20, 29, 25, 833, DateTimeKind.Local).AddTicks(8162) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8183), new DateTime(2021, 12, 2, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8177) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 25, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8201), new DateTime(2024, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8195) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 14, 44, 25, 833, DateTimeKind.Local).AddTicks(8220), new DateTime(2034, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8213) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8235), new DateTime(2021, 12, 1, 11, 29, 25, 833, DateTimeKind.Local).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8252), new DateTime(2021, 11, 21, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8246) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8268), new DateTime(2021, 10, 19, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8263) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8285), new DateTime(2022, 3, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8280) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8302), new DateTime(2021, 12, 1, 15, 29, 25, 833, DateTimeKind.Local).AddTicks(8296) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 16, 29, 25, 833, DateTimeKind.Local).AddTicks(8318), new DateTime(2021, 12, 1, 18, 29, 25, 833, DateTimeKind.Local).AddTicks(8312) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 17, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8336), new DateTime(2021, 12, 6, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8331) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 21, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8355), new DateTime(2023, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8349) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 15, 12, 25, 833, DateTimeKind.Local).AddTicks(8371), new DateTime(2031, 12, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8365) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 26, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8388), new DateTime(2021, 12, 1, 2, 29, 25, 833, DateTimeKind.Local).AddTicks(8382) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8402), new DateTime(2021, 11, 24, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8397) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8418), new DateTime(2022, 1, 13, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8414) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8435), new DateTime(2022, 3, 1, 14, 29, 25, 833, DateTimeKind.Local).AddTicks(8429) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(5027));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(5807));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(5888));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(5898));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(2159));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(2172));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(2182));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 12, 1, 14, 29, 25, 834, DateTimeKind.Local).AddTicks(2204));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "InitialPrice",
                table: "OrderDishes");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "OrderDishes");

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
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(294));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(1056));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(1103));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(1118));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(1129));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 28, 16, 13, 52, 861, DateTimeKind.Local).AddTicks(1150));

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
    }
}
