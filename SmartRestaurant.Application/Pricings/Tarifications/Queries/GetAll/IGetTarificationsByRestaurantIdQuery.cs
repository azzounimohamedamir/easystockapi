using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Pricings.Tarifications.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Pricings.Tarifications.Queries.GetAll
{


    public interface IGetTarificationsByRestaurantIdQuery
    {
        IEnumerable<TarificationItemModel> Execute(string id);
    }
    public class GetTarificationsByRestaurantIdQuery : IGetTarificationsByRestaurantIdQuery
    {
        private readonly ILoggerService<GetTarificationsByRestaurantIdQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetTarificationsByRestaurantIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetTarificationsByRestaurantIdQuery> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }

        public IEnumerable<TarificationItemModel> Execute(string id)
        {
            try
            {
                return db.Tarifications
                    .Include(x => x.Restaurant)
                    .Where(x => x.RestaurantId == id.ToGuid())
                    .Select(x => new TarificationItemModel
                    {
                        Id = x.Id.ToString(),
                        Alias = x.Alias,
                        IsPercentage = x.IsPercentage,
                        Amount = x.Amount,
                        Description = x.Description,
                        IsDisabled = x.IsDisabled.DisabledDisplay(),
                        Name = x.Name,
                        SlugUrl = x.SlugUrl,
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
