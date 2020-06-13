using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Commun.Quantities;
using SmartRestaurant.Application.Foods.Queries;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.FoodCompositions.Queries.GetAll
{


    public interface IGetAllFoodCompositionQuery
    {
        List<FoodCompositionModel> Execute();
    }
    public class GetAllFoodCompositionQuery : IGetAllFoodCompositionQuery
    {
        private readonly ILoggerService<GetAllFoodCompositionQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllFoodCompositionQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllFoodCompositionQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public List<FoodCompositionModel> Execute()
        {
            try
            {
                var Foods = db.FoodCompositions
                     .Include(p => p.Food)
                     .Include(q => q.Quantity.Unit)
                     .Select(x => new FoodCompositionModel
                     {
                         Id = x.Id.ToString(),
                         Description = x.Food.Description,
                         Name = x.Food.Name,                        
                         SlugUrl = x.Food.SlugUrl,
                         Quantity = QuantityModel.GetQuantityModel(x.Quantity)
                     }).ToList();

                return Foods;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
