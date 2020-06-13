using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Translates.Commands.Delete
{


    public interface IDeleteTranslateCommand
    {
        void Execute(DeleteTranslateModel model);
    }

    public class DeleteTranslateCommand : IDeleteTranslateCommand
    {
        private readonly ILoggerService<DeleteTranslateCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteTranslateCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteTranslateCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteTranslateModel model)
        {
            try
            {
                var validator = new DeleteTranslateCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var guid = model.Id.ToGuid();
                var Translate = db.Translates.FirstOrDefault(f => f.Id == guid);
                if (Translate == null) throw new NotFoundException();


                db.Translates.Remove(Translate);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
