using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.FoodCategories.Queries;
using SmartRestaurant.Application.Foods.FoodCategories.Queries.Factory;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Foods;
using System.Collections.Generic;
using System.Linq;


namespace SmartRestaurant.Application.Foods.Queries.GetBySpecification
{
    public interface IGetFoodBySpecificationQuery
    {
        List<FoodItemModel> Execute(ISpecification<Food> specification, out int count);
        //TODO: Séparer les méthodes dans la prochaine version
        List<FoodItemModel> Execute(ISpecification<Food> specification);
    }

    public class GetFoodBySpecificationQuery : IGetFoodBySpecificationQuery
    {
        private readonly ILoggerService<GetFoodBySpecificationQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetFoodBySpecificationQuery(
            ISmartRestaurantDatabaseService db,
            ILoggerService<GetFoodBySpecificationQuery> logger, 
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<FoodItemModel> Execute(ISpecification<Food> specification, out int count)
        {            
            var query = db.Foods.Query(specification);
            count = query.Count();
            return query
                .Skip(specification.Skip)
                .Take(specification.Take)
                .ToFoodItemModels()
                .ToList();
            
        }

        public List<FoodItemModel> Execute(ISpecification<Food> specification)
        {
            var query = db.Foods.Query(specification);            
            return query                
                .ToFoodItemModels()
                .ToList();
        }
    }
}
