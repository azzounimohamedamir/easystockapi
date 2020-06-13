using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.FoodCategories.Queries;
using SmartRestaurant.Application.FoodCategories.Queries.GetAll;
using SmartRestaurant.Application.Foods.FoodCategories.Queries.Factory;
using SmartRestaurant.Application.Foods.Specifications;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SmartRestaurant.Application.Foods.FoodCategories.Queries.GetBySpecification
{
    public interface IGetFoodCategoryBySpecificationQuery
    {
        List<FoodCategoryItemModel> Execute(ISpecification<FoodCategory> specification);
    }

    public class GetFoodCategoryBySpecificationQuery: IGetFoodCategoryBySpecificationQuery
    {
        private readonly ILoggerService<GetFoodCategoryBySpecificationQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetFoodCategoryBySpecificationQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetFoodCategoryBySpecificationQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<FoodCategoryItemModel> Execute(ISpecification<FoodCategory> specification)
        {
            return db.FoodCategories                    
                    .AsQueryable()
                    .ApplySpecification(specification)
                    .ToFoodCategoryItemModels()
                    .ToList();

        }
    }
}
