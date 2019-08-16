using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Areas.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Helpers;

namespace SmartRestaurant.Application.Restaurants.Areas.Queries.GetByFloorId
{


    public interface IGetAreasByFloorIdQuery
    {
        IEnumerable<AreaItemModel> Execute(string Id);
    }
    public class GetAreasByFloorIdQuery : IGetAreasByFloorIdQuery
    {
        private readonly ILoggerService<GetAreasByFloorIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAreasByFloorIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAreasByFloorIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public IEnumerable<AreaItemModel> Execute(string Id)
        {
            try
            {
                var guid = Id.ToGuid();
                return db.Areas
                    .Include(i => i.Floor)
                    .Where(a => a.FloorId == guid)
                    .Select(x => new AreaItemModel
                    {
                        Id = x.Id.ToString(),
                        Alias = x.Alias,
                        IsDisabled = x.IsDisabled.DisabledDisplay(),
                        Description = x.Description,
                        FloorName = x.Floor.Name,
                        Name = x.Name
                    }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
