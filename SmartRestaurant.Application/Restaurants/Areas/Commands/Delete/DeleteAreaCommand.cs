using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Application.Restaurants.Areas.Commands.Delete
{


    public interface IDeleteAreaCommand
    {
        void Execute(DeleteAreaModel model);
    }

    public class DeleteAreaCommand : IDeleteAreaCommand
    {
        private readonly ILoggerService<DeleteAreaCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteAreaCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteAreaCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteAreaModel model)
        {
            try
            {
                var validator = new DeleteAreaCommandValidation();
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

                if (db.Tables.Any(x => x.AreaId == guid))
                {
                    throw new DeleteFailureException(nameof(Area) + model.Id);
                }

                db.Areas.Remove(area);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
