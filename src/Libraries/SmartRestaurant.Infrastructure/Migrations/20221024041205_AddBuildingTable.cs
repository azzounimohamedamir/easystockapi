using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddBuildingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    HotelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_HotelId",
                table: "Buildings",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");

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
        }
    }
}
