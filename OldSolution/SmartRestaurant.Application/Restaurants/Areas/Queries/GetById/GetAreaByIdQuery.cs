using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Restaurants.Areas.Commands.Update;

namespace SmartRestaurant.Application.Restaurants.Areas.Queries.GetById
{


    public interface IGetAreaByIdQuery
    {
        UpdateAreaModel Execute(string Id);
    }
    public class GetAreaByIdQuery : IGetAreaByIdQuery
    {
        private readonly ILoggerService<GetAreaByIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAreaByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAreaByIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateAreaModel Execute(string Id)
        {
            try
            {
                var guid = Id.ToGuid();
                return db.Areas
                    .Include(i => i.Floor)
                    .Where(a => a.Id == guid)
                    .Select(x => new UpdateAreaModel
                    {
                        Alias = x.Alias,
                        Id = x.Id.ToString(),
                        Description = x.Description,
                        FloorId = x.FloorId.ToString(),
                        FloorName = x.Floor.Name,
                        Name = x.Name,
                        IsDisabled = x.IsDisabled,
                        RestaurantId=x.Floor.RestaurantId.ToString()
                    }).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
