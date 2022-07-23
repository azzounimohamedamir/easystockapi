using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class initDataTranslationSpecification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [dbo].[OrderComboBoxItemTranslations]
               (OrderComboBoxItemTranslationId
               ,[Name]
               ,[Names_AR]
               ,[Names_EN]
               ,[Names_FR]
               ,[Names_TR]
               ,[Names_RU]
               ,[OrderDishSpecificationId])
                SELECT
                NEWID() as [OrderComboBoxItemTranslationId]
                  , c.s as [Name]
                  , c.s as[Names_AR]
                  , c.s as[Names_EN]
                  , c.s as[Names_FR]
                  , c.s as[Names_TR]
                  , c.s as[Names_RU]
                  , sp.[OrderDishSpecificationId] as [OrderDishSpecificationId]

                FROM
                    [dbo].[OrderDishSpecifications] AS sp

                outer apply(SELECT value as s FROM STRING_SPLIT(sp.comboboxContent, ';')) c
                where isnull(sp.comboboxContent, '') <> '' and sp.ContentType = 1");
            migrationBuilder.Sql(@"INSERT INTO [dbo].[DishComboBoxItemTranslations]
               ([DishComboBoxItemTranslationId]
               ,[Name]
               ,[Names_AR]
               ,[Names_EN]
               ,[Names_FR]
               ,[Names_TR]
               ,[Names_RU]
               ,[DishSpecificationId])
     
            SELECT
			NEWID() as [DishComboBoxItemTranslationId]
			  ,c.s as [Name]
			  ,c.s as[Names_AR]
			  ,c.s as[Names_EN]
			  ,c.s as[Names_FR]
			  ,c.s as[Names_TR]
			  ,c.s as[Names_RU]
			  ,sp.[DishSpecificationId] as [DishSpecificationId]
            FROM
                [dbo].[DishSpecifications] AS sp
            outer apply ( SELECT value as s FROM STRING_SPLIT(sp.comboboxContent, ';')) c
            where isnull(sp.comboboxContent,'')<>'' and sp.ContentType=1");
            migrationBuilder.Sql(@"update [dbo].[DishSpecifications] set [Names_AR]=[Title]
              ,[Names_EN]=[Title]
              ,[Names_FR]=[Title]
              ,[Names_RU]=[Title]
              ,[Names_TR]=[Title]");
            migrationBuilder.Sql(@"update [dbo].[OrderDishSpecifications] set [Names_AR]=[Title]
              ,[Names_EN]=[Title]
              ,[Names_FR]=[Title]
              ,[Names_RU]=[Title]
              ,[Names_TR]=[Title]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
