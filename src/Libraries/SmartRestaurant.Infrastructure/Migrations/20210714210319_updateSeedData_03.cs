using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateSeedData_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FoodBusinessUsers",
                columns: new[] { "ApplicationUserId", "FoodBusinessId" },
                values: new object[,]
                {
                    { "3cbf3570-4444-4444-8746-29b7cf568093", new Guid("3cbf3570-4444-4673-8746-29b7cf568093") },
                    { "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093") },
                    { "44bf3570-0d44-4673-8746-29b7cf568088", new Guid("66bf3570-440d-4673-8746-29b7cf568099") },
                    { "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099") }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodBusinessUsers",
                keyColumns: new[] { "ApplicationUserId", "FoodBusinessId" },
                keyValues: new object[] { "3cbf3570-4444-4444-8746-29b7cf568093", new Guid("3cbf3570-4444-4673-8746-29b7cf568093") });

            migrationBuilder.DeleteData(
                table: "FoodBusinessUsers",
                keyColumns: new[] { "ApplicationUserId", "FoodBusinessId" },
                keyValues: new object[] { "44bf3570-0d44-4673-8746-29b7cf568088", new Guid("66bf3570-440d-4673-8746-29b7cf568099") });

            migrationBuilder.DeleteData(
                table: "FoodBusinessUsers",
                keyColumns: new[] { "ApplicationUserId", "FoodBusinessId" },
                keyValues: new object[] { "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093") });

            migrationBuilder.DeleteData(
                table: "FoodBusinessUsers",
                keyColumns: new[] { "ApplicationUserId", "FoodBusinessId" },
                keyValues: new object[] { "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099") });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(7057), new DateTime(2021, 7, 12, 4, 41, 10, 628, DateTimeKind.Local).AddTicks(635) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 4, 41, 10, 630, DateTimeKind.Local).AddTicks(8076), new DateTime(2021, 7, 12, 7, 41, 10, 630, DateTimeKind.Local).AddTicks(7983) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 26, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8141), new DateTime(2021, 7, 12, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8103) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 26, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8278), new DateTime(2026, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8155) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 0, 17, 10, 630, DateTimeKind.Local).AddTicks(8300), new DateTime(2036, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8291) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 10, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8335), new DateTime(2021, 7, 11, 20, 41, 10, 630, DateTimeKind.Local).AddTicks(8332) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8345), new DateTime(2021, 6, 29, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8343) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8357), new DateTime(2021, 5, 19, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8355) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8368), new DateTime(2021, 12, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8365) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8378), new DateTime(2021, 7, 12, 3, 41, 10, 630, DateTimeKind.Local).AddTicks(8375) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 4, 41, 10, 630, DateTimeKind.Local).AddTicks(8386), new DateTime(2021, 7, 12, 6, 41, 10, 630, DateTimeKind.Local).AddTicks(8384) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 27, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8396), new DateTime(2021, 7, 13, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8394) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 31, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8406), new DateTime(2025, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8403) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 0, 17, 10, 630, DateTimeKind.Local).AddTicks(8418), new DateTime(2036, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8415) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 9, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8427), new DateTime(2021, 7, 11, 19, 41, 10, 630, DateTimeKind.Local).AddTicks(8425) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8437), new DateTime(2021, 6, 28, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8434) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 4, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8446), new DateTime(2021, 5, 22, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8444) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8455), new DateTime(2021, 11, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8453) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8465), new DateTime(2021, 7, 12, 2, 41, 10, 630, DateTimeKind.Local).AddTicks(8463) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 3, 41, 10, 630, DateTimeKind.Local).AddTicks(8474), new DateTime(2021, 7, 12, 5, 41, 10, 630, DateTimeKind.Local).AddTicks(8472) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 27, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8486), new DateTime(2021, 7, 12, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8484) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 4, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8497), new DateTime(2024, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8494) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 11, 23, 56, 10, 630, DateTimeKind.Local).AddTicks(8509), new DateTime(2034, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8507) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 8, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8519), new DateTime(2021, 7, 11, 20, 41, 10, 630, DateTimeKind.Local).AddTicks(8516) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8527), new DateTime(2021, 7, 1, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8525) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8537), new DateTime(2021, 5, 29, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8534) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8547), new DateTime(2021, 10, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8544) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8738), new DateTime(2021, 7, 12, 0, 41, 10, 630, DateTimeKind.Local).AddTicks(8733) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 1, 41, 10, 630, DateTimeKind.Local).AddTicks(8749), new DateTime(2021, 7, 12, 3, 41, 10, 630, DateTimeKind.Local).AddTicks(8746) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 27, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8758), new DateTime(2021, 7, 16, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8756) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 31, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8769), new DateTime(2023, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8766) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 12, 0, 24, 10, 630, DateTimeKind.Local).AddTicks(8778), new DateTime(2031, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8776) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 6, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8787), new DateTime(2021, 7, 11, 11, 41, 10, 630, DateTimeKind.Local).AddTicks(8785) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8797), new DateTime(2021, 7, 4, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8794) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8806), new DateTime(2021, 8, 23, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8804) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8817), new DateTime(2021, 10, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8814) });
        }
    }
}
