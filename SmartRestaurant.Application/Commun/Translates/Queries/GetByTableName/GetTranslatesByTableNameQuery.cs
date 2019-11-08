using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Commun.Languages.Queries;
using SmartRestaurant.Application.Commun.Translators.Extensions;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SmartRestaurant.Application.Commun.Translates.Queries.GetByTableName
{
    public interface IGetTranslatesByTableNameQuery
    {
        List<ItemTranslatesModel> Execute(string tableName);

    }
    public class GetTranslatesByTableNameQuery : IGetTranslatesByTableNameQuery
    {
        private readonly ILoggerService<GetTranslatesByTableNameQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetTranslatesByTableNameQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetTranslatesByTableNameQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<ItemTranslatesModel> Execute(string tableName)
        {
            try
            {
                if (tableName.IsNullOrEmpty()) return null;
                var languages = db.Languages.OrderBy(x => x.EnglishName).ToList();

                //get translate from db
                var texts = db.Translates
                   .Where(p => p.TableName == tableName)
                   .Include(i => i.Language)
                   .Select(x => new
                   TranslateItemModel
                   {
                       Id = x.Id.ToString(),
                       Text = x.Text,
                       PrimaryKeyName = x.PrimaryKeyName,
                       TableName = x.TableName,
                       PrimaryKeyValue = x.PrimaryKeyValue,
                       Language = x.Language,
                       IsDisabled = x.IsDisabled.DisabledDisplay(),
                       ColumnName = x.ColumnName
                   }).ToList();

                //add the new rows
                var fullTypeName = "";
                switch (tableName)
                {
                    case "Dishes":
                        fullTypeName = "SmartRestaurant.Domain.Dishes.Dish";
                        break;
                    case "Foods":
                        fullTypeName = "SmartRestaurant.Domain.Foods.Food";
                        break;
                    case "Ingredients":
                        fullTypeName = "SmartRestaurant.Domain.Dishes.DishIngredient";
                         break;
                    case "FoodCatigories":
                        fullTypeName = "SmartRestaurant.Domain.Foods.FoodCatigory";
                        break;
                    case "ProductFamilies":
                        fullTypeName = "SmartRestaurant.Domain.Products.ProductFamily";
                        break;
                    case "Products":
                        fullTypeName = "SmartRestaurant.Domain.Products.Product";
                        break;
                }
                var tableType = TranslateExtension.GetType(fullTypeName);
                var table = db.Set(tableType).ToList();

                foreach (var row in table)
                {
                    if (!texts.Any(x => x.PrimaryKeyValue == row.Id.ToString()))
                    {
                        foreach (var lang in languages)
                        {
                            texts.Add(new TranslateItemModel
                            {
                                Id = Guid.NewGuid().ToString(),
                                Text = "",
                                OriginalText = row.Name,
                                ColumnName = "Name",
                                PrimaryKeyName = "Id",
                                TableName = tableName,
                                PrimaryKeyValue = row.Id.ToString(),
                                Language = lang,
                                IsDisabled = false.DisabledDisplay(),
                            });
                            texts.Add(new TranslateItemModel
                            {
                                Id = Guid.NewGuid().ToString(),
                                Text = "",
                                ColumnName = "Description",
                                PrimaryKeyName = "Id",
                                OriginalText = row.Description,
                                TableName = tableName,
                                PrimaryKeyValue = row.Id.ToString(),
                                Language = lang,
                                IsDisabled = false.DisabledDisplay(),
                            });
                        }
                    }
                    else
                    {
                        var columns = texts.Where(x => x.PrimaryKeyValue == row.Id.ToString());
                        if (columns != null)
                            foreach (var item in columns)
                            {
                                {
                                    if (item.ColumnName == "Name")
                                        item.OriginalText = row.Name;
                                    else if (item.ColumnName == "Description")
                                        item.OriginalText = row.Description;
                                }
                            }

                    }
                }

                var result = new List<ItemTranslatesModel>();

                //group items by is
                var groupedById = texts.GroupBy(x => x.PrimaryKeyValue);

                foreach (var idGroup in groupedById)
                {
                    // group by column name
                    var columnGroup = idGroup.GroupBy(x => x.ColumnName);

                    foreach (var column in columnGroup)
                    {
                        List<TextTraslation> textTraslations = new List<TextTraslation>();
                        // sort each element of each column 

                        foreach (var element in column.OrderBy(x => x.Language.EnglishName))
                        {

                            textTraslations.Add(new TextTraslation
                            {
                                Text = element.Text,
                                Language = new LanguageItemModel
                                {
                                    Id = element.Language.Id,
                                    IsoCode = element.Language.IsoCode,
                                    EnglishName = element.Language.EnglishName,
                                    Alias = element.Language.Alias,
                                    Name = element.Language.Name,
                                    IsRTL = element.Language.IsRTL,
                                }
                            });
                        }
                        result.Add(new ItemTranslatesModel
                        {
                            TableName = tableName,
                            OriginalText = column.FirstOrDefault().OriginalText,
                            ColumnName = column.Key,
                            PrimaryKeyValue = idGroup.Key,
                            TextTraslations = textTraslations
                        });
                    }

                }

                for (int i = 0; i < result.Count; i++)
                {
                    result[i].Index = i;
                    for (int j = 0; j < result[i].TextTraslations.Count; j++)
                    {
                        result[i].TextTraslations[j].Index = j;
                        result[i].TextTraslations[j].ParentIndex = i;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
