using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;
using SmartRestaurant.Domain.Pricings;
using SmartRestaurant.Application.Pricings.Tarifications.Commands.Create;

namespace SmartRestaurant.Application.Pricings.Tarifications.Commands.Update
{


    public interface IUpdateTarificationCommand
    {
        void Execute(UpdateTarificationModel model);
    }

    public class UpdateTarificationCommand : IUpdateTarificationCommand
    {
        private readonly ILoggerService<UpdateTarificationCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateTarificationCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateTarificationCommand> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateTarificationModel model)
        {
            try
            {
                var validator = new UpdateTarificationCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }


                var id = model.Id.ToGuid();
                var tarification = db.Tarifications.FirstOrDefault(x => x.Id == id);
                if (tarification == null)
                {
                    throw new NotFoundException(nameof(tarification) + model.Id);
                }

                var named = db.Tarifications
                    .FirstOrDefault(f => f.Name == model.Name && f.Id != id);

                if (named != null)
                    throw new AlreadyExistsExeption($"{ nameof(Tarification)}:{model.Name}");


                model.ToEntity(ref tarification);

                var products = db.ProductTarifications
                  .Where(s => s.TarificationId == model.Id.ToGuid());
                var dishes = db.DishTarifications
                  .Where(s => s.TarificationId == model.Id.ToGuid());

                // Exist in Db but not selected in UI
                foreach (var dbItem in products)
                {
                    if (!model.ProductsIds.Any(x => x.ToLower() ==
                    dbItem.ProductId.ToString().ToLower()))
                    {
                        tarification.ProductTarifications.Remove(dbItem);
                    }
                }
                // Does not exist in Db but selected in UI
                foreach (var UiId in model.ProductsIds)
                {
                    if (!products.Any(x => x.ProductId.ToString().ToLower() == UiId.ToLower()))
                    {
                        tarification.ProductTarifications.Add(new ProductTarification
                        {
                            ProductId = UiId.ToGuid()
                        });
                    }
                }

                // Exist in Db but not selected in UI
                foreach (var dbItem in dishes)
                {
                    if (!model.DishesIds.Any(x => x.ToLower() ==
                    dbItem.DishId.ToString().ToLower()))
                    {
                        tarification.DishTarifications.Remove(dbItem);
                    }
                }
                // Does not exist in Db but selected in UI
                foreach (var UiId in model.DishesIds)
                {
                    if (!dishes.Any(x => x.DishId.ToString().ToLower() == UiId.ToLower()))
                    {
                        tarification.DishTarifications.Add(new DishTarification
                        {
                            DishId = UiId.ToGuid()
                        });
                    }
                }

                db.Tarifications.Update(tarification);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
