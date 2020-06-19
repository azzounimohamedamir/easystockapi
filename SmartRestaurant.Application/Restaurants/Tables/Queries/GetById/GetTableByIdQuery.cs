using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Tables.Commands.Update;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Tables.Queries.GetById
{


    public interface IGetTableByIdQuery
    {
        UpdateTableModel Execute(string Id);
    }
    public class GetTableByIdQuery : IGetTableByIdQuery
    {
        private readonly ILoggerService<GetTableByIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetTableByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetTableByIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateTableModel Execute(string Id)
        {
            try
            {
                var guid = Id.ToGuid();
                return db.Tables
                    .Include(i => i.Area)
                    .Where(t => t.Id == guid)
                    .Select(x => new UpdateTableModel
                    {
                        Alias = x.Alias,
                        AreaName = x.Area.Name,
                        AreaId = x.Area.Id.ToString(),
                        Description = x.Description,
                        Id = x.Id.ToString(),
                        RestaurantId = x.Area.Floor.RestaurantId.ToString(),
                        FloorId = x.Area.FloorId.ToString(),
                        Name = x.Name,
                        IsDisabled = x.IsDisabled
                    }).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
