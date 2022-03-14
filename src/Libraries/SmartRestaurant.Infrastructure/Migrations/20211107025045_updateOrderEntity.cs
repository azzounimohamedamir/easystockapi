using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updateOrderEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDishes_Orders_OrderId",
                table: "OrderDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDishIngredients_OrderDishes_OrderDishId",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "OrderDateTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderType",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "PriceValuePerStep",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "OrderDishes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OrderDishes");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                table: "OrderDishes");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "OrderDishes");

            migrationBuilder.DropColumn(
                name: "PriceValue",
                table: "OrderDishes");

            migrationBuilder.RenameColumn(
                name: "QuantityPerStep_MeasurementUnits",
                table: "OrderDishIngredients",
                newName: "MeasurementUnits");

            migrationBuilder.RenameColumn(
                name: "QuantityPerStep_Amount",
                table: "OrderDishIngredients",
                newName: "OrderIngredient_EnergeticValue_Amount");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderDishId",
                table: "OrderDishIngredients",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MeasurementUnits",
                table: "OrderDishIngredients",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Amount",
                table: "OrderDishIngredients",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "AmountIncreasePerStep",
                table: "OrderDishIngredients",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "OrderDishIngredients",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "MaximumAmount",
                table: "OrderDishIngredients",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MinimumAmount",
                table: "OrderDishIngredients",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PriceIncreasePerStep",
                table: "OrderDishIngredients",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "OrderIngredient_IngredientId",
                table: "OrderDishIngredients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderIngredient_Names",
                table: "OrderDishIngredients",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "OrderIngredient_EnergeticValue_Carbohydrates",
                table: "OrderDishIngredients",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "OrderIngredient_EnergeticValue_Energy",
                table: "OrderDishIngredients",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "OrderIngredient_EnergeticValue_Fat",
                table: "OrderDishIngredients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderIngredient_EnergeticValue_MeasurementUnit",
                table: "OrderDishIngredients",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "OrderIngredient_EnergeticValue_Protein",
                table: "OrderDishIngredients",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderDishes",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChairNumber",
                table: "OrderDishes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderDishes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DishId",
                table: "OrderDishes",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "EnergeticValue",
                table: "OrderDishes",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "EstimatedPreparationTime",
                table: "OrderDishes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Quantity",
                table: "OrderDishes",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "OrderDishes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "UnitPrice",
                table: "OrderDishes",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderNumberLastResetDateTime",
                table: "FoodBusinesses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "OrderDishSpecifications",
                columns: table => new
                {
                    OrderDishSpecificationId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ContentType = table.Column<int>(nullable: false),
                    CheckBoxContent = table.Column<bool>(nullable: false),
                    ComboBoxContent = table.Column<string>(nullable: true),
                    CheckBoxSelection = table.Column<bool>(nullable: false),
                    ComboBoxSelection = table.Column<string>(nullable: true),
                    OrderDishId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDishSpecifications", x => x.OrderDishSpecificationId);
                    table.ForeignKey(
                        name: "FK_OrderDishSpecifications_OrderDishes_OrderDishId",
                        column: x => x.OrderDishId,
                        principalTable: "OrderDishes",
                        principalColumn: "OrderDishId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDishSupplements",
                columns: table => new
                {
                    OrderDishSupplementId = table.Column<Guid>(nullable: false),
                    SupplementId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    EnergeticValue = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsSelected = table.Column<bool>(nullable: false),
                    OrderDishId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDishSupplements", x => x.OrderDishSupplementId);
                    table.ForeignKey(
                        name: "FK_OrderDishSupplements_OrderDishes_OrderDishId",
                        column: x => x.OrderDishId,
                        principalTable: "OrderDishes",
                        principalColumn: "OrderDishId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderOccupiedTables",
                columns: table => new
                {
                    OrderOccupiedTableId = table.Column<Guid>(nullable: false),
                    TableId = table.Column<string>(nullable: true),
                    OrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderOccupiedTables", x => x.OrderOccupiedTableId);
                    table.ForeignKey(
                        name: "FK_OrderOccupiedTables_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderProductId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<float>(nullable: false),
                    EnergeticValue = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TableNumber = table.Column<int>(nullable: false),
                    ChairNumber = table.Column<int>(nullable: false),
                    Quantity = table.Column<float>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.OrderProductId);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(530));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(519));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(478));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(489));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(499));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(9645));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(396));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(444));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(468));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 841, DateTimeKind.Local).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(7625), new DateTime(2021, 11, 7, 8, 50, 43, 835, DateTimeKind.Local).AddTicks(4784) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 8, 50, 43, 839, DateTimeKind.Local).AddTicks(8815), new DateTime(2021, 11, 7, 11, 50, 43, 839, DateTimeKind.Local).AddTicks(8761) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 23, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(8892), new DateTime(2021, 11, 8, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(8843) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 22, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(8982), new DateTime(2026, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(8910) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 4, 26, 43, 839, DateTimeKind.Local).AddTicks(9010), new DateTime(2036, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9000) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 6, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9050), new DateTime(2021, 11, 7, 0, 50, 43, 839, DateTimeKind.Local).AddTicks(9042) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9069), new DateTime(2021, 10, 26, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9063) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9087), new DateTime(2021, 9, 15, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9081) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 3, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9104), new DateTime(2022, 4, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9098) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9122), new DateTime(2021, 11, 7, 7, 50, 43, 839, DateTimeKind.Local).AddTicks(9116) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 8, 50, 43, 839, DateTimeKind.Local).AddTicks(9139), new DateTime(2021, 11, 7, 10, 50, 43, 839, DateTimeKind.Local).AddTicks(9133) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 24, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9154), new DateTime(2021, 11, 9, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9149) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 28, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9171), new DateTime(2025, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9165) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 4, 26, 43, 839, DateTimeKind.Local).AddTicks(9188), new DateTime(2036, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9182) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 5, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9203), new DateTime(2021, 11, 6, 23, 50, 43, 839, DateTimeKind.Local).AddTicks(9198) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9219), new DateTime(2021, 10, 25, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9213) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9235), new DateTime(2021, 9, 18, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9229) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9251), new DateTime(2022, 3, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9245) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9472), new DateTime(2021, 11, 7, 6, 50, 43, 839, DateTimeKind.Local).AddTicks(9458) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 7, 50, 43, 839, DateTimeKind.Local).AddTicks(9491), new DateTime(2021, 11, 7, 9, 50, 43, 839, DateTimeKind.Local).AddTicks(9485) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 24, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9507), new DateTime(2021, 11, 8, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9501) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 1, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9524), new DateTime(2024, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9517) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 4, 5, 43, 839, DateTimeKind.Local).AddTicks(9541), new DateTime(2034, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9535) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 4, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9557), new DateTime(2021, 11, 7, 0, 50, 43, 839, DateTimeKind.Local).AddTicks(9551) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9574), new DateTime(2021, 10, 28, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9568) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9591), new DateTime(2021, 9, 25, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9586) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9608), new DateTime(2022, 2, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9602) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9625), new DateTime(2021, 11, 7, 4, 50, 43, 839, DateTimeKind.Local).AddTicks(9619) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 5, 50, 43, 839, DateTimeKind.Local).AddTicks(9643), new DateTime(2021, 11, 7, 7, 50, 43, 839, DateTimeKind.Local).AddTicks(9637) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 24, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9685), new DateTime(2021, 11, 12, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9680) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 27, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9703), new DateTime(2023, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9696) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 7, 4, 33, 43, 839, DateTimeKind.Local).AddTicks(9718), new DateTime(2031, 11, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9713) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 2, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9734), new DateTime(2021, 11, 6, 15, 50, 43, 839, DateTimeKind.Local).AddTicks(9729) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9749), new DateTime(2021, 10, 31, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9744) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9765), new DateTime(2021, 12, 20, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9759) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9780), new DateTime(2022, 2, 7, 3, 50, 43, 839, DateTimeKind.Local).AddTicks(9775) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(6437));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(7254));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(7303));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(7317));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(7338));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(7348));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(3614));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(3642));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(3655));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 11, 7, 3, 50, 43, 840, DateTimeKind.Local).AddTicks(3666));

            migrationBuilder.CreateIndex(
                name: "IX_OrderDishSpecifications_OrderDishId",
                table: "OrderDishSpecifications",
                column: "OrderDishId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDishSupplements_OrderDishId",
                table: "OrderDishSupplements",
                column: "OrderDishId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderOccupiedTables_OrderId",
                table: "OrderOccupiedTables",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDishes_Orders_OrderId",
                table: "OrderDishes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDishIngredients_OrderDishes_OrderDishId",
                table: "OrderDishIngredients",
                column: "OrderDishId",
                principalTable: "OrderDishes",
                principalColumn: "OrderDishId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDishes_Orders_OrderId",
                table: "OrderDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDishIngredients_OrderDishes_OrderDishId",
                table: "OrderDishIngredients");

            migrationBuilder.DropTable(
                name: "OrderDishSpecifications");

            migrationBuilder.DropTable(
                name: "OrderDishSupplements");

            migrationBuilder.DropTable(
                name: "OrderOccupiedTables");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "AmountIncreasePerStep",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "MaximumAmount",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "MinimumAmount",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "PriceIncreasePerStep",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "OrderIngredient_IngredientId",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "OrderIngredient_Names",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "OrderIngredient_EnergeticValue_Carbohydrates",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "OrderIngredient_EnergeticValue_Energy",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "OrderIngredient_EnergeticValue_Fat",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "OrderIngredient_EnergeticValue_MeasurementUnit",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "OrderIngredient_EnergeticValue_Protein",
                table: "OrderDishIngredients");

            migrationBuilder.DropColumn(
                name: "ChairNumber",
                table: "OrderDishes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderDishes");

            migrationBuilder.DropColumn(
                name: "DishId",
                table: "OrderDishes");

            migrationBuilder.DropColumn(
                name: "EnergeticValue",
                table: "OrderDishes");

            migrationBuilder.DropColumn(
                name: "EstimatedPreparationTime",
                table: "OrderDishes");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderDishes");

            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "OrderDishes");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "OrderDishes");

            migrationBuilder.DropColumn(
                name: "OrderNumberLastResetDateTime",
                table: "FoodBusinesses");

            migrationBuilder.RenameColumn(
                name: "OrderIngredient_EnergeticValue_Amount",
                table: "OrderDishIngredients",
                newName: "QuantityPerStep_Amount");

            migrationBuilder.RenameColumn(
                name: "MeasurementUnits",
                table: "OrderDishIngredients",
                newName: "QuantityPerStep_MeasurementUnits");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDateTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OrderType",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderDishId",
                table: "OrderDishIngredients",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "QuantityPerStep_MeasurementUnits",
                table: "OrderDishIngredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "OrderDishIngredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "OrderDishIngredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                table: "OrderDishIngredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "OrderDishIngredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderDishIngredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PriceValuePerStep",
                table: "OrderDishIngredients",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderDishes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "OrderDishes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "OrderDishes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                table: "OrderDishes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "OrderDishes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PriceValue",
                table: "OrderDishes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("45051fc7-6983-44a5-9c12-66116c4533bf"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 113, DateTimeKind.Local).AddTicks(379));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("8f8c0139-1f90-40f3-ab88-5db2de45ff2e"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 113, DateTimeKind.Local).AddTicks(315));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 113, DateTimeKind.Local).AddTicks(76));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 113, DateTimeKind.Local).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aa02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 113, DateTimeKind.Local).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aaba"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(8789));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabb"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(9861));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabc"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(9986));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabd"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 113, DateTimeKind.Local).AddTicks(27));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("ccaecd78-ccbb-ee04-56ff-88887129aabe"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 113, DateTimeKind.Local).AddTicks(52));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: new Guid("e2289d77-b8e1-4476-bf66-e64f1a23d752"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 113, DateTimeKind.Local).AddTicks(137));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596300"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(1501), new DateTime(2021, 10, 28, 10, 17, 1, 104, DateTimeKind.Local).AddTicks(8524) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596301"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 10, 17, 1, 111, DateTimeKind.Local).AddTicks(2553), new DateTime(2021, 10, 28, 13, 17, 1, 111, DateTimeKind.Local).AddTicks(2499) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596302"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 13, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2636), new DateTime(2021, 10, 29, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2587) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596303"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 12, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2728), new DateTime(2026, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2654) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596304"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 5, 53, 1, 111, DateTimeKind.Local).AddTicks(2759), new DateTime(2036, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2748) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596305"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 27, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2801), new DateTime(2021, 10, 28, 2, 17, 1, 111, DateTimeKind.Local).AddTicks(2792) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596306"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2819), new DateTime(2021, 10, 16, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2813) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596307"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2839), new DateTime(2021, 9, 5, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2833) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596308"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 2, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2859), new DateTime(2022, 3, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2853) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596309"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2878), new DateTime(2021, 10, 28, 9, 17, 1, 111, DateTimeKind.Local).AddTicks(2871) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596310"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 10, 17, 1, 111, DateTimeKind.Local).AddTicks(2896), new DateTime(2021, 10, 28, 12, 17, 1, 111, DateTimeKind.Local).AddTicks(2889) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596311"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2916), new DateTime(2021, 10, 30, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2909) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596312"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 18, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2943), new DateTime(2025, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2931) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596313"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 5, 53, 1, 111, DateTimeKind.Local).AddTicks(2976), new DateTime(2036, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(2965) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596314"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 26, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3049), new DateTime(2021, 10, 28, 1, 17, 1, 111, DateTimeKind.Local).AddTicks(3024) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596315"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3080), new DateTime(2021, 10, 15, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3071) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596316"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 7, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3111), new DateTime(2021, 9, 8, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3101) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596317"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2022, 1, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3147), new DateTime(2022, 2, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3134) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596327"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3180), new DateTime(2021, 10, 28, 8, 17, 1, 111, DateTimeKind.Local).AddTicks(3168) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596328"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 9, 17, 1, 111, DateTimeKind.Local).AddTicks(3215), new DateTime(2021, 10, 28, 11, 17, 1, 111, DateTimeKind.Local).AddTicks(3203) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596329"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3243), new DateTime(2021, 10, 29, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3232) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596330"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 22, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3279), new DateTime(2024, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596331"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 5, 32, 1, 111, DateTimeKind.Local).AddTicks(3310), new DateTime(2034, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3300) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596332"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 25, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3338), new DateTime(2021, 10, 28, 2, 17, 1, 111, DateTimeKind.Local).AddTicks(3329) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596333"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3374), new DateTime(2021, 10, 18, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3364) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596334"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 8, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3405), new DateTime(2021, 9, 15, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3395) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596335"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3444), new DateTime(2022, 1, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3427) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596336"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3475), new DateTime(2021, 10, 28, 6, 17, 1, 111, DateTimeKind.Local).AddTicks(3465) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596337"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 7, 17, 1, 111, DateTimeKind.Local).AddTicks(3505), new DateTime(2021, 10, 28, 9, 17, 1, 111, DateTimeKind.Local).AddTicks(3493) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596338"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 14, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3546), new DateTime(2021, 11, 2, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3531) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596339"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 17, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3581), new DateTime(2023, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3569) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596340"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 28, 6, 0, 1, 111, DateTimeKind.Local).AddTicks(3623), new DateTime(2031, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3606) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596341"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 10, 23, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3657), new DateTime(2021, 10, 27, 17, 17, 1, 111, DateTimeKind.Local).AddTicks(3645) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596342"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 9, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3688), new DateTime(2021, 10, 21, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3678) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596343"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 11, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3720), new DateTime(2021, 12, 10, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3709) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("acbf657b-3398-7a73-8746-77b7cf596344"),
                columns: new[] { "CreatedAt", "ReservationDate" },
                values: new object[] { new DateTime(2021, 12, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3755), new DateTime(2022, 1, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(3741) });

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab00"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab01"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(5504));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab02"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(5561));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129ab03"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(5578));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(5592));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("44aecd78-59bb-7504-bfff-07c07129aba3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(5604));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: new Guid("b006e2c5-5b8e-4584-8021-3cecd76c9ca6"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 112, DateTimeKind.Local).AddTicks(5616));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc0"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(8125));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(9272));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-3304-bfaa-07c08082abc3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(9288));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba1"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(9304));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("32bccd11-59fd-33ff-bfaa-07c08082aba2"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(9321));

            migrationBuilder.UpdateData(
                table: "Zones",
                keyColumn: "ZoneId",
                keyValue: new Guid("f60d55e2-4e54-4896-9632-98d36d7680c3"),
                column: "CreatedAt",
                value: new DateTime(2021, 10, 28, 5, 17, 1, 111, DateTimeKind.Local).AddTicks(9334));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDishes_Orders_OrderId",
                table: "OrderDishes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDishIngredients_OrderDishes_OrderDishId",
                table: "OrderDishIngredients",
                column: "OrderDishId",
                principalTable: "OrderDishes",
                principalColumn: "OrderDishId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
