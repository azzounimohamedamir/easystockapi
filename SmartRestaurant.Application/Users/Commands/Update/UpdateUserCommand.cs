using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
namespace SmartRestaurant.Application.Users.Commands.Update
{


    public interface IUpdateUserCommand
    {
        void Execute(UpdateUserModel model);
    }

    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly ILoggerService<UpdateUserCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateUserCommand(ISmartRestaurantDatabaseService db,
           ILoggerService<UpdateUserCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateUserModel model)
        {
            try
            {

                var validator = new UpdateUserCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }
                //  var entity = db.SRUsers.Find(model.Id.ToGuid());

                //if (entity.ToString().IsNullOrEmpty())
                //{
                //    throw new NotFoundException(nameof(SRUser) + model.Id);
                //}

                //entity.FirstName = model.FirstName;
                //entity.LastName = model.LastName;
                //entity.Id = model.Id.ToGuid().ToString();
                //entity.UserName = model.UserName;
                //entity.PasswordHash = model.Password;
                //entity.Email = model.Email;


                //db.SRUsers.Update(entity);
                db.Save();
            }
            catch (Exception)
            {


            }


        }
    }

}
