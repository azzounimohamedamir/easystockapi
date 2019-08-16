using FluentValidation.Resources;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Commun.Languages.Commands.Delete
{



    public interface IDeleteLanguageCommand
    {
        void Execute(DeleteLanguageModel model);
    }

    public class DeleteLanguageCommand : IDeleteLanguageCommand
    {
        private readonly ILoggerService<DeleteLanguageCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteLanguageCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteLanguageCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteLanguageModel model)
        {
            try
            {
                var entity = db.Languages.Find(model.Id);

                if (entity == null)
                {
                    throw new NotFoundException("name" + model.Id);
                }



                db.Languages.Remove(entity);
                db.Save();

            }
            catch { }



        }
    }

}
