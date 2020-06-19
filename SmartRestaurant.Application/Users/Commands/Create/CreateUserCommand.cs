using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Users.Commands.Create
{


    public interface ICreateUserCommand
    {
        void Execute(CreateUserModel model);
    }

    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly ILoggerService<CreateUserCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ICreateUserFactory _factory;
        private readonly ISmartRestaurantDatabaseService db;
        

        public CreateUserCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateUserCommand> logger, IMailingService mailing,
            INotifyService notify , 
            ICreateUserFactory createUserFactory 
            
            )
        {
            this.db = db;
            this.log = logger;
            this.mailing = mailing;
            this.notify = notify;
            this._factory = createUserFactory;
        }
        public void Execute(CreateUserModel model)
        {
            try
            {

                var validator = new CreateUserCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }

                /// TODO: Checking user has the same email or same username 
            //  var _country = db.Users.Where(c => c. == model.u).FirstOrDefault();
                //if (_country != null)
                //    throw new AlreadyExistsExeption($"Country: {model.Name} Exists");


                var entity = _factory.Create(model.FirstName, model.LastName, 
                model.UserName, model.Email, model.Password);
                entity.Id = Guid.NewGuid().ToString();
                //usermanger
                //db.SRUsers.Add(entity);
                db.Save();

            }
            catch(Exception e )
            {
                throw e; 

            }

               


        }
    }

}
