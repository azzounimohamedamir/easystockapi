using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Services.Commnads.Create
{
    public interface ICreateServiceCommand
    {
        void Execute(CreateServiceModel model);
    }

    public class CreateServiceCommand : ICreateServiceCommand
    {
        private readonly ILoggerService<CreateServiceCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateServiceCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateServiceCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateServiceModel model)
        {
            try
            {
                var validator = new CreateServiceCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var Service = model.ToEntity();
                 
                db.Services.Add(Service);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
