using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Chains.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Helpers;

namespace SmartRestaurant.Application.Restaurants.Chains.Queries.GetAll
{


    public interface IGetAllChainsQuery
    {
        IEnumerable<ChainItemModel> Execute( );
    }
    public class GetAllChainsQuery : IGetAllChainsQuery
    {
        private readonly ILoggerService<GetAllChainsQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllChainsQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllChainsQuery> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }

        public IEnumerable< ChainItemModel> Execute()
        {
            try
            {
                return db.Chains
                   .Include(x => x.Owner)
                   .Select(x => new ChainItemModel
                   {
                       Id = x.Id.ToString(),
                       Alias = x.Alias,
                       Description = x.Description,
                       IsDisabled = x.IsDisabled.DisabledDisplay(),
                       Name = x.Name,
                       OwnerName = x.Owner.FullName,
                       OwnerId=x.OwnerId.ToString()
                   }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
