using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Pricings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;

namespace SmartRestaurant.Application.Pricings.Tarifications.Commands.Create
{


    public interface ICreateTarificationCommand
    {
        void Execute(CreateTarificationModel model);
    }

    public class CreateTarificationCommand : ICreateTarificationCommand
    {
        private readonly ILoggerService<CreateTarificationCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateTarificationCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateTarificationCommand> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateTarificationModel model)
        {
            try
            {
                var validator = new CreateTarificationCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var named = db.Tarifications.FirstOrDefault(x => x.Name == model.Name);
                if (named != null)
                    throw new AlreadyExistsExeption(nameof(Tarification) + ":" + model.Name);


                var tarification = model.ToEntity();

                 
                foreach (var id in model.DishesIds)
                {
                    tarification.DishTarifications.Add(new DishTarification
                    {
                        DishId = id.ToGuid()
                    });
                }
                foreach (var id in model.ProductsIds)
                {
                    tarification.ProductTarifications.Add(new ProductTarification
                    {
                        ProductId = id.ToGuid()
                    });
                }

                db.Tarifications.Add(tarification);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
