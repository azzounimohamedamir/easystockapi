using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Templates.Commands.Factory;
using System;

namespace SmartRestaurant.Application.Templates.Commands.Create
{


    public interface ICreateTemplateCommand
    {
        void Execute(CreateTemplateModel model);
    }

    public class CreateTemplateCommand : ICreateTemplateCommand
    {
        private readonly ILoggerService<CreateTemplateCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ICreateTemplateFactory _factory;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateTemplateCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateTemplateCommand> logger, IMailingService mailing,
            INotifyService notify,
            ICreateTemplateFactory createTemplateFactory
            )
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
            _factory = createTemplateFactory;
        }
        public void Execute(CreateTemplateModel model)
        {

            try
            {



                var validator = new CreateTemplateCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }
                var entity = _factory.Create(model.Name, model.Description,
                    model.Type, model.IsDisabled, model.Alias, model.Title, model.Subject, model.Body);
                entity.Id = Guid.NewGuid();
                db.Templates.Add(entity);
                db.Save();
            }
            catch (Exception e)
            {
                throw e;

            }


        }
    }

}
