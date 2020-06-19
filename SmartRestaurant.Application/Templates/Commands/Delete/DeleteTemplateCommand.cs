using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain;
using System;

namespace SmartRestaurant.Application.Templates.Commands.Delete
{


    public interface IDeleteTemplateCommand
    {
        void Execute(DeleteTemplateModel model);
    }

    public class DeleteTemplateCommand : IDeleteTemplateCommand
    {
        private readonly ILoggerService<DeleteTemplateCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteTemplateCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteTemplateCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteTemplateModel model)
        {
            try
            {

                var validator = new DeleteTemplateCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }


                var entity = db.Templates.Find(model.Id.ToGuid());

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Template) + model.Id);
                }



                db.Templates.Remove(entity);
                db.Save();



            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }

}
