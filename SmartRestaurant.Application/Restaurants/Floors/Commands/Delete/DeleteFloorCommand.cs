using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Floors.Commands.Delete
{


    public interface IDeleteFloorCommand
    {
        void Execute(DeleteFloorModel model);
    }

    public class DeleteFloorCommand : IDeleteFloorCommand
    {
        private readonly ILoggerService<DeleteFloorCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteFloorCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteFloorCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteFloorModel model)
        {
            try
            {
                var validator = new DeleteFloorCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var guid = model.Id.ToGuid();
                var floor = db.Floors.FirstOrDefault(x => x.Id == guid);
                if (floor == null)
                {
                    throw new NotFoundException(nameof(Floor));
                }

                if (db.Areas.Any(x => x.FloorId == guid))
                {
                    throw new DeleteFailureException(nameof(Floor) + model.Id);
                }

                db.Floors.Remove(floor);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
