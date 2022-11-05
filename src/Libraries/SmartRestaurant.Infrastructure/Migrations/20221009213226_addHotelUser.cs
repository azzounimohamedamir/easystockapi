using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class addHotelUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hotelUsers",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    HotelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotelUsers", x => new { x.ApplicationUserId, x.HotelId });
                    table.ForeignKey(
                        name: "FK_hotelUsers_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(5121));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(5062));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(5078));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(5092));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(3572));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(4953));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(5014));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(5031));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 46, DateTimeKind.Local).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(7088), new DateTime(2022, 10, 10, 3, 32, 21, 39, DateTimeKind.Local).AddTicks(7695) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 10, 3, 32, 21, 43, DateTimeKind.Local).AddTicks(8731), new DateTime(2022, 10, 10, 6, 32, 21, 43, DateTimeKind.Local).AddTicks(8638) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 24, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(8858), new DateTime(2022, 10, 10, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(8787) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 24, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9085), new DateTime(2027, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(8879) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 9, 23, 8, 21, 43, DateTimeKind.Local).AddTicks(9129), new DateTime(2037, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9111) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 8, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9197), new DateTime(2022, 10, 9, 19, 32, 21, 43, DateTimeKind.Local).AddTicks(9190) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9219), new DateTime(2022, 9, 27, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9214) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9242), new DateTime(2022, 8, 17, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9237) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 2, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9263), new DateTime(2023, 3, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9257) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9284), new DateTime(2022, 10, 10, 2, 32, 21, 43, DateTimeKind.Local).AddTicks(9279) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 10, 3, 32, 21, 43, DateTimeKind.Local).AddTicks(9305), new DateTime(2022, 10, 10, 5, 32, 21, 43, DateTimeKind.Local).AddTicks(9299) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 25, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9330), new DateTime(2022, 10, 11, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9325) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 29, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9350), new DateTime(2026, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9344) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 9, 23, 8, 21, 43, DateTimeKind.Local).AddTicks(9370), new DateTime(2037, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9365) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 7, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9391), new DateTime(2022, 10, 9, 18, 32, 21, 43, DateTimeKind.Local).AddTicks(9386) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9410), new DateTime(2022, 9, 26, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9406) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9432), new DateTime(2022, 8, 20, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9427) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 1, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9457), new DateTime(2023, 2, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9451) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9479), new DateTime(2022, 10, 10, 1, 32, 21, 43, DateTimeKind.Local).AddTicks(9474) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 10, 2, 32, 21, 43, DateTimeKind.Local).AddTicks(9499), new DateTime(2022, 10, 10, 4, 32, 21, 43, DateTimeKind.Local).AddTicks(9494) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 25, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9519), new DateTime(2022, 10, 10, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9515) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 3, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9540), new DateTime(2025, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9535) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 9, 22, 47, 21, 43, DateTimeKind.Local).AddTicks(9560), new DateTime(2035, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9555) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 6, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9579), new DateTime(2022, 10, 9, 19, 32, 21, 43, DateTimeKind.Local).AddTicks(9574) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9598), new DateTime(2022, 9, 29, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9594) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9618), new DateTime(2022, 8, 27, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9613) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9640), new DateTime(2023, 1, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9634) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9660), new DateTime(2022, 10, 9, 23, 32, 21, 43, DateTimeKind.Local).AddTicks(9655) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 10, 0, 32, 21, 43, DateTimeKind.Local).AddTicks(9680), new DateTime(2022, 10, 10, 2, 32, 21, 43, DateTimeKind.Local).AddTicks(9674) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 25, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9700), new DateTime(2022, 10, 14, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9694) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 29, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9724), new DateTime(2024, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9715) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 9, 23, 15, 21, 43, DateTimeKind.Local).AddTicks(9745), new DateTime(2032, 10, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9738) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9766), new DateTime(2022, 10, 9, 10, 32, 21, 43, DateTimeKind.Local).AddTicks(9761) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9785), new DateTime(2022, 10, 2, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9780) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9806), new DateTime(2022, 11, 21, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9801) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9827), new DateTime(2023, 1, 9, 22, 32, 21, 43, DateTimeKind.Local).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(7467));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(8867));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(8932));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(8949));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(8981));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(218));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(1723));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(1847));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(1887));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(1906));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 9, 22, 32, 21, 45, DateTimeKind.Local).AddTicks(1923));

            migrationBuilder.CreateIndex(
                name: "IX_hotelUsers_HotelId",
                table: "hotelUsers",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hotelUsers");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(2143));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(2102));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(2115));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(648));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(1982));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(2042));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(2060));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(2074));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 732, DateTimeKind.Local).AddTicks(2130));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(2850), new DateTime(2022, 10, 4, 19, 46, 4, 724, DateTimeKind.Local).AddTicks(1701) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 19, 46, 4, 729, DateTimeKind.Local).AddTicks(4660), new DateTime(2022, 10, 4, 22, 46, 4, 729, DateTimeKind.Local).AddTicks(4545) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 19, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(4797), new DateTime(2022, 10, 5, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(4715) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 19, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5039), new DateTime(2027, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(4824) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 15, 22, 4, 729, DateTimeKind.Local).AddTicks(5091), new DateTime(2037, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5072) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 3, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5161), new DateTime(2022, 10, 4, 11, 46, 4, 729, DateTimeKind.Local).AddTicks(5153) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5182), new DateTime(2022, 9, 22, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5178) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5205), new DateTime(2022, 8, 12, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5201) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 2, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5228), new DateTime(2023, 3, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5223) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5249), new DateTime(2022, 10, 4, 18, 46, 4, 729, DateTimeKind.Local).AddTicks(5245) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 19, 46, 4, 729, DateTimeKind.Local).AddTicks(5267), new DateTime(2022, 10, 4, 21, 46, 4, 729, DateTimeKind.Local).AddTicks(5262) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 20, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5284), new DateTime(2022, 10, 6, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5280) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 24, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5305), new DateTime(2026, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5298) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 15, 22, 4, 729, DateTimeKind.Local).AddTicks(5327), new DateTime(2037, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5321) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 2, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5345), new DateTime(2022, 10, 4, 10, 46, 4, 729, DateTimeKind.Local).AddTicks(5341) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5370), new DateTime(2022, 9, 21, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5365) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5391), new DateTime(2022, 8, 15, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5387) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 1, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5412), new DateTime(2023, 2, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5406) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5433), new DateTime(2022, 10, 4, 17, 46, 4, 729, DateTimeKind.Local).AddTicks(5427) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 18, 46, 4, 729, DateTimeKind.Local).AddTicks(5451), new DateTime(2022, 10, 4, 20, 46, 4, 729, DateTimeKind.Local).AddTicks(5446) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 20, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5471), new DateTime(2022, 10, 5, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5467) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 28, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5490), new DateTime(2025, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5485) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 15, 1, 4, 729, DateTimeKind.Local).AddTicks(5509), new DateTime(2035, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5504) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 1, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5528), new DateTime(2022, 10, 4, 11, 46, 4, 729, DateTimeKind.Local).AddTicks(5524) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5547), new DateTime(2022, 9, 24, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5543) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5569), new DateTime(2022, 8, 22, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5562) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5587), new DateTime(2023, 1, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5582) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5606), new DateTime(2022, 10, 4, 15, 46, 4, 729, DateTimeKind.Local).AddTicks(5601) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 16, 46, 4, 729, DateTimeKind.Local).AddTicks(5623), new DateTime(2022, 10, 4, 18, 46, 4, 729, DateTimeKind.Local).AddTicks(5619) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 20, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5641), new DateTime(2022, 10, 9, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5637) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 24, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5664), new DateTime(2024, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5657) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 4, 15, 29, 4, 729, DateTimeKind.Local).AddTicks(5684), new DateTime(2032, 10, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5678) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 29, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5704), new DateTime(2022, 10, 4, 2, 46, 4, 729, DateTimeKind.Local).AddTicks(5699) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5722), new DateTime(2022, 9, 27, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5718) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5743), new DateTime(2022, 11, 16, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5738) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5763), new DateTime(2023, 1, 4, 14, 46, 4, 729, DateTimeKind.Local).AddTicks(5757) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 731, DateTimeKind.Local).AddTicks(4674));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 731, DateTimeKind.Local).AddTicks(6038));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 731, DateTimeKind.Local).AddTicks(6104));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 731, DateTimeKind.Local).AddTicks(6119));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 731, DateTimeKind.Local).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 731, DateTimeKind.Local).AddTicks(6148));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 731, DateTimeKind.Local).AddTicks(6164));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 730, DateTimeKind.Local).AddTicks(6122));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 730, DateTimeKind.Local).AddTicks(7630));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 730, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 730, DateTimeKind.Local).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 730, DateTimeKind.Local).AddTicks(7817));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 730, DateTimeKind.Local).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 4, 14, 46, 4, 730, DateTimeKind.Local).AddTicks(7850));
        }
    }
}
