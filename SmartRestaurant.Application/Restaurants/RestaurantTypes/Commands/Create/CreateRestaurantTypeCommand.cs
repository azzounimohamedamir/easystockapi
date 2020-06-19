using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;

namespace SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Create
{


    public interface ICreateRestaurantTypeCommand
    {
        void Execute(CreateRestaurantTypeModel model);
    }

    public class CreateRestaurantTypeCommand : ICreateRestaurantTypeCommand
    {
        private readonly ILoggerService<CreateRestaurantTypeCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateRestaurantTypeCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateRestaurantTypeCommand> log, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateRestaurantTypeModel model)
        {
            try
            {
                var validator = new CreateRestaurantTypeCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var restaurantType = model.ToEntity();

                db.RestaurantTypes.Add(restaurantType);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
