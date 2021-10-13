using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carbs",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "FoodBusinessId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "MaxQuantity_Amount",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "MaxQuantity_MeasurementUnits",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "MinQuantity_MeasurementUnits",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "MinQuantity_Amount",
                table: "Ingredients",
                newName: "EnergeticValue_Amount");

            migrationBuilder.RenameColumn(
                name: "Protein",
                table: "Ingredients",
                newName: "EnergeticValue_Protein");

            migrationBuilder.RenameColumn(
                name: "Fat",
                table: "Ingredients",
                newName: "EnergeticValue_Fat");

            migrationBuilder.RenameColumn(
                name: "Energy",
                table: "Ingredients",
                newName: "EnergeticValue_Energy");

            migrationBuilder.AlterColumn<float>(
                name: "EnergeticValue_Protein",
                table: "Ingredients",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "EnergeticValue_Fat",
                table: "Ingredients",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "EnergeticValue_Energy",
                table: "Ingredients",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "Names",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "EnergeticValue_Carbohydrates",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnergeticValue_MeasurementUnit",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6275));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6223));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6233));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6243));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(5423));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6140));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6187));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6202));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6212));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(3263), new DateTime(2021, 10, 11, 9, 54, 4, 318, DateTimeKind.Local).AddTicks(638) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 9, 54, 4, 324, DateTimeKind.Local).AddTicks(4314), new DateTime(2021, 10, 11, 12, 54, 4, 324, DateTimeKind.Local).AddTicks(4248) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 26, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4402), new DateTime(2021, 10, 12, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4351) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 26, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4490), new DateTime(2026, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4424) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 5, 30, 4, 324, DateTimeKind.Local).AddTicks(4525), new DateTime(2036, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4513) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 10, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4569), new DateTime(2021, 10, 11, 1, 54, 4, 324, DateTimeKind.Local).AddTicks(4558) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4589), new DateTime(2021, 9, 29, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4583) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4606), new DateTime(2021, 8, 19, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4601) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4625), new DateTime(2022, 3, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4619) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4645), new DateTime(2021, 10, 11, 8, 54, 4, 324, DateTimeKind.Local).AddTicks(4638) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 9, 54, 4, 324, DateTimeKind.Local).AddTicks(4665), new DateTime(2021, 10, 11, 11, 54, 4, 324, DateTimeKind.Local).AddTicks(4657) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4684), new DateTime(2021, 10, 13, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4677) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4703), new DateTime(2025, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4696) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 5, 30, 4, 324, DateTimeKind.Local).AddTicks(4720), new DateTime(2036, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4713) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 9, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4739), new DateTime(2021, 10, 11, 0, 54, 4, 324, DateTimeKind.Local).AddTicks(4733) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4756), new DateTime(2021, 9, 28, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4750) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4772), new DateTime(2021, 8, 22, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4766) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4788), new DateTime(2022, 2, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4782) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4807), new DateTime(2021, 10, 11, 7, 54, 4, 324, DateTimeKind.Local).AddTicks(4800) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 8, 54, 4, 324, DateTimeKind.Local).AddTicks(4825), new DateTime(2021, 10, 11, 10, 54, 4, 324, DateTimeKind.Local).AddTicks(4818) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4841), new DateTime(2021, 10, 12, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4835) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 5, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4857), new DateTime(2024, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4851) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 5, 9, 4, 324, DateTimeKind.Local).AddTicks(4875), new DateTime(2034, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 8, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(4891), new DateTime(2021, 10, 11, 1, 54, 4, 324, DateTimeKind.Local).AddTicks(4886) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5072), new DateTime(2021, 10, 1, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5088), new DateTime(2021, 8, 29, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5083) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5106), new DateTime(2022, 1, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5099) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5124), new DateTime(2021, 10, 11, 5, 54, 4, 324, DateTimeKind.Local).AddTicks(5117) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 6, 54, 4, 324, DateTimeKind.Local).AddTicks(5146), new DateTime(2021, 10, 11, 8, 54, 4, 324, DateTimeKind.Local).AddTicks(5139) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 27, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5165), new DateTime(2021, 10, 16, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5159) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 31, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5182), new DateTime(2023, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5175) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 5, 37, 4, 324, DateTimeKind.Local).AddTicks(5199), new DateTime(2031, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5217), new DateTime(2021, 10, 10, 16, 54, 4, 324, DateTimeKind.Local).AddTicks(5212) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5233), new DateTime(2021, 10, 4, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5228) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5250), new DateTime(2021, 11, 23, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5245) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5268), new DateTime(2022, 1, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(5262) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(2987));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(3079));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 325, DateTimeKind.Local).AddTicks(3089));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(8342));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(9125));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(9178));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(9192));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(9205));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 11, 4, 54, 4, 324, DateTimeKind.Local).AddTicks(9228));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Names",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "EnergeticValue_Carbohydrates",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "EnergeticValue_MeasurementUnit",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "EnergeticValue_Protein",
                table: "Ingredients",
                newName: "Protein");

            migrationBuilder.RenameColumn(
                name: "EnergeticValue_Fat",
                table: "Ingredients",
                newName: "Fat");

            migrationBuilder.RenameColumn(
                name: "EnergeticValue_Energy",
                table: "Ingredients",
                newName: "Energy");

            migrationBuilder.RenameColumn(
                name: "EnergeticValue_Amount",
                table: "Ingredients",
                newName: "MinQuantity_Amount");

            migrationBuilder.AlterColumn<float>(
                name: "Protein",
                table: "Ingredients",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Fat",
                table: "Ingredients",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Energy",
                table: "Ingredients",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Carbs",
                table: "Ingredients",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<Guid>(
                name: "FoodBusinessId",
                table: "Ingredients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MaxQuantity_Amount",
                table: "Ingredients",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxQuantity_MeasurementUnits",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinQuantity_MeasurementUnits",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3262));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3252));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3207));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3228));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(2358));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3116));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3167));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3182));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3193));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(3239));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 20, 38, 30, 812, DateTimeKind.Local).AddTicks(8889), new DateTime(2021, 10, 8, 1, 38, 30, 807, DateTimeKind.Local).AddTicks(612) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 8, 1, 38, 30, 812, DateTimeKind.Local).AddTicks(9769), new DateTime(2021, 10, 8, 4, 38, 30, 812, DateTimeKind.Local).AddTicks(9717) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 22, 20, 38, 30, 812, DateTimeKind.Local).AddTicks(9841), new DateTime(2021, 10, 8, 20, 38, 30, 812, DateTimeKind.Local).AddTicks(9798) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 22, 20, 38, 30, 812, DateTimeKind.Local).AddTicks(9926), new DateTime(2026, 10, 7, 20, 38, 30, 812, DateTimeKind.Local).AddTicks(9859) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 21, 14, 30, 812, DateTimeKind.Local).AddTicks(9958), new DateTime(2036, 10, 7, 20, 38, 30, 812, DateTimeKind.Local).AddTicks(9944) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 6, 20, 38, 30, 812, DateTimeKind.Local).AddTicks(9999), new DateTime(2021, 10, 7, 17, 38, 30, 812, DateTimeKind.Local).AddTicks(9990) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(14), new DateTime(2021, 9, 25, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(9) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(32), new DateTime(2021, 8, 15, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(27) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(48), new DateTime(2022, 3, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(43) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(65), new DateTime(2021, 10, 8, 0, 38, 30, 813, DateTimeKind.Local).AddTicks(60) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 8, 1, 38, 30, 813, DateTimeKind.Local).AddTicks(82), new DateTime(2021, 10, 8, 3, 38, 30, 813, DateTimeKind.Local).AddTicks(76) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(98), new DateTime(2021, 10, 9, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(93) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 27, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(115), new DateTime(2025, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(109) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 21, 14, 30, 813, DateTimeKind.Local).AddTicks(133), new DateTime(2036, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(127) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 5, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(148), new DateTime(2021, 10, 7, 16, 38, 30, 813, DateTimeKind.Local).AddTicks(143) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(164), new DateTime(2021, 9, 24, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(159) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(180), new DateTime(2021, 8, 18, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(175) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(197), new DateTime(2022, 2, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(191) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(213), new DateTime(2021, 10, 7, 23, 38, 30, 813, DateTimeKind.Local).AddTicks(207) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 8, 0, 38, 30, 813, DateTimeKind.Local).AddTicks(228), new DateTime(2021, 10, 8, 2, 38, 30, 813, DateTimeKind.Local).AddTicks(223) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(243), new DateTime(2021, 10, 8, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(238) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 1, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(259), new DateTime(2024, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(253) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 20, 53, 30, 813, DateTimeKind.Local).AddTicks(280), new DateTime(2034, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(275) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 4, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(296), new DateTime(2021, 10, 7, 17, 38, 30, 813, DateTimeKind.Local).AddTicks(291) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(311), new DateTime(2021, 9, 27, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(306) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(327), new DateTime(2021, 8, 25, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(322) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(343), new DateTime(2022, 1, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(337) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(358), new DateTime(2021, 10, 7, 21, 38, 30, 813, DateTimeKind.Local).AddTicks(353) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 22, 38, 30, 813, DateTimeKind.Local).AddTicks(373), new DateTime(2021, 10, 8, 0, 38, 30, 813, DateTimeKind.Local).AddTicks(368) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(390), new DateTime(2021, 10, 12, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(383) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(406), new DateTime(2023, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(400) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 21, 21, 30, 813, DateTimeKind.Local).AddTicks(423), new DateTime(2031, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(417) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(440), new DateTime(2021, 10, 7, 8, 38, 30, 813, DateTimeKind.Local).AddTicks(435) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(460), new DateTime(2021, 9, 30, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(455) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(475), new DateTime(2021, 11, 19, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(470) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(492), new DateTime(2022, 1, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(486) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(9948));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(15));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(26));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(36));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 814, DateTimeKind.Local).AddTicks(48));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(5556));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(5642));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(5655));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 7, 20, 38, 30, 813, DateTimeKind.Local).AddTicks(5667));
        }
    }
}
