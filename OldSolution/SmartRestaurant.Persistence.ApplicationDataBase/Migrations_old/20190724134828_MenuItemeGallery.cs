using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Migrations
{
    public partial class MenuItemeGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChainId",
                table: "SRUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RestuarantId",
                table: "SRUsers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GalleryId",
                table: "MenuItems",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MenuItemId",
                table: "Galleries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 15, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: false),
                    Periode = table.Column<int>(nullable: false),
                    DateService_Date = table.Column<DateTime>(nullable: false),
                    DateService_StartTime_Value = table.Column<TimeSpan>(nullable: false),
                    DateService_EndTime_Value = table.Column<TimeSpan>(nullable: false),
                    RestaurantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDishes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 15, nullable: true),
                    ServiceId = table.Column<Guid>(nullable: false),
                    DishId = table.Column<Guid>(nullable: true),
                    Quantity_Value = table.Column<decimal>(nullable: false),
                    Quantity_UnitId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceDishes_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceDishes_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceDishes_Units_Quantity_UnitId",
                        column: x => x.Quantity_UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 15, nullable: true),
                    ServiceId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    Quantity_Value = table.Column<decimal>(nullable: false),
                    Quantity_UnitId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceProducts_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProducts_Units_Quantity_UnitId",
                        column: x => x.Quantity_UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceState",
                columns: table => new
                {
                    ServiceId = table.Column<Guid>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    SysDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceState", x => new { x.ServiceId, x.State });
                    table.ForeignKey(
                        name: "FK_ServiceState_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_MenuItemId",
                table: "Galleries",
                column: "MenuItemId",
                unique: true,
                filter: "[MenuItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDishes_DishId",
                table: "ServiceDishes",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDishes_ServiceId",
                table: "ServiceDishes",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDishes_Quantity_UnitId",
                table: "ServiceDishes",
                column: "Quantity_UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProducts_ProductId",
                table: "ServiceProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProducts_ServiceId",
                table: "ServiceProducts",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProducts_Quantity_UnitId",
                table: "ServiceProducts",
                column: "Quantity_UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_RestaurantId",
                table: "Services",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Galleries_MenuItems_MenuItemId",
                table: "Galleries",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_MenuItems_MenuItemId",
                table: "Galleries");

            migrationBuilder.DropTable(
                name: "ServiceDishes");

            migrationBuilder.DropTable(
                name: "ServiceProducts");

            migrationBuilder.DropTable(
                name: "ServiceState");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Galleries_MenuItemId",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "ChainId",
                table: "SRUsers");

            migrationBuilder.DropColumn(
                name: "RestuarantId",
                table: "SRUsers");

            migrationBuilder.DropColumn(
                name: "GalleryId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "Galleries");
        }
    }
}
