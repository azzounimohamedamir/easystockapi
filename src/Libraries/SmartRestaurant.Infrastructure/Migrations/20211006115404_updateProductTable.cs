using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sections_SectionId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubSections_SubSectionId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SectionId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SubSectionId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubSectionId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(5101));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(5002));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(5028));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(3620));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(6042), new DateTime(2021, 10, 6, 18, 54, 3, 15, DateTimeKind.Local).AddTicks(1264) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 18, 54, 3, 22, DateTimeKind.Local).AddTicks(7539), new DateTime(2021, 10, 6, 21, 54, 3, 22, DateTimeKind.Local).AddTicks(7454) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 21, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(7671), new DateTime(2021, 10, 7, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(7593) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 21, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(7831), new DateTime(2026, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(7702) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 14, 30, 3, 22, DateTimeKind.Local).AddTicks(7893), new DateTime(2036, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(7867) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(7980), new DateTime(2021, 10, 6, 10, 54, 3, 22, DateTimeKind.Local).AddTicks(7960) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8016), new DateTime(2021, 9, 24, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8004) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8055), new DateTime(2021, 8, 14, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8041) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8092), new DateTime(2022, 3, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8079) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8129), new DateTime(2021, 10, 6, 17, 54, 3, 22, DateTimeKind.Local).AddTicks(8117) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 18, 54, 3, 22, DateTimeKind.Local).AddTicks(8162), new DateTime(2021, 10, 6, 20, 54, 3, 22, DateTimeKind.Local).AddTicks(8150) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 22, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8195), new DateTime(2021, 10, 8, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8183) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 26, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8234), new DateTime(2025, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8219) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 14, 30, 3, 22, DateTimeKind.Local).AddTicks(8272), new DateTime(2036, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8258) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 4, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8305), new DateTime(2021, 10, 6, 9, 54, 3, 22, DateTimeKind.Local).AddTicks(8295) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8338), new DateTime(2021, 9, 23, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8327) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8373), new DateTime(2021, 8, 17, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8362) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8406), new DateTime(2022, 2, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8395) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8442), new DateTime(2021, 10, 6, 16, 54, 3, 22, DateTimeKind.Local).AddTicks(8430) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 17, 54, 3, 22, DateTimeKind.Local).AddTicks(8474), new DateTime(2021, 10, 6, 19, 54, 3, 22, DateTimeKind.Local).AddTicks(8462) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 22, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8506), new DateTime(2021, 10, 7, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8495) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 30, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8540), new DateTime(2024, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8527) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 14, 9, 3, 22, DateTimeKind.Local).AddTicks(8573), new DateTime(2034, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8561) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 3, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8605), new DateTime(2021, 10, 6, 10, 54, 3, 22, DateTimeKind.Local).AddTicks(8595) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8640), new DateTime(2021, 9, 26, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8629) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8673), new DateTime(2021, 8, 24, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8661) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8708), new DateTime(2022, 1, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8696) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8740), new DateTime(2021, 10, 6, 14, 54, 3, 22, DateTimeKind.Local).AddTicks(8729) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 15, 54, 3, 22, DateTimeKind.Local).AddTicks(8777), new DateTime(2021, 10, 6, 17, 54, 3, 22, DateTimeKind.Local).AddTicks(8764) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 22, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8811), new DateTime(2021, 10, 11, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 26, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8845), new DateTime(2023, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8833) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 14, 37, 3, 22, DateTimeKind.Local).AddTicks(8877), new DateTime(2031, 10, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8865) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 1, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8908), new DateTime(2021, 10, 6, 1, 54, 3, 22, DateTimeKind.Local).AddTicks(8898) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8944), new DateTime(2021, 9, 29, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8932) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8976), new DateTime(2021, 11, 18, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8964) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(9010), new DateTime(2022, 1, 6, 13, 54, 3, 22, DateTimeKind.Local).AddTicks(8997) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 23, DateTimeKind.Local).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(18));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(90));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(103));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(114));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 24, DateTimeKind.Local).AddTicks(124));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 23, DateTimeKind.Local).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 23, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 23, DateTimeKind.Local).AddTicks(4716));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 23, DateTimeKind.Local).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 23, DateTimeKind.Local).AddTicks(4769));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 23, DateTimeKind.Local).AddTicks(4793));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 6, 13, 54, 3, 23, DateTimeKind.Local).AddTicks(4818));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SectionId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubSectionId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 416, DateTimeKind.Local).AddTicks(1227));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 416, DateTimeKind.Local).AddTicks(1216));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 416, DateTimeKind.Local).AddTicks(1173));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 416, DateTimeKind.Local).AddTicks(1185));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 416, DateTimeKind.Local).AddTicks(1196));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 416, DateTimeKind.Local).AddTicks(398));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 416, DateTimeKind.Local).AddTicks(1092));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 416, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 416, DateTimeKind.Local).AddTicks(1153));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 416, DateTimeKind.Local).AddTicks(1163));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 416, DateTimeKind.Local).AddTicks(1206));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 14, 52, 53, 414, DateTimeKind.Local).AddTicks(9265), new DateTime(2021, 10, 5, 19, 52, 53, 410, DateTimeKind.Local).AddTicks(9173) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 19, 52, 53, 415, DateTimeKind.Local).AddTicks(217), new DateTime(2021, 10, 5, 22, 52, 53, 415, DateTimeKind.Local).AddTicks(169) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 20, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(284), new DateTime(2021, 10, 6, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(243) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 20, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(370), new DateTime(2026, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(300) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 15, 28, 53, 415, DateTimeKind.Local).AddTicks(403), new DateTime(2036, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(391) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 4, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(445), new DateTime(2021, 10, 5, 11, 52, 53, 415, DateTimeKind.Local).AddTicks(437) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(461), new DateTime(2021, 9, 23, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(456) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(478), new DateTime(2021, 8, 13, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(473) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(495), new DateTime(2022, 3, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(489) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(511), new DateTime(2021, 10, 5, 18, 52, 53, 415, DateTimeKind.Local).AddTicks(506) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 19, 52, 53, 415, DateTimeKind.Local).AddTicks(527), new DateTime(2021, 10, 5, 21, 52, 53, 415, DateTimeKind.Local).AddTicks(521) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 21, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(543), new DateTime(2021, 10, 7, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(538) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 25, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(560), new DateTime(2025, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(554) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 15, 28, 53, 415, DateTimeKind.Local).AddTicks(577), new DateTime(2036, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(570) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 3, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(594), new DateTime(2021, 10, 5, 10, 52, 53, 415, DateTimeKind.Local).AddTicks(589) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(610), new DateTime(2021, 9, 22, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(605) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(625), new DateTime(2021, 8, 16, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(620) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(641), new DateTime(2022, 2, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(635) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(657), new DateTime(2021, 10, 5, 17, 52, 53, 415, DateTimeKind.Local).AddTicks(652) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 18, 52, 53, 415, DateTimeKind.Local).AddTicks(672), new DateTime(2021, 10, 5, 20, 52, 53, 415, DateTimeKind.Local).AddTicks(667) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 21, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(686), new DateTime(2021, 10, 6, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(681) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 29, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(702), new DateTime(2024, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(696) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 15, 7, 53, 415, DateTimeKind.Local).AddTicks(718), new DateTime(2034, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(712) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(736), new DateTime(2021, 10, 5, 11, 52, 53, 415, DateTimeKind.Local).AddTicks(731) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(752), new DateTime(2021, 9, 25, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(747) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(768), new DateTime(2021, 8, 23, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(763) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(783), new DateTime(2022, 1, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(778) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(799), new DateTime(2021, 10, 5, 15, 52, 53, 415, DateTimeKind.Local).AddTicks(794) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 16, 52, 53, 415, DateTimeKind.Local).AddTicks(814), new DateTime(2021, 10, 5, 18, 52, 53, 415, DateTimeKind.Local).AddTicks(808) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 21, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(830), new DateTime(2021, 10, 10, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(824) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(845), new DateTime(2023, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(839) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 15, 35, 53, 415, DateTimeKind.Local).AddTicks(862), new DateTime(2031, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(856) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 30, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(878), new DateTime(2021, 10, 5, 2, 52, 53, 415, DateTimeKind.Local).AddTicks(872) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(900), new DateTime(2021, 9, 28, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(894) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(915), new DateTime(2021, 11, 17, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(931), new DateTime(2022, 1, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(926) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(7360));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(8190));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(8200));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(3671));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(4437));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(4484));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 5, 14, 52, 53, 415, DateTimeKind.Local).AddTicks(4612));

            migrationBuilder.CreateIndex(
                name: "IX_Products_SectionId",
                table: "Products",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubSectionId",
                table: "Products",
                column: "SubSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sections_SectionId",
                table: "Products",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubSections_SubSectionId",
                table: "Products",
                column: "SubSectionId",
                principalTable: "SubSections",
                principalColumn: "SubSectionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
