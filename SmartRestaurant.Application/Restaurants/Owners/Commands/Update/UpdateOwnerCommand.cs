using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Owners.Commands.Create;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Owners.Commands.Update
{


    public interface IUpdateOwnerCommand
    {
        void Execute(UpdateOwnerModel model);
    }

    public class UpdateOwnerCommand : IUpdateOwnerCommand
    {
        private readonly ILoggerService<UpdateOwnerCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateOwnerCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateOwnerCommand> log, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateOwnerModel model)
        {
            try
            {
                var validator = new UpdateOwnerCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var idGuid = model.Id.ToGuid();
                var Owner = db.Owners.FirstOrDefault(x => x.Id == idGuid);
                if (Owner == null)
                {
                    throw new NotFoundException(nameof(Owner) + model.Id);
                }

                model.ToEntity(ref Owner);

                db.Owners.Update(Owner);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
