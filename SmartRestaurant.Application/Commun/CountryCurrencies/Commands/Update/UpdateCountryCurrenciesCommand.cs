using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Commun.CountryCurrencies.Commands.Update
{


    public interface IUpdateCountryCurrenciesCommand
    {
        void Execute(UpdateCountryCurrenciesModel model);
    }

    public class UpdateCountryCurrenciesCommand : IUpdateCountryCurrenciesCommand
    {
        private readonly ILoggerService<UpdateCountryCurrenciesModel> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateCountryCurrenciesCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateCountryCurrenciesModel> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateCountryCurrenciesModel model)
        {
            try
            {

                var validator = new UpdateCountryCurrenciesCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }
                var entity = new CountryCurrency();

                var _country = db.Countries.Where(c => c.Id == model.CountryId).FirstOrDefault();
                if (_country != null)
                    throw new AlreadyExistsExeption($"Country: {model.CountryId} Exists");

                var _currecny = db.Currencies.Where(c => c.Id == model.CurrencyId).FirstOrDefault();
                if (_currecny != null)
                    throw new AlreadyExistsExeption($"Currency: {model.CurrencyId} Exists");

                //var entity = _factory.Create(model.CountryId, model.CurrencyId);

                entity.Currency = db.Currencies.FirstOrDefault(c => c.Id == model.CurrencyId);
                entity.Country = db.Countries.FirstOrDefault(c => c.Id == model.CountryId);



                db.CountryCurrencies.Add(entity);
                db.Save();

            }
            catch (Exception)
            {


            }

        }
    }

}
