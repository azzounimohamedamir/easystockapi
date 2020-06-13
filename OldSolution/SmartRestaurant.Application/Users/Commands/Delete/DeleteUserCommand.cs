using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
namespace SmartRestaurant.Application.Users.Commands.Delete
{


    public interface IDeleteUserCommand
    {
        void Execute(DeleteUserModel model);
    }

    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly ILoggerService<DeleteUserCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteUserCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteUserCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteUserModel model)
        {



            try
            {
                var validator = new DeleteUserCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                //var entity = db.SRUsers.Find(model.Id.ToGuid());

                //if (entity.ToString().IsNullOrEmpty())
                //{
                //    throw new NotFoundException(nameof(SRUser) + model.Id);
                //}

               // db.SRUsers.Remove(entity);
                db.Save();


            }
            catch (Exception ex)
            {
                throw ex;
            }
              


        }
    }

}
