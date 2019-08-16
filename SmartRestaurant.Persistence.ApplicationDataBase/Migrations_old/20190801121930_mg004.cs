using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Migrations
{
    public partial class mg004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Translates_Id",
                table: "Translates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Translates",
                table: "Translates");

            migrationBuilder.AlterColumn<string>(
                name: "PrimaryKeyValue",
                table: "Translates",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translates",
                table: "Translates",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Translates",
                table: "Translates");

            migrationBuilder.AlterColumn<string>(
                name: "PrimaryKeyValue",
                table: "Translates",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Translates_Id",
                table: "Translates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translates",
                table: "Translates",
                column: "PrimaryKeyValue");
        }
    }
}
