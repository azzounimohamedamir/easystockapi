using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Owners.Queries.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.Owners.Queries.GetAll
{
    public interface IGetAllOwnersQuery
    {
        List<OwnerItemModel> Execute();
    }
    public class GetAllOwnersQuery : IGetAllOwnersQuery
    {
        private readonly ILoggerService<IGetAllOwnersQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllOwnersQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<IGetAllOwnersQuery> log, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public List<OwnerItemModel> Execute()
        {
            try
            {
                return db.Owners.Include(i=>i.Restaurants).ToOwnerItemModels()
                                .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
