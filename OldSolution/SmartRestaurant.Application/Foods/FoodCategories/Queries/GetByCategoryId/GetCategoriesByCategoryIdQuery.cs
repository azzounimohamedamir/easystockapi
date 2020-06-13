using SmartRestaurant.Application.FoodCategories.Queries.GetAll;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SmartRestaurant.Application.FoodCategories.Queries;
using SmartRestaurant.Application.Foods.Specifications;
using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Foods.FoodCategories.Queries.Factory;

namespace SmartRestaurant.Application.Foods.FoodCategories.Queries.GetByCategoryId
{


    public interface IGetCategoriesByCategoryIdQuery
    {
        List<FoodCategoryItemModel> Execute(string Id);
    }
    public class GetCategoriesByCategoryIdQuery : IGetCategoriesByCategoryIdQuery
    {
        private readonly ILoggerService<GetCategoriesByCategoryIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetCategoriesByCategoryIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetCategoriesByCategoryIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<FoodCategoryItemModel> Execute(string Id)
        {
            try
            {
                var guid = Id.GuidFromString();

                /*var specification = new FoodCategorySpecification(x=>x.ParentId==guid).AddInclude(fc => fc.Parent);
                return db.FoodCategories
                    .AsQueryable()
                    .ApplySpecification(specification)
                    .ToList()
                    .ToFoodCategoryItemModels();*/

                return db.FoodCategories
                    .Include(i => i.Parent)
                    .Include(p => p.Picture)
                    .Where(f => f.ParentId == guid)
                    .Select(x => new FoodCategoryItemModel
                    {
                        Id = x.Id.ToString(),
                        Description = x.Description,
                        ParentName = x.Parent.Name,
                        Name = x.Name,
                        PictureUrl = x.Picture != null ? x.Picture.ImageUrl : null,
                        SlugUrl = x.SlugUrl                                               
                    }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
