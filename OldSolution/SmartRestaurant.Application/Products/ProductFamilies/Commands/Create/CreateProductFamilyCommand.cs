using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;

namespace SmartRestaurant.Application.Products.ProductFamilies.Commands.Create
{


    public interface ICreateProductFamilyCommand
    {
        void Execute(CreateProductFamilyModel model);
    }

    public class CreateProductFamilyCommand : ICreateProductFamilyCommand
    {
        private readonly ILoggerService<CreateProductFamilyCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateProductFamilyCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateProductFamilyCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateProductFamilyModel model)
        {
            try
            {
                var validator = new CreateProductFamilyCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var familty = model.ToEntity();
                familty.Id = Guid.NewGuid();

            
                db.ProductFamilies.Add(familty);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
