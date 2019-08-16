using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Foods.FoodCategories.Queries.Factory;
using SmartRestaurant.Application.Foods.Specifications;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Foods.Queries.GetAll
{


    public interface IGetAllFoodsQuery
    {
        List<FoodItemModel> Execute();
    }
    public class GetAllFoodsQuery : IGetAllFoodsQuery
    {
        private readonly ILoggerService<GetAllFoodsQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllFoodsQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllFoodsQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public List<FoodItemModel> Execute()
        {
            try
            {
                var specification = new FoodSpecification()                    
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
