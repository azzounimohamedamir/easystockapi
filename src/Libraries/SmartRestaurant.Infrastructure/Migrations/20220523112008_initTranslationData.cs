using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class initTranslationData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("update [dbo].[Dishes] set [Names_AR]=[Name],[Names_EN]=[Name],[Names_FR]=[Name],[Names_TR]=[Name],[Names_RU]=[Name]");
            migrationBuilder.Sql("update [dbo].[Products] set [Names_AR]=[Name],[Names_EN]=[Name],[Names_FR]=[Name],[Names_TR]=[Name],[Names_RU]=[Name]");
            migrationBuilder.Sql("update [dbo].[Illnesses] set [Names_AR]=[Name],[Names_EN]=[Name],[Names_FR]=[Name],[Names_TR]=[Name],[Names_RU]=[Name]");
            migrationBuilder.Sql("update [dbo].[Sections] set [Names_AR]=[Name],[Names_EN]=[Name],[Names_FR]=[Name],[Names_TR]=[Name],[Names_RU]=[Name]");
            migrationBuilder.Sql("update [dbo].[SubSections] set [Names_AR]=[Name],[Names_EN]=[Name],[Names_FR]=[Name],[Names_TR]=[Name],[Names_RU]=[Name]");
            migrationBuilder.Sql("update [dbo].[Zones] set [Names_AR]=[ZoneTitle],[Names_EN]=[ZoneTitle],[Names_FR]=[ZoneTitle],[Names_TR]=[ZoneTitle],[Names_RU]=[ZoneTitle]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
