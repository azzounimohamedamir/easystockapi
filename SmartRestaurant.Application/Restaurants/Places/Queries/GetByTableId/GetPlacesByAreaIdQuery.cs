using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Places.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SmartRestaurant.Application.Helpers;

namespace SmartRestaurant.Application.Restaurants.Places.Queries.GetByAreaId
{


    public interface IGetPlacesByAreaIdQuery
    {
        List<PlaceItemModel> Execute(string Id);
    }
    public class GetPlacesByAreaIdQuery : IGetPlacesByAreaIdQuery
    {
        private readonly ILoggerService<GetPlacesByAreaIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetPlacesByAreaIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetPlacesByAreaIdQuery> logger, IMailingService mailing,
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
                    .Include(t => t.Table)
                    .Include(i => i.Table.Area)                   
                    .Where(t => t.TableId == guid)
                    .Select(x => new PlaceItemModel
                    {
                        Alias = x.Alias,
                        AreaName = x.Table.Area.Name,
                        Description = x.Description,
                        Id = x.Id.ToString(),
                        IsDisabled = x.IsDisabled.DisabledDisplay(),
                        FloorName = x.Table.Area.Floor.Name,
                        Name = x.Name,
                        TableNumber = x.Table.TableNumber.ToString()
                    }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
