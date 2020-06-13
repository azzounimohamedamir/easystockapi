using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers; 
namespace SmartRestaurant.Application.Mails.Commands.Delete
{


    public interface IDeleteMailingCommand
    {
        void Execute(DeleteMailingModel model);
    }

    public class DeleteMailingCommand : IDeleteMailingCommand
    {
        private readonly ILoggerService<DeleteMailingCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteMailingCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteMailingCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteMailingModel model)
        {
            try
            {

                   var validator = new DeleteMailingCommandValidation();
                    var result = validator.Validate(model);
                    if (!result.IsValid)
                    {
                        throw new NotValidException(result.Errors);
                    }


                    var entity = db.Mailings.Find(model.Id.ToGuid());

                    if (string.IsNullOrEmpty(entity.ToString()))
                    {
                        throw new NotFoundException(nameof(mailing) + model.Id);
                    }



                    db.Mailings.Remove(entity);
                    db.Save();



                }
                catch (Exception e)
                {
                    throw e;
                }
            }
    

    }
}
