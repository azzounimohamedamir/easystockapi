using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Chains.Commands.Create;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Chains.Commands.Update
{


    public interface IUpdateChainCommand
    {
        void Execute(UpdateChainModel model);
    }

    public class UpdateChainCommand : IUpdateChainCommand
    {
        private readonly ILoggerService<UpdateChainCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateChainCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateChainCommand> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateChainModel model)
        {
            try
            {
                var validator = new UpdateChainCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }
                var chain = db.Chains.FirstOrDefault(x => x.Id == model.Id.ToGuid());
                if (chain == null)
                    throw new NotFoundException(nameof(Chain) + ":" + model.Id);

                var ownerGuid = model.OwnerId.ToGuid();
                if (model.OwnerId.NotNullOrEmpty() &&
                    !db.Owners.Any(x => x.Id == ownerGuid))
                {
                    throw new NotFoundException(nameof(Owner));
                }

                model.ToEntity(ref chain);

                db.Chains.Update(chain);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
