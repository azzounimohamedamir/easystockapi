using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateFoodBusinessClientSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FoodBusinessClients",
                columns: new[] { "FoodBusinessClientId", "CreatedAt", "CreatedBy", "Description", "Email", "FoodBusinessId", "LastModifiedAt", "LastModifiedBy", "ManagerId", "NIF", "NIS", "NRC", "Name", "Website" },
                values: new object[,]
                {
                    { new Guid("e6f980ba-c381-4319-8b62-da017e116692"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SONATRACH est la première entreprise du continent africain. Une société intégrée de l'Amont à l'Aval pétrolier et gazier et un Groupe internationale.", null, new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "a3dbd500-eab0-4233-86fd-7f1a4195f9a9", 0, 0, 0, "Sonatrach", "https://sonatrach.com/" },
                    { new Guid("1eb2b784-074d-4be4-afb7-9708331c0c63"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cevital is a family-run Group whose success and reputation are rooted in its history, its track record and its values.", null, new Guid("88bc7853-220f-9173-3246-afb7cf595022"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ba89dc5f-dfd1-4c87-9372-233c611cc756", 0, 0, 0, "CEVITAL", "https://cevital.com/" }
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(4036));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(4032));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(4015));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(4019));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(3632));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(3985));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(4002));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(4011));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(4028));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(7705), new DateTime(2021, 10, 14, 17, 52, 15, 312, DateTimeKind.Local).AddTicks(5841) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 17, 52, 15, 313, DateTimeKind.Local).AddTicks(8194), new DateTime(2021, 10, 14, 20, 52, 15, 313, DateTimeKind.Local).AddTicks(8164) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 29, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8228), new DateTime(2021, 10, 15, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8208) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 29, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8301), new DateTime(2026, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8235) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 13, 28, 15, 313, DateTimeKind.Local).AddTicks(8313), new DateTime(2036, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8307) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8333), new DateTime(2021, 10, 14, 9, 52, 15, 313, DateTimeKind.Local).AddTicks(8331) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8340), new DateTime(2021, 10, 2, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8338) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8346), new DateTime(2021, 8, 22, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8345) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8435), new DateTime(2022, 3, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8432) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8442), new DateTime(2021, 10, 14, 16, 52, 15, 313, DateTimeKind.Local).AddTicks(8440) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 17, 52, 15, 313, DateTimeKind.Local).AddTicks(8448), new DateTime(2021, 10, 14, 19, 52, 15, 313, DateTimeKind.Local).AddTicks(8447) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 30, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8455), new DateTime(2021, 10, 16, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8453) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 4, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8462), new DateTime(2025, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8460) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 13, 28, 15, 313, DateTimeKind.Local).AddTicks(8472), new DateTime(2036, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8470) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8478), new DateTime(2021, 10, 14, 8, 52, 15, 313, DateTimeKind.Local).AddTicks(8477) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8484), new DateTime(2021, 10, 1, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8483) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8491), new DateTime(2021, 8, 25, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8490) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8498), new DateTime(2022, 2, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8496) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8504), new DateTime(2021, 10, 14, 15, 52, 15, 313, DateTimeKind.Local).AddTicks(8502) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 16, 52, 15, 313, DateTimeKind.Local).AddTicks(8511), new DateTime(2021, 10, 14, 18, 52, 15, 313, DateTimeKind.Local).AddTicks(8509) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 30, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8516), new DateTime(2021, 10, 15, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8515) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 8, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8523), new DateTime(2024, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8521) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 13, 7, 15, 313, DateTimeKind.Local).AddTicks(8529), new DateTime(2034, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8527) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8536), new DateTime(2021, 10, 14, 9, 52, 15, 313, DateTimeKind.Local).AddTicks(8534) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8542), new DateTime(2021, 10, 4, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8540) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8549), new DateTime(2021, 9, 1, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8548) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8556), new DateTime(2022, 1, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8554) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8562), new DateTime(2021, 10, 14, 13, 52, 15, 313, DateTimeKind.Local).AddTicks(8560) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 14, 52, 15, 313, DateTimeKind.Local).AddTicks(8567), new DateTime(2021, 10, 14, 16, 52, 15, 313, DateTimeKind.Local).AddTicks(8566) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 30, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8573), new DateTime(2021, 10, 19, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8572) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8579), new DateTime(2023, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8577) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 13, 35, 15, 313, DateTimeKind.Local).AddTicks(8585), new DateTime(2031, 10, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8583) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 9, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8591), new DateTime(2021, 10, 14, 0, 52, 15, 313, DateTimeKind.Local).AddTicks(8589) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8597), new DateTime(2021, 10, 7, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8595) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8603), new DateTime(2021, 11, 26, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8601) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8609), new DateTime(2022, 1, 14, 12, 52, 15, 313, DateTimeKind.Local).AddTicks(8607) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(1954));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(2403));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(2427));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(2431));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(2436));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(70));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(462));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(485));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(490));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(495));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(502));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 52, 15, 314, DateTimeKind.Local).AddTicks(506));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                value: new DateTime(2021, 10, 14, 12, 48, 32, 63, DateTimeKind.Local).AddTicks(3662));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 63, DateTimeKind.Local).AddTicks(3658));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 63, DateTimeKind.Local).AddTicks(3639));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 63, DateTimeKind.Local).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 63, DateTimeKind.Local).AddTicks(3649));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 63, DateTimeKind.Local).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 63, DateTimeKind.Local).AddTicks(3607));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 63, DateTimeKind.Local).AddTicks(3625));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 63, DateTimeKind.Local).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 63, DateTimeKind.Local).AddTicks(3634));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 63, DateTimeKind.Local).AddTicks(3653));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(6525), new DateTime(2021, 10, 14, 17, 48, 32, 61, DateTimeKind.Local).AddTicks(1276) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 17, 48, 32, 62, DateTimeKind.Local).AddTicks(7097), new DateTime(2021, 10, 14, 20, 48, 32, 62, DateTimeKind.Local).AddTicks(7066) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 29, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7138), new DateTime(2021, 10, 15, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7113) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 29, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7217), new DateTime(2026, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7144) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 13, 24, 32, 62, DateTimeKind.Local).AddTicks(7230), new DateTime(2036, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7224) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7250), new DateTime(2021, 10, 14, 9, 48, 32, 62, DateTimeKind.Local).AddTicks(7248) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7256), new DateTime(2021, 10, 2, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7255) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7263), new DateTime(2021, 8, 22, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7262) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7271), new DateTime(2022, 3, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7269) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7277), new DateTime(2021, 10, 14, 16, 48, 32, 62, DateTimeKind.Local).AddTicks(7276) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 17, 48, 32, 62, DateTimeKind.Local).AddTicks(7283), new DateTime(2021, 10, 14, 19, 48, 32, 62, DateTimeKind.Local).AddTicks(7281) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 30, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7289), new DateTime(2021, 10, 16, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7287) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 4, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7295), new DateTime(2025, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7293) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 13, 24, 32, 62, DateTimeKind.Local).AddTicks(7302), new DateTime(2036, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7300) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 12, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7308), new DateTime(2021, 10, 14, 8, 48, 32, 62, DateTimeKind.Local).AddTicks(7307) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7314), new DateTime(2021, 10, 1, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7313) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7321), new DateTime(2021, 8, 25, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7320) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7328), new DateTime(2022, 2, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7327) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7335), new DateTime(2021, 10, 14, 15, 48, 32, 62, DateTimeKind.Local).AddTicks(7333) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 16, 48, 32, 62, DateTimeKind.Local).AddTicks(7341), new DateTime(2021, 10, 14, 18, 48, 32, 62, DateTimeKind.Local).AddTicks(7340) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 30, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7347), new DateTime(2021, 10, 15, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7346) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 8, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7355), new DateTime(2024, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7353) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 13, 3, 32, 62, DateTimeKind.Local).AddTicks(7361), new DateTime(2034, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7360) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7367), new DateTime(2021, 10, 14, 9, 48, 32, 62, DateTimeKind.Local).AddTicks(7366) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7373), new DateTime(2021, 10, 4, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7372) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7379), new DateTime(2021, 9, 1, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7378) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7386), new DateTime(2022, 1, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7384) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7393), new DateTime(2021, 10, 14, 13, 48, 32, 62, DateTimeKind.Local).AddTicks(7391) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 14, 48, 32, 62, DateTimeKind.Local).AddTicks(7398), new DateTime(2021, 10, 14, 16, 48, 32, 62, DateTimeKind.Local).AddTicks(7397) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 30, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7405), new DateTime(2021, 10, 19, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7403) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 3, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7411), new DateTime(2023, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7409) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 13, 31, 32, 62, DateTimeKind.Local).AddTicks(7417), new DateTime(2031, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7416) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 9, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7424), new DateTime(2021, 10, 14, 0, 48, 32, 62, DateTimeKind.Local).AddTicks(7422) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7434), new DateTime(2021, 10, 7, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7428) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7440), new DateTime(2021, 11, 26, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7439) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7447), new DateTime(2022, 1, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(7445) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 63, DateTimeKind.Local).AddTicks(1492));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 63, DateTimeKind.Local).AddTicks(1910));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 63, DateTimeKind.Local).AddTicks(1930));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 63, DateTimeKind.Local).AddTicks(1935));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 63, DateTimeKind.Local).AddTicks(1940));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 63, DateTimeKind.Local).AddTicks(1945));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 63, DateTimeKind.Local).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(9309));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(9824));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(9851));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(9861));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 14, 12, 48, 32, 62, DateTimeKind.Local).AddTicks(9865));
        }
    }
}
