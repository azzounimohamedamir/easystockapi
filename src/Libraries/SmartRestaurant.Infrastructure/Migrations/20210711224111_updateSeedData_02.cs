using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateSeedData_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CreatedAt", "CreatedBy", "FoodBusinessId", "LastModifiedAt", "LastModifiedBy", "NumberOfDiners", "ReservationDate", "ReservationName" },
                values: new object[,]
                {
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596300"), new DateTime(2021, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(7057), "5a84cd00-59f0-4b22-bfce-07c080829118", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, new DateTime(2021, 7, 12, 4, 41, 10, 628, DateTimeKind.Local).AddTicks(635), "ReservationName_00" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596329"), new DateTime(2021, 6, 27, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8486), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, new DateTime(2021, 7, 12, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8484), "ReservationName_29" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596330"), new DateTime(2021, 9, 4, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8497), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, new DateTime(2024, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8494), "ReservationName_30" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596331"), new DateTime(2021, 7, 11, 23, 56, 10, 630, DateTimeKind.Local).AddTicks(8509), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, new DateTime(2034, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8507), "ReservationName_31" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596332"), new DateTime(2021, 7, 8, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8519), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 14, new DateTime(2021, 7, 11, 20, 41, 10, 630, DateTimeKind.Local).AddTicks(8516), "ReservationName_32" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596333"), new DateTime(2021, 6, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8527), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, new DateTime(2021, 7, 1, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8525), "ReservationName_33" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596334"), new DateTime(2021, 5, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8537), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, new DateTime(2021, 5, 29, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8534), "ReservationName_34" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596328"), new DateTime(2021, 7, 12, 3, 41, 10, 630, DateTimeKind.Local).AddTicks(8474), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, new DateTime(2021, 7, 12, 5, 41, 10, 630, DateTimeKind.Local).AddTicks(8472), "ReservationName_28" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596335"), new DateTime(2021, 9, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8547), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, new DateTime(2021, 10, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8544), "ReservationName_35" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596337"), new DateTime(2021, 7, 12, 1, 41, 10, 630, DateTimeKind.Local).AddTicks(8749), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, new DateTime(2021, 7, 12, 3, 41, 10, 630, DateTimeKind.Local).AddTicks(8746), "ReservationName_37" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596338"), new DateTime(2021, 6, 27, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8758), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, new DateTime(2021, 7, 16, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8756), "ReservationName_38" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596339"), new DateTime(2021, 7, 31, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8769), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, new DateTime(2023, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8766), "ReservationName_39" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596340"), new DateTime(2021, 7, 12, 0, 24, 10, 630, DateTimeKind.Local).AddTicks(8778), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, new DateTime(2031, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8776), "ReservationName_40" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596341"), new DateTime(2021, 7, 6, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8787), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 17, new DateTime(2021, 7, 11, 11, 41, 10, 630, DateTimeKind.Local).AddTicks(8785), "ReservationName_41" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596342"), new DateTime(2021, 6, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8797), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, new DateTime(2021, 7, 4, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8794), "ReservationName_42" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596336"), new DateTime(2021, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8738), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, new DateTime(2021, 7, 12, 0, 41, 10, 630, DateTimeKind.Local).AddTicks(8733), "ReservationName_36" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596327"), new DateTime(2021, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8465), "a1997466-cedc-4850-b18d-0ac4f4102cff", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, new DateTime(2021, 7, 12, 2, 41, 10, 630, DateTimeKind.Local).AddTicks(8463), "ReservationName_27" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596317"), new DateTime(2021, 10, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8455), "6b14cd00-59f0-4422-bfce-07c080829987", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, new DateTime(2021, 11, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8453), "ReservationName_17" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596316"), new DateTime(2021, 4, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8446), "6b14cd00-59f0-4422-bfce-07c080829987", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, new DateTime(2021, 5, 22, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8444), "ReservationName_16" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596301"), new DateTime(2021, 7, 12, 4, 41, 10, 630, DateTimeKind.Local).AddTicks(8076), "5a84cd00-59f0-4b22-bfce-07c080829118", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, new DateTime(2021, 7, 12, 7, 41, 10, 630, DateTimeKind.Local).AddTicks(7983), "ReservationName_01" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596302"), new DateTime(2021, 6, 26, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8141), "5a84cd00-59f0-4b22-bfce-07c080829118", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, new DateTime(2021, 7, 12, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8103), "ReservationName_02" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596303"), new DateTime(2021, 7, 26, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8278), "5a84cd00-59f0-4b22-bfce-07c080829118", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, new DateTime(2026, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8155), "ReservationName_03" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596304"), new DateTime(2021, 7, 12, 0, 17, 10, 630, DateTimeKind.Local).AddTicks(8300), "5a84cd00-59f0-4b22-bfce-07c080829118", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, new DateTime(2036, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8291), "ReservationName_04" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596305"), new DateTime(2021, 7, 10, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8335), "5a84cd00-59f0-4b22-bfce-07c080829118", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 13, new DateTime(2021, 7, 11, 20, 41, 10, 630, DateTimeKind.Local).AddTicks(8332), "ReservationName_05" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596306"), new DateTime(2021, 6, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8345), "5a84cd00-59f0-4b22-bfce-07c080829118", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, new DateTime(2021, 6, 29, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8343), "ReservationName_06" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596307"), new DateTime(2021, 5, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8357), "5a84cd00-59f0-4b22-bfce-07c080829118", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, new DateTime(2021, 5, 19, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8355), "ReservationName_07" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596308"), new DateTime(2021, 11, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8368), "5a84cd00-59f0-4b22-bfce-07c080829118", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, new DateTime(2021, 12, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8365), "ReservationName_08" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596309"), new DateTime(2021, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8378), "6b14cd00-59f0-4422-bfce-07c080829987", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, new DateTime(2021, 7, 12, 3, 41, 10, 630, DateTimeKind.Local).AddTicks(8375), "ReservationName_09" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596310"), new DateTime(2021, 7, 12, 4, 41, 10, 630, DateTimeKind.Local).AddTicks(8386), "6b14cd00-59f0-4422-bfce-07c080829987", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, new DateTime(2021, 7, 12, 6, 41, 10, 630, DateTimeKind.Local).AddTicks(8384), "ReservationName_10" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596311"), new DateTime(2021, 6, 27, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8396), "6b14cd00-59f0-4422-bfce-07c080829987", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, new DateTime(2021, 7, 13, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8394), "ReservationName_11" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596312"), new DateTime(2021, 8, 31, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8406), "6b14cd00-59f0-4422-bfce-07c080829987", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, new DateTime(2025, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8403), "ReservationName_12" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596313"), new DateTime(2021, 7, 12, 0, 17, 10, 630, DateTimeKind.Local).AddTicks(8418), "6b14cd00-59f0-4422-bfce-07c080829987", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, new DateTime(2036, 7, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8415), "ReservationName_13" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596314"), new DateTime(2021, 7, 9, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8427), "6b14cd00-59f0-4422-bfce-07c080829987", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 14, new DateTime(2021, 7, 11, 19, 41, 10, 630, DateTimeKind.Local).AddTicks(8425), "ReservationName_14" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596315"), new DateTime(2021, 6, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8437), "6b14cd00-59f0-4422-bfce-07c080829987", new Guid("3cbf3570-4444-4673-8746-29b7cf568093"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, new DateTime(2021, 6, 28, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8434), "ReservationName_15" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596343"), new DateTime(2021, 8, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8806), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, new DateTime(2021, 8, 23, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8804), "ReservationName_43" },
                    { new Guid("acbf657b-3398-7a73-8746-77b7cf596344"), new DateTime(2021, 9, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8817), "b2207466-ceda-4b50-b18d-0ac4f4102caa", new Guid("66bf3570-440d-4673-8746-29b7cf568099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, new DateTime(2021, 10, 11, 23, 41, 10, 630, DateTimeKind.Local).AddTicks(8814), "ReservationName_44" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"));
        }
    }
}
