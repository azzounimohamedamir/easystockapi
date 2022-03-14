using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    EnergeticValue = table.Column<float>(nullable: false),
                    SubSectionId = table.Column<Guid>(nullable: true),
                    SectionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_SubSections_SubSectionId",
                        column: x => x.SubSectionId,
                        principalTable: "SubSections",
                        principalColumn: "SubSectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "FoodBusinessClients",
                columns: new[] { "FoodBusinessClientId", "CreatedAt", "CreatedBy", "Description", "Email", "LastModifiedAt", "LastModifiedBy", "ManagerId", "NIF", "NIS", "NRC", "Name", "Website" },
                values: new object[,]
                {
                    { new Guid("e6f980ba-c381-4319-8b62-da017e116692"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SONATRACH est la première entreprise du continent africain. Une société intégrée de l'Amont à l'Aval pétrolier et gazier et un Groupe internationale.", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "a3dbd500-eab0-4233-86fd-7f1a4195f9a9", 0, 0, 0, "Sonatrach", "https://sonatrach.com/" },
                    { new Guid("1eb2b784-074d-4be4-afb7-9708331c0c63"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cevital is a family-run Group whose success and reputation are rooted in its history, its track record and its values.", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ba89dc5f-dfd1-4c87-9372-233c611cc756", 0, 0, 0, "CEVITAL", "https://cevital.com/" }
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DeleteData(
                table: "FoodBusinessClients",
                keyColumn: "FoodBusinessClientId",
                keyValue: new Guid("1eb2b784-074d-4be4-afb7-9708331c0c63"));

            migrationBuilder.DeleteData(
                table: "FoodBusinessClients",
                keyColumn: "FoodBusinessClientId",
                keyValue: new Guid("e6f980ba-c381-4319-8b62-da017e116692"));

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
    }
}
