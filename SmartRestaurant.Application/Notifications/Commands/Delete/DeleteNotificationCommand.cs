using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
namespace SmartRestaurant.Application.Notifications.Commands.Delete
{


    public interface IDeleteNotificationCommand
    {
        void Execute(DeleteNotificationModel model);
    }

    public class DeleteNotificationCommand : IDeleteNotificationCommand
    {
        private readonly ILoggerService<DeleteNotificationCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteNotificationCommand(
            ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteNotificationCommand> logger, 
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteNotificationModel model)
        {
            try
            {
                var validator = new DeleteNotificationCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var entity = db.Notifications.Find(model.Id.ToGuid());

                if (string.IsNullOrEmpty(entity.ToString()))
                {
                    throw new NotFoundException(nameof(Notification) + model.Id);
                }



                db.Notifications.Remove(entity);
                db.Save();



            }
            catch (Exception e )
            {
                throw e; 
            }


        }
    }

}
