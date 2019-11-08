using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
namespace SmartRestaurant.Application.NotificationUsers.Commands.Delete
{



    public interface IDeleteNotificationUserCommand
    {
        void Execute(DeleteNotificationUserModel model);
    }

    public class DeleteNotificationUserCommand : IDeleteNotificationUserCommand
    {
        private readonly ILoggerService<DeleteNotificationUserCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;


        public DeleteNotificationUserCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteNotificationUserCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteNotificationUserModel model)
        {
            try
            {
                var validator = new DeleteNotificationUserCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var entity = db.NotificationUsers.Find(model.NotificationId);

                if (string.IsNullOrEmpty(entity.ToString()))
                {
                    throw new NotFoundException(nameof(MailingUser));
                }




                db.NotificationUsers.Remove(entity);
                db.Save();


            }
            catch (Exception e)
            {

            }

        }
    }

}
