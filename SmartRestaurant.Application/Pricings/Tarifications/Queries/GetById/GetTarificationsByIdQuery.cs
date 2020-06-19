using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Pricings.Tarifications.Commands.Update;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Pricings.Tarifications.Queries.GetById
{


    public interface IGetTarificationByIdQuery
    {
        UpdateTarificationModel Execute(string Id);
    }
    public class GetTarificationByIdQuery : IGetTarificationByIdQuery
    {
        private readonly ILoggerService<IGetTarificationByIdQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetTarificationByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<IGetTarificationByIdQuery> log,
             IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateTarificationModel Execute(string Id)
        {
            try
            {
                return db.Tarifications
                    .Include(x => x.DishTarifications)
                    .Include(x => x.ProductTarifications)
                    .Include("DishTarifications.Dish")
                    .Include("ProductTarifications.Product")
                    .Select(x => new UpdateTarificationModel
                    {
                        Id = x.Id.ToString(),
                        Alias = x.Alias,
                        Description = x.Description,
                        IsDisabled = x.IsDisabled,
                        Name = x.Name,
                        SlugUrl = x.SlugUrl,
                        IsPercentage = x.IsPercentage,
                        Amount = x.Amount,
                        RestaurantId = x.RestaurantId.ToString(),
                        DishesNames = x.DishTarifications.Select(d => new IdName
                        {
                            Name = d.Dish.Name,
                            Id = d.Dish.Id.ToString()
                        }).ToList(),
                        ProductsNames = x.ProductTarifications.Select(d => new IdName
                        {
                            Name = d.Product.Name,
                            Id = d.Product.Id.ToString()
                        }).ToList()
                    }).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
