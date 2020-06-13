using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Allergies.Illnesses.Queries.GetBySpesification;
using SmartRestaurant.Application.Allergies.Illnesses.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;
using SmartRestaurant.Application.Allergies.Illnesses.Queries.Factory;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Allergies.Illnesses.Commands.Update;
using SmartRestaurant.Application.Helpers;

namespace SmartRestaurant.Application.Allergies.Illnesses.Queries.GetById
{


    public interface IGetIllnessByIdQuery
    {
        UpdateIllnessModel Execute(string Id);
    }
    public class GetIllnessByIdQuery : IGetIllnessByIdQuery
    {
        private readonly ILoggerService<IGetIllnessByIdQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;


        public GetIllnessByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<IGetIllnessByIdQuery> log,
             IMailingService mailing,
             IGetIllnessesBySpecificationQuery getBySpec,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;

        }

        public UpdateIllnessModel Execute(string Id)
        {
            try
            {
                return db.Illnesses
                    .Include(i => i.FoodIllnesses)
                    .Include("FoodIllnesses.Food")
                    .Where(x => x.Id == Id.ToGuid())
                    .Select(x => new UpdateIllnessModel
                    {
                        Alias = x.Alias,
                        Description = x.Description,
                        Name = x.Name,
                        IsDisabled = x.IsDisabled,
                        Id = x.Id.ToString(),
                        FoodsIdsNames = x.FoodIllnesses
                       .Select(i => new IdName
                       {
                           Id = i.Food.Id.ToString(),
                           Name = i.Food.Name
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
