using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Migrations
{
    public partial class mig003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pricings_Gain_CurrencyId",
                table: "Pricings");

            migrationBuilder.DropIndex(
                name: "IX_Pricings_PurchasePriceHT_CurrencyId",
                table: "Pricings");

            migrationBuilder.CreateIndex(
                name: "IX_Pricings_Gain_CurrencyId",
                table: "Pricings",
                column: "Gain_CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Pricings_PurchasePriceHT_CurrencyId",
                table: "Pricings",
                column: "PurchasePriceHT_CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pricings_Gain_CurrencyId",
                table: "Pricings");

            migrationBuilder.DropIndex(
                name: "IX_Pricings_PurchasePriceHT_CurrencyId",
                table: "Pricings");

            migrationBuilder.CreateIndex(
                name: "IX_Pricings_Gain_CurrencyId",
                table: "Pricings",
                column: "Gain_CurrencyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pricings_PurchasePriceHT_CurrencyId",
                table: "Pricings",
                column: "PurchasePriceHT_CurrencyId",
                unique: true);
        }
    }
}
