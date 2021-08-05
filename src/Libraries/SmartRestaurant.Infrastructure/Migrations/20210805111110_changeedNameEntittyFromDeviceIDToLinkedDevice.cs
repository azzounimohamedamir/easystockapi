using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class changeedNameEntittyFromDeviceIDToLinkedDevice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevicesID");

            migrationBuilder.CreateTable(
                name: "LinkedDevices",
                columns: table => new
                {
                    LinkedDeviceId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    IdentifierDevice = table.Column<string>(nullable: true),
                    FoodBusinessId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedDevices", x => x.LinkedDeviceId);
                    table.ForeignKey(
                        name: "FK_LinkedDevices_FoodBusinesses_FoodBusinessId",
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

            migrationBuilder.CreateIndex(
                name: "IX_LinkedDevices_FoodBusinessId",
                table: "LinkedDevices",
                column: "FoodBusinessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkedDevices");

            migrationBuilder.CreateTable(
                name: "DevicesID",
                columns: table => new
                {
                    DeviceIDId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodBusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentifierDevice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevicesID", x => x.DeviceIDId);
                    table.ForeignKey(
                        name: "FK_DevicesID_FoodBusinesses_FoodBusinessId",
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
                value: new DateTime(2021, 8, 2, 14, 23, 18, 711, DateTimeKind.Local).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 711, DateTimeKind.Local).AddTicks(1397));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 711, DateTimeKind.Local).AddTicks(1375));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 711, DateTimeKind.Local).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 711, DateTimeKind.Local).AddTicks(1387));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 711, DateTimeKind.Local).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 711, DateTimeKind.Local).AddTicks(1336));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 711, DateTimeKind.Local).AddTicks(1359));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 711, DateTimeKind.Local).AddTicks(1365));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 711, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 711, DateTimeKind.Local).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(2344), new DateTime(2021, 8, 2, 19, 23, 18, 708, DateTimeKind.Local).AddTicks(9404) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 2, 19, 23, 18, 710, DateTimeKind.Local).AddTicks(2984), new DateTime(2021, 8, 2, 22, 23, 18, 710, DateTimeKind.Local).AddTicks(2949) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 18, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3030), new DateTime(2021, 8, 3, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3002) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 17, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3124), new DateTime(2026, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3040) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 2, 14, 59, 18, 710, DateTimeKind.Local).AddTicks(3140), new DateTime(2036, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3133) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 1, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3165), new DateTime(2021, 8, 2, 11, 23, 18, 710, DateTimeKind.Local).AddTicks(3162) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3173), new DateTime(2021, 7, 21, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3172) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3182), new DateTime(2021, 6, 10, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3181) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3190), new DateTime(2022, 1, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3188) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3198), new DateTime(2021, 8, 2, 18, 23, 18, 710, DateTimeKind.Local).AddTicks(3196) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 2, 19, 23, 18, 710, DateTimeKind.Local).AddTicks(3206), new DateTime(2021, 8, 2, 21, 23, 18, 710, DateTimeKind.Local).AddTicks(3204) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 19, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3212), new DateTime(2021, 8, 4, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3211) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 22, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3220), new DateTime(2025, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3218) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 2, 14, 59, 18, 710, DateTimeKind.Local).AddTicks(3229), new DateTime(2036, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3226) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 31, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3236), new DateTime(2021, 8, 2, 10, 23, 18, 710, DateTimeKind.Local).AddTicks(3234) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3244), new DateTime(2021, 7, 20, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3242) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3251), new DateTime(2021, 6, 13, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3249) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3260), new DateTime(2021, 12, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3258) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3268), new DateTime(2021, 8, 2, 17, 23, 18, 710, DateTimeKind.Local).AddTicks(3265) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 2, 18, 23, 18, 710, DateTimeKind.Local).AddTicks(3275), new DateTime(2021, 8, 2, 20, 23, 18, 710, DateTimeKind.Local).AddTicks(3273) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 19, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3282), new DateTime(2021, 8, 3, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 26, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3290), new DateTime(2024, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3287) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 2, 14, 38, 18, 710, DateTimeKind.Local).AddTicks(3298), new DateTime(2034, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3295) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 30, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3305), new DateTime(2021, 8, 2, 11, 23, 18, 710, DateTimeKind.Local).AddTicks(3303) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3313), new DateTime(2021, 7, 23, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3310) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3321), new DateTime(2021, 6, 20, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3319) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3328), new DateTime(2021, 11, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3326) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3335), new DateTime(2021, 8, 2, 15, 23, 18, 710, DateTimeKind.Local).AddTicks(3333) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 2, 16, 23, 18, 710, DateTimeKind.Local).AddTicks(3343), new DateTime(2021, 8, 2, 18, 23, 18, 710, DateTimeKind.Local).AddTicks(3341) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 19, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3351), new DateTime(2021, 8, 7, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3349) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 22, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3358), new DateTime(2023, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3356) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 2, 15, 6, 18, 710, DateTimeKind.Local).AddTicks(3366), new DateTime(2031, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3364) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3372), new DateTime(2021, 8, 2, 2, 23, 18, 710, DateTimeKind.Local).AddTicks(3370) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3380), new DateTime(2021, 7, 26, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3378) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3469), new DateTime(2021, 9, 14, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3466) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3477), new DateTime(2021, 11, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(3475) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(8984));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(9034));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(9041));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(9046));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(5966));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(5990));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(5996));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(6002));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 2, 14, 23, 18, 710, DateTimeKind.Local).AddTicks(6012));

            migrationBuilder.CreateIndex(
                name: "IX_DevicesID_FoodBusinessId",
                table: "DevicesID",
                column: "FoodBusinessId");
        }
    }
}
