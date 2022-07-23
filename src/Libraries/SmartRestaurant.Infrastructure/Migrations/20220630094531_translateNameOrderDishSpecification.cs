using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class translateNameOrderDishSpecification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Names_AR",
                table: "OrderDishSpecifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_EN",
                table: "OrderDishSpecifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_FR",
                table: "OrderDishSpecifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_RU",
                table: "OrderDishSpecifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_TR",
                table: "OrderDishSpecifications",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 293, DateTimeKind.Local).AddTicks(862));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 293, DateTimeKind.Local).AddTicks(859));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 293, DateTimeKind.Local).AddTicks(843));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 293, DateTimeKind.Local).AddTicks(847));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 293, DateTimeKind.Local).AddTicks(851));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 293, DateTimeKind.Local).AddTicks(475));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 293, DateTimeKind.Local).AddTicks(813));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 293, DateTimeKind.Local).AddTicks(830));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 293, DateTimeKind.Local).AddTicks(834));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 293, DateTimeKind.Local).AddTicks(839));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 293, DateTimeKind.Local).AddTicks(855));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(3645), new DateTime(2022, 6, 30, 15, 45, 30, 290, DateTimeKind.Local).AddTicks(9091) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 15, 45, 30, 292, DateTimeKind.Local).AddTicks(4179), new DateTime(2022, 6, 30, 18, 45, 30, 292, DateTimeKind.Local).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 15, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4215), new DateTime(2022, 7, 1, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4193) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 15, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4284), new DateTime(2027, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4221) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 11, 21, 30, 292, DateTimeKind.Local).AddTicks(4295), new DateTime(2037, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4290) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 29, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4312), new DateTime(2022, 6, 30, 7, 45, 30, 292, DateTimeKind.Local).AddTicks(4311) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4317), new DateTime(2022, 6, 18, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4316) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4325), new DateTime(2022, 5, 8, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4324) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4331), new DateTime(2022, 11, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4329) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4337), new DateTime(2022, 6, 30, 14, 45, 30, 292, DateTimeKind.Local).AddTicks(4335) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 15, 45, 30, 292, DateTimeKind.Local).AddTicks(4342), new DateTime(2022, 6, 30, 17, 45, 30, 292, DateTimeKind.Local).AddTicks(4341) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 16, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4347), new DateTime(2022, 7, 2, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4346) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 20, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4353), new DateTime(2026, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4351) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 11, 21, 30, 292, DateTimeKind.Local).AddTicks(4358), new DateTime(2037, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4357) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 28, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4364), new DateTime(2022, 6, 30, 6, 45, 30, 292, DateTimeKind.Local).AddTicks(4362) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4369), new DateTime(2022, 6, 17, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4368) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4375), new DateTime(2022, 5, 11, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4374) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4381), new DateTime(2022, 10, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4379) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4386), new DateTime(2022, 6, 30, 13, 45, 30, 292, DateTimeKind.Local).AddTicks(4385) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 14, 45, 30, 292, DateTimeKind.Local).AddTicks(4392), new DateTime(2022, 6, 30, 16, 45, 30, 292, DateTimeKind.Local).AddTicks(4391) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 16, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4397), new DateTime(2022, 7, 1, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4396) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 24, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4404), new DateTime(2025, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4402) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 11, 0, 30, 292, DateTimeKind.Local).AddTicks(4409), new DateTime(2035, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4408) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 27, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4414), new DateTime(2022, 6, 30, 7, 45, 30, 292, DateTimeKind.Local).AddTicks(4413) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4420), new DateTime(2022, 6, 20, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4418) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4425), new DateTime(2022, 5, 18, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4424) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4431), new DateTime(2022, 9, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4429) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4436), new DateTime(2022, 6, 30, 11, 45, 30, 292, DateTimeKind.Local).AddTicks(4435) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 12, 45, 30, 292, DateTimeKind.Local).AddTicks(4442), new DateTime(2022, 6, 30, 14, 45, 30, 292, DateTimeKind.Local).AddTicks(4441) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 16, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4463), new DateTime(2022, 7, 5, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4462) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 20, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4470), new DateTime(2024, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4468) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 30, 11, 28, 30, 292, DateTimeKind.Local).AddTicks(4476), new DateTime(2032, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4474) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 25, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4481), new DateTime(2022, 6, 29, 22, 45, 30, 292, DateTimeKind.Local).AddTicks(4480) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4486), new DateTime(2022, 6, 23, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4485) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4492), new DateTime(2022, 8, 12, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4491) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4498), new DateTime(2022, 9, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(4496) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(8978));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(9365));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(9369));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(9373));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(9376));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(9380));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(7177));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(7578));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(7584));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(7594));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 30, 10, 45, 30, 292, DateTimeKind.Local).AddTicks(7598));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Names_AR",
                table: "OrderDishSpecifications");

            migrationBuilder.DropColumn(
                name: "Names_EN",
                table: "OrderDishSpecifications");

            migrationBuilder.DropColumn(
                name: "Names_FR",
                table: "OrderDishSpecifications");

            migrationBuilder.DropColumn(
                name: "Names_RU",
                table: "OrderDishSpecifications");

            migrationBuilder.DropColumn(
                name: "Names_TR",
                table: "OrderDishSpecifications");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(6798));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(6795));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(6779));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(6447));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(6751));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(6771));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(6775));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(143), new DateTime(2022, 6, 21, 15, 33, 57, 477, DateTimeKind.Local).AddTicks(9944) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 21, 15, 33, 57, 479, DateTimeKind.Local).AddTicks(562), new DateTime(2022, 6, 21, 18, 33, 57, 479, DateTimeKind.Local).AddTicks(538) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 6, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(594), new DateTime(2022, 6, 22, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(575) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 6, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(661), new DateTime(2027, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(600) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 21, 11, 9, 57, 479, DateTimeKind.Local).AddTicks(669), new DateTime(2037, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(665) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 20, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(686), new DateTime(2022, 6, 21, 7, 33, 57, 479, DateTimeKind.Local).AddTicks(684) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(691), new DateTime(2022, 6, 9, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(690) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(697), new DateTime(2022, 4, 29, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(696) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(703), new DateTime(2022, 11, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(701) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(708), new DateTime(2022, 6, 21, 14, 33, 57, 479, DateTimeKind.Local).AddTicks(706) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 21, 15, 33, 57, 479, DateTimeKind.Local).AddTicks(714), new DateTime(2022, 6, 21, 17, 33, 57, 479, DateTimeKind.Local).AddTicks(713) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 7, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(719), new DateTime(2022, 6, 23, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(718) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 11, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(724), new DateTime(2026, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(723) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 21, 11, 9, 57, 479, DateTimeKind.Local).AddTicks(729), new DateTime(2037, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(728) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 19, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(734), new DateTime(2022, 6, 21, 6, 33, 57, 479, DateTimeKind.Local).AddTicks(733) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(739), new DateTime(2022, 6, 8, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(737) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(744), new DateTime(2022, 5, 2, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(742) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(749), new DateTime(2022, 10, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(747) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(754), new DateTime(2022, 6, 21, 13, 33, 57, 479, DateTimeKind.Local).AddTicks(752) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 21, 14, 33, 57, 479, DateTimeKind.Local).AddTicks(759), new DateTime(2022, 6, 21, 16, 33, 57, 479, DateTimeKind.Local).AddTicks(758) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 7, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(764), new DateTime(2022, 6, 22, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(762) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 15, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(769), new DateTime(2025, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(767) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 21, 10, 48, 57, 479, DateTimeKind.Local).AddTicks(774), new DateTime(2035, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(773) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 18, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(779), new DateTime(2022, 6, 21, 7, 33, 57, 479, DateTimeKind.Local).AddTicks(778) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(786), new DateTime(2022, 6, 11, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(784) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(791), new DateTime(2022, 5, 9, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(789) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(796), new DateTime(2022, 9, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(794) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(801), new DateTime(2022, 6, 21, 11, 33, 57, 479, DateTimeKind.Local).AddTicks(800) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 21, 12, 33, 57, 479, DateTimeKind.Local).AddTicks(806), new DateTime(2022, 6, 21, 14, 33, 57, 479, DateTimeKind.Local).AddTicks(805) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 7, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(811), new DateTime(2022, 6, 26, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(810) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 11, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(817), new DateTime(2024, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(815) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 21, 11, 16, 57, 479, DateTimeKind.Local).AddTicks(822), new DateTime(2032, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(820) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 16, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(827), new DateTime(2022, 6, 20, 22, 33, 57, 479, DateTimeKind.Local).AddTicks(826) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(832), new DateTime(2022, 6, 14, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(831) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(837), new DateTime(2022, 8, 3, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(836) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(843), new DateTime(2022, 9, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(841) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(5075));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(5424));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(5428));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(5432));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(5436));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(5440));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(2992));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(3332));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(3349));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(3353));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(3358));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(3362));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 21, 10, 33, 57, 479, DateTimeKind.Local).AddTicks(3367));
        }
    }
}
