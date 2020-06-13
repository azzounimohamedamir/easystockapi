using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.FoodCompositions.Queries.GetAll;
using SmartRestaurant.Application.Foods.Queries;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Linq;

namespace SmartRestaurant.Application.FoodCompositions.Querys.GetById
{


    public interface IGetFoodCompositionByIdQuery
    {
        FoodCompositionModel Execute(string Id);
    }
    public class GetFoodCompositionByIdQuery : IGetFoodCompositionByIdQuery
    {
        private readonly ILoggerService<GetFoodCompositionByIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetFoodCompositionByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetFoodCompositionByIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public FoodCompositionModel Execute(string Id)
        {
            try
            {
                var guid = Id.ToGuid();
                var Foods = db.FoodCompositions
                     .Include(p => p.Food)
                     .Include(q=>q.Quantity.Unit) 
                     .Where(w => w.Id == guid)
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
