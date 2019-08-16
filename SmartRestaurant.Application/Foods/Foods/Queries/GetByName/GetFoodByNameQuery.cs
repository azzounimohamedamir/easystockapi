using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Foods.FoodCategories.Queries.Factory;
using SmartRestaurant.Application.Foods.Queries.GetAll;
using SmartRestaurant.Application.Foods.Specifications;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Foods.Queries.GetByName
{

    public interface IGetFoodByNameQuery
    {
        FoodItemModel Execute(string name);
    }
    public class GetFoodByNameQuery : IGetFoodByNameQuery
    {
        private readonly ILoggerService<GetFoodByNameQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetFoodByNameQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetFoodByNameQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public FoodItemModel Execute(string name)
        {
            try
            {
                var specification = new FoodSpecification(f => f.Name == name)
                    .AddInclude(f => f.Nutrition.Quantity.Unit);

                return db.Foods
                    .Filter(specification)
                    .FirstOrDefault()
                    .ToFoodItemModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
