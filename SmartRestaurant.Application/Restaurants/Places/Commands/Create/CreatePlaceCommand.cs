using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Places.Commands.Create
{


    public interface ICreatePlaceCommand
    {
        void Execute(CreatePlaceModel model);
    }

    public class CreatePlaceCommand : ICreatePlaceCommand
    {
        private readonly ILoggerService<CreatePlaceCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreatePlaceCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreatePlaceCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreatePlaceModel model)
        {
            try
            {
                var validator = new CreatePlaceCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var tableGuid = model.TableId.ToGuid();
                if (!db.Tables.Any(x => x.Id == tableGuid))
                {
                    throw new NotFoundException(nameof(Table) + model.TableId);
                }

                var Place = model.ToEntity();

                db.Places.Add(Place);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
