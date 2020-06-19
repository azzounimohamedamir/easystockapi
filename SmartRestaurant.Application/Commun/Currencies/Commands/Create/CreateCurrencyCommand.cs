using SmartRestaurant.Application.Commun.Currencies.Commands.Factory;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Currencies.Commands.Create
{


    public interface ICreateCurrencyCommand
    {
        void Execute(CreateCurrencyModel model);
    }

    public class CreateCurrencyCommand : ICreateCurrencyCommand
    {
        private readonly ILoggerService<CreateCurrencyCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ICreateCurrencyFactory _factory;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateCurrencyCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateCurrencyCommand> logger, IMailingService mailing,
            INotifyService notify,
            ICreateCurrencyFactory createCurrencyFactory
            )
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
            _factory = createCurrencyFactory;
        }
        public void Execute(CreateCurrencyModel model)
        {

            try
            {

                var validator = new CreateCurrencyCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }
                var _currency = db.Currencies.Where(c => c.Name == model.Name).FirstOrDefault();
                if (_currency != null)
                    throw new AlreadyExistsExeption($"Currency: {model.Name} Exists");

                var entity = _factory.Create(model.Name, model.IsoCode, model.Alias, model.IsDisabled);
                entity.Id = Guid.NewGuid();
                db.Currencies.Add(entity);
                db.Save();
            }
            catch (Exception)
            {

            }


        }
    }

}
