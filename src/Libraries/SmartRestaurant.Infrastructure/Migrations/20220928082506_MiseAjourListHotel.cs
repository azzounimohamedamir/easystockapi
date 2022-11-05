using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class MiseAjourListHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("88bc7853-220f-9173-3246-afb7cf595022"));

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "FoodBusinessAdministratorId", "ImagUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("461b8d1f-bc06-489d-b6dc-2a2ecda89474"), "3cbf3570-4444-4444-8746-29b7cf568093", "assets/hotels/aurassi.jpg", "Aurassi" },
                    { new Guid("abc43ab1-3c8c-483f-9687-9374c20c49de"), "3cbf3570-4444-4444-8746-29b7cf568093", "assets/hotels/sofitel.jpg", "Sofitel" },
                    { new Guid("06c996cf-949b-49bf-849f-bf4f7f466132"), "3cbf3570-4444-4444-8746-29b7cf568093", "assets/hotels/tulip.jpg", "Tulip" }
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(4117));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(4074));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(2553));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(3936));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(4014));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(4030));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 23, DateTimeKind.Local).AddTicks(4088));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(6705), new DateTime(2022, 9, 28, 14, 25, 2, 16, DateTimeKind.Local).AddTicks(5496) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 14, 25, 2, 20, DateTimeKind.Local).AddTicks(8463), new DateTime(2022, 9, 28, 17, 25, 2, 20, DateTimeKind.Local).AddTicks(8354) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 13, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8598), new DateTime(2022, 9, 29, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8516) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 13, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8821), new DateTime(2027, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8618) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 10, 1, 2, 20, DateTimeKind.Local).AddTicks(8861), new DateTime(2037, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8844) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8927), new DateTime(2022, 9, 28, 6, 25, 2, 20, DateTimeKind.Local).AddTicks(8920) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8945), new DateTime(2022, 9, 16, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8941) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8967), new DateTime(2022, 8, 6, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8963) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 1, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8988), new DateTime(2023, 2, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(8982) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9007), new DateTime(2022, 9, 28, 13, 25, 2, 20, DateTimeKind.Local).AddTicks(9002) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 14, 25, 2, 20, DateTimeKind.Local).AddTicks(9025), new DateTime(2022, 9, 28, 16, 25, 2, 20, DateTimeKind.Local).AddTicks(9021) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 14, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9044), new DateTime(2022, 9, 30, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9039) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 18, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9064), new DateTime(2026, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9058) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 10, 1, 2, 20, DateTimeKind.Local).AddTicks(9083), new DateTime(2037, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9078) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 26, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9105), new DateTime(2022, 9, 28, 5, 25, 2, 20, DateTimeKind.Local).AddTicks(9100) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9124), new DateTime(2022, 9, 15, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9119) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9143), new DateTime(2022, 8, 9, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9139) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9163), new DateTime(2023, 1, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9157) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9182), new DateTime(2022, 9, 28, 12, 25, 2, 20, DateTimeKind.Local).AddTicks(9177) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 13, 25, 2, 20, DateTimeKind.Local).AddTicks(9446), new DateTime(2022, 9, 28, 15, 25, 2, 20, DateTimeKind.Local).AddTicks(9437) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 14, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9464), new DateTime(2022, 9, 29, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9459) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 22, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9484), new DateTime(2025, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9477) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 9, 40, 2, 20, DateTimeKind.Local).AddTicks(9503), new DateTime(2035, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9498) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 25, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9523), new DateTime(2022, 9, 28, 6, 25, 2, 20, DateTimeKind.Local).AddTicks(9518) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9541), new DateTime(2022, 9, 18, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9536) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9559), new DateTime(2022, 8, 16, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9555) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9581), new DateTime(2022, 12, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9576) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9602), new DateTime(2022, 9, 28, 10, 25, 2, 20, DateTimeKind.Local).AddTicks(9597) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 11, 25, 2, 20, DateTimeKind.Local).AddTicks(9620), new DateTime(2022, 9, 28, 13, 25, 2, 20, DateTimeKind.Local).AddTicks(9616) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 14, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9639), new DateTime(2022, 10, 3, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9634) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 18, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9661), new DateTime(2024, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9653) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 10, 8, 2, 20, DateTimeKind.Local).AddTicks(9683), new DateTime(2032, 9, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9676) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 23, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9701), new DateTime(2022, 9, 27, 21, 25, 2, 20, DateTimeKind.Local).AddTicks(9696) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9721), new DateTime(2022, 9, 21, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9716) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9743), new DateTime(2022, 11, 10, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9737) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9763), new DateTime(2022, 12, 28, 9, 25, 2, 20, DateTimeKind.Local).AddTicks(9758) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(8025));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(8086));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(8102));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(8114));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 21, DateTimeKind.Local).AddTicks(8815));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(381));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(449));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(469));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(486));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(502));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 28, 9, 25, 2, 22, DateTimeKind.Local).AddTicks(517));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("06c996cf-949b-49bf-849f-bf4f7f466132"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("461b8d1f-bc06-489d-b6dc-2a2ecda89474"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("abc43ab1-3c8c-483f-9687-9374c20c49de"));

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "FoodBusinessAdministratorId", "ImagUrl", "Name" },
                values: new object[] { new Guid("88bc7853-220f-9173-3246-afb7cf595022"), "amir", "assets/hotels/aurassi.jpg", "Aurassi" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2537));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2496));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2517));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2415));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 984, DateTimeKind.Local).AddTicks(2528));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 19, 19, 38, 981, DateTimeKind.Local).AddTicks(7765), new DateTime(2022, 9, 28, 0, 19, 38, 977, DateTimeKind.Local).AddTicks(5920) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 0, 19, 38, 982, DateTimeKind.Local).AddTicks(951), new DateTime(2022, 9, 28, 3, 19, 38, 982, DateTimeKind.Local).AddTicks(828) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 12, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1107), new DateTime(2022, 9, 28, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1017) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 12, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1406), new DateTime(2027, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1137) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 19, 55, 38, 982, DateTimeKind.Local).AddTicks(1465), new DateTime(2037, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1441) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 26, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1553), new DateTime(2022, 9, 27, 16, 19, 38, 982, DateTimeKind.Local).AddTicks(1544) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1581), new DateTime(2022, 9, 15, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1575) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1614), new DateTime(2022, 8, 5, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1607) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2023, 1, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1645), new DateTime(2023, 2, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1637) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1675), new DateTime(2022, 9, 27, 23, 19, 38, 982, DateTimeKind.Local).AddTicks(1669) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 28, 0, 19, 38, 982, DateTimeKind.Local).AddTicks(1705), new DateTime(2022, 9, 28, 2, 19, 38, 982, DateTimeKind.Local).AddTicks(1699) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 13, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1734), new DateTime(2022, 9, 29, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1728) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 17, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1767), new DateTime(2026, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(1758) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 19, 55, 38, 982, DateTimeKind.Local).AddTicks(2012), new DateTime(2037, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2000) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 25, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2041), new DateTime(2022, 9, 27, 15, 19, 38, 982, DateTimeKind.Local).AddTicks(2035) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2071), new DateTime(2022, 9, 14, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2064) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2101), new DateTime(2022, 8, 8, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2095) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 12, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2133), new DateTime(2023, 1, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2125) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2163), new DateTime(2022, 9, 27, 22, 19, 38, 982, DateTimeKind.Local).AddTicks(2157) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 23, 19, 38, 982, DateTimeKind.Local).AddTicks(2190), new DateTime(2022, 9, 28, 1, 19, 38, 982, DateTimeKind.Local).AddTicks(2184) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 13, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2220), new DateTime(2022, 9, 28, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2214) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 21, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2250), new DateTime(2025, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2242) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 19, 34, 38, 982, DateTimeKind.Local).AddTicks(2282), new DateTime(2035, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2273) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 24, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2310), new DateTime(2022, 9, 27, 16, 19, 38, 982, DateTimeKind.Local).AddTicks(2304) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2339), new DateTime(2022, 9, 17, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2333) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2368), new DateTime(2022, 8, 15, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2362) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2399), new DateTime(2022, 12, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2391) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2429), new DateTime(2022, 9, 27, 20, 19, 38, 982, DateTimeKind.Local).AddTicks(2423) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 21, 19, 38, 982, DateTimeKind.Local).AddTicks(2457), new DateTime(2022, 9, 27, 23, 19, 38, 982, DateTimeKind.Local).AddTicks(2449) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 13, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2484), new DateTime(2022, 10, 2, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2478) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 17, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2514), new DateTime(2024, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2504) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 27, 20, 2, 38, 982, DateTimeKind.Local).AddTicks(2544), new DateTime(2032, 9, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2535) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 22, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2571), new DateTime(2022, 9, 27, 7, 19, 38, 982, DateTimeKind.Local).AddTicks(2565) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2597), new DateTime(2022, 9, 20, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2591) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2625), new DateTime(2022, 11, 9, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2619) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 11, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2652), new DateTime(2022, 12, 27, 19, 19, 38, 982, DateTimeKind.Local).AddTicks(2644) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(6828));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(7997));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(8011));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(8021));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(2362));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(2441));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(2453));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 9, 27, 19, 19, 38, 983, DateTimeKind.Local).AddTicks(2465));
        }
    }
}
