using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Places.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SmartRestaurant.Application.Helpers;

namespace SmartRestaurant.Application.Restaurants.Places.Queries.GetByRestaurantId
{


    public interface IGetPlacesByRestaurantIdQuery
    {
        List<PlaceItemModel> Execute(string Id);
    }
    public class GetPlacesByRestaurantIdQuery : IGetPlacesByRestaurantIdQuery
    {
        private readonly ILoggerService<GetPlacesByRestaurantIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetPlacesByRestaurantIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetPlacesByRestaurantIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<PlaceItemModel> Execute(string Id)
        {
            try
            {
                var guid = Id.ToGuid();
                return db.Places
                    .Include(b => b.Table)
                    .Include(i => i.Table.Area)
                    .Include(f=>f.Table.Area.Floor)
                    .Include(r=>r.Table.Area.Floor.Restaurant)
                    .Where(t => t.Table.Area.Floor.RestaurantId == guid)
                    .Select(x => new PlaceItemModel
                    {
                        Alias = x.Alias,
                        AreaName = x.Table.Area.Name,
                        Description = x.Description,
                        Id = x.Id.ToString(),
                        FloorName=x.Table.Area.Floor.Name,
                        Name = x.Name,
                        IsDisabled = x.IsDisabled.DisabledDisplay(),
                        TableNumber=x.Table.TableNumber.ToString()
                        
                    }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
