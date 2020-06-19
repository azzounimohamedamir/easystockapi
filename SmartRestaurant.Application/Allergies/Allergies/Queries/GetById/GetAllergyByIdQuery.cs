using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Allergies.Allergies.Commands.Update;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Linq;


namespace SmartRestaurant.Application.Allergies.Allergies.Queries.GetById
{


    public interface IGetAllergyByIdQuery
    {
        UpdateAllergyModel Execute(string Id);
    }
    public class GetAllergyByIdQuery : IGetAllergyByIdQuery
    {
        private readonly ILoggerService<IGetAllergyByIdQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllergyByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<IGetAllergyByIdQuery> log,
             IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateAllergyModel Execute(string Id)
        {
            try
            {
                return db.Allergies
                    .Include(i => i.FoodAllergies)
                    .Include("FoodAllergies.Food")
                    .Where(x => x.Id == Id.ToGuid())
                    .Select(x => new UpdateAllergyModel
                    {
                        Alias = x.Alias,
                        Description = x.Description,
                        Name = x.Name,
                        IsDisabled = x.IsDisabled,
                        Id = x.Id.ToString(),
                        FoodsIdsNames = x.FoodAllergies
                       .Select(i => new IdName
                       {
                           Name = i.Food.Name,
                           Id = i.FoodId.ToString()
                       }).ToList()
                    })
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
