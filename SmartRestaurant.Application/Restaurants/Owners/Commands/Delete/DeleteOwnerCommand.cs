using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Owners.Commands.Delete
{


    public interface IDeleteOwnerCommand
    {
        void Execute(DeleteOwnerModel model);
    }

    public class DeleteOwnerCommand : IDeleteOwnerCommand
    {
        private readonly ILoggerService<DeleteOwnerCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteOwnerCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteOwnerCommand> log, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteOwnerModel model)
        {
            try
            {
                var validator = new DeleteOwnerCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var guid = model.Id.ToGuid();
                var Owner = db.Owners.FirstOrDefault(x => x.Id == guid);
                if (Owner == null)
                {
                    throw new NotFoundException(nameof(Owner));
                }

                if (db.Restaurants.Any(x => x.OwnerId == guid))
                {
                    throw new DeleteFailureException(nameof(Owner) + model.Id);
                }

                db.Owners.Remove(Owner);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
