using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.MailingUsers.Queries;
using SmartRestaurant.Domain;
using System;

namespace SmartRestaurant.Application.MailingUsers.Commands.Delete
{



    public interface IDeleteMailingUserCommand
    {
        void Execute(MailingUserItem model);
    }

    public class DeleteMailingUserCommand : IDeleteMailingUserCommand
    {
        private readonly ILoggerService<DeleteMailingUserCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;


        public DeleteMailingUserCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteMailingUserCommand> logger, IMailingService mailing,
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
                var validator = new DeleteMailingUserCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var entity = db.MailingUsers.Find(model.MailingId);

                if (string.IsNullOrEmpty(entity.ToString()))
                {
                    throw new NotFoundException(nameof(MailingUser));
                }




                db.MailingUsers.Remove(entity);
                db.Save();


            }
            catch (Exception)
            {

            }

        }
    }

}
