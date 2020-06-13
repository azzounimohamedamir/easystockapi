using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Commun.Prices;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Commun.Translates.Commands.Create;

namespace SmartRestaurant.Application.Commun.Translates.Commands.Update
{
    public interface IUpdateTranslateCommand
    {
        void Execute(UpdateTranslateModel model);
    }

    public class UpdateTranslateCommand : IUpdateTranslateCommand
    {
        private readonly ILoggerService<UpdateTranslateCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateTranslateCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateTranslateCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateTranslateModel model)
        {
            try
            {
                var validator = new UpdateTranslateCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var guid = model.Id.ToGuid();
                var Translate = db.Translates                    
                    .FirstOrDefault(f => f.Id == guid);
                if (Translate == null) throw new NotFoundException();


                model.ToEntity(ref Translate);


                if (!db.Languages.Any(x => x.Id == Translate.LanguageId))
                    throw new NotFoundException(nameof(Language) +
                        Translate.LanguageId);

            
                db.Translates.Update(Translate);
                db.Save();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

}
