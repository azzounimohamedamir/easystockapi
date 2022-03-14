using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class addMenuItemsToSubSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubSectionDishes",
                columns: table => new
                {
                    SubSectionId = table.Column<Guid>(nullable: false),
                    DishId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSectionDishes", x => new { x.SubSectionId, x.DishId });
                    table.ForeignKey(
                        name: "FK_SubSectionDishes_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubSectionDishes_SubSections_SubSectionId",
                        column: x => x.SubSectionId,
                        principalTable: "SubSections",
                        principalColumn: "SubSectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubSectionProducts",
                columns: table => new
                {
                    SubSectionId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSectionProducts", x => new { x.SubSectionId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_SubSectionProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubSectionProducts_SubSections_SubSectionId",
                        column: x => x.SubSectionId,
                        principalTable: "SubSections",
                        principalColumn: "SubSectionId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_SubSectionDishes_DishId",
                table: "SubSectionDishes",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSectionProducts_ProductId",
                table: "SubSectionProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubSectionDishes");

            migrationBuilder.DropTable(
                name: "SubSectionProducts");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5687));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5677));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5636));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5647));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5657));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5555));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5600));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5625));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(5667));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(3431), new DateTime(2021, 10, 27, 11, 8, 57, 47, DateTimeKind.Local).AddTicks(8323) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 11, 8, 57, 52, DateTimeKind.Local).AddTicks(4353), new DateTime(2021, 10, 27, 14, 8, 57, 52, DateTimeKind.Local).AddTicks(4303) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 12, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4423), new DateTime(2021, 10, 28, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4382) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 11, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4511), new DateTime(2026, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4439) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 6, 44, 57, 52, DateTimeKind.Local).AddTicks(4542), new DateTime(2036, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4531) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 26, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4585), new DateTime(2021, 10, 27, 3, 8, 57, 52, DateTimeKind.Local).AddTicks(4577) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4602), new DateTime(2021, 10, 15, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4597) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4765), new DateTime(2021, 9, 4, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4754) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4783), new DateTime(2022, 3, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4777) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4800), new DateTime(2021, 10, 27, 10, 8, 57, 52, DateTimeKind.Local).AddTicks(4795) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 11, 8, 57, 52, DateTimeKind.Local).AddTicks(4817), new DateTime(2021, 10, 27, 13, 8, 57, 52, DateTimeKind.Local).AddTicks(4812) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4833), new DateTime(2021, 10, 29, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4827) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 17, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4850), new DateTime(2025, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4844) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 6, 44, 57, 52, DateTimeKind.Local).AddTicks(4868), new DateTime(2036, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4861) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4885), new DateTime(2021, 10, 27, 2, 8, 57, 52, DateTimeKind.Local).AddTicks(4880) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4902), new DateTime(2021, 10, 14, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4895) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4918), new DateTime(2021, 9, 7, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4913) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4934), new DateTime(2022, 2, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4929) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4951), new DateTime(2021, 10, 27, 9, 8, 57, 52, DateTimeKind.Local).AddTicks(4945) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 10, 8, 57, 52, DateTimeKind.Local).AddTicks(4966), new DateTime(2021, 10, 27, 12, 8, 57, 52, DateTimeKind.Local).AddTicks(4961) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4982), new DateTime(2021, 10, 28, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4976) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 21, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5002), new DateTime(2024, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(4996) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 6, 23, 57, 52, DateTimeKind.Local).AddTicks(5019), new DateTime(2034, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5013) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 24, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5034), new DateTime(2021, 10, 27, 3, 8, 57, 52, DateTimeKind.Local).AddTicks(5029) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5052), new DateTime(2021, 10, 17, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5046) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5069), new DateTime(2021, 9, 14, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5064) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5086), new DateTime(2022, 1, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5080) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5102), new DateTime(2021, 10, 27, 7, 8, 57, 52, DateTimeKind.Local).AddTicks(5096) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 8, 8, 57, 52, DateTimeKind.Local).AddTicks(5117), new DateTime(2021, 10, 27, 10, 8, 57, 52, DateTimeKind.Local).AddTicks(5112) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5133), new DateTime(2021, 11, 1, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5127) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 16, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5149), new DateTime(2023, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5144) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 6, 51, 57, 52, DateTimeKind.Local).AddTicks(5165), new DateTime(2031, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5160) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 22, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5181), new DateTime(2021, 10, 26, 18, 8, 57, 52, DateTimeKind.Local).AddTicks(5176) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5197), new DateTime(2021, 10, 20, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5191) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5213), new DateTime(2021, 12, 9, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5207) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5229), new DateTime(2022, 1, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(5224) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(2538));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(2586));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(2601));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(2613));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(2624));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 53, DateTimeKind.Local).AddTicks(2635));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(8105));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(8881));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(8929));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(8943));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(8955));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 6, 8, 57, 52, DateTimeKind.Local).AddTicks(8978));
        }
    }
}
