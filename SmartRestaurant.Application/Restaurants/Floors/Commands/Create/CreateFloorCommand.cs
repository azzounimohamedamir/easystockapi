using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Floors.Commands.Create
{


    public interface ICreateFloorCommand
    {
        void Execute(CreateFloorModel model);
    }

    public class CreateFloorCommand : ICreateFloorCommand
    {
        private readonly ILoggerService<CreateFloorCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateFloorCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateFloorCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateFloorModel model)
        {
            try
            {
                var validator = new CreateFloorCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var restaurantGuid = model.RestaurantId.ToGuid();
                if (!db.Restaurants.Any(x => x.Id == restaurantGuid))
                {
                    throw new NotFoundException(nameof(Restaurant) + model.RestaurantId);
                }

                var floor = model.ToEntity();

                db.Floors.Add(floor);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
