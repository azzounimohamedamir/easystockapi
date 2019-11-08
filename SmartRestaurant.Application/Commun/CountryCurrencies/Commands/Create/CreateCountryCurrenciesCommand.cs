using SmartRestaurant.Application.Commun.CountryCurrencies.Factory;
using SmartRestaurant.Application.Commun.CountryCurrencies.Queries;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Commun.CountryCurrencies.Commands.Create
{


    internal interface ICreateCountryCurrenciesCommand
    {
        void Execute(CountryCurrencyItem model);
    }

    public class CreateCountryCurrenciesCommand : ICreateCountryCurrenciesCommand
    {
        private readonly ILoggerService<CreateCountryCurrenciesCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ICreateCountryCurrenciesFactory _factory;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateCountryCurrenciesCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateCountryCurrenciesCommand> logger, IMailingService mailing,
            INotifyService notify,
            ICreateCountryCurrenciesFactory createCountryCurrenciesFactory  
            )
        {
            this.db = db;
            this.log = logger;
            this.mailing = mailing;
            this.notify = notify;
            _factory = createCountryCurrenciesFactory; 
        }
        public void Execute(CountryCurrencyItem model)
        {
            try
            {

                var validator = new CreateCountryCurrenciesCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }



                var entity = new CountryCurrency();
                entity = _factory.Create(model.CountryId, model.CurrencyId); 
                entity.Country = db.Countries.FirstOrDefault(p => p.Id == model.CountryId);
                entity.Currency = db.Currencies.FirstOrDefault(p => p.Id == model.CurrencyId);
                db.CountryCurrencies.Add(entity);
                //db.Save();

            }
            catch(Exception e )
            {


            }

        }
    }

}
