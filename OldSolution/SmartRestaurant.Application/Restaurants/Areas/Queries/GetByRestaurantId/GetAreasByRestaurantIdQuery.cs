using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Areas.Queries.GetById;

namespace SmartRestaurant.Application.Restaurants.Areas.Queries.GetByRestaurantId
{
    public interface IGetAreasByRestaurantIdQuery
    {
        List<AreaItemModel> Execute(string Id);
    }
    public class GetAreasByRestaurantIdQuery : IGetAreasByRestaurantIdQuery
    {
        private readonly ILoggerService<GetAreasByRestaurantIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAreasByRestaurantIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAreasByRestaurantIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<AreaItemModel> Execute(string Id)
        {
            try
            {
                var guid = Id.ToGuid();
                return db.Areas
                    .Include(i => i.Floor)
                    .Include(i => i.Floor.Restaurant)
                    .Where(a => a.Floor.RestaurantId == guid)
                    .Select(x => new AreaItemModel
                    {
                        Alias = x.Alias,
                        Id = x.Id.ToString(),
                        IsDisabled = x.IsDisabled.DisabledDisplay(),
                        Description = x.Description,
                        FloorName = x.Floor.Name,
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
