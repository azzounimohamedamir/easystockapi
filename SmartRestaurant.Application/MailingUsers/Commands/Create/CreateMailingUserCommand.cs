using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.MailingUsers.Queries;
using SmartRestaurant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers; 
namespace SmartRestaurant.Application.MailingUsers.Commands.Create
{



    public interface ICreateMailingUserCommand
    {
        void Execute(MailingUserItem model);
    }

    public class CreateMailingUserCommand : ICreateMailingUserCommand
    {
        private readonly ILoggerService<CreateMailingUserCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        //private readonly ICreateMailingUserFactory _factory;
        private readonly ISmartRestaurantDatabaseService db;
        public CreateMailingUserCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateMailingUserCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(MailingUserItem model)
        {
            try
            {
                var validator = new CreateMailingUserCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }



                var entity = new MailingUser();
                entity.MailingId = model.MailingId;
               // entity.SRUserId = model.UserId.ToString();

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
