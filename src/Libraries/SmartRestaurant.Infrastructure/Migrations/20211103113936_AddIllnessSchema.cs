using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddIllnessSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Illnesses",
                columns: table => new
                {
                    IllnessId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illnesses", x => x.IllnessId);
                });

            migrationBuilder.CreateTable(
                name: "IngredientIllnesses",
                columns: table => new
                {
                    IllnessId = table.Column<Guid>(nullable: false),
                    IngredientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientIllnesses", x => new { x.IllnessId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_IngredientIllnesses_Illnesses_IllnessId",
                        column: x => x.IllnessId,
                        principalTable: "Illnesses",
                        principalColumn: "IllnessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientIllnesses_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(8952));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(8947));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(8919));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(8924));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(8935));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(8426));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(8881));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(8901));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(8908));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(8913));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(8941));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 39, 35, 807, DateTimeKind.Local).AddTicks(9220), new DateTime(2021, 11, 3, 17, 39, 35, 805, DateTimeKind.Local).AddTicks(2598) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 17, 39, 35, 808, DateTimeKind.Local).AddTicks(114), new DateTime(2021, 11, 3, 20, 39, 35, 808, DateTimeKind.Local).AddTicks(67) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 19, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(186), new DateTime(2021, 11, 4, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(145) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 18, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(326), new DateTime(2026, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(197) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 13, 15, 35, 808, DateTimeKind.Local).AddTicks(347), new DateTime(2036, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(338) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 2, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(384), new DateTime(2021, 11, 3, 9, 39, 35, 808, DateTimeKind.Local).AddTicks(379) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(396), new DateTime(2021, 10, 22, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(412), new DateTime(2021, 9, 11, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(409) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(425), new DateTime(2022, 4, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(422) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(438), new DateTime(2021, 11, 3, 16, 39, 35, 808, DateTimeKind.Local).AddTicks(436) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 17, 39, 35, 808, DateTimeKind.Local).AddTicks(450), new DateTime(2021, 11, 3, 19, 39, 35, 808, DateTimeKind.Local).AddTicks(447) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 20, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(464), new DateTime(2021, 11, 5, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(460) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 24, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(478), new DateTime(2025, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(475) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 13, 15, 35, 808, DateTimeKind.Local).AddTicks(493), new DateTime(2036, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(489) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 1, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(507), new DateTime(2021, 11, 3, 8, 39, 35, 808, DateTimeKind.Local).AddTicks(504) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(517), new DateTime(2021, 10, 21, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(515) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(532), new DateTime(2021, 9, 14, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(527) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(546), new DateTime(2022, 3, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(543) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(557), new DateTime(2021, 11, 3, 15, 39, 35, 808, DateTimeKind.Local).AddTicks(555) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 16, 39, 35, 808, DateTimeKind.Local).AddTicks(576), new DateTime(2021, 11, 3, 18, 39, 35, 808, DateTimeKind.Local).AddTicks(574) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 20, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(589), new DateTime(2021, 11, 4, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(587) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 28, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(730), new DateTime(2024, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(726) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 54, 35, 808, DateTimeKind.Local).AddTicks(742), new DateTime(2034, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(739) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 31, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(756), new DateTime(2021, 11, 3, 9, 39, 35, 808, DateTimeKind.Local).AddTicks(752) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(766), new DateTime(2021, 10, 24, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(764) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(781), new DateTime(2021, 9, 21, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(776) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(796), new DateTime(2022, 2, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(793) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(812), new DateTime(2021, 11, 3, 13, 39, 35, 808, DateTimeKind.Local).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 14, 39, 35, 808, DateTimeKind.Local).AddTicks(822), new DateTime(2021, 11, 3, 16, 39, 35, 808, DateTimeKind.Local).AddTicks(819) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 20, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(836), new DateTime(2021, 11, 8, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(833) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(852), new DateTime(2023, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(847) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 13, 22, 35, 808, DateTimeKind.Local).AddTicks(862), new DateTime(2031, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(859) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 29, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(876), new DateTime(2021, 11, 3, 0, 39, 35, 808, DateTimeKind.Local).AddTicks(873) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(887), new DateTime(2021, 10, 27, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(884) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(900), new DateTime(2021, 12, 16, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(898) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(913), new DateTime(2022, 2, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(6345));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(6857));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(6878));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(6885));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(6890));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(6896));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(6902));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(3782));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(4255));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(4275));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(4281));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(4293));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(4298));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 3, 12, 39, 35, 808, DateTimeKind.Local).AddTicks(4305));

            migrationBuilder.CreateIndex(
                name: "IX_IngredientIllnesses_IngredientId",
                table: "IngredientIllnesses",
                column: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientIllnesses");

            migrationBuilder.DropTable(
                name: "Illnesses");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 113, DateTimeKind.Local).AddTicks(379));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 113, DateTimeKind.Local).AddTicks(315));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 113, DateTimeKind.Local).AddTicks(76));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 113, DateTimeKind.Local).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 113, DateTimeKind.Local).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(8789));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(9861));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(9986));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 113, DateTimeKind.Local).AddTicks(27));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 113, DateTimeKind.Local).AddTicks(52));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 113, DateTimeKind.Local).AddTicks(137));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(1501), new DateTime(2021, 10, 28, 10, 17, 1, 104, DateTimeKind.Local).AddTicks(8524) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 10, 17, 1, 111, DateTimeKind.Local).AddTicks(2553), new DateTime(2021, 10, 28, 13, 17, 1, 111, DateTimeKind.Local).AddTicks(2499) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2636), new DateTime(2021, 10, 29, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2587) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 12, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2728), new DateTime(2026, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2654) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 5, 53, 1, 111, DateTimeKind.Local).AddTicks(2759), new DateTime(2036, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2748) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2801), new DateTime(2021, 10, 28, 2, 17, 1, 111, DateTimeKind.Local).AddTicks(2792) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2819), new DateTime(2021, 10, 16, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2813) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2839), new DateTime(2021, 9, 5, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2833) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2859), new DateTime(2022, 3, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2853) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2878), new DateTime(2021, 10, 28, 9, 17, 1, 111, DateTimeKind.Local).AddTicks(2871) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 10, 17, 1, 111, DateTimeKind.Local).AddTicks(2896), new DateTime(2021, 10, 28, 12, 17, 1, 111, DateTimeKind.Local).AddTicks(2889) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2916), new DateTime(2021, 10, 30, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2909) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 18, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2943), new DateTime(2025, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2931) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 5, 53, 1, 111, DateTimeKind.Local).AddTicks(2976), new DateTime(2036, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2965) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 26, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3049), new DateTime(2021, 10, 28, 1, 17, 1, 111, DateTimeKind.Local).AddTicks(3024) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3080), new DateTime(2021, 10, 15, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3071) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3111), new DateTime(2021, 9, 8, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3101) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3147), new DateTime(2022, 2, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3134) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3180), new DateTime(2021, 10, 28, 8, 17, 1, 111, DateTimeKind.Local).AddTicks(3168) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 9, 17, 1, 111, DateTimeKind.Local).AddTicks(3215), new DateTime(2021, 10, 28, 11, 17, 1, 111, DateTimeKind.Local).AddTicks(3203) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3243), new DateTime(2021, 10, 29, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3232) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 22, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3279), new DateTime(2024, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 5, 32, 1, 111, DateTimeKind.Local).AddTicks(3310), new DateTime(2034, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3300) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3338), new DateTime(2021, 10, 28, 2, 17, 1, 111, DateTimeKind.Local).AddTicks(3329) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3374), new DateTime(2021, 10, 18, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3364) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3405), new DateTime(2021, 9, 15, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3395) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3444), new DateTime(2022, 1, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3427) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3475), new DateTime(2021, 10, 28, 6, 17, 1, 111, DateTimeKind.Local).AddTicks(3465) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 7, 17, 1, 111, DateTimeKind.Local).AddTicks(3505), new DateTime(2021, 10, 28, 9, 17, 1, 111, DateTimeKind.Local).AddTicks(3493) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3546), new DateTime(2021, 11, 2, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3531) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 17, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3581), new DateTime(2023, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3569) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 6, 0, 1, 111, DateTimeKind.Local).AddTicks(3623), new DateTime(2031, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3606) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 23, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3657), new DateTime(2021, 10, 27, 17, 17, 1, 111, DateTimeKind.Local).AddTicks(3645) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3688), new DateTime(2021, 10, 21, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3678) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3720), new DateTime(2021, 12, 10, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3709) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3755), new DateTime(2022, 1, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3741) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(5504));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(5561));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(5578));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(5592));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(5604));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(5616));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(8125));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(9272));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(9288));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(9304));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(9321));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(9334));
        }
    }
}
