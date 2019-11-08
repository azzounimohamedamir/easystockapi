using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Migrations
{
    public partial class mg6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishAccompanying_Dishes_ParentId",
                table: "DishAccompanying");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricings_Currencies_PurchasePriceHt_CurrencyId",
                table: "Pricings");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricings_Currencies_SalePrice_CurrencyId",
                table: "Pricings");

            migrationBuilder.DropColumn(
                name: "Body",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Body",
                table: "Mailings");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Mailings");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Mailings");

            migrationBuilder.RenameColumn(
                name: "PurchasePriceHt_CurrencyId",
                table: "Pricings",
                newName: "PurchasePriceHT_CurrencyId");

            migrationBuilder.RenameColumn(
                name: "PurchasePriceHt_Amount",
                table: "Pricings",
                newName: "PurchasePriceHT_Amount");

            migrationBuilder.RenameColumn(
                name: "SalePrice_CurrencyId",
                table: "Pricings",
                newName: "Gain_CurrencyId");

            migrationBuilder.RenameColumn(
                name: "SalePrice_Amount",
                table: "Pricings",
                newName: "Gain_Amount");

            migrationBuilder.RenameColumn(
                name: "TarificationAmount",
                table: "Pricings",
                newName: "GainAmount");

            migrationBuilder.RenameIndex(
                name: "IX_Pricings_PurchasePriceHt_CurrencyId",
                table: "Pricings",
                newName: "IX_Pricings_PurchasePriceHT_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Pricings_SalePrice_CurrencyId",
                table: "Pricings",
                newName: "IX_Pricings_Gain_CurrencyId");

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Templates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Templates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Templates",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pricings",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AddColumn<bool>(
                name: "IsPercentage",
                table: "Pricings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_DishAccompanying_Dishes_ParentId",
                table: "DishAccompanying",
                column: "ParentId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricings_Currencies_Gain_CurrencyId",
                table: "Pricings",
                column: "Gain_CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_DishAccompanying_Dishes_ParentId",
                table: "DishAccompanying");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricings_Currencies_Gain_CurrencyId",
                table: "Pricings");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricings_Currencies_PurchasePriceHT_CurrencyId",
                table: "Pricings");

            migrationBuilder.DropColumn(
                name: "Body",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "IsPercentage",
                table: "Pricings");

            migrationBuilder.RenameColumn(
                name: "PurchasePriceHT_CurrencyId",
                table: "Pricings",
                newName: "PurchasePriceHt_CurrencyId");

            migrationBuilder.RenameColumn(
                name: "PurchasePriceHT_Amount",
                table: "Pricings",
                newName: "PurchasePriceHt_Amount");

            migrationBuilder.RenameColumn(
                name: "Gain_CurrencyId",
                table: "Pricings",
                newName: "SalePrice_CurrencyId");

            migrationBuilder.RenameColumn(
                name: "Gain_Amount",
                table: "Pricings",
                newName: "SalePrice_Amount");

            migrationBuilder.RenameColumn(
                name: "GainAmount",
                table: "Pricings",
                newName: "TarificationAmount");

            migrationBuilder.RenameIndex(
                name: "IX_Pricings_PurchasePriceHT_CurrencyId",
                table: "Pricings",
                newName: "IX_Pricings_PurchasePriceHt_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Pricings_Gain_CurrencyId",
                table: "Pricings",
                newName: "IX_Pricings_SalePrice_CurrencyId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pricings",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Notifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Notifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Notifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Mailings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Mailings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Mailings",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DishAccompanying_Dishes_ParentId",
                table: "DishAccompanying",
                column: "ParentId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricings_Currencies_PurchasePriceHt_CurrencyId",
                table: "Pricings",
                column: "PurchasePriceHt_CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
