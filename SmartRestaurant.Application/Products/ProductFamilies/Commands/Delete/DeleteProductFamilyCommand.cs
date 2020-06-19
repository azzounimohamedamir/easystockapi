using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Products;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Products.ProductFamilies.Commands.Delete
{


    public interface IDeleteProductFamilyCommand
    {
        void Execute(DeleteProductFamilyModel model);
    }

    public class DeleteProductFamilyCommand : IDeleteProductFamilyCommand
    {
        private readonly ILoggerService<DeleteProductFamilyCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteProductFamilyCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteProductFamilyCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteProductFamilyModel model)
        {
            try
            {
                var validator = new DeleteProductFamilyCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var guid = model.Id.ToGuid();
                var family = db.ProductFamilies.Include(c => c.Products)
                      .FirstOrDefault(f => f.Id == guid);

                if (family == null)
                    throw new NotFoundException();

                if (family.Products.Any())
                    throw new DeleteFailureException(nameof(ProductFamily));

                db.ProductFamilies.Remove(family);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }

}
