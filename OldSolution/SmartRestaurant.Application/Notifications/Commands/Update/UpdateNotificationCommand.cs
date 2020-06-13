using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using Microsoft.EntityFrameworkCore;

namespace SmartRestaurant.Application.Notifications.Commands.Update
{


    public interface IUpdateNotificationCommand
    {
        void Execute(UpdateNotificationModel model);
    }

    public class UpdateNotificationCommand : IUpdateNotificationCommand
    {
        private readonly ILoggerService<UpdateNotificationCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateNotificationCommand(
            ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateNotificationCommand> logger, 
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateNotificationModel model)
        {
            try
            {

                var validator = new UpdateNotificationCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }

                var entity = db.Notifications.Include(x=>x.Users).FirstOrDefault(x=>x.Id==model.Id.ToGuid());

                if (entity.ToString().IsNullOrEmpty())
                {
                    throw new NotFoundException(nameof(Notification) + model.Id);
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
                            new NotificationUser
                            {

                                UserId = s,
                            }
                            );
                    }

                }

                db.Notifications.Update(entity);
                db.Save();

            }
            catch(Exception e )
            {
                throw e;
            }


        }
    }

}
