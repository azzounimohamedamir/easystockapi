using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class addNamesTranslationOfOrderDishAndSuppluments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Names_AR",
                table: "OrderProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_EN",
                table: "OrderProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_FR",
                table: "OrderProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_RU",
                table: "OrderProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_TR",
                table: "OrderProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_AR",
                table: "OrderDishSupplements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_EN",
                table: "OrderDishSupplements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_FR",
                table: "OrderDishSupplements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_RU",
                table: "OrderDishSupplements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_TR",
                table: "OrderDishSupplements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_AR",
                table: "OrderDishes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_EN",
                table: "OrderDishes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_FR",
                table: "OrderDishes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_RU",
                table: "OrderDishes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names_TR",
                table: "OrderDishes",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(4651));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(4640));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(4644));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(4290));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(4628));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(4632));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(4647));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(7665), new DateTime(2022, 6, 14, 14, 1, 47, 394, DateTimeKind.Local).AddTicks(7690) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 14, 1, 47, 395, DateTimeKind.Local).AddTicks(8114), new DateTime(2022, 6, 14, 17, 1, 47, 395, DateTimeKind.Local).AddTicks(8089) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 30, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8147), new DateTime(2022, 6, 15, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8128) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 29, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8217), new DateTime(2027, 6, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8154) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 9, 37, 47, 395, DateTimeKind.Local).AddTicks(8227), new DateTime(2037, 6, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8222) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 13, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8246), new DateTime(2022, 6, 14, 6, 1, 47, 395, DateTimeKind.Local).AddTicks(8244) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8251), new DateTime(2022, 6, 2, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8250) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8257), new DateTime(2022, 4, 22, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8256) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8264), new DateTime(2022, 11, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8263) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8270), new DateTime(2022, 6, 14, 13, 1, 47, 395, DateTimeKind.Local).AddTicks(8268) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 14, 1, 47, 395, DateTimeKind.Local).AddTicks(8274), new DateTime(2022, 6, 14, 16, 1, 47, 395, DateTimeKind.Local).AddTicks(8273) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 31, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8279), new DateTime(2022, 6, 16, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8278) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 4, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8285), new DateTime(2026, 6, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8284) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 9, 37, 47, 395, DateTimeKind.Local).AddTicks(8291), new DateTime(2037, 6, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8289) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 12, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8296), new DateTime(2022, 6, 14, 5, 1, 47, 395, DateTimeKind.Local).AddTicks(8295) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8301), new DateTime(2022, 6, 1, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8300) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8307), new DateTime(2022, 4, 25, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8306) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8312), new DateTime(2022, 10, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8311) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8317), new DateTime(2022, 6, 14, 12, 1, 47, 395, DateTimeKind.Local).AddTicks(8316) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 13, 1, 47, 395, DateTimeKind.Local).AddTicks(8322), new DateTime(2022, 6, 14, 15, 1, 47, 395, DateTimeKind.Local).AddTicks(8321) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 31, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8327), new DateTime(2022, 6, 15, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8326) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 8, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8333), new DateTime(2025, 6, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8331) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 9, 16, 47, 395, DateTimeKind.Local).AddTicks(8338), new DateTime(2035, 6, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8337) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 11, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8343), new DateTime(2022, 6, 14, 6, 1, 47, 395, DateTimeKind.Local).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8348), new DateTime(2022, 6, 4, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8347) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8354), new DateTime(2022, 5, 2, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8359), new DateTime(2022, 9, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8358) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8365), new DateTime(2022, 6, 14, 10, 1, 47, 395, DateTimeKind.Local).AddTicks(8363) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 11, 1, 47, 395, DateTimeKind.Local).AddTicks(8370), new DateTime(2022, 6, 14, 13, 1, 47, 395, DateTimeKind.Local).AddTicks(8369) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 31, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8375), new DateTime(2022, 6, 19, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8374) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 4, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8381), new DateTime(2024, 6, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8379) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 14, 9, 44, 47, 395, DateTimeKind.Local).AddTicks(8387), new DateTime(2032, 6, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8386) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 9, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8392), new DateTime(2022, 6, 13, 21, 1, 47, 395, DateTimeKind.Local).AddTicks(8391) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8398), new DateTime(2022, 6, 7, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8397) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8404), new DateTime(2022, 7, 27, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8403) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8410), new DateTime(2022, 9, 14, 9, 1, 47, 395, DateTimeKind.Local).AddTicks(8408) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(3130));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(3149));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(3154));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(3163));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(3167));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(1036));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(1401));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 14, 9, 1, 47, 396, DateTimeKind.Local).AddTicks(1442));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Names_AR",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "Names_EN",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "Names_FR",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "Names_RU",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "Names_TR",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "Names_AR",
                table: "OrderDishSupplements");

            migrationBuilder.DropColumn(
                name: "Names_EN",
                table: "OrderDishSupplements");

            migrationBuilder.DropColumn(
                name: "Names_FR",
                table: "OrderDishSupplements");

            migrationBuilder.DropColumn(
                name: "Names_RU",
                table: "OrderDishSupplements");

            migrationBuilder.DropColumn(
                name: "Names_TR",
                table: "OrderDishSupplements");

            migrationBuilder.DropColumn(
                name: "Names_AR",
                table: "OrderDishes");

            migrationBuilder.DropColumn(
                name: "Names_EN",
                table: "OrderDishes");

            migrationBuilder.DropColumn(
                name: "Names_FR",
                table: "OrderDishes");

            migrationBuilder.DropColumn(
                name: "Names_RU",
                table: "OrderDishes");

            migrationBuilder.DropColumn(
                name: "Names_TR",
                table: "OrderDishes");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7881));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7877));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7864));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7867));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7870));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7839));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7857));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(7874));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(1456), new DateTime(2022, 6, 7, 4, 37, 24, 174, DateTimeKind.Local).AddTicks(2083) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 7, 4, 37, 24, 175, DateTimeKind.Local).AddTicks(1875), new DateTime(2022, 6, 7, 7, 37, 24, 175, DateTimeKind.Local).AddTicks(1855) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 22, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(1907), new DateTime(2022, 6, 7, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(1886) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 21, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(1995), new DateTime(2027, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(1912) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 7, 0, 13, 24, 175, DateTimeKind.Local).AddTicks(2004), new DateTime(2037, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2000) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 5, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2024), new DateTime(2022, 6, 6, 20, 37, 24, 175, DateTimeKind.Local).AddTicks(2023) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2030), new DateTime(2022, 5, 25, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2029) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2037), new DateTime(2022, 4, 14, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2036) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 10, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2042), new DateTime(2022, 11, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2041) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2047), new DateTime(2022, 6, 7, 3, 37, 24, 175, DateTimeKind.Local).AddTicks(2046) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 7, 4, 37, 24, 175, DateTimeKind.Local).AddTicks(2051), new DateTime(2022, 6, 7, 6, 37, 24, 175, DateTimeKind.Local).AddTicks(2050) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 23, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2056), new DateTime(2022, 6, 8, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2055) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 27, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2061), new DateTime(2026, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2059) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 7, 0, 13, 24, 175, DateTimeKind.Local).AddTicks(2066), new DateTime(2037, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2064) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 4, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2070), new DateTime(2022, 6, 6, 19, 37, 24, 175, DateTimeKind.Local).AddTicks(2069) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2076), new DateTime(2022, 5, 24, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2075) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2084), new DateTime(2022, 4, 17, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2083) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 9, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2089), new DateTime(2022, 10, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2087) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2093), new DateTime(2022, 6, 7, 2, 37, 24, 175, DateTimeKind.Local).AddTicks(2092) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 7, 3, 37, 24, 175, DateTimeKind.Local).AddTicks(2098), new DateTime(2022, 6, 7, 5, 37, 24, 175, DateTimeKind.Local).AddTicks(2097) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 23, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2102), new DateTime(2022, 6, 7, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2101) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 31, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2107), new DateTime(2025, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2105) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 6, 23, 52, 24, 175, DateTimeKind.Local).AddTicks(2111), new DateTime(2035, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2110) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 3, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2116), new DateTime(2022, 6, 6, 20, 37, 24, 175, DateTimeKind.Local).AddTicks(2114) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2120), new DateTime(2022, 5, 27, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2119) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 4, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2124), new DateTime(2022, 4, 24, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2123) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2130), new DateTime(2022, 9, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2129) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2135), new DateTime(2022, 6, 7, 0, 37, 24, 175, DateTimeKind.Local).AddTicks(2134) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 7, 1, 37, 24, 175, DateTimeKind.Local).AddTicks(2139), new DateTime(2022, 6, 7, 3, 37, 24, 175, DateTimeKind.Local).AddTicks(2138) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 23, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2144), new DateTime(2022, 6, 11, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2143) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 26, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2150), new DateTime(2024, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2147) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 7, 0, 20, 24, 175, DateTimeKind.Local).AddTicks(2156), new DateTime(2032, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2154) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 6, 1, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2160), new DateTime(2022, 6, 6, 11, 37, 24, 175, DateTimeKind.Local).AddTicks(2159) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 5, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2164), new DateTime(2022, 5, 30, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2163) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 7, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2169), new DateTime(2022, 7, 19, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2168) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 8, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2175), new DateTime(2022, 9, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(2173) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(5837));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(6555));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(6569));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(6573));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(6578));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(6585));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(4221));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(4541));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(4570));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2022, 6, 6, 23, 37, 24, 175, DateTimeKind.Local).AddTicks(4574));
        }
    }
}
