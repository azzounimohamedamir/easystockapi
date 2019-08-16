using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;

namespace SmartRestaurant.Application.Products.Products.Commands.Delete
{


    public interface IDeleteProductCommand
    {
        void Execute(DeleteProductModel model);
    }

    public class DeleteProductCommand : IDeleteProductCommand
    {
        private readonly ILoggerService<DeleteProductCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteProductCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteProductCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteProductModel model)
        {
            try
            {
                var validator = new DeleteProductCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var guid = model.Id.ToGuid();
                var product = db.Products.FirstOrDefault(f => f.Id == guid);
                if (product == null) throw new NotFoundException();


                db.Products.Remove(product);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
