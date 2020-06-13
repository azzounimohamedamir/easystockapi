using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Migrations
{
    public partial class mig002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceDish_Dishes_DishId",
                table: "ServiceDish");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceDish_Services_ServiceId",
                table: "ServiceDish");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProduct_Products_ProductId",
                table: "ServiceProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProduct_Services_ServiceId",
                table: "ServiceProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceProduct",
                table: "ServiceProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceDish",
                table: "ServiceDish");

            migrationBuilder.RenameTable(
                name: "ServiceProduct",
                newName: "ServiceProducts");

            migrationBuilder.RenameTable(
                name: "ServiceDish",
                newName: "ServiceDishes");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceProduct_ServiceId",
                table: "ServiceProducts",
                newName: "IX_ServiceProducts_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceProduct_ProductId",
                table: "ServiceProducts",
                newName: "IX_ServiceProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceDish_ServiceId",
                table: "ServiceDishes",
                newName: "IX_ServiceDishes_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceDish_DishId",
                table: "ServiceDishes",
                newName: "IX_ServiceDishes_DishId");

            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                table: "Services",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateService_Date",
                table: "Services",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "DateService_EndTime_Value",
                table: "Services",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "DateService_StartTime_Value",
                table: "Services",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                table: "ServiceProducts",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Quantity_UnitId",
                table: "ServiceProducts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity_Value",
                table: "ServiceProducts",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                table: "ServiceDishes",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Quantity_UnitId",
                table: "ServiceDishes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity_Value",
                table: "ServiceDishes",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceProducts",
                table: "ServiceProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceDishes",
                table: "ServiceDishes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProducts_Quantity_UnitId",
                table: "ServiceProducts",
                column: "Quantity_UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDishes_Quantity_UnitId",
                table: "ServiceDishes",
                column: "Quantity_UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceDishes_Dishes_DishId",
                table: "ServiceDishes",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceDishes_Services_ServiceId",
                table: "ServiceDishes",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceDishes_Units_Quantity_UnitId",
                table: "ServiceDishes",
                column: "Quantity_UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProducts_Products_ProductId",
                table: "ServiceProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProducts_Services_ServiceId",
                table: "ServiceProducts",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProducts_Units_Quantity_UnitId",
                table: "ServiceProducts",
                column: "Quantity_UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceDishes_Dishes_DishId",
                table: "ServiceDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceDishes_Services_ServiceId",
                table: "ServiceDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceDishes_Units_Quantity_UnitId",
                table: "ServiceDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProducts_Products_ProductId",
                table: "ServiceProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProducts_Services_ServiceId",
                table: "ServiceProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProducts_Units_Quantity_UnitId",
                table: "ServiceProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceProducts",
                table: "ServiceProducts");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProducts_Quantity_UnitId",
                table: "ServiceProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceDishes",
                table: "ServiceDishes");

            migrationBuilder.DropIndex(
                name: "IX_ServiceDishes_Quantity_UnitId",
                table: "ServiceDishes");

            migrationBuilder.DropColumn(
                name: "DateService_Date",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DateService_EndTime_Value",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DateService_StartTime_Value",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Quantity_UnitId",
                table: "ServiceProducts");

            migrationBuilder.DropColumn(
                name: "Quantity_Value",
                table: "ServiceProducts");

            migrationBuilder.DropColumn(
                name: "Quantity_UnitId",
                table: "ServiceDishes");

            migrationBuilder.DropColumn(
                name: "Quantity_Value",
                table: "ServiceDishes");

            migrationBuilder.RenameTable(
                name: "ServiceProducts",
                newName: "ServiceProduct");

            migrationBuilder.RenameTable(
                name: "ServiceDishes",
                newName: "ServiceDish");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceProducts_ServiceId",
                table: "ServiceProduct",
                newName: "IX_ServiceProduct_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceProducts_ProductId",
                table: "ServiceProduct",
                newName: "IX_ServiceProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceDishes_ServiceId",
                table: "ServiceDish",
                newName: "IX_ServiceDish_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceDishes_DishId",
                table: "ServiceDish",
                newName: "IX_ServiceDish_DishId");

            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                table: "Services",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                table: "ServiceProduct",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                table: "ServiceDish",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceProduct",
                table: "ServiceProduct",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceDish",
                table: "ServiceDish",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceDish_Dishes_DishId",
                table: "ServiceDish",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceDish_Services_ServiceId",
                table: "ServiceDish",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProduct_Products_ProductId",
                table: "ServiceProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProduct_Services_ServiceId",
                table: "ServiceProduct",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
