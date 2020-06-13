using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.FoodCompositions.Queries.GetAll;
using SmartRestaurant.Application.Foods.Queries;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Linq;

namespace SmartRestaurant.Application.FoodCompositions.Queries.GetByName
{


    public interface IGetFoodCompositionByNameQuery
    {
        FoodCompositionModel Execute(string name);
    }
    public class GetFoodCompositionByNameQuery : IGetFoodCompositionByNameQuery
    {
        private readonly ILoggerService<GetFoodCompositionByNameQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetFoodCompositionByNameQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetFoodCompositionByNameQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public FoodCompositionModel Execute(string name)
        {
            try
            {
                 var Foods = db.FoodCompositions
                     .Include(p => p.Food)
                     .Include(q => q.Quantity.Unit)
                     .Where(w => w.Food.Name == name)
                     .Select(x => new FoodCompositionModel
                     {
                         Id = x.Id.ToString(),
                         Description = x.Food.Description,
                         Name = x.Food.Name,
                         SlugUrl = x.Food.SlugUrl,
                         //Quantity = QuantityModel.GetQuantityModel(x.Quantity)
                     }).FirstOrDefault();

                return Foods;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }

}
