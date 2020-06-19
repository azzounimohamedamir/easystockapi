using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Chains.Commands.Update;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Chains.Queries.GetById
{


    public interface IGetChainByIdQuery
    {
        UpdateChainModel Execute(string Id);
    }
    public class GetChainByIdQuery : IGetChainByIdQuery
    {
        private readonly ILoggerService<IGetChainByIdQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetChainByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<IGetChainByIdQuery> log,
             IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateChainModel Execute(string Id)
        {
            try
            {
                return db.Chains
                     .Where(x => x.Id == Id.ToGuid())
                     .Include(x => x.Owner)
                     .Select(x => new UpdateChainModel
                     {
                         Id = x.Id.ToString(),
                         Alias = x.Alias,
                         Description = x.Description,
                         IsDisabled = x.IsDisabled,
                         Name = x.Name,
                         OwnerId = x.OwnerId.ToString()
                     }).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
