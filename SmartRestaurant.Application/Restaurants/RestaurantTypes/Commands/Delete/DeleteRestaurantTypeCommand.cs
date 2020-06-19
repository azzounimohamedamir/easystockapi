using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Delete
{


    public interface IDeleteRestaurantTypeCommand
    {
        void Execute(DeleteRestaurantTypeModel model);
    }

    public class DeleteRestaurantTypeCommand : IDeleteRestaurantTypeCommand
    {
        private readonly ILoggerService<DeleteRestaurantTypeCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteRestaurantTypeCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteRestaurantTypeCommand> log, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteRestaurantTypeModel model)
        {
            try
            {
                var validator = new DeleteRestaurantTypeCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }


                var guid = model.Id.ToGuid();
                var restaurantType = db.RestaurantTypes.FirstOrDefault(x => x.Id == guid);
                if (restaurantType == null)
                {
                    throw new NotFoundException(nameof(RestaurantType));
                }

                var RestaurantTypeGuid = model.Id.ToGuid();
                if (db.Restaurants.Any(x => x.RestaurantTypeId == RestaurantTypeGuid))
                {
                    throw new DeleteFailureException(nameof(RestaurantType) + model.Id);
                }

                db.RestaurantTypes.Remove(restaurantType);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
