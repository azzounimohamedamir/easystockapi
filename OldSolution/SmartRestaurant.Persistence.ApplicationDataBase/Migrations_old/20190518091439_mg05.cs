using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Migrations
{
    public partial class mg05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pricings_Currencies_SalePrice_CurrencyId",
                table: "Pricings");

            migrationBuilder.RenameColumn(
                name: "SalePrice_CurrencyId",
                table: "Pricings",
                newName: "Gain_CurrencyId");

            migrationBuilder.RenameColumn(
                name: "SalePrice_Amount",
                table: "Pricings",
                newName: "Gain_Amount");

            migrationBuilder.RenameIndex(
                name: "IX_Pricings_SalePrice_CurrencyId",
                table: "Pricings",
                newName: "IX_Pricings_Gain_CurrencyId");

            migrationBuilder.AddColumn<decimal>(
                name: "GainAmount",
                table: "Pricings",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsPercentage",
                table: "Pricings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricings_Currencies_Gain_CurrencyId",
                table: "Pricings",
                column: "Gain_CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pricings_Currencies_Gain_CurrencyId",
                table: "Pricings");

            migrationBuilder.DropColumn(
                name: "GainAmount",
                table: "Pricings");

            migrationBuilder.DropColumn(
                name: "IsPercentage",
                table: "Pricings");

            migrationBuilder.RenameColumn(
                name: "Gain_CurrencyId",
                table: "Pricings",
                newName: "SalePrice_CurrencyId");

            migrationBuilder.RenameColumn(
                name: "Gain_Amount",
                table: "Pricings",
                newName: "SalePrice_Amount");

            migrationBuilder.RenameIndex(
                name: "IX_Pricings_Gain_CurrencyId",
                table: "Pricings",
                newName: "IX_Pricings_SalePrice_CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pricings_Currencies_SalePrice_CurrencyId",
                table: "Pricings",
                column: "SalePrice_CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
