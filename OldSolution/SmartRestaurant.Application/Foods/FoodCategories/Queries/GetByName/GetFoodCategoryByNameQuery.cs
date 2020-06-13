using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.FoodCategories.Queries.GetAll;
using SmartRestaurant.Application.Foods.FoodCategories.Queries.Factory;
using SmartRestaurant.Application.Foods.FoodCategories.Queries.GetBySpecification;
using SmartRestaurant.Application.Foods.Specifications;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.FoodCategories.Queries.GetByName
{


    public interface IGetFoodCategoryByNameQuery
    {
        FoodCategoryItemModel Execute(string name);
    }

    public class GetFoodCategoryByNameQuery : IGetFoodCategoryByNameQuery
    {
        private readonly ILoggerService<GetFoodCategoryByNameQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly IGetFoodCategoryBySpecificationQuery query;
        private readonly ISmartRestaurantDatabaseService db;

        public GetFoodCategoryByNameQuery(
            ISmartRestaurantDatabaseService db,
            ILoggerService<GetFoodCategoryByNameQuery>logger, 
            IMailingService mailing,
            INotifyService notify,
            IGetFoodCategoryBySpecificationQuery query)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
            this.query = query;
        }

        public FoodCategoryItemModel Execute(string name)
        {
            try
            {
                //var specification = new FoodCategorySpecification(fc=>fc.Name==name)
                //    .AddInclude(fc => fc.Parent);

                //query.Execute(specification).FirstOrDefault();
                //return db.FoodCategories.AsQueryable()
                //    .ApplySpecification(specification)
                //    .FirstOrDefault()
                //    .ToFoodCategoryItemModel();

                /*var FoodCategorie = db.FoodCategories
                    .Include(p => p.Parent)
                    .Include(c => c.Picture)
                    .Where(f => f.Name == name)
                    .FirstOrDefault()
                    .ToFoodCategoryItemModel();
                    .Select(x => new FoodCategoryItemModel
                    {
                        Id = x.Id.ToString(),
                        Name = x.Name,
                        ParentName = x.Parent.Name,
                        PictureUrl = x.Picture != null ? x.Picture.ImageUrl : null,
                        Description = x.Description,
                        SlugUrl = x.SlugUrl
                    }).FirstOrDefault();

                return FoodCategorie;*/
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
