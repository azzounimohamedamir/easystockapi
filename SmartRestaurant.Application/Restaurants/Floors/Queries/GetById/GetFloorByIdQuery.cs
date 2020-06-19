using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Floors.Commands.Update;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Floors.Queries.GetById
{


    public interface IGetFloorByIdQuery
    {
        UpdateFloorModel Execute(string Id);
    }
    public class GetFloorByIdQuery : IGetFloorByIdQuery
    {
        private readonly ILoggerService<GetFloorByIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetFloorByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetFloorByIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateFloorModel Execute(string Id)
        {
            try
            {
                var guid = Id.ToGuid();
                return db.Floors
                    .Include(i => i.Restaurant)
                    .Where(f => f.Id == guid)
                    .Select(x => new UpdateFloorModel
                    {
                        Alias = x.Alias,
                        Id = x.Id.ToString(),
                        Description = x.Description,
                        Name = x.Name,
                        RestaurantName = x.Restaurant.Name,
                        RestaurantId = x.Restaurant.Id.ToString(),

                    }).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
