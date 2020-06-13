using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Notifications.Commands.Factory;
using SmartRestaurant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers; 

namespace SmartRestaurant.Application.Notifications.Commands.Create
{


    public interface ICreateNotificationCommand
    {
        void Execute(CreateNotificationModel model);
    }

    public class CreateNotificationCommand : ICreateNotificationCommand
    {
        private readonly ILoggerService<CreateNotificationCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ICreateNotificationFactory _factory;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateNotificationCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateNotificationCommand> logger, IMailingService mailing,
            INotifyService notify , 
            ICreateNotificationFactory createNotificationFactory 
            )
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
            _factory = createNotificationFactory; 
        }
        public void Execute(CreateNotificationModel model)
        {
            try
            {



                var validator = new CreateNotificationCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }

                var entity = _factory.Create(model.Action, model.TableName,
                   model.TemplateId, model.Name, model.Alias
                   , model.Description, model.IsDisabled,
                    model.Type);

                entity.Template = db.Templates.FirstOrDefault(c => c.Id.ToString() == model.TemplateId);

                entity.Id = Guid.NewGuid();
                db.Notifications.Add(entity);

                foreach (var item in model.UsersId)
                {
                    entity.Users.Add(new NotificationUser
                    {
                        NotificationId = entity.Id,
                        UserId = item,
                        User = db.SRUsers.FirstOrDefault(x => x.Id == item),
                        Notification = entity , 
                    });

                }
                db.Save();       
            }
            catch (Exception)
            {




            }







        }
    }

}
