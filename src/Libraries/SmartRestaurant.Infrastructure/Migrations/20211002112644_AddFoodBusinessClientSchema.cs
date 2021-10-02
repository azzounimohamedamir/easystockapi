using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddFoodBusinessClientSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodBusinessClients",
                columns: table => new
                {
                    FoodBusinessClientId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NRC = table.Column<int>(nullable: false),
                    NIF = table.Column<int>(nullable: false),
                    NIS = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Address_StreetAddress = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_Country = table.Column<string>(nullable: true),
                    Address_GeoPosition_Latitude = table.Column<string>(nullable: true),
                    Address_GeoPosition_Longitude = table.Column<string>(nullable: true),
                    PhoneNumber_CountryCode = table.Column<int>(nullable: true),
                    PhoneNumber_Number = table.Column<int>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    ManagerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodBusinessClients", x => x.FoodBusinessClientId);
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(7450));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(7438));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(7441));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(7136));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(7414));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(7431));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(7434));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(7447));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(2608), new DateTime(2021, 10, 2, 17, 26, 44, 133, DateTimeKind.Local).AddTicks(3413) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 17, 26, 44, 134, DateTimeKind.Local).AddTicks(2972), new DateTime(2021, 10, 2, 20, 26, 44, 134, DateTimeKind.Local).AddTicks(2951) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 17, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3002), new DateTime(2021, 10, 3, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(2985) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 17, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3060), new DateTime(2026, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3007) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 13, 2, 44, 134, DateTimeKind.Local).AddTicks(3071), new DateTime(2036, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3066) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 1, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3084), new DateTime(2021, 10, 2, 9, 26, 44, 134, DateTimeKind.Local).AddTicks(3083) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3089), new DateTime(2021, 9, 20, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3088) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3095), new DateTime(2021, 8, 10, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3094) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3100), new DateTime(2022, 3, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3098) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3104), new DateTime(2021, 10, 2, 16, 26, 44, 134, DateTimeKind.Local).AddTicks(3103) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 17, 26, 44, 134, DateTimeKind.Local).AddTicks(3109), new DateTime(2021, 10, 2, 19, 26, 44, 134, DateTimeKind.Local).AddTicks(3108) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 18, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3115), new DateTime(2021, 10, 4, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3114) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 22, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3119), new DateTime(2025, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3118) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 13, 2, 44, 134, DateTimeKind.Local).AddTicks(3124), new DateTime(2036, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3122) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 30, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3128), new DateTime(2021, 10, 2, 8, 26, 44, 134, DateTimeKind.Local).AddTicks(3127) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3132), new DateTime(2021, 9, 19, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3131) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3138), new DateTime(2021, 8, 13, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3137) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3143), new DateTime(2022, 2, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3141) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3147), new DateTime(2021, 10, 2, 15, 26, 44, 134, DateTimeKind.Local).AddTicks(3146) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 16, 26, 44, 134, DateTimeKind.Local).AddTicks(3152), new DateTime(2021, 10, 2, 18, 26, 44, 134, DateTimeKind.Local).AddTicks(3151) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 18, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3156), new DateTime(2021, 10, 3, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3155) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 26, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3216), new DateTime(2024, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3214) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 12, 41, 44, 134, DateTimeKind.Local).AddTicks(3221), new DateTime(2034, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3220) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 29, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3226), new DateTime(2021, 10, 2, 9, 26, 44, 134, DateTimeKind.Local).AddTicks(3225) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3230), new DateTime(2021, 9, 22, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3229) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3235), new DateTime(2021, 8, 20, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3234) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3240), new DateTime(2022, 1, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3238) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3244), new DateTime(2021, 10, 2, 13, 26, 44, 134, DateTimeKind.Local).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 14, 26, 44, 134, DateTimeKind.Local).AddTicks(3248), new DateTime(2021, 10, 2, 16, 26, 44, 134, DateTimeKind.Local).AddTicks(3247) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 18, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3253), new DateTime(2021, 10, 7, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3251) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 22, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3257), new DateTime(2023, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3256) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 13, 9, 44, 134, DateTimeKind.Local).AddTicks(3262), new DateTime(2031, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3267), new DateTime(2021, 10, 2, 0, 26, 44, 134, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3272), new DateTime(2021, 9, 25, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3276), new DateTime(2021, 11, 14, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3275) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3281), new DateTime(2022, 1, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(6184));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(6203));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(6206));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(6209));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(6212));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(4423));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(4743));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 2, 12, 26, 44, 134, DateTimeKind.Local).AddTicks(4755));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodBusinessClients");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3257));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3253));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3242));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3246));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3249));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(2922));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3232));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3235));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3239));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3249));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(5844), new DateTime(2021, 9, 23, 17, 51, 30, 359, DateTimeKind.Local).AddTicks(7534) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 17, 51, 30, 375, DateTimeKind.Local).AddTicks(6627), new DateTime(2021, 9, 23, 20, 51, 30, 375, DateTimeKind.Local).AddTicks(6591) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 8, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6680), new DateTime(2021, 9, 24, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6644) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6782), new DateTime(2026, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6687) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 13, 27, 30, 375, DateTimeKind.Local).AddTicks(6796), new DateTime(2036, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6792) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 22, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6814), new DateTime(2021, 9, 23, 9, 51, 30, 375, DateTimeKind.Local).AddTicks(6810) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6817), new DateTime(2021, 9, 11, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6817) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6821), new DateTime(2021, 8, 1, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6821) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6828), new DateTime(2022, 2, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6824) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6835), new DateTime(2021, 9, 23, 16, 51, 30, 375, DateTimeKind.Local).AddTicks(6831) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 17, 51, 30, 375, DateTimeKind.Local).AddTicks(6838), new DateTime(2021, 9, 23, 19, 51, 30, 375, DateTimeKind.Local).AddTicks(6838) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 9, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6842), new DateTime(2021, 9, 25, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6842) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 13, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6852), new DateTime(2025, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6849) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 13, 27, 30, 375, DateTimeKind.Local).AddTicks(6859), new DateTime(2036, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6856) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 21, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6863), new DateTime(2021, 9, 23, 8, 51, 30, 375, DateTimeKind.Local).AddTicks(6863) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6870), new DateTime(2021, 9, 10, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6866) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6874), new DateTime(2021, 8, 4, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6874) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6877), new DateTime(2022, 1, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6877) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6884), new DateTime(2021, 9, 23, 15, 51, 30, 375, DateTimeKind.Local).AddTicks(6881) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 16, 51, 30, 375, DateTimeKind.Local).AddTicks(6888), new DateTime(2021, 9, 23, 18, 51, 30, 375, DateTimeKind.Local).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 9, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6891), new DateTime(2021, 9, 24, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6891) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 17, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6895), new DateTime(2024, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6895) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 13, 6, 30, 375, DateTimeKind.Local).AddTicks(6902), new DateTime(2034, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6898) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 20, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6909), new DateTime(2021, 9, 23, 9, 51, 30, 375, DateTimeKind.Local).AddTicks(6909) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6912), new DateTime(2021, 9, 13, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6912) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6919), new DateTime(2021, 8, 11, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6916) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6923), new DateTime(2021, 12, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6923) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6933), new DateTime(2021, 9, 23, 13, 51, 30, 375, DateTimeKind.Local).AddTicks(6926) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 14, 51, 30, 375, DateTimeKind.Local).AddTicks(6937), new DateTime(2021, 9, 23, 16, 51, 30, 375, DateTimeKind.Local).AddTicks(6937) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 9, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6944), new DateTime(2021, 9, 28, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6944) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6948), new DateTime(2023, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6948) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 13, 34, 30, 375, DateTimeKind.Local).AddTicks(6955), new DateTime(2031, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6955) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 18, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6958), new DateTime(2021, 9, 23, 0, 51, 30, 375, DateTimeKind.Local).AddTicks(6958) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6965), new DateTime(2021, 9, 16, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6965) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6969), new DateTime(2021, 11, 5, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6969) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6976), new DateTime(2021, 12, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6976) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(1564));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(9543));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(5));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(9));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(12));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(20));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(27));
        }
    }
}
