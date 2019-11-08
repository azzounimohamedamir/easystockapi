using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Migrations
{
    public partial class AddSelectedLanguages : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "SelectLanguage",
                table: "Languages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    Periode = table.Column<int>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDish",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    ServiceId = table.Column<Guid>(nullable: false),
                    DishId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceDish_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceDish_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    ServiceId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceProduct_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    ServiceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceStatus_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDish_DishId",
                table: "ServiceDish",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDish_ServiceId",
                table: "ServiceDish",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProduct_ProductId",
                table: "ServiceProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProduct_ServiceId",
                table: "ServiceProduct",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_RestaurantId",
                table: "Services",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceStatus_ServiceId",
                table: "ServiceStatus",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceDish");

            migrationBuilder.DropTable(
                name: "ServiceProduct");

            migrationBuilder.DropTable(
                name: "ServiceStatus");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropColumn(
                name: "ChainId",
                table: "SRUsers");

            migrationBuilder.DropColumn(
                name: "RestuarantId",
                table: "SRUsers");

            migrationBuilder.DropColumn(
                name: "SelectLanguage",
                table: "Languages");
        }
    }
}
