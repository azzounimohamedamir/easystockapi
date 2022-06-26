using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class updatedefaulValueTranslationOrderDishOrderProductOrderDishSupplument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("update [dbo].[OrderDishes] set [Names_AR]=[Name],[Names_EN]=[Name],[Names_FR]=[Name],[Names_RU]=[Name],[Names_TR]=[Name]");
            migrationBuilder.Sql("update [dbo].[OrderProducts] set [Names_AR]=[Name],[Names_EN]=[Name],[Names_FR]=[Name],[Names_RU]=[Name],[Names_TR]=[Name]");
            migrationBuilder.Sql("update [dbo].[OrderDishSupplements] set [Names_AR]=[Name],[Names_EN]=[Name],[Names_FR]=[Name],[Names_RU]=[Name],[Names_TR]=[Name]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
