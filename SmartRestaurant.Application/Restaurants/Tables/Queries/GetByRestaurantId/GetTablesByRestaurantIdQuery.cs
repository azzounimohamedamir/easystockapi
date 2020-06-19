using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Tables.Queries.GetByRestaurantId
{


    public interface IGetTablesByRestaurantIdQuery
    {
        List<TableItemModel> Execute(string Id);
    }
    public class GetTablesByRestaurantIdQuery : IGetTablesByRestaurantIdQuery
    {
        private readonly ILoggerService<GetTablesByRestaurantIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetTablesByRestaurantIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetTablesByRestaurantIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<TableItemModel> Execute(string Id)
        {
            try
            {
                var guid = Id.ToGuid();
                return db.Tables
                    .Include(i => i.Area)
                    .ThenInclude(a => a.Floor)
                    .ThenInclude(f => f.Restaurant)
                    .Where(t => t.Area.Floor.RestaurantId == guid)
                    .Select(x => new TableItemModel
                    {
                        Alias = x.Alias,
                        AreaName = x.Area.Name,
                        Description = x.Description,
                        Id = x.Id.ToString(),
                        FloorName = x.Area.Floor.Name,
                        Name = x.Name,
                        IsDisabled = x.IsDisabled.DisabledDisplay(),
                    }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
