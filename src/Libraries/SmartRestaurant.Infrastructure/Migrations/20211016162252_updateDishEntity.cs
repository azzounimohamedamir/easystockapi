using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateDishEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DishIngredients",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "DishIngredientId",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "PricePerStep",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "AmountPerStep_Amount",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "AmountPerStep_MeasurementUnits",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "Quantity_Amount",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "PriceAmount",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "AveragePreparationTime_TimeUnits",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "AveragePreparationTime_Value",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "Quantity_MeasurementUnits",
                table: "DishIngredients",
                newName: "MeasurementUnits");

            migrationBuilder.AlterColumn<int>(
                name: "MeasurementUnits",
                table: "DishIngredients",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "AmountIncreasePerStep",
                table: "DishIngredients",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "InitialAmount",
                table: "DishIngredients",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MaximumAmount",
                table: "DishIngredients",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MinimumAmount",
                table: "DishIngredients",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PriceIncreasePerStep",
                table: "DishIngredients",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<Guid>(
                name: "FoodBusinessId",
                table: "Dishes",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Dishes",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "EnergeticValue",
                table: "Dishes",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "EstimatedPreparationTime",
                table: "Dishes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Dishes",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Dishes",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishIngredients",
                table: "DishIngredients",
                columns: new[] { "DishId", "IngredientId" });

            migrationBuilder.CreateTable(
                name: "DishSpecifications",
                columns: table => new
                {
                    DishSpecificationId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ContentType = table.Column<int>(nullable: false),
                    CheckBoxContent = table.Column<bool>(nullable: false),
                    ComboBoxContent = table.Column<string>(nullable: true),
                    DishId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishSpecifications", x => x.DishSpecificationId);
                    table.ForeignKey(
                        name: "FK_DishSpecifications_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishSupplements",
                columns: table => new
                {
                    SupplementId = table.Column<Guid>(nullable: false),
                    DishId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishSupplements", x => new { x.DishId, x.SupplementId });
                    table.ForeignKey(
                        name: "FK_DishSupplements_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishSupplements_Dishes_SupplementId",
                        column: x => x.SupplementId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(7125));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(7113));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(7078));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(6193));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(6892));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(7049));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(5002), new DateTime(2021, 10, 16, 23, 22, 51, 670, DateTimeKind.Local).AddTicks(5208) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 23, 22, 51, 674, DateTimeKind.Local).AddTicks(6071), new DateTime(2021, 10, 17, 2, 22, 51, 674, DateTimeKind.Local).AddTicks(6018) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 1, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6146), new DateTime(2021, 10, 17, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6100) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 31, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6234), new DateTime(2026, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6165) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 18, 58, 51, 674, DateTimeKind.Local).AddTicks(6263), new DateTime(2036, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6251) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 15, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6304), new DateTime(2021, 10, 16, 15, 22, 51, 674, DateTimeKind.Local).AddTicks(6295) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6323), new DateTime(2021, 10, 4, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6316) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6342), new DateTime(2021, 8, 24, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6336) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6360), new DateTime(2022, 3, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6354) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6378), new DateTime(2021, 10, 16, 22, 22, 51, 674, DateTimeKind.Local).AddTicks(6371) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 23, 22, 51, 674, DateTimeKind.Local).AddTicks(6398), new DateTime(2021, 10, 17, 1, 22, 51, 674, DateTimeKind.Local).AddTicks(6392) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6415), new DateTime(2021, 10, 18, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6409) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 6, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6434), new DateTime(2025, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6427) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 18, 58, 51, 674, DateTimeKind.Local).AddTicks(6453), new DateTime(2036, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6446) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6471), new DateTime(2021, 10, 16, 14, 22, 51, 674, DateTimeKind.Local).AddTicks(6465) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6488), new DateTime(2021, 10, 3, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6481) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6505), new DateTime(2021, 8, 27, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6499) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6527), new DateTime(2022, 2, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6520) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6545), new DateTime(2021, 10, 16, 21, 22, 51, 674, DateTimeKind.Local).AddTicks(6539) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 22, 22, 51, 674, DateTimeKind.Local).AddTicks(6562), new DateTime(2021, 10, 17, 0, 22, 51, 674, DateTimeKind.Local).AddTicks(6556) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6579), new DateTime(2021, 10, 17, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6573) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 10, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6597), new DateTime(2024, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6590) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 18, 37, 51, 674, DateTimeKind.Local).AddTicks(6615), new DateTime(2034, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6609) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6631), new DateTime(2021, 10, 16, 15, 22, 51, 674, DateTimeKind.Local).AddTicks(6626) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6648), new DateTime(2021, 10, 6, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6666), new DateTime(2021, 9, 3, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6660) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6686), new DateTime(2022, 1, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6680) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6703), new DateTime(2021, 10, 16, 19, 22, 51, 674, DateTimeKind.Local).AddTicks(6698) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 20, 22, 51, 674, DateTimeKind.Local).AddTicks(6719), new DateTime(2021, 10, 16, 22, 22, 51, 674, DateTimeKind.Local).AddTicks(6714) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 2, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6736), new DateTime(2021, 10, 21, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6731) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 5, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6753), new DateTime(2023, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6747) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 16, 19, 5, 51, 674, DateTimeKind.Local).AddTicks(6771), new DateTime(2031, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6764) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 11, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6787), new DateTime(2021, 10, 16, 6, 22, 51, 674, DateTimeKind.Local).AddTicks(6781) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6803), new DateTime(2021, 10, 9, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6798) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6820), new DateTime(2021, 11, 28, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6814) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6836), new DateTime(2022, 1, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(6830) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(3186));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(3943));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(3989));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(4014));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(4026));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 674, DateTimeKind.Local).AddTicks(9533));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(345));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(358));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(370));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(382));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 16, 18, 22, 51, 675, DateTimeKind.Local).AddTicks(395));

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_IngredientId",
                table: "DishIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_FoodBusinessId",
                table: "Dishes",
                column: "FoodBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_DishSpecifications_DishId",
                table: "DishSpecifications",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishSupplements_SupplementId",
                table: "DishSupplements",
                column: "SupplementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_FoodBusinesses_FoodBusinessId",
                table: "Dishes",
                column: "FoodBusinessId",
                principalTable: "FoodBusinesses",
                principalColumn: "FoodBusinessId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Ingredients_IngredientId",
                table: "DishIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_FoodBusinesses_FoodBusinessId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Ingredients_IngredientId",
                table: "DishIngredients");

            migrationBuilder.DropTable(
                name: "DishSpecifications");

            migrationBuilder.DropTable(
                name: "DishSupplements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishIngredients",
                table: "DishIngredients");

            migrationBuilder.DropIndex(
                name: "IX_DishIngredients_IngredientId",
                table: "DishIngredients");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_FoodBusinessId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "AmountIncreasePerStep",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "InitialAmount",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "MaximumAmount",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "MinimumAmount",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "PriceIncreasePerStep",
                table: "DishIngredients");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "EnergeticValue",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "EstimatedPreparationTime",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "MeasurementUnits",
                table: "DishIngredients",
                newName: "Quantity_MeasurementUnits");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity_MeasurementUnits",
                table: "DishIngredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<Guid>(
                name: "DishIngredientId",
                table: "DishIngredients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "DishIngredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DishIngredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                table: "DishIngredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "DishIngredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PricePerStep",
                table: "DishIngredients",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "AmountPerStep_Amount",
                table: "DishIngredients",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmountPerStep_MeasurementUnits",
                table: "DishIngredients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Quantity_Amount",
                table: "DishIngredients",
                type: "real",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FoodBusinessId",
                table: "Dishes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MenuId",
                table: "Dishes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PriceAmount",
                table: "Dishes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<Guid>(
                name: "SectionId",
                table: "Dishes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AveragePreparationTime_TimeUnits",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "AveragePreparationTime_Value",
                table: "Dishes",
                type: "real",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishIngredients",
                table: "DishIngredients",
                column: "DishIngredientId");

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
    }
}
