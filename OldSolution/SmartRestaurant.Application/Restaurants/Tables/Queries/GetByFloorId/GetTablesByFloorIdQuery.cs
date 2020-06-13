using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SmartRestaurant.Application.Helpers;

namespace SmartRestaurant.Application.Restaurants.Tables.Queries.GetByFloorId
{


    public interface IGetTablesByFloorIdQuery
    {
        List<TableItemModel> Execute(string Id);
    }
    public class GetTablesByFloorIdQuery : IGetTablesByFloorIdQuery
    {
        private readonly ILoggerService<GetTablesByFloorIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetTablesByFloorIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetTablesByFloorIdQuery> logger, IMailingService mailing,
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
                    .Include(f => f.Area.Floor)
                    .Where(t => t.Area.FloorId == guid)
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
