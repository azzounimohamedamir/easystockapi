using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Migrations
{
    public partial class mg02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pricings_Currencies_PurchasePriceHt_CurrencyId",
                table: "Pricings");

            migrationBuilder.DropColumn(
                name: "TarificationAmount",
                table: "Pricings");

            migrationBuilder.RenameColumn(
                name: "PurchasePriceHt_CurrencyId",
                table: "Pricings",
                newName: "PurchasePriceHT_CurrencyId");

            migrationBuilder.RenameColumn(
                name: "PurchasePriceHt_Amount",
                table: "Pricings",
                newName: "PurchasePriceHT_Amount");

            migrationBuilder.RenameIndex(
                name: "IX_Pricings_PurchasePriceHt_CurrencyId",
                table: "Pricings",
                newName: "IX_Pricings_PurchasePriceHT_CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pricings_Currencies_PurchasePriceHT_CurrencyId",
                table: "Pricings",
                column: "PurchasePriceHT_CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pricings_Currencies_PurchasePriceHT_CurrencyId",
                table: "Pricings");

            migrationBuilder.RenameColumn(
                name: "PurchasePriceHT_CurrencyId",
                table: "Pricings",
                newName: "PurchasePriceHt_CurrencyId");

            migrationBuilder.RenameColumn(
                name: "PurchasePriceHT_Amount",
                table: "Pricings",
                newName: "PurchasePriceHt_Amount");

            migrationBuilder.RenameIndex(
                name: "IX_Pricings_PurchasePriceHT_CurrencyId",
                table: "Pricings",
                newName: "IX_Pricings_PurchasePriceHt_CurrencyId");

            migrationBuilder.AddColumn<decimal>(
                name: "TarificationAmount",
                table: "Pricings",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricings_Currencies_PurchasePriceHt_CurrencyId",
                table: "Pricings",
                column: "PurchasePriceHt_CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
