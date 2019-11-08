using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Update
{


    public interface IUpdateRestaurantTypeCommand
    {
        void Execute(UpdateRestaurantTypeModel model);
    }

    public class UpdateRestaurantTypeCommand : IUpdateRestaurantTypeCommand
    {
        private readonly ILoggerService<UpdateRestaurantTypeCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateRestaurantTypeCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateRestaurantTypeCommand> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateRestaurantTypeModel model)
        {
            try
            {
                var validator = new UpdateRestaurantTypeCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }
                var guid = model.Id.ToGuid();
                var restaurantType = db.RestaurantTypes.FirstOrDefault(x => x.Id == guid);

                if (restaurantType == null)
                    throw new NotFoundException(nameof(RestaurantType) + model.Id);

                model.ToEntity(ref restaurantType);

                db.RestaurantTypes.Update(restaurantType);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
