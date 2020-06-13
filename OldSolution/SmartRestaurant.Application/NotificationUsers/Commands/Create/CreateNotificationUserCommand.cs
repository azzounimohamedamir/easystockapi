using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.NotificationUsers.Commands.Create
{


    public interface ICreateNotificationUserCommand
    {
        void Execute(CreateNotificationUserModel model);
    }

    public class CreateNotificationUserCommand : ICreateNotificationUserCommand
    {

        private readonly ILoggerService<CreateNotificationUserCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        //private readonly ICreateMailingUserFactory _factory;
        private readonly ISmartRestaurantDatabaseService db;
        public CreateNotificationUserCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateNotificationUserCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateNotificationUserModel model)
        {
            try
            {
                var validator = new CreateNotificationUserCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }



                var entity = new MailingUser();
                entity.MailingId = model.MailingId;
               entity.UserId = model.UserId.ToString();

                entity.Mailing = db.Mailings.FirstOrDefault(p => p.Id == model.MailingId);
             // entity.SampleUser = db.Users.FirstOrDefault(p => p.Id == model.UserId);
                db.MailingUsers.Add(entity);
                db.Save();



            }
            catch (Exception)
            {


            }


        }
    }

}
