using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddIlnessUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("52bf370c-4b82-44d0-8d2c-7cfa9e60d2fe"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("5677350e-7725-44e1-a904-382b0ec393d1"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("7a6f6699-9470-4f51-acd1-fe8efe010b54"));

            migrationBuilder.CreateTable(
                name: "ilnessUsers",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    IllnessId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ilnessUsers", x => new { x.ApplicationUserId, x.IllnessId });
                    table.ForeignKey(
                        name: "FK_ilnessUsers_Illnesses_IllnessId",
                        column: x => x.IllnessId,
                        principalTable: "Illnesses",
                        principalColumn: "IllnessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "HotelId", "LastModifiedAt", "LastModifiedBy", "Name", "Picture" },
                values: new object[,]
                {
                    { new Guid("27fe6c3a-2ed1-410a-aa91-352e8b0be164"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Building 01", null },
                    { new Guid("232f39c8-ff3e-46aa-91b0-2230aa3d82a8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Building 02", null },
                    { new Guid("3fb4fa5f-9bac-4cc0-a436-bd2deb94c32d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Building 03", null }
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 406, DateTimeKind.Local).AddTicks(2052));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 406, DateTimeKind.Local).AddTicks(2045));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 406, DateTimeKind.Local).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 406, DateTimeKind.Local).AddTicks(2027));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 406, DateTimeKind.Local).AddTicks(2033));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 406, DateTimeKind.Local).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 406, DateTimeKind.Local).AddTicks(1976));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 406, DateTimeKind.Local).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 406, DateTimeKind.Local).AddTicks(2008));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 406, DateTimeKind.Local).AddTicks(2014));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 406, DateTimeKind.Local).AddTicks(2039));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(8346), new DateTime(2022, 11, 13, 16, 47, 46, 402, DateTimeKind.Local).AddTicks(6927) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 13, 16, 47, 46, 404, DateTimeKind.Local).AddTicks(9089), new DateTime(2022, 11, 13, 19, 47, 46, 404, DateTimeKind.Local).AddTicks(9049) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 29, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9194), new DateTime(2022, 11, 14, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9159) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 28, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9297), new DateTime(2027, 11, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9203) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 13, 12, 23, 46, 404, DateTimeKind.Local).AddTicks(9320), new DateTime(2037, 11, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9311) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 12, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9350), new DateTime(2022, 11, 13, 8, 47, 46, 404, DateTimeKind.Local).AddTicks(9346) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9360), new DateTime(2022, 11, 1, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9358) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9372), new DateTime(2022, 9, 21, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9370) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 3, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9383), new DateTime(2023, 4, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9381) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9392), new DateTime(2022, 11, 13, 15, 47, 46, 404, DateTimeKind.Local).AddTicks(9390) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 13, 16, 47, 46, 404, DateTimeKind.Local).AddTicks(9401), new DateTime(2022, 11, 13, 18, 47, 46, 404, DateTimeKind.Local).AddTicks(9399) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 30, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9410), new DateTime(2022, 11, 15, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9408) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 1, 3, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9419), new DateTime(2026, 11, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9416) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 13, 12, 23, 46, 404, DateTimeKind.Local).AddTicks(9427), new DateTime(2037, 11, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9425) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 11, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9436), new DateTime(2022, 11, 13, 7, 47, 46, 404, DateTimeKind.Local).AddTicks(9434) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9445), new DateTime(2022, 10, 31, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9443) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9453), new DateTime(2022, 9, 24, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9451) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 2, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9463), new DateTime(2023, 3, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9460) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9472), new DateTime(2022, 11, 13, 14, 47, 46, 404, DateTimeKind.Local).AddTicks(9469) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 13, 15, 47, 46, 404, DateTimeKind.Local).AddTicks(9480), new DateTime(2022, 11, 13, 17, 47, 46, 404, DateTimeKind.Local).AddTicks(9478) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 30, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9489), new DateTime(2022, 11, 14, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9487) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 1, 7, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9498), new DateTime(2025, 11, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9494) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 13, 12, 2, 46, 404, DateTimeKind.Local).AddTicks(9506), new DateTime(2035, 11, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9503) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 10, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9515), new DateTime(2022, 11, 13, 8, 47, 46, 404, DateTimeKind.Local).AddTicks(9512) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9523), new DateTime(2022, 11, 3, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9521) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9532), new DateTime(2022, 10, 1, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 1, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9586), new DateTime(2023, 2, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9583) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9596), new DateTime(2022, 11, 13, 12, 47, 46, 404, DateTimeKind.Local).AddTicks(9594) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 13, 13, 47, 46, 404, DateTimeKind.Local).AddTicks(9604), new DateTime(2022, 11, 13, 15, 47, 46, 404, DateTimeKind.Local).AddTicks(9602) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 30, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9612), new DateTime(2022, 11, 18, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9610) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 3, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9622), new DateTime(2024, 11, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9619) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 13, 12, 30, 46, 404, DateTimeKind.Local).AddTicks(9631), new DateTime(2032, 11, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9628) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 8, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9640), new DateTime(2022, 11, 12, 23, 47, 46, 404, DateTimeKind.Local).AddTicks(9638) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9650), new DateTime(2022, 11, 6, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9648) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9659), new DateTime(2022, 12, 26, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9657) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 1, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9668), new DateTime(2023, 2, 13, 11, 47, 46, 404, DateTimeKind.Local).AddTicks(9666) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 405, DateTimeKind.Local).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 405, DateTimeKind.Local).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 405, DateTimeKind.Local).AddTicks(9365));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 405, DateTimeKind.Local).AddTicks(9372));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 405, DateTimeKind.Local).AddTicks(9380));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 405, DateTimeKind.Local).AddTicks(9387));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 405, DateTimeKind.Local).AddTicks(9394));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 405, DateTimeKind.Local).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 405, DateTimeKind.Local).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 405, DateTimeKind.Local).AddTicks(5704));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 405, DateTimeKind.Local).AddTicks(5713));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 405, DateTimeKind.Local).AddTicks(5723));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 405, DateTimeKind.Local).AddTicks(5731));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 13, 11, 47, 46, 405, DateTimeKind.Local).AddTicks(5739));

            migrationBuilder.CreateIndex(
                name: "IX_ilnessUsers_IllnessId",
                table: "ilnessUsers",
                column: "IllnessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ilnessUsers");

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("232f39c8-ff3e-46aa-91b0-2230aa3d82a8"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("27fe6c3a-2ed1-410a-aa91-352e8b0be164"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("3fb4fa5f-9bac-4cc0-a436-bd2deb94c32d"));

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "HotelId", "LastModifiedAt", "LastModifiedBy", "Name", "Picture" },
                values: new object[,]
                {
                    { new Guid("7a6f6699-9470-4f51-acd1-fe8efe010b54"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Building 01", null },
                    { new Guid("52bf370c-4b82-44d0-8d2c-7cfa9e60d2fe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Building 01", null },
                    { new Guid("5677350e-7725-44e1-a904-382b0ec393d1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Building 03", null }
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(8671));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(8645));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(8654));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(8658));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(7932));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(8607));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(8628));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(8632));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(8662));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(5973), new DateTime(2022, 10, 24, 10, 12, 3, 809, DateTimeKind.Local).AddTicks(4746) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 24, 10, 12, 3, 811, DateTimeKind.Local).AddTicks(6741), new DateTime(2022, 10, 24, 13, 12, 3, 811, DateTimeKind.Local).AddTicks(6706) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 9, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(6813), new DateTime(2022, 10, 25, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(6783) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 8, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(6928), new DateTime(2027, 10, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(6826) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 24, 5, 48, 3, 811, DateTimeKind.Local).AddTicks(6945), new DateTime(2037, 10, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(6937) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 23, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(6971), new DateTime(2022, 10, 24, 2, 12, 3, 811, DateTimeKind.Local).AddTicks(6971) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(6980), new DateTime(2022, 10, 12, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(6988), new DateTime(2022, 9, 1, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(6988) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 2, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7001), new DateTime(2023, 3, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(6997) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7009), new DateTime(2022, 10, 24, 9, 12, 3, 811, DateTimeKind.Local).AddTicks(7009) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 24, 10, 12, 3, 811, DateTimeKind.Local).AddTicks(7014), new DateTime(2022, 10, 24, 12, 12, 3, 811, DateTimeKind.Local).AddTicks(7014) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 10, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7022), new DateTime(2022, 10, 26, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7022) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 14, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7031), new DateTime(2026, 10, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7031) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 24, 5, 48, 3, 811, DateTimeKind.Local).AddTicks(7039), new DateTime(2037, 10, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7039) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 22, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7048), new DateTime(2022, 10, 24, 1, 12, 3, 811, DateTimeKind.Local).AddTicks(7044) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7052), new DateTime(2022, 10, 11, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7052) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7061), new DateTime(2022, 9, 4, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7061) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 1, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7069), new DateTime(2023, 2, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7069) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7078), new DateTime(2022, 10, 24, 8, 12, 3, 811, DateTimeKind.Local).AddTicks(7078) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 24, 9, 12, 3, 811, DateTimeKind.Local).AddTicks(7086), new DateTime(2022, 10, 24, 11, 12, 3, 811, DateTimeKind.Local).AddTicks(7082) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 10, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7090), new DateTime(2022, 10, 25, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7090) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 18, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7099), new DateTime(2025, 10, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7099) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 24, 5, 27, 3, 811, DateTimeKind.Local).AddTicks(7108), new DateTime(2035, 10, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7103) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 21, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7112), new DateTime(2022, 10, 24, 2, 12, 3, 811, DateTimeKind.Local).AddTicks(7112) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7120), new DateTime(2022, 10, 14, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7120) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7129), new DateTime(2022, 9, 11, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7129) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7137), new DateTime(2023, 1, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7133) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7146), new DateTime(2022, 10, 24, 6, 12, 3, 811, DateTimeKind.Local).AddTicks(7142) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 24, 7, 12, 3, 811, DateTimeKind.Local).AddTicks(7150), new DateTime(2022, 10, 24, 9, 12, 3, 811, DateTimeKind.Local).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 10, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7159), new DateTime(2022, 10, 29, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7159) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 13, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7167), new DateTime(2024, 10, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7163) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 24, 5, 55, 3, 811, DateTimeKind.Local).AddTicks(7176), new DateTime(2032, 10, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7172) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 19, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7180), new DateTime(2022, 10, 23, 17, 12, 3, 811, DateTimeKind.Local).AddTicks(7180) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7189), new DateTime(2022, 10, 17, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7189) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7197), new DateTime(2022, 12, 6, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7197) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7206), new DateTime(2023, 1, 24, 5, 12, 3, 811, DateTimeKind.Local).AddTicks(7201) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(5633));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(5637));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(5650));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(5654));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(1268));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(1976));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(2018));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(2031));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 10, 24, 5, 12, 3, 812, DateTimeKind.Local).AddTicks(2036));
        }
    }
}
