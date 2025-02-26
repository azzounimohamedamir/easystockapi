using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class addCtegoriesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAttribute_ProductAttributes_ProductAttributeId",
                table: "CategoryAttribute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryAttribute",
                table: "CategoryAttribute");

            migrationBuilder.DropIndex(
                name: "IX_CategoryAttribute_ProductAttributeId",
                table: "CategoryAttribute");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductAttributes");

            migrationBuilder.DropColumn(
                name: "ProductAttributeId",
                table: "CategoryAttribute");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "AttributeValues");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryAttributeId",
                table: "ProductAttributes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "ProductAttributes",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CategoryAttribute",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "CategoryAttribute",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "Categories",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Valeur",
                table: "AttributeValues",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryAttribute",
                table: "CategoryAttribute",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                column: "DateEcheance",
                value: new DateTime(2035, 1, 6, 9, 6, 31, 164, DateTimeKind.Local).AddTicks(7816));

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_CategoryAttributeId",
                table: "ProductAttributes",
                column: "CategoryAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAttribute_CategoryId",
                table: "CategoryAttribute",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_CategoryAttribute_CategoryAttributeId",
                table: "ProductAttributes",
                column: "CategoryAttributeId",
                principalTable: "CategoryAttribute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_CategoryAttribute_CategoryAttributeId",
                table: "ProductAttributes");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributes_CategoryAttributeId",
                table: "ProductAttributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryAttribute",
                table: "CategoryAttribute");

            migrationBuilder.DropIndex(
                name: "IX_CategoryAttribute_CategoryId",
                table: "CategoryAttribute");

            migrationBuilder.DropColumn(
                name: "CategoryAttributeId",
                table: "ProductAttributes");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "ProductAttributes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CategoryAttribute");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "CategoryAttribute");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Valeur",
                table: "AttributeValues");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductAttributes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductAttributeId",
                table: "CategoryAttribute",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "AttributeValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryAttribute",
                table: "CategoryAttribute",
                columns: new[] { "CategoryId", "ProductAttributeId" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                column: "DateEcheance",
                value: new DateTime(2034, 9, 30, 16, 3, 20, 900, DateTimeKind.Local).AddTicks(4444));

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAttribute_ProductAttributeId",
                table: "CategoryAttribute",
                column: "ProductAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryAttribute_ProductAttributes_ProductAttributeId",
                table: "CategoryAttribute",
                column: "ProductAttributeId",
                principalTable: "ProductAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
