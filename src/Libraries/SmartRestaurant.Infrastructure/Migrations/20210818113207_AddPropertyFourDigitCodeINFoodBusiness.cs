using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddPropertyFourDigitCodeINFoodBusiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FourDigitCode",
                table: "FoodBusinesses",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(7251));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(7134));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(7139));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(7145));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(6534));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(7088));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(7115));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(7122));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(7127));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(7150));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(7102), new DateTime(2021, 8, 18, 17, 32, 6, 273, DateTimeKind.Local).AddTicks(1399) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 18, 17, 32, 6, 274, DateTimeKind.Local).AddTicks(7819), new DateTime(2021, 8, 18, 20, 32, 6, 274, DateTimeKind.Local).AddTicks(7781) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 3, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(7872), new DateTime(2021, 8, 19, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(7844) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 2, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(7972), new DateTime(2026, 8, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 18, 13, 8, 6, 274, DateTimeKind.Local).AddTicks(7992), new DateTime(2036, 8, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(7984) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 17, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8021), new DateTime(2021, 8, 18, 9, 32, 6, 274, DateTimeKind.Local).AddTicks(8018) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8137), new DateTime(2021, 8, 6, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8133) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8146), new DateTime(2021, 6, 26, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8156), new DateTime(2022, 1, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8154) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8165), new DateTime(2021, 8, 18, 16, 32, 6, 274, DateTimeKind.Local).AddTicks(8163) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 18, 17, 32, 6, 274, DateTimeKind.Local).AddTicks(8175), new DateTime(2021, 8, 18, 19, 32, 6, 274, DateTimeKind.Local).AddTicks(8173) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 4, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8185), new DateTime(2021, 8, 20, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8183) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8193), new DateTime(2025, 8, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8191) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 18, 13, 8, 6, 274, DateTimeKind.Local).AddTicks(8203), new DateTime(2036, 8, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8200) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 16, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8211), new DateTime(2021, 8, 18, 8, 32, 6, 274, DateTimeKind.Local).AddTicks(8209) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8219), new DateTime(2021, 8, 5, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8218) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8227), new DateTime(2021, 6, 29, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8226) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8236), new DateTime(2021, 12, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8234) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8245), new DateTime(2021, 8, 18, 15, 32, 6, 274, DateTimeKind.Local).AddTicks(8243) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 18, 16, 32, 6, 274, DateTimeKind.Local).AddTicks(8253), new DateTime(2021, 8, 18, 18, 32, 6, 274, DateTimeKind.Local).AddTicks(8251) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 4, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8263), new DateTime(2021, 8, 19, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8261) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8271), new DateTime(2024, 8, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8269) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 18, 12, 47, 6, 274, DateTimeKind.Local).AddTicks(8280), new DateTime(2034, 8, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8278) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 15, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8288), new DateTime(2021, 8, 18, 9, 32, 6, 274, DateTimeKind.Local).AddTicks(8286) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8296), new DateTime(2021, 8, 8, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8294) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8304), new DateTime(2021, 7, 6, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8302) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8312), new DateTime(2021, 11, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8309) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8320), new DateTime(2021, 8, 18, 13, 32, 6, 274, DateTimeKind.Local).AddTicks(8318) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 18, 14, 32, 6, 274, DateTimeKind.Local).AddTicks(8327), new DateTime(2021, 8, 18, 16, 32, 6, 274, DateTimeKind.Local).AddTicks(8325) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 4, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8336), new DateTime(2021, 8, 23, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8334) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 7, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8345), new DateTime(2023, 8, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 18, 13, 15, 6, 274, DateTimeKind.Local).AddTicks(8354), new DateTime(2031, 8, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8352) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 13, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8361), new DateTime(2021, 8, 18, 0, 32, 6, 274, DateTimeKind.Local).AddTicks(8360) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8369), new DateTime(2021, 8, 11, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8367) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8378), new DateTime(2021, 9, 30, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8376) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8386), new DateTime(2021, 11, 18, 12, 32, 6, 274, DateTimeKind.Local).AddTicks(8384) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(3941));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(4656));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(4669));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(4675));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(1108));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(1688));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(1715));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(1731));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 18, 12, 32, 6, 275, DateTimeKind.Local).AddTicks(1746));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FourDigitCode",
                table: "FoodBusinesses");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 392, DateTimeKind.Local).AddTicks(3059));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 392, DateTimeKind.Local).AddTicks(3053));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 392, DateTimeKind.Local).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 392, DateTimeKind.Local).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 392, DateTimeKind.Local).AddTicks(3043));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 392, DateTimeKind.Local).AddTicks(2420));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 392, DateTimeKind.Local).AddTicks(2984));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 392, DateTimeKind.Local).AddTicks(3010));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 392, DateTimeKind.Local).AddTicks(3018));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 392, DateTimeKind.Local).AddTicks(3025));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 392, DateTimeKind.Local).AddTicks(3048));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(3822), new DateTime(2021, 8, 5, 17, 11, 9, 390, DateTimeKind.Local).AddTicks(599) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 5, 17, 11, 9, 391, DateTimeKind.Local).AddTicks(4471), new DateTime(2021, 8, 5, 20, 11, 9, 391, DateTimeKind.Local).AddTicks(4434) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 21, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4513), new DateTime(2021, 8, 6, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4487) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 20, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4608), new DateTime(2026, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4524) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 5, 12, 47, 9, 391, DateTimeKind.Local).AddTicks(4625), new DateTime(2036, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4618) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 4, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4651), new DateTime(2021, 8, 5, 9, 11, 9, 391, DateTimeKind.Local).AddTicks(4648) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4659), new DateTime(2021, 7, 24, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4657) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4668), new DateTime(2021, 6, 13, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4666) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4676), new DateTime(2022, 1, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4674) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4683), new DateTime(2021, 8, 5, 16, 11, 9, 391, DateTimeKind.Local).AddTicks(4682) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 5, 17, 11, 9, 391, DateTimeKind.Local).AddTicks(4692), new DateTime(2021, 8, 5, 19, 11, 9, 391, DateTimeKind.Local).AddTicks(4690) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 22, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4699), new DateTime(2021, 8, 7, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4697) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 25, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4709), new DateTime(2025, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4706) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 5, 12, 47, 9, 391, DateTimeKind.Local).AddTicks(4717), new DateTime(2036, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4715) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 3, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4726), new DateTime(2021, 8, 5, 8, 11, 9, 391, DateTimeKind.Local).AddTicks(4724) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4734), new DateTime(2021, 7, 23, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4732) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4741), new DateTime(2021, 6, 16, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4739) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4749), new DateTime(2021, 12, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4747) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4757), new DateTime(2021, 8, 5, 15, 11, 9, 391, DateTimeKind.Local).AddTicks(4754) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 5, 16, 11, 9, 391, DateTimeKind.Local).AddTicks(4764), new DateTime(2021, 8, 5, 18, 11, 9, 391, DateTimeKind.Local).AddTicks(4762) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 22, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4771), new DateTime(2021, 8, 6, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4769) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 29, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4778), new DateTime(2024, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4776) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 5, 12, 26, 9, 391, DateTimeKind.Local).AddTicks(4788), new DateTime(2034, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4786) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 2, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4795), new DateTime(2021, 8, 5, 9, 11, 9, 391, DateTimeKind.Local).AddTicks(4794) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4802), new DateTime(2021, 7, 26, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4801) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4811), new DateTime(2021, 6, 23, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4809) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4819), new DateTime(2021, 11, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4817) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4827), new DateTime(2021, 8, 5, 13, 11, 9, 391, DateTimeKind.Local).AddTicks(4825) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 5, 14, 11, 9, 391, DateTimeKind.Local).AddTicks(4834), new DateTime(2021, 8, 5, 16, 11, 9, 391, DateTimeKind.Local).AddTicks(4832) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 22, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4842), new DateTime(2021, 8, 10, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4840) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 25, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4851), new DateTime(2023, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4848) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 5, 12, 54, 9, 391, DateTimeKind.Local).AddTicks(4860), new DateTime(2031, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4858) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 31, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4867), new DateTime(2021, 8, 5, 0, 11, 9, 391, DateTimeKind.Local).AddTicks(4866) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4875), new DateTime(2021, 7, 29, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4873) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4883), new DateTime(2021, 9, 17, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4881) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4891), new DateTime(2021, 11, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(4889) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 392, DateTimeKind.Local).AddTicks(349));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 392, DateTimeKind.Local).AddTicks(394));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 392, DateTimeKind.Local).AddTicks(401));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 392, DateTimeKind.Local).AddTicks(407));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 392, DateTimeKind.Local).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 392, DateTimeKind.Local).AddTicks(417));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(6974));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(7556));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(7603));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(7612));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(7617));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(7623));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 5, 12, 11, 9, 391, DateTimeKind.Local).AddTicks(7630));
        }
    }
}
