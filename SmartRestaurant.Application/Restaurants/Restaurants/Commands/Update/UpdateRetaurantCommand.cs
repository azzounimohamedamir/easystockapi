using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Restaurants.Commands.Update
{


    public interface IUpdateRestaurantCommand
    {
        void Execute(UpdateRestaurantModel model);
    }

    public class UpdateRestaurantCommand : IUpdateRestaurantCommand
    {
        private readonly ILoggerService<UpdateRestaurantCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateRestaurantCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateRestaurantCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateRestaurantModel model)
        {
            try
            {
                var validator = new UpdateRestaurantCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var idGuid = model.Id.ToGuid();
                var restaurant = db.Restaurants.FirstOrDefault(x => x.Id == idGuid);
                if (restaurant == null)
                {
                    throw new NotFoundException(nameof(Restaurant) + model.Id);
                }

                var chainGuid = model.ChainId.ToGuid();
                if (model.ChainId.NotNullOrEmpty() &&
                    !db.Chains.Any(x => x.Id == chainGuid))
                {
                    throw new NotFoundException(nameof(Chain));
                }
                var typeGuid = model.RestaurantTypeId.ToGuid();
                if (!db.RestaurantTypes.Any(x => x.Id == typeGuid))
                {
                    throw new NotFoundException(nameof(RestaurantType));
                }
                var AllergyGuid = model.OwnerId.ToGuid();
                if (model.OwnerId.NotNullOrEmpty() &&
                    !db.Owners.Any(x => x.Id == AllergyGuid))
                {
                    throw new NotFoundException(nameof(Owner));
                }

                model.ToEntity(ref restaurant);

                db.Restaurants.Update(restaurant);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

}
