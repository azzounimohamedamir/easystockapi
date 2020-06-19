using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Mails.Commands.Update
{


    public interface IUpdateMailingCommand
    {
        void Execute(UpdateMailingModel model);
    }

    public class UpdateMailCommand : IUpdateMailingCommand
    {
        private readonly ILoggerService<UpdateMailCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateMailCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateMailCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateMailingModel model)
        {
            try
            {

                var validator = new UpdateMailCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }

                var entity = db.Mailings.Include(x => x.Users).FirstOrDefault(x => x.Id == model.Id.ToGuid());

                if (entity.ToString().IsNullOrEmpty())
                {
                    throw new NotFoundException(nameof(mailing) + model.Id);
                }

                entity.TableName = model.TableName;
                entity.Action = model.Action;
                entity.Name = model.Name;
                entity.Alias = model.Alias;
                entity.IsDisabled = model.IsDisabled;
                entity.Type = model.Type;
                entity.TemplateId = model.TemplateId;
                entity.Template = db.Templates.FirstOrDefault(p => p.Id.ToString() == model.TemplateId);

                //in db
                HashSet<string> idsDB = new HashSet<string>(entity.Users.Select(i => i.UserId.ToString()));
                //if not null 
                HashSet<string> idsMODEL = new HashSet<string>(model.UsersId);

                foreach (string s in idsDB)
                {
                    if (!idsMODEL.Contains(s))
                    {
                        //Delete
                        var item = entity.Users.FirstOrDefault(i => i.UserId == s);
                        entity.Users.Remove(item);
                    }
                }
                foreach (string s in idsMODEL)
                {
                    //Add
                    if (!idsDB.Contains(s))
                    {
                        entity.Users.Add(
                            new MailingUser
                            {

                                UserId = s,
                            }
                            );
                    }

                }




                db.Mailings.Update(entity);
                db.Save();

            }
            catch (Exception e)
            {
                throw e;
            }


        }
    }

}
