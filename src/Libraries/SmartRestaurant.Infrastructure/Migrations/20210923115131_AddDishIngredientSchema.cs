using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddDishIngredientSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_FoodBusinesses_FoodBusinessId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_FoodBusinessId",
                table: "Menus");

            migrationBuilder.AddColumn<Guid>(
                name: "DefaultCurrencyId",
                table: "FoodBusinesses",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Symbol = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    DishId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsSupplement = table.Column<bool>(nullable: false),
                    AveragePreparationTime_Value = table.Column<float>(nullable: true),
                    AveragePreparationTime_TimeUnits = table.Column<int>(nullable: true),
                    PriceAmount = table.Column<float>(nullable: false),
                    MenuId = table.Column<Guid>(nullable: true),
                    SectionId = table.Column<Guid>(nullable: true),
                    FoodBusinessId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.DishId);
                });

            migrationBuilder.CreateTable(
                name: "DishIngredients",
                columns: table => new
                {
                    DishIngredientId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    IsPrimary = table.Column<bool>(nullable: false),
                    Quantity_Amount = table.Column<float>(nullable: true),
                    Quantity_MeasurementUnits = table.Column<int>(nullable: true),
                    AmountPerStep_Amount = table.Column<float>(nullable: true),
                    AmountPerStep_MeasurementUnits = table.Column<int>(nullable: true),
                    PricePerStep = table.Column<float>(nullable: false),
                    DishId = table.Column<Guid>(nullable: false),
                    IngredientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredients", x => x.DishIngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Fat = table.Column<float>(nullable: false),
                    Protein = table.Column<float>(nullable: false),
                    Carbs = table.Column<float>(nullable: false),
                    Energy = table.Column<float>(nullable: false),
                    MinQuantity_Amount = table.Column<float>(nullable: true),
                    MinQuantity_MeasurementUnits = table.Column<int>(nullable: true),
                    MaxQuantity_Amount = table.Column<float>(nullable: true),
                    MaxQuantity_MeasurementUnits = table.Column<int>(nullable: true),
                    FoodBusinessId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    TotalToPay = table.Column<float>(nullable: false),
                    MoneyReceived = table.Column<float>(nullable: false),
                    MoneyReturned = table.Column<float>(nullable: false),
                    OrderType = table.Column<int>(nullable: false),
                    OrderDateTime = table.Column<DateTime>(nullable: false),
                    FoodBusinessId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    SpecificationId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DishId = table.Column<Guid>(nullable: false),
                    FoodBusinessId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.SpecificationId);
                });

            migrationBuilder.CreateTable(
                name: "OrderDishes",
                columns: table => new
                {
                    OrderDishId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PriceValue = table.Column<float>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDishes", x => x.OrderDishId);
                    table.ForeignKey(
                        name: "FK_OrderDishes_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDishIngredients",
                columns: table => new
                {
                    OrderDishIngredientId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    QuantityPerStep_Amount = table.Column<float>(nullable: true),
                    QuantityPerStep_MeasurementUnits = table.Column<int>(nullable: true),
                    PriceValuePerStep = table.Column<float>(nullable: false),
                    Steps = table.Column<int>(nullable: false),
                    OrderDishId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDishIngredients", x => x.OrderDishIngredientId);
                    table.ForeignKey(
                        name: "FK_OrderDishIngredients_OrderDishes_OrderDishId",
                        column: x => x.OrderDishId,
                        principalTable: "OrderDishes",
                        principalColumn: "OrderDishId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3257));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3253));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3242));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3246));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3249));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(2922));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3232));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3235));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3239));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(3249));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(5844), new DateTime(2021, 9, 23, 17, 51, 30, 359, DateTimeKind.Local).AddTicks(7534) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 17, 51, 30, 375, DateTimeKind.Local).AddTicks(6627), new DateTime(2021, 9, 23, 20, 51, 30, 375, DateTimeKind.Local).AddTicks(6591) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 8, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6680), new DateTime(2021, 9, 24, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6644) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 8, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6782), new DateTime(2026, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6687) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 13, 27, 30, 375, DateTimeKind.Local).AddTicks(6796), new DateTime(2036, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6792) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 22, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6814), new DateTime(2021, 9, 23, 9, 51, 30, 375, DateTimeKind.Local).AddTicks(6810) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6817), new DateTime(2021, 9, 11, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6817) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6821), new DateTime(2021, 8, 1, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6821) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6828), new DateTime(2022, 2, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6824) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6835), new DateTime(2021, 9, 23, 16, 51, 30, 375, DateTimeKind.Local).AddTicks(6831) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 17, 51, 30, 375, DateTimeKind.Local).AddTicks(6838), new DateTime(2021, 9, 23, 19, 51, 30, 375, DateTimeKind.Local).AddTicks(6838) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 9, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6842), new DateTime(2021, 9, 25, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6842) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 13, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6852), new DateTime(2025, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6849) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 13, 27, 30, 375, DateTimeKind.Local).AddTicks(6859), new DateTime(2036, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6856) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 21, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6863), new DateTime(2021, 9, 23, 8, 51, 30, 375, DateTimeKind.Local).AddTicks(6863) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6870), new DateTime(2021, 9, 10, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6866) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6874), new DateTime(2021, 8, 4, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6874) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6877), new DateTime(2022, 1, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6877) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6884), new DateTime(2021, 9, 23, 15, 51, 30, 375, DateTimeKind.Local).AddTicks(6881) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 16, 51, 30, 375, DateTimeKind.Local).AddTicks(6888), new DateTime(2021, 9, 23, 18, 51, 30, 375, DateTimeKind.Local).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 9, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6891), new DateTime(2021, 9, 24, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6891) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 17, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6895), new DateTime(2024, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6895) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 13, 6, 30, 375, DateTimeKind.Local).AddTicks(6902), new DateTime(2034, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6898) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 20, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6909), new DateTime(2021, 9, 23, 9, 51, 30, 375, DateTimeKind.Local).AddTicks(6909) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6912), new DateTime(2021, 9, 13, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6912) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6919), new DateTime(2021, 8, 11, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6916) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6923), new DateTime(2021, 12, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6923) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6933), new DateTime(2021, 9, 23, 13, 51, 30, 375, DateTimeKind.Local).AddTicks(6926) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 14, 51, 30, 375, DateTimeKind.Local).AddTicks(6937), new DateTime(2021, 9, 23, 16, 51, 30, 375, DateTimeKind.Local).AddTicks(6937) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 9, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6944), new DateTime(2021, 9, 28, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6944) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6948), new DateTime(2023, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6948) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 23, 13, 34, 30, 375, DateTimeKind.Local).AddTicks(6955), new DateTime(2031, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6955) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 18, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6958), new DateTime(2021, 9, 23, 0, 51, 30, 375, DateTimeKind.Local).AddTicks(6958) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6965), new DateTime(2021, 9, 16, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6965) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6969), new DateTime(2021, 11, 5, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6969) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6976), new DateTime(2021, 12, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(6976) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(1564));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(9543));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 375, DateTimeKind.Local).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(5));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(9));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(12));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(20));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 9, 23, 12, 51, 30, 376, DateTimeKind.Local).AddTicks(27));

            migrationBuilder.CreateIndex(
                name: "IX_OrderDishes_OrderId",
                table: "OrderDishes",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDishIngredients_OrderDishId",
                table: "OrderDishIngredients",
                column: "OrderDishId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "DishIngredients");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "OrderDishIngredients");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "OrderDishes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropColumn(
                name: "DefaultCurrencyId",
                table: "FoodBusinesses");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2301));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2298));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2284));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2259));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2273));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(4709), new DateTime(2021, 8, 28, 15, 51, 26, 390, DateTimeKind.Local).AddTicks(2065) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 15, 51, 26, 402, DateTimeKind.Local).AddTicks(5248), new DateTime(2021, 8, 28, 18, 51, 26, 402, DateTimeKind.Local).AddTicks(5216) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 13, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5287), new DateTime(2021, 8, 29, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5262) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 12, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5372), new DateTime(2026, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5294) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 11, 27, 26, 402, DateTimeKind.Local).AddTicks(5379), new DateTime(2036, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5375) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 27, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5400), new DateTime(2021, 8, 28, 7, 51, 26, 402, DateTimeKind.Local).AddTicks(5400) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5407), new DateTime(2021, 8, 16, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5407) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5410), new DateTime(2021, 7, 6, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5410) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5417), new DateTime(2022, 1, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5414) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5421), new DateTime(2021, 8, 28, 14, 51, 26, 402, DateTimeKind.Local).AddTicks(5421) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 15, 51, 26, 402, DateTimeKind.Local).AddTicks(5424), new DateTime(2021, 8, 28, 17, 51, 26, 402, DateTimeKind.Local).AddTicks(5424) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 14, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5428), new DateTime(2021, 8, 30, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5428) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 18, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5431), new DateTime(2025, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5431) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 11, 27, 26, 402, DateTimeKind.Local).AddTicks(5439), new DateTime(2036, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5435) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 26, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5442), new DateTime(2021, 8, 28, 6, 51, 26, 402, DateTimeKind.Local).AddTicks(5442) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5446), new DateTime(2021, 8, 15, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5446) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 5, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5449), new DateTime(2021, 7, 9, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5449) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5456), new DateTime(2021, 12, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5453) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5460), new DateTime(2021, 8, 28, 13, 51, 26, 402, DateTimeKind.Local).AddTicks(5460) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 14, 51, 26, 402, DateTimeKind.Local).AddTicks(5463), new DateTime(2021, 8, 28, 16, 51, 26, 402, DateTimeKind.Local).AddTicks(5463) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 14, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5470), new DateTime(2021, 8, 29, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5467) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 22, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5474), new DateTime(2024, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 11, 6, 26, 402, DateTimeKind.Local).AddTicks(5477), new DateTime(2034, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5477) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 25, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5481), new DateTime(2021, 8, 28, 7, 51, 26, 402, DateTimeKind.Local).AddTicks(5481) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5484), new DateTime(2021, 8, 18, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5484) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 6, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5491), new DateTime(2021, 7, 16, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5488) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5495), new DateTime(2021, 11, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5495) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5498), new DateTime(2021, 8, 28, 11, 51, 26, 402, DateTimeKind.Local).AddTicks(5498) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 12, 51, 26, 402, DateTimeKind.Local).AddTicks(5502), new DateTime(2021, 8, 28, 14, 51, 26, 402, DateTimeKind.Local).AddTicks(5502) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 14, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5506), new DateTime(2021, 9, 2, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5506) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 17, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5509), new DateTime(2023, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5509) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 11, 34, 26, 402, DateTimeKind.Local).AddTicks(5513), new DateTime(2031, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5513) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 23, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5516), new DateTime(2021, 8, 27, 22, 51, 26, 402, DateTimeKind.Local).AddTicks(5516) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5520), new DateTime(2021, 8, 21, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5520) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5527), new DateTime(2021, 10, 10, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5523) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5530), new DateTime(2021, 11, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(5530) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(9804));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(206));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(209));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(213));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 403, DateTimeKind.Local).AddTicks(216));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(7924));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(7928));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(7932));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(7935));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 10, 51, 26, 402, DateTimeKind.Local).AddTicks(7939));

            migrationBuilder.CreateIndex(
                name: "IX_Menus_FoodBusinessId",
                table: "Menus",
                column: "FoodBusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_FoodBusinesses_FoodBusinessId",
                table: "Menus",
                column: "FoodBusinessId",
                principalTable: "FoodBusinesses",
                principalColumn: "FoodBusinessId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
