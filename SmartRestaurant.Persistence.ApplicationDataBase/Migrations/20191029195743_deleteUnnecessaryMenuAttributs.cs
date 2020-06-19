using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Migrations
{
    public partial class deleteUnnecessaryMenuAttributs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Staffs_ChefId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_ChefId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "ChefId",
                table: "Menus");

            migrationBuilder.AddColumn<Guid>(
                name: "StaffId",
                table: "Menus",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_StaffId",
                table: "Menus",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Staffs_StaffId",
                table: "Menus",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Staffs_StaffId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_StaffId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Menus");

            migrationBuilder.AddColumn<Guid>(
                name: "ChefId",
                table: "Menus",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ChefId",
                table: "Menus",
                column: "ChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Staffs_ChefId",
                table: "Menus",
                column: "ChefId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
