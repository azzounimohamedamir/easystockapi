using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.Owners.Commands.Create
{


    public interface ICreateOwnerCommand
    {
        void Execute(CreateOwnerModel model);
    }

    public class CreateOwnerCommand : ICreateOwnerCommand
    {
        private readonly ILoggerService<CreateOwnerCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateOwnerCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateOwnerCommand> log, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateOwnerModel model)
        {
            try
            {
                var validator = new CreateOwnerCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var Owner = model.ToEntity();

                db.Owners.Add(Owner);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
