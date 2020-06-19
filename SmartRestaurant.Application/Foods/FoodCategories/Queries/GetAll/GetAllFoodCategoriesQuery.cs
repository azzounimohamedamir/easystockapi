using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Foods.FoodCategories.Queries.Factory;
using SmartRestaurant.Application.Foods.Specifications;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.FoodCategories.Queries.GetAll
{
    public interface IGetAllFoodCategoriesQuery
    {
        List<FoodCategoryItemModel> Execute(string parentId);
    }

    public class GetAllFoodCategoriesQuery : IGetAllFoodCategoriesQuery
    {
        private readonly ILoggerService<GetAllFoodCategoriesQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllFoodCategoriesQuery(
            ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllFoodCategoriesQuery> logger,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public List<FoodCategoryItemModel> Execute(string parentId)
        {
            try
            {
                var specification = new FoodCategorySpecification(fc => fc.ParentId.ToString() == parentId)//
                    .AddInclude(fc => fc.Parent)
                    .AddInclude(fc => fc.Childs)
                    .ApplyOrderBy(fc => fc.Name);

                return db.FoodCategories
                    .Filter(specification)
                    .ToFoodCategoryItemModels()
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
