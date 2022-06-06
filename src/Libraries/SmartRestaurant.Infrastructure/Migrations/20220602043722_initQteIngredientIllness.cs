using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class initQteIngredientIllness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("update [dbo].[IngredientIllnesses] set Quantity=1 ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
         
        }
    }
}
