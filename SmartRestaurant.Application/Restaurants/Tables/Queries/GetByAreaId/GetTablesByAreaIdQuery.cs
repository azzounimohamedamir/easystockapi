using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Tables.Queries.GetByAreaId
{


    public interface IGetTablesByAreaIdQuery
    {
        List<TableItemModel> Execute(string Id);
    }
    public class GetTablesByAreaIdQuery : IGetTablesByAreaIdQuery
    {
        private readonly ILoggerService<GetTablesByAreaIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetTablesByAreaIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetTablesByAreaIdQuery> logger, IMailingService mailing,
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
                    .Where(t => t.AreaId == guid)
                    .Select(x => new TableItemModel
                    {
                        Alias = x.Alias,
                        AreaName = x.Area.Name,
                        Description = x.Description,
                        Id = x.Id.ToString(),
                        IsDisabled = x.IsDisabled.DisabledDisplay(),
                        FloorName = x.Area.Floor.Name,
                        Name = x.Name
                    }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
