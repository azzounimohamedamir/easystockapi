using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Chains.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using SmartRestaurant.Application.Helpers;

namespace SmartRestaurant.Application.Restaurants.Chains.Queries.GetByOwnerId
{


    public interface IGetChainsByOwnerIdQuery
    {
        IEnumerable<ChainItemModel> Execute(string Id);
    }
    public class GetChainsByOwnerIdQuery : IGetChainsByOwnerIdQuery
    {
        private readonly ILoggerService<GetChainsByOwnerIdQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetChainsByOwnerIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetChainsByOwnerIdQuery> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }

        public IEnumerable<ChainItemModel> Execute(string id)
        {
            try
            {
                return db.Chains
                    .Where(x => id.IsNullOrEmpty() || x.OwnerId == id.ToGuid())
                    .Include(x => x.Owner)
                    .Select(x => new ChainItemModel
                    {
                        Id = x.Id.ToString(),
                        Alias = x.Alias,
                        Description = x.Description,
                        IsDisabled = x.IsDisabled.DisabledDisplay(),
                        Name = x.Name,
                        OwnerName = x.Owner.FullName,
                        OwnerId = x.OwnerId.ToString()
                    }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
