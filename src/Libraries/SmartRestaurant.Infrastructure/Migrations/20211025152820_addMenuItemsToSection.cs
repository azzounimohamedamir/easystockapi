using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class addMenuItemsToSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasSubSection",
                table: "Sections",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SectionDishes",
                columns: table => new
                {
                    SectionId = table.Column<Guid>(nullable: false),
                    DishId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionDishes", x => new { x.SectionId, x.DishId });
                    table.ForeignKey(
                        name: "FK_SectionDishes_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionDishes_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionProducts",
                columns: table => new
                {
                    SectionId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionProducts", x => new { x.SectionId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_SectionProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionProducts_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1713));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1658));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1669));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(829));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1577));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1622));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 34, DateTimeKind.Local).AddTicks(1690));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 17, 28, 19, 32, DateTimeKind.Local).AddTicks(9464), new DateTime(2021, 10, 25, 22, 28, 19, 27, DateTimeKind.Local).AddTicks(9768) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 22, 28, 19, 33, DateTimeKind.Local).AddTicks(405), new DateTime(2021, 10, 26, 1, 28, 19, 33, DateTimeKind.Local).AddTicks(354) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 10, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(473), new DateTime(2021, 10, 26, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(432) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 9, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(554), new DateTime(2026, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(489) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 18, 4, 19, 33, DateTimeKind.Local).AddTicks(583), new DateTime(2036, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(572) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 24, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(627), new DateTime(2021, 10, 25, 14, 28, 19, 33, DateTimeKind.Local).AddTicks(618) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(644), new DateTime(2021, 10, 13, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(639) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(663), new DateTime(2021, 9, 2, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(657) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(680), new DateTime(2022, 3, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(674) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(696), new DateTime(2021, 10, 25, 21, 28, 19, 33, DateTimeKind.Local).AddTicks(691) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 22, 28, 19, 33, DateTimeKind.Local).AddTicks(713), new DateTime(2021, 10, 26, 0, 28, 19, 33, DateTimeKind.Local).AddTicks(707) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(729), new DateTime(2021, 10, 27, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(723) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 15, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(746), new DateTime(2025, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(740) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 18, 4, 19, 33, DateTimeKind.Local).AddTicks(764), new DateTime(2036, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(757) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 23, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(781), new DateTime(2021, 10, 25, 13, 28, 19, 33, DateTimeKind.Local).AddTicks(776) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(799), new DateTime(2021, 10, 12, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(793) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(814), new DateTime(2021, 9, 5, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(832), new DateTime(2022, 2, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(826) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(849), new DateTime(2021, 10, 25, 20, 28, 19, 33, DateTimeKind.Local).AddTicks(843) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 21, 28, 19, 33, DateTimeKind.Local).AddTicks(914), new DateTime(2021, 10, 25, 23, 28, 19, 33, DateTimeKind.Local).AddTicks(907) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(930), new DateTime(2021, 10, 26, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(924) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 19, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(946), new DateTime(2024, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(940) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 17, 43, 19, 33, DateTimeKind.Local).AddTicks(963), new DateTime(2034, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(957) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 22, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(979), new DateTime(2021, 10, 25, 14, 28, 19, 33, DateTimeKind.Local).AddTicks(974) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(996), new DateTime(2021, 10, 15, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(991) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1014), new DateTime(2021, 9, 12, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1008) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1031), new DateTime(2022, 1, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1025) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1047), new DateTime(2021, 10, 25, 18, 28, 19, 33, DateTimeKind.Local).AddTicks(1042) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 19, 28, 19, 33, DateTimeKind.Local).AddTicks(1064), new DateTime(2021, 10, 25, 21, 28, 19, 33, DateTimeKind.Local).AddTicks(1058) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1080), new DateTime(2021, 10, 30, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1074) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 14, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1207), new DateTime(2023, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1195) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 18, 11, 19, 33, DateTimeKind.Local).AddTicks(1224), new DateTime(2031, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1218) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 20, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1242), new DateTime(2021, 10, 25, 5, 28, 19, 33, DateTimeKind.Local).AddTicks(1236) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1258), new DateTime(2021, 10, 18, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1252) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1277), new DateTime(2021, 12, 7, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1271) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1294), new DateTime(2022, 1, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(1288) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(8582));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(8628));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(8644));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(8656));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(4108));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(4885));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 25, 17, 28, 19, 33, DateTimeKind.Local).AddTicks(4983));

            migrationBuilder.CreateIndex(
                name: "IX_SectionDishes_DishId",
                table: "SectionDishes",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionProducts_ProductId",
                table: "SectionProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectionDishes");

            migrationBuilder.DropTable(
                name: "SectionProducts");

            migrationBuilder.DropColumn(
                name: "HasSubSection",
                table: "Sections");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1763));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1755));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1731));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(736));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1649));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1692));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1702));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1712));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 654, DateTimeKind.Local).AddTicks(1746));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(7105), new DateTime(2021, 10, 15, 23, 43, 58, 649, DateTimeKind.Local).AddTicks(6191) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 23, 43, 58, 652, DateTimeKind.Local).AddTicks(8222), new DateTime(2021, 10, 16, 2, 43, 58, 652, DateTimeKind.Local).AddTicks(8154) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 30, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8301), new DateTime(2021, 10, 16, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8247) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 30, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8448), new DateTime(2026, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8313) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 19, 19, 58, 652, DateTimeKind.Local).AddTicks(8470), new DateTime(2036, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8460) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8502), new DateTime(2021, 10, 15, 15, 43, 58, 652, DateTimeKind.Local).AddTicks(8498) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8515), new DateTime(2021, 10, 3, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8513) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8530), new DateTime(2021, 8, 23, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8528) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8541), new DateTime(2022, 3, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8538) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8554), new DateTime(2021, 10, 15, 22, 43, 58, 652, DateTimeKind.Local).AddTicks(8550) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 23, 43, 58, 652, DateTimeKind.Local).AddTicks(8567), new DateTime(2021, 10, 16, 1, 43, 58, 652, DateTimeKind.Local).AddTicks(8564) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 1, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8579), new DateTime(2021, 10, 17, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8577) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 5, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8591), new DateTime(2025, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8588) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 19, 19, 58, 652, DateTimeKind.Local).AddTicks(8605), new DateTime(2036, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8601) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8618), new DateTime(2021, 10, 15, 14, 43, 58, 652, DateTimeKind.Local).AddTicks(8615) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8630), new DateTime(2021, 10, 2, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8628) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8644), new DateTime(2021, 8, 26, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8641) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8656), new DateTime(2022, 2, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8653) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8671), new DateTime(2021, 10, 15, 21, 43, 58, 652, DateTimeKind.Local).AddTicks(8668) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 22, 43, 58, 652, DateTimeKind.Local).AddTicks(8683), new DateTime(2021, 10, 16, 0, 43, 58, 652, DateTimeKind.Local).AddTicks(8680) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 1, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8694), new DateTime(2021, 10, 16, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8692) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 9, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8708), new DateTime(2024, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8705) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 18, 58, 58, 652, DateTimeKind.Local).AddTicks(8721), new DateTime(2034, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8718) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 12, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8734), new DateTime(2021, 10, 15, 15, 43, 58, 652, DateTimeKind.Local).AddTicks(8731) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8745), new DateTime(2021, 10, 5, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8743) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8759), new DateTime(2021, 9, 2, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8756) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8774), new DateTime(2022, 1, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8770) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8788), new DateTime(2021, 10, 15, 19, 43, 58, 652, DateTimeKind.Local).AddTicks(8785) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 20, 43, 58, 652, DateTimeKind.Local).AddTicks(8799), new DateTime(2021, 10, 15, 22, 43, 58, 652, DateTimeKind.Local).AddTicks(8797) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 1, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8811), new DateTime(2021, 10, 20, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8808) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 4, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8825), new DateTime(2023, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8819) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 19, 26, 58, 652, DateTimeKind.Local).AddTicks(8836), new DateTime(2031, 10, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8833) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 10, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(8850), new DateTime(2021, 10, 15, 6, 43, 58, 652, DateTimeKind.Local).AddTicks(8846) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(9047), new DateTime(2021, 10, 8, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(9043) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(9062), new DateTime(2021, 11, 27, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(9059) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(9078), new DateTime(2022, 1, 15, 18, 43, 58, 652, DateTimeKind.Local).AddTicks(9074) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(7347));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(8231));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(8261));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(8269));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(3350));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(4271));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(4283));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(4293));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 15, 18, 43, 58, 653, DateTimeKind.Local).AddTicks(4303));
        }
    }
}
