using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
namespace SmartRestaurant.Application.Mails.Commands.Create
{


    public interface ICreateMailingCommand
    {
        void Execute(CreateMailingModel model);
    }

    public class CreateMailingCommand : ICreateMailingCommand
    {
        private readonly ILoggerService<CreateMailingCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ICreateMailingFactory _factory;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateMailingCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateMailingCommand> logger, IMailingService mailing,
            INotifyService notify,
            ICreateMailingFactory createMailingFactory)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
            _factory = createMailingFactory; 
        }
        public void Execute(CreateMailingModel model)
        {
            try
            {



                var validator = new CreateMailingCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }

                var _mailing = db.Mailings.Where(c => c.Action == model.Action && c.TableName == model.TableName).FirstOrDefault();
                if (_mailing != null)
                    throw new AlreadyExistsExeption($"Mailing : {model.Name} Exists");


                var entity = _factory.Create(model.Action, model.TableName,
                    model.TemplateId,model.Name , model.Alias
                    , model.Description , model.IsDisabled , model.Type);

                entity.Id = Guid.NewGuid(); 
                entity.Template = db.Templates.FirstOrDefault(c => c.Id.ToString() == model.TemplateId);

                db.Mailings.Add(entity);
                foreach (var item in model.UsersId)
                {
                    entity.Users.Add(new MailingUser
                    {
                        MailingId = entity.Id,
                        UserId = item,
                        User = db.SRUsers.FirstOrDefault(x=>x.Id == item) ,
                        Mailing = entity ,
                    });

                }
                db.Save();
                //model.Id = entity.Id.ToString();
            }
            catch (Exception)
            {




            }


        }
    }

}
