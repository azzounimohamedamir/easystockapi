using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Chains.Commands.Create
{
    public interface ICreateChainCommand
    {
        void Execute(CreateChainModel model);
    }

    public class CreateChainCommand : ICreateChainCommand
    {
        private readonly ILoggerService<CreateChainCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateChainCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateChainCommand> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateChainModel model)
        {
            try
            {
                var validator = new CreateChainCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var ownerGuid = model.OwnerId.ToGuid();
                if (model.OwnerId.NotNullOrEmpty() &&
                    !db.Owners.Any(x => x.Id == ownerGuid))
                {
                    throw new NotFoundException(nameof(Owner));
                }

                var chain = model.ToEntity();

                db.Chains.Add(chain);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
