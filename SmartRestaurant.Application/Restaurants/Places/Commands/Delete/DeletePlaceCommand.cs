using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Places.Commands.Delete
{


    public interface IDeletePlaceCommand
    {
        void Execute(DeletePlaceModel model);
    }

    public class DeletePlaceCommand : IDeletePlaceCommand
    {
        private readonly ILoggerService<DeletePlaceCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeletePlaceCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeletePlaceCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeletePlaceModel model)
        {
            try
            {
                var validator = new DeletePlaceCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var guid = model.Id.ToGuid();
                var Place = db.Places.FirstOrDefault(x => x.Id == guid);
                if (Place == null)
                {
                    throw new NotFoundException(nameof(Place) + model.Id);
                }

                db.Places.Remove(Place);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
