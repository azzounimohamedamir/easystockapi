using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Floors.Commands.Create;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;

namespace SmartRestaurant.Application.Restaurants.Floors.Commands.Update
{


    public interface IUpdateFloorCommand
    {
        void Execute(UpdateFloorModel model);
    }

    public class UpdateFloorCommand : IUpdateFloorCommand
    {
        private readonly ILoggerService<UpdateFloorCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateFloorCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateFloorCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateFloorModel model)
        {
            try
            {
                var validator = new UpdateFloorCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var idGuid = model.Id.ToGuid();
                var floor = db.Floors.FirstOrDefault(x => x.Id == idGuid);
                if (floor == null)
                {
                    throw new NotFoundException(nameof(Floor) + model.Id);
                }

                var restaurantGuid = model.RestaurantId.ToGuid();
                if (!db.Restaurants.Any(x => x.Id == restaurantGuid))
                {
                    throw new NotFoundException(nameof(Restaurant) + model.RestaurantId);
                }

                 model.ToEntity(ref floor);

                db.Floors.Update(floor);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
