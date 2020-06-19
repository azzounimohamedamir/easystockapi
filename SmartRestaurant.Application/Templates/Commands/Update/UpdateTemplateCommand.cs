using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers; 
namespace SmartRestaurant.Application.Templates.Commands.Update
{


    public interface IUpdateTemplateCommand
    {
        void Execute(UpdateTemplateModel model);
    }

    public class UpdateTemplateCommand : IUpdateTemplateCommand
    {
        private readonly ILoggerService<UpdateTemplateCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateTemplateCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateTemplateCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateTemplateModel model)
        {
            try
            {

                var validator = new UpdateTemplateCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }

                var entity = db.Templates.Find(model.Id.ToGuid());

                if (entity.ToString().IsNullOrEmpty())
                {
                    throw new NotFoundException(nameof(Template) + model.Id);
                }

                entity.Description = model.Description;
                entity.Name = model.Name;
                entity.Type = model.Type;
                entity.IsDisabled = model.IsDisabled;
                entity.Subject = model.Subject;
                entity.Title = model.Title;
                entity.Body = model.Body;

                db.Templates.Update(entity);
                db.Save();

            }
            catch
            {

            }

        }
    }

}
