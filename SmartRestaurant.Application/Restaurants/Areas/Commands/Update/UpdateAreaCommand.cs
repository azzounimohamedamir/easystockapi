using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;
using SmartRestaurant.Domain.Restaurants;
using SmartRestaurant.Application.Restaurants.Areas.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Areas.Commands.Update
{


    public interface IUpdateAreaCommand
    {
        void Execute(UpdateAreaModel model);
    }

    public class UpdateAreaCommand : IUpdateAreaCommand
    {
        private readonly ILoggerService<UpdateAreaCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateAreaCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateAreaCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateAreaModel model)
        {
            try
            {
                var validator = new UpdateAreaCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var guid = model.Id.ToGuid();
                var area = db.Areas.FirstOrDefault(x => x.Id == guid);
                if (area == null)
                {
                    throw new NotFoundException(nameof(Area) + model.Id);
                }

                var floorGuid = model.FloorId.ToGuid();
                if (!db.Floors.Any(x => x.Id == floorGuid))
                {
                    throw new NotFoundException(nameof(Floor) + model.FloorId);
                }

                 model.ToEntity(ref area);

                db.Areas.Update(area);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
