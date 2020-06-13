using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;
using SmartRestaurant.Domain.Restaurants;
using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create
{


    public interface ICreateRestaurantCommand
    {
        void Execute(CreateRestaurantModel model);
    }

    public class CreateRestaurantCommand : ICreateRestaurantCommand
    {
        private readonly ILoggerService<CreateRestaurantCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateRestaurantCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateRestaurantCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateRestaurantModel model)
        {
            try
            {

                var validator = new CreateRestaurantCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var chainGuid = model.ChainId.ToGuid();
                if (model.ChainId.NotNullOrEmpty() &&
                    !db.Chains.Any(x => x.Id == chainGuid))
                {
                    throw new NotFoundException(nameof(Chain));
                }
                var typeGuid = model.RestaurantTypeId.ToGuid();
                if ( !db.RestaurantTypes.Any(x => x.Id == typeGuid))                   
                {
                    throw new NotFoundException(nameof(RestaurantType));
                }
                var ownerGuid = model.OwnerId.ToGuid();
                if (model.OwnerId.NotNullOrEmpty() &&
                    !db.Owners.Any(x => x.Id == ownerGuid))
                {
                    throw new NotFoundException(nameof(Owner));
                }

                var restaurant = model.ToEntity();

                var cid = db.Currencies.FirstOrDefault().Id;
                restaurant.PriceRange = new PriceRange(cid, 1, 1);

                db.Restaurants.Add(restaurant);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
