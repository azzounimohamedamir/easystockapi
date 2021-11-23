using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddFoodBusinessClientToOrderEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FoodBusinessClientId",
                table: "Orders",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9321));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9311));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9271));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9282));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9291));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(8484));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9190));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9236));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9252));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9261));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(9301));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(7085), new DateTime(2021, 11, 23, 16, 55, 7, 914, DateTimeKind.Local).AddTicks(7077) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 16, 55, 7, 918, DateTimeKind.Local).AddTicks(7996), new DateTime(2021, 11, 23, 19, 55, 7, 918, DateTimeKind.Local).AddTicks(7939) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 8, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8073), new DateTime(2021, 11, 24, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8028) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 8, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8160), new DateTime(2026, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8089) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 12, 31, 7, 918, DateTimeKind.Local).AddTicks(8191), new DateTime(2036, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8179) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 22, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8239), new DateTime(2021, 11, 23, 8, 55, 7, 918, DateTimeKind.Local).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8257), new DateTime(2021, 11, 11, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8252) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8273), new DateTime(2021, 10, 1, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8268) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8290), new DateTime(2022, 4, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8285) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8305), new DateTime(2021, 11, 23, 15, 55, 7, 918, DateTimeKind.Local).AddTicks(8300) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 16, 55, 7, 918, DateTimeKind.Local).AddTicks(8321), new DateTime(2021, 11, 23, 18, 55, 7, 918, DateTimeKind.Local).AddTicks(8316) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8338), new DateTime(2021, 11, 25, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8331) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 13, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8353), new DateTime(2025, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8347) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 12, 31, 7, 918, DateTimeKind.Local).AddTicks(8369), new DateTime(2036, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8363) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 21, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8384), new DateTime(2021, 11, 23, 7, 55, 7, 918, DateTimeKind.Local).AddTicks(8379) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8402), new DateTime(2021, 11, 10, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8396) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8417), new DateTime(2021, 10, 4, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8412) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8433), new DateTime(2022, 3, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8428) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8449), new DateTime(2021, 11, 23, 14, 55, 7, 918, DateTimeKind.Local).AddTicks(8443) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 15, 55, 7, 918, DateTimeKind.Local).AddTicks(8463), new DateTime(2021, 11, 23, 17, 55, 7, 918, DateTimeKind.Local).AddTicks(8458) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8478), new DateTime(2021, 11, 24, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8473) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 17, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8494), new DateTime(2024, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8488) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 12, 10, 7, 918, DateTimeKind.Local).AddTicks(8509), new DateTime(2034, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8503) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 20, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8523), new DateTime(2021, 11, 23, 8, 55, 7, 918, DateTimeKind.Local).AddTicks(8518) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8539), new DateTime(2021, 11, 13, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8533) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8555), new DateTime(2021, 10, 11, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8550) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8571), new DateTime(2022, 2, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8565) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8586), new DateTime(2021, 11, 23, 12, 55, 7, 918, DateTimeKind.Local).AddTicks(8581) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 13, 55, 7, 918, DateTimeKind.Local).AddTicks(8600), new DateTime(2021, 11, 23, 15, 55, 7, 918, DateTimeKind.Local).AddTicks(8595) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8614), new DateTime(2021, 11, 28, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8609) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 13, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8629), new DateTime(2023, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8623) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 12, 38, 7, 918, DateTimeKind.Local).AddTicks(8644), new DateTime(2031, 11, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8639) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 18, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8658), new DateTime(2021, 11, 22, 23, 55, 7, 918, DateTimeKind.Local).AddTicks(8653) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8672), new DateTime(2021, 11, 16, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8668) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8689), new DateTime(2022, 1, 5, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8683) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8705), new DateTime(2022, 2, 23, 11, 55, 7, 918, DateTimeKind.Local).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(5306));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(6129));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(6145));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(6156));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(6165));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(6261));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(2391));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(2454));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(2465));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(2475));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 23, 11, 55, 7, 919, DateTimeKind.Local).AddTicks(2485));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FoodBusinessClientId",
                table: "Orders",
                column: "FoodBusinessClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FoodBusinessId",
                table: "Orders",
                column: "FoodBusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FoodBusinessClients_FoodBusinessClientId",
                table: "Orders",
                column: "FoodBusinessClientId",
                principalTable: "FoodBusinessClients",
                principalColumn: "FoodBusinessClientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FoodBusinesses_FoodBusinessId",
                table: "Orders",
                column: "FoodBusinessId",
                principalTable: "FoodBusinesses",
                principalColumn: "FoodBusinessId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FoodBusinessClients_FoodBusinessClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FoodBusinesses_FoodBusinessId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FoodBusinessClientId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FoodBusinessId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FoodBusinessClientId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6852));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6830));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6786));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(5462));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6589));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6668));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6696));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6719));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(6807));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(8069), new DateTime(2021, 11, 9, 7, 55, 52, 24, DateTimeKind.Local).AddTicks(2558) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 7, 55, 52, 29, DateTimeKind.Local).AddTicks(9454), new DateTime(2021, 11, 9, 10, 55, 52, 29, DateTimeKind.Local).AddTicks(9372) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9573), new DateTime(2021, 11, 10, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9508) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 24, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9719), new DateTime(2026, 11, 9, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9606) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 3, 31, 52, 29, DateTimeKind.Local).AddTicks(9773), new DateTime(2036, 11, 9, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9753) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 8, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9851), new DateTime(2021, 11, 8, 23, 55, 52, 29, DateTimeKind.Local).AddTicks(9834) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 9, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9881), new DateTime(2021, 10, 28, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9870) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 9, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9914), new DateTime(2021, 9, 17, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9903) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 9, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9946), new DateTime(2022, 4, 9, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9935) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 2, 55, 52, 29, DateTimeKind.Local).AddTicks(9981), new DateTime(2021, 11, 9, 6, 55, 52, 29, DateTimeKind.Local).AddTicks(9969) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 7, 55, 52, 30, DateTimeKind.Local).AddTicks(11), new DateTime(2021, 11, 9, 9, 55, 52, 30, DateTimeKind.Local).AddTicks(1) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 26, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(41), new DateTime(2021, 11, 11, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(31) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 30, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(72), new DateTime(2025, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(61) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 3, 31, 52, 30, DateTimeKind.Local).AddTicks(151), new DateTime(2036, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(135) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(189), new DateTime(2021, 11, 8, 22, 55, 52, 30, DateTimeKind.Local).AddTicks(179) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(218), new DateTime(2021, 10, 27, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(209) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(250), new DateTime(2021, 9, 20, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(281), new DateTime(2022, 3, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(270) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(312), new DateTime(2021, 11, 9, 5, 55, 52, 30, DateTimeKind.Local).AddTicks(302) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 6, 55, 52, 30, DateTimeKind.Local).AddTicks(342), new DateTime(2021, 11, 9, 8, 55, 52, 30, DateTimeKind.Local).AddTicks(332) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 26, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(374), new DateTime(2021, 11, 10, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(364) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(407), new DateTime(2024, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(396) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 3, 10, 52, 30, DateTimeKind.Local).AddTicks(438), new DateTime(2034, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(427) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 6, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(468), new DateTime(2021, 11, 8, 23, 55, 52, 30, DateTimeKind.Local).AddTicks(457) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(499), new DateTime(2021, 10, 30, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(489) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(531), new DateTime(2021, 9, 27, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(519) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(566), new DateTime(2022, 2, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(554) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(598), new DateTime(2021, 11, 9, 3, 55, 52, 30, DateTimeKind.Local).AddTicks(587) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 4, 55, 52, 30, DateTimeKind.Local).AddTicks(627), new DateTime(2021, 11, 9, 6, 55, 52, 30, DateTimeKind.Local).AddTicks(618) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 26, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(658), new DateTime(2021, 11, 14, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(647) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 29, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(691), new DateTime(2023, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(679) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 3, 38, 52, 30, DateTimeKind.Local).AddTicks(725), new DateTime(2031, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(713) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 4, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(757), new DateTime(2021, 11, 8, 14, 55, 52, 30, DateTimeKind.Local).AddTicks(746) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(792), new DateTime(2021, 11, 2, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(781) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(825), new DateTime(2021, 12, 22, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(814) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(859), new DateTime(2022, 2, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(846) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(568));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(1856));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 31, DateTimeKind.Local).AddTicks(2034));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(6110));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(6142));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 9, 2, 55, 52, 30, DateTimeKind.Local).AddTicks(6215));
        }
    }
}
