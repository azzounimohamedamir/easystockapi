using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateSeedData_04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "CreatedAt", "CreatedBy", "FoodBusinessId", "LastModifiedAt", "LastModifiedBy", "MenuState", "Name" },
                values: new object[,]
                {
                    { new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"), new DateTime(2021, 7, 24, 18, 12, 32, 199, DateTimeKind.Local).AddTicks(2293), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "TajMhal Dishes Menu" },
                    { new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"), new DateTime(2021, 7, 24, 18, 12, 32, 199, DateTimeKind.Local).AddTicks(3330), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "TajMhal Pizza Menu" },
                    { new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"), new DateTime(2021, 7, 24, 18, 12, 32, 199, DateTimeKind.Local).AddTicks(3394), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "TajMhal Sandwiches Menu" },
                    { new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"), new DateTime(2021, 7, 24, 18, 12, 32, 199, DateTimeKind.Local).AddTicks(3420), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "TajMhal Beverage  Menu" },
                    { new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"), new DateTime(2021, 7, 24, 18, 12, 32, 199, DateTimeKind.Local).AddTicks(3444), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "TajMhal Dessert Menu" },
                    { new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"), new DateTime(2021, 7, 24, 18, 12, 32, 199, DateTimeKind.Local).AddTicks(3467), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Mcdonald Sandwiches Menu" },
                    { new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"), new DateTime(2021, 7, 24, 18, 12, 32, 199, DateTimeKind.Local).AddTicks(3492), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Mcdonald Beverage  Menu" },
                    { new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"), new DateTime(2021, 7, 24, 18, 12, 32, 199, DateTimeKind.Local).AddTicks(3514), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Mcdonald Dessert Menu" }
                });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(5647), new DateTime(2021, 7, 24, 23, 12, 32, 185, DateTimeKind.Local).AddTicks(6104) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 23, 12, 32, 197, DateTimeKind.Local).AddTicks(6927), new DateTime(2021, 7, 25, 2, 12, 32, 197, DateTimeKind.Local).AddTicks(6842) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 9, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7047), new DateTime(2021, 7, 25, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(6980) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 8, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7181), new DateTime(2026, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7078) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 18, 48, 32, 197, DateTimeKind.Local).AddTicks(7232), new DateTime(2036, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7212) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 23, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7304), new DateTime(2021, 7, 24, 15, 12, 32, 197, DateTimeKind.Local).AddTicks(7289) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7337), new DateTime(2021, 7, 12, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7325) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7377), new DateTime(2021, 6, 1, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7364) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7412), new DateTime(2021, 12, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7400) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7453), new DateTime(2021, 7, 24, 22, 12, 32, 197, DateTimeKind.Local).AddTicks(7439) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 23, 12, 32, 197, DateTimeKind.Local).AddTicks(7485), new DateTime(2021, 7, 25, 1, 12, 32, 197, DateTimeKind.Local).AddTicks(7473) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 10, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7517), new DateTime(2021, 7, 26, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7506) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 13, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7551), new DateTime(2025, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7539) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 18, 48, 32, 197, DateTimeKind.Local).AddTicks(7586), new DateTime(2036, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7573) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 22, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7619), new DateTime(2021, 7, 24, 14, 12, 32, 197, DateTimeKind.Local).AddTicks(7608) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7650), new DateTime(2021, 7, 11, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7639) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 4, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7686), new DateTime(2021, 6, 4, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7674) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7723), new DateTime(2021, 11, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7710) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7757), new DateTime(2021, 7, 24, 21, 12, 32, 197, DateTimeKind.Local).AddTicks(7746) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 22, 12, 32, 197, DateTimeKind.Local).AddTicks(7792), new DateTime(2021, 7, 25, 0, 12, 32, 197, DateTimeKind.Local).AddTicks(7780) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 10, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7825), new DateTime(2021, 7, 25, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7814) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 17, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7862), new DateTime(2024, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7849) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 18, 27, 32, 197, DateTimeKind.Local).AddTicks(7896), new DateTime(2034, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7884) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 21, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7931), new DateTime(2021, 7, 24, 15, 12, 32, 197, DateTimeKind.Local).AddTicks(7919) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7964), new DateTime(2021, 7, 14, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7953) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8000), new DateTime(2021, 6, 11, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(7987) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8043), new DateTime(2021, 10, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8029) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8078), new DateTime(2021, 7, 24, 19, 12, 32, 197, DateTimeKind.Local).AddTicks(8066) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 20, 12, 32, 197, DateTimeKind.Local).AddTicks(8112), new DateTime(2021, 7, 24, 22, 12, 32, 197, DateTimeKind.Local).AddTicks(8100) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 10, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8148), new DateTime(2021, 7, 29, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8135) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 13, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8182), new DateTime(2023, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8169) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 24, 18, 55, 32, 197, DateTimeKind.Local).AddTicks(8249), new DateTime(2031, 7, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8234) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 19, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8282), new DateTime(2021, 7, 24, 6, 12, 32, 197, DateTimeKind.Local).AddTicks(8270) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8317), new DateTime(2021, 7, 17, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8305) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8352), new DateTime(2021, 9, 5, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8341) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8389), new DateTime(2021, 10, 24, 18, 12, 32, 197, DateTimeKind.Local).AddTicks(8376) });

            migrationBuilder.InsertData(
                table: "Zones",
                columns: new[] { "ZoneId", "CreatedAt", "CreatedBy", "FoodBusinessId", "LastModifiedAt", "LastModifiedBy", "ZoneTitle" },
                values: new object[,]
                {
                    { new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"), new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(2582), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TajMhal VIP Zone" },
                    { new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"), new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(3873), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TajMhal FAMILY Zone" },
                    { new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"), new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(3952), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TajMhal NORMAL Zone" },
                    { new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"), new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(3977), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TajMhal OUTDOOR Zone" },
                    { new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"), new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(4027), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mcdonald OUTDOOR Zone" },
                    { new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"), new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(4006), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mcdonald NORMAL Zone" }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "TableNumber", "TableState", "ZoneId" },
                values: new object[,]
                {
                    { new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"), 4, new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(8005), "a1997466-cedc-4850-b18d-0ac4f4102cff", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, (short)0, new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0") },
                    { new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"), 6, new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(8984), "a1997466-cedc-4850-b18d-0ac4f4102cff", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, (short)0, new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1") },
                    { new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"), 4, new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(9105), "a1997466-cedc-4850-b18d-0ac4f4102cff", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, (short)0, new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2") },
                    { new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"), 3, new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(9132), "a1997466-cedc-4850-b18d-0ac4f4102cff", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, (short)0, new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3") },
                    { new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"), 5, new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(9154), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, (short)0, new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1") },
                    { new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"), 3, new DateTime(2021, 7, 24, 18, 12, 32, 198, DateTimeKind.Local).AddTicks(9177), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, (short)0, new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"));

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"));

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"));

            migrationBuilder.DeleteData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"));

            migrationBuilder.DeleteData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"));

            migrationBuilder.DeleteData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"));

            migrationBuilder.DeleteData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"));

            migrationBuilder.DeleteData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"));

            migrationBuilder.DeleteData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(3199), new DateTime(2021, 7, 15, 3, 3, 18, 308, DateTimeKind.Local).AddTicks(8102) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 15, 3, 3, 18, 311, DateTimeKind.Local).AddTicks(4118), new DateTime(2021, 7, 15, 6, 3, 18, 311, DateTimeKind.Local).AddTicks(4068) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 29, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4353), new DateTime(2021, 7, 15, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4293) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 29, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4493), new DateTime(2026, 7, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4365) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 22, 39, 18, 311, DateTimeKind.Local).AddTicks(4518), new DateTime(2036, 7, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4507) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 13, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4551), new DateTime(2021, 7, 14, 19, 3, 18, 311, DateTimeKind.Local).AddTicks(4548) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4563), new DateTime(2021, 7, 2, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4561) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4577), new DateTime(2021, 5, 22, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4575) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4589), new DateTime(2021, 12, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4586) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4599), new DateTime(2021, 7, 15, 2, 3, 18, 311, DateTimeKind.Local).AddTicks(4597) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 15, 3, 3, 18, 311, DateTimeKind.Local).AddTicks(4610), new DateTime(2021, 7, 15, 5, 3, 18, 311, DateTimeKind.Local).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 30, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4619), new DateTime(2021, 7, 16, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4617) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 3, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4631), new DateTime(2025, 7, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4629) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 22, 39, 18, 311, DateTimeKind.Local).AddTicks(4642), new DateTime(2036, 7, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4639) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4652), new DateTime(2021, 7, 14, 18, 3, 18, 311, DateTimeKind.Local).AddTicks(4649) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4661), new DateTime(2021, 7, 1, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4659) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 4, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4673), new DateTime(2021, 5, 25, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4671) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4683), new DateTime(2021, 11, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4681) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4694), new DateTime(2021, 7, 15, 1, 3, 18, 311, DateTimeKind.Local).AddTicks(4691) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 15, 2, 3, 18, 311, DateTimeKind.Local).AddTicks(4703), new DateTime(2021, 7, 15, 4, 3, 18, 311, DateTimeKind.Local).AddTicks(4701) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 30, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4713), new DateTime(2021, 7, 15, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4711) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 7, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4724), new DateTime(2024, 7, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4721) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 22, 18, 18, 311, DateTimeKind.Local).AddTicks(4734), new DateTime(2034, 7, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4731) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 11, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4743), new DateTime(2021, 7, 14, 19, 3, 18, 311, DateTimeKind.Local).AddTicks(4740) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4752), new DateTime(2021, 7, 4, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4750) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4763), new DateTime(2021, 6, 1, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4759) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4774), new DateTime(2021, 10, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4772) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4784), new DateTime(2021, 7, 14, 23, 3, 18, 311, DateTimeKind.Local).AddTicks(4782) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 15, 0, 3, 18, 311, DateTimeKind.Local).AddTicks(4793), new DateTime(2021, 7, 15, 2, 3, 18, 311, DateTimeKind.Local).AddTicks(4791) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 30, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4802), new DateTime(2021, 7, 19, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 3, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4812), new DateTime(2023, 7, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4809) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 14, 22, 46, 18, 311, DateTimeKind.Local).AddTicks(4824), new DateTime(2031, 7, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4821) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 9, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4833), new DateTime(2021, 7, 14, 10, 3, 18, 311, DateTimeKind.Local).AddTicks(4831) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4843), new DateTime(2021, 7, 7, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4841) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4853), new DateTime(2021, 8, 26, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4850) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4864), new DateTime(2021, 10, 14, 22, 3, 18, 311, DateTimeKind.Local).AddTicks(4860) });
        }
    }
}
