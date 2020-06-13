using SmartRestaurant.Application.Foods.Queries.GetAll;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Foods.Queries;
using SmartRestaurant.Application.Foods.Specifications;
using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Foods.FoodCategories.Queries.Factory;

namespace SmartRestaurant.Application.Foods.Foods.Queries.GetByCategoryId
{


    public interface IGetFoodsByCategoryIdQuery
    {
        List<FoodItemModel> Execute(string categoryId);
    }
    public class GetFoodsByCategoryIdQuery : IGetFoodsByCategoryIdQuery
    {
        private readonly ILoggerService<GetFoodsByCategoryIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetFoodsByCategoryIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetFoodsByCategoryIdQuery>  logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<FoodItemModel> Execute(string categoryId)
        {
            try
            {
                var specification = new FoodSpecification(
                    f=>f.FoodCategoryId==categoryId.ToGuid()
                    || f.Category.Parent.Id== categoryId.ToGuid()
                    || f.Category.Parent.Parent.Id == categoryId.ToGuid()
                    || f.Category.Parent.Parent.Parent.Id == categoryId.ToGuid()
                    )
                    .AddInclude(f => f.Nutrition.Quantity.Unit)
                    .ApplyOrderBy(fc => fc.Name);

                return db.Foods
                    .Filter(specification)
                    .ToFoodItemModels()
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
