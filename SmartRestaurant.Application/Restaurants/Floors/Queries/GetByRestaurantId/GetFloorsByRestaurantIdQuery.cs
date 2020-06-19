
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Floors.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Helpers;

namespace SmartRestaurant.Application.Restaurants.Floors.Queries.GetByRestaurantId
{


    public interface IGetFloorsByRestaurantIdQuery
    {
        IEnumerable<FloorItemModel> Execute(string Id);
    }
    public class GetFloorsByRestaurantIdQuery : IGetFloorsByRestaurantIdQuery
    {
        private readonly ILoggerService<GetFloorsByRestaurantIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetFloorsByRestaurantIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetFloorsByRestaurantIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public IEnumerable<FloorItemModel> Execute(string Id)
        {
            try
            {
                var guid = Id.ToGuid();
                return db.Floors
                    .Include(i=>i.Restaurant)
                    .Where(f => f.RestaurantId == guid)
                    .Select(x => new FloorItemModel
                    {
                        Alias = x.Alias,
                        Id = x.Id.ToString(),
                        Description = x.Description,
                        Name = x.Name,
                        IsDisabled = x.IsDisabled.DisabledDisplay(),
                        RestaurantName = x.Restaurant.Name

                    }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
