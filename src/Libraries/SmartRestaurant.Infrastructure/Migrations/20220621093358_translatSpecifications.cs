using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class translatSpecifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Names_AR",
                table: "DishSpecifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_EN",
                table: "DishSpecifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_FR",
                table: "DishSpecifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_RU",
                table: "DishSpecifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_TR",
                table: "DishSpecifications",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DishComboBoxItemTranslations",
                columns: table => new
                {
                    DishComboBoxItemTranslationId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Names_AR = table.Column<string>(nullable: true),
                    Names_EN = table.Column<string>(nullable: true),
                    Names_FR = table.Column<string>(nullable: true),
                    Names_TR = table.Column<string>(nullable: true),
                    Names_RU = table.Column<string>(nullable: true),
                    DishSpecificationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishComboBoxItemTranslations", x => x.DishComboBoxItemTranslationId);
                    table.ForeignKey(
                        name: "FK_DishComboBoxItemTranslations_DishSpecifications_DishSpecificationId",
                        column: x => x.DishSpecificationId,
                        principalTable: "DishSpecifications",
                        principalColumn: "DishSpecificationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderComboBoxItemTranslations",
                columns: table => new
                {
                    OrderComboBoxItemTranslationId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Names_AR = table.Column<string>(nullable: true),
                    Names_EN = table.Column<string>(nullable: true),
                    Names_FR = table.Column<string>(nullable: true),
                    Names_TR = table.Column<string>(nullable: true),
                    Names_RU = table.Column<string>(nullable: true),
                    OrderDishSpecificationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderComboBoxItemTranslations", x => x.OrderComboBoxItemTranslationId);
                    table.ForeignKey(
                        name: "FK_OrderComboBoxItemTranslations_OrderDishSpecifications_OrderDishSpecificationId",
                        column: x => x.OrderDishSpecificationId,
                        principalTable: "OrderDishSpecifications",
                        principalColumn: "OrderDishSpecificationId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_DishComboBoxItemTranslations_DishSpecificationId",
                table: "DishComboBoxItemTranslations",
                column: "DishSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderComboBoxItemTranslations_OrderDishSpecificationId",
                table: "OrderComboBoxItemTranslations",
                column: "OrderDishSpecificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishComboBoxItemTranslations");

            migrationBuilder.DropTable(
                name: "OrderComboBoxItemTranslations");

            migrationBuilder.DropColumn(
                name: "Names_AR",
                table: "DishSpecifications");

            migrationBuilder.DropColumn(
                name: "Names_EN",
                table: "DishSpecifications");

            migrationBuilder.DropColumn(
                name: "Names_FR",
                table: "DishSpecifications");

            migrationBuilder.DropColumn(
                name: "Names_RU",
                table: "DishSpecifications");

            migrationBuilder.DropColumn(
                name: "Names_TR",
                table: "DishSpecifications");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 943, DateTimeKind.Local).AddTicks(2601));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 943, DateTimeKind.Local).AddTicks(2596));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 943, DateTimeKind.Local).AddTicks(2579));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 943, DateTimeKind.Local).AddTicks(2583));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 943, DateTimeKind.Local).AddTicks(2589));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 943, DateTimeKind.Local).AddTicks(2228));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 943, DateTimeKind.Local).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 943, DateTimeKind.Local).AddTicks(2564));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 943, DateTimeKind.Local).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 943, DateTimeKind.Local).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 943, DateTimeKind.Local).AddTicks(2593));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(5650), new DateTime(2022, 6, 14, 14, 11, 51, 941, DateTimeKind.Local).AddTicks(5868) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 14, 11, 51, 942, DateTimeKind.Local).AddTicks(6166), new DateTime(2022, 6, 14, 17, 11, 51, 942, DateTimeKind.Local).AddTicks(6140) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 30, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6197), new DateTime(2022, 6, 15, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6178) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 29, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6271), new DateTime(2027, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6205) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 9, 47, 51, 942, DateTimeKind.Local).AddTicks(6282), new DateTime(2037, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6277) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 13, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6302), new DateTime(2022, 6, 14, 6, 11, 51, 942, DateTimeKind.Local).AddTicks(6299) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6307), new DateTime(2022, 6, 2, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6306) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6314), new DateTime(2022, 4, 22, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6312) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6321), new DateTime(2022, 11, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6319) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6326), new DateTime(2022, 6, 14, 13, 11, 51, 942, DateTimeKind.Local).AddTicks(6324) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 14, 11, 51, 942, DateTimeKind.Local).AddTicks(6331), new DateTime(2022, 6, 14, 16, 11, 51, 942, DateTimeKind.Local).AddTicks(6330) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 31, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6338), new DateTime(2022, 6, 16, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6336) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 4, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6344), new DateTime(2026, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6342) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 9, 47, 51, 942, DateTimeKind.Local).AddTicks(6349), new DateTime(2037, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6347) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 12, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6355), new DateTime(2022, 6, 14, 5, 11, 51, 942, DateTimeKind.Local).AddTicks(6354) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6361), new DateTime(2022, 6, 1, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6360) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6367), new DateTime(2022, 4, 25, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6366) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6373), new DateTime(2022, 10, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6372) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6379), new DateTime(2022, 6, 14, 12, 11, 51, 942, DateTimeKind.Local).AddTicks(6378) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 13, 11, 51, 942, DateTimeKind.Local).AddTicks(6384), new DateTime(2022, 6, 14, 15, 11, 51, 942, DateTimeKind.Local).AddTicks(6383) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 31, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6390), new DateTime(2022, 6, 15, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6388) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 8, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6397), new DateTime(2025, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6395) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 9, 26, 51, 942, DateTimeKind.Local).AddTicks(6403), new DateTime(2035, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6401) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 11, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6408), new DateTime(2022, 6, 14, 6, 11, 51, 942, DateTimeKind.Local).AddTicks(6407) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6415), new DateTime(2022, 6, 4, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6414) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6422), new DateTime(2022, 5, 2, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6427), new DateTime(2022, 9, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6426) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6433), new DateTime(2022, 6, 14, 10, 11, 51, 942, DateTimeKind.Local).AddTicks(6432) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 11, 11, 51, 942, DateTimeKind.Local).AddTicks(6439), new DateTime(2022, 6, 14, 13, 11, 51, 942, DateTimeKind.Local).AddTicks(6437) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 31, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6444), new DateTime(2022, 6, 19, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6443) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6450), new DateTime(2024, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6448) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 9, 54, 51, 942, DateTimeKind.Local).AddTicks(6457), new DateTime(2032, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6455) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 9, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6462), new DateTime(2022, 6, 13, 21, 11, 51, 942, DateTimeKind.Local).AddTicks(6460) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6467), new DateTime(2022, 6, 7, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6465) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6472), new DateTime(2022, 7, 27, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6471) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6478), new DateTime(2022, 9, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(6477) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 943, DateTimeKind.Local).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 943, DateTimeKind.Local).AddTicks(1125));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 943, DateTimeKind.Local).AddTicks(1143));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 943, DateTimeKind.Local).AddTicks(1148));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 943, DateTimeKind.Local).AddTicks(1152));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 943, DateTimeKind.Local).AddTicks(1156));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 943, DateTimeKind.Local).AddTicks(1160));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(9259));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(9278));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(9283));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(9288));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(9293));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 11, 51, 942, DateTimeKind.Local).AddTicks(9301));
        }
    }
}
