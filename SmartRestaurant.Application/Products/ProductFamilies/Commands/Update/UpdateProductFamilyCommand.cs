using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Products.ProductFamilies.Commands.Create;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Products.ProductFamilies.Commands.Update
{


    public interface IUpdateProductFamilyCommand
    {
        void Execute(UpdateProductFamilyModel model);
    }

    public class UpdateProductFamilyCommand : IUpdateProductFamilyCommand
    {
        private readonly ILoggerService<UpdateProductFamilyCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateProductFamilyCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateProductFamilyCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateProductFamilyModel model)
        {
            try
            {
                var validator = new UpdateProductFamilyCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var guid = model.Id.ToGuid();
                var family = db.ProductFamilies
                      .FirstOrDefault(f => f.Id == guid);

                if (family == null)
                    throw new NotFoundException();

                model.ToEntity(ref family);

                db.ProductFamilies.Update(family);
                db.Save();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
