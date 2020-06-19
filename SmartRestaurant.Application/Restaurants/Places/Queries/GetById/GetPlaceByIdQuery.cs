using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Places.Commands.Update;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Places.Queries.GetById
{


    public interface IGetPlaceByIdQuery
    {
        UpdatePlaceModel Execute(string Id);
    }
    public class GetPlaceByIdQuery : IGetPlaceByIdQuery
    {
        private readonly ILoggerService<GetPlaceByIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetPlaceByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetPlaceByIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdatePlaceModel Execute(string Id)
        {
            try
            {
                var guid = Id.ToGuid();
                return db.Places
                    .Include(i => i.Table)
                    .Include(a => a.Table.Area)
                    .Include(f => f.Table.Area.Floor)
                    .Include(r => r.Table.Area.Floor.Restaurant)
                    .Where(t => t.Id == guid)
                    .Select(x => new UpdatePlaceModel
                    {
                        Alias = x.Alias,
                        TableName = x.Table.Name,
                        TableId = x.TableId.ToString(),
                        Description = x.Description,
                        Id = x.Id.ToString(),
                        RestaurantId = x.Table.Area.Floor.RestaurantId.ToString(),
                        FloorId = x.Table.Area.FloorId.ToString(),
                        Name = x.Name,
                        AreaId = x.Table.AreaId.ToString(),
                        WaiterId = x.Table.Area.Floor.Restaurant.Staffs.FirstOrDefault().Id.ToString(),
                        IsDisabled = x.IsDisabled,

                    }).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
