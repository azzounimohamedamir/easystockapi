using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class AddHotelOrderParameteresValueOrderdestinations_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CheckinId = table.Column<Guid>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: false),
                    HotelId = table.Column<Guid>(nullable: false),
                    Names_AR = table.Column<string>(nullable: true),
                    Names_EN = table.Column<string>(nullable: true),
                    Names_FR = table.Column<string>(nullable: true),
                    Names_TR = table.Column<string>(nullable: true),
                    Names_RU = table.Column<string>(nullable: true),
                    DateOrder = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    TableId = table.Column<Guid>(nullable: false),
                    FoodBusinessId = table.Column<Guid>(nullable: false),
                    ChairNumber = table.Column<int>(nullable: false),
                    IsSmartrestaurantMenue = table.Column<bool>(nullable: false),
                    SmartRestaurentOrderId = table.Column<Guid>(nullable: false),
                    OrderStat = table.Column<int>(nullable: false),
                    SuccesMessage_AR = table.Column<string>(nullable: true),
                    SuccesMessage_EN = table.Column<string>(nullable: true),
                    SuccesMessage_FR = table.Column<string>(nullable: true),
                    SuccesMessage_TR = table.Column<string>(nullable: true),
                    SuccesMessage_RU = table.Column<string>(nullable: true),
                    FailureMessage_AR = table.Column<string>(nullable: true),
                    FailureMessage_EN = table.Column<string>(nullable: true),
                    FailureMessage_FR = table.Column<string>(nullable: true),
                    FailureMessage_TR = table.Column<string>(nullable: true),
                    FailureMessage_RU = table.Column<string>(nullable: true),
                    ServiceManagerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelOrders_CheckIns_CheckinId",
                        column: x => x.CheckinId,
                        principalTable: "CheckIns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelOrders_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelOrders_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDestinations",
                columns: table => new
                {
                    OrderDestinationId = table.Column<Guid>(nullable: false),
                    HotelId = table.Column<Guid>(nullable: false),
                    Names_AR = table.Column<string>(nullable: true),
                    Names_EN = table.Column<string>(nullable: true),
                    Names_FR = table.Column<string>(nullable: true),
                    Names_TR = table.Column<string>(nullable: true),
                    Names_RU = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDestinations", x => x.OrderDestinationId);
                });

            migrationBuilder.CreateTable(
                name: "ParametresValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Names_AR = table.Column<string>(nullable: true),
                    Names_EN = table.Column<string>(nullable: true),
                    Names_FR = table.Column<string>(nullable: true),
                    Names_TR = table.Column<string>(nullable: true),
                    Names_RU = table.Column<string>(nullable: true),
                    ServiceParametreType = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    NumberValue = table.Column<int>(nullable: false),
                    SelectedValueId = table.Column<Guid>(nullable: true),
                    HotelOrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametresValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParametresValues_HotelOrders_HotelOrderId",
                        column: x => x.HotelOrderId,
                        principalTable: "HotelOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParametresValues_ListingDetails_SelectedValueId",
                        column: x => x.SelectedValueId,
                        principalTable: "ListingDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelOrders_CheckinId",
                table: "HotelOrders",
                column: "CheckinId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelOrders_HotelId",
                table: "HotelOrders",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelOrders_RoomId",
                table: "HotelOrders",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametresValues_HotelOrderId",
                table: "ParametresValues",
                column: "HotelOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametresValues_SelectedValueId",
                table: "ParametresValues",
                column: "SelectedValueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDestinations");

            migrationBuilder.DropTable(
                name: "ParametresValues");

            migrationBuilder.DropTable(
                name: "HotelOrders");
        }
    }
}
