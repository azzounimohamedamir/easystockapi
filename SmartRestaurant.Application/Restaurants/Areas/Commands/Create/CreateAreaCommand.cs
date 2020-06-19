using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Areas.Commands.Create
{


    public interface ICreateAreaCommand
    {
        void Execute(CreateAreaModel model);
    }

    public class CreateAreaCommand : ICreateAreaCommand
    {
        private readonly ILoggerService<CreateAreaCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateAreaCommand(
            ISmartRestaurantDatabaseService db,
            ILoggerService<CreateAreaCommand> logger,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateAreaModel model)
        {
            try
            {
                var validator = new CreateAreaCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var floorGuid = model.FloorId.ToGuid();
                if (!db.Floors.Any(x => x.Id == floorGuid))
                {
                    throw new NotFoundException(nameof(Floor) + model.FloorId);
                }

                var area = model.ToEntity();

                db.Areas.Add(area);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
