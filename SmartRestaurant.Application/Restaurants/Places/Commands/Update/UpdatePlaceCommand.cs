using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;
using SmartRestaurant.Domain.Restaurants;
using SmartRestaurant.Application.Restaurants.Places.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Places.Commands.Update
{


    public interface IUpdatePlaceCommand
    {
        void Execute(UpdatePlaceModel model);
    }

    public class UpdatePlaceCommand : IUpdatePlaceCommand
    {
        private readonly ILoggerService<UpdatePlaceCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdatePlaceCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdatePlaceCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdatePlaceModel model)
        {
            try
            {
                var validator = new UpdatePlaceCommandValidation();
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

                var tableGuid = model.TableId.ToGuid();
                if (!db.Areas.Any(x => x.Id == tableGuid))
                {
                    throw new NotFoundException(nameof(Table) + model.TableId);
                }

                model.ToEntity(ref Place);

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
