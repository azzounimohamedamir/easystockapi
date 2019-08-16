using SmartRestaurant.Application.Commun.Countries.Factory;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;

namespace SmartRestaurant.Application.Commun.Countries.Commands.Create
{
    public class CreateCountryCommand : ICreateCountryCommand
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly INotifyService _notify;
        private readonly IMailingService _mailing;
        private readonly ILoggerService<CreateCountryCommand> _log;
        private readonly ICreateCountryFactory _factory;

        public CreateCountryCommand(
            ISmartRestaurantDatabaseService database,
            INotifyService notify,
            IMailingService mailing,
            ILoggerService<CreateCountryCommand> log , 
            ICreateCountryFactory createCountryFactory 
            )
        {
            _db = database ?? throw new ArgumentNullException(nameof(database));
            _notify = notify;
            _mailing = mailing;
            _log = log;
            _factory = createCountryFactory; 
        }
        public void Execute(CreateCountryModel model)
        {
            try
            {

                var validator = new CreateCountryCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }

                var _country = _db.Countries.Where(c => c.Name == model.Name).FirstOrDefault();
                if (_country != null)
                {
                    //_mailing.SendAsync("Countries", "UserId", "Create","AlredyExists");
                    throw new AlreadyExistsExeption($"Country: {model.Name} Exists");
                }                   


                var entity = _factory.Create(model.Alias, model.IsoCode, model.Name , model.IsDisabled);
                entity.Id = Guid.NewGuid().ToString();  
                if(model.CurrenciesId != null) { 
                foreach (var item in model.CurrenciesId)
                {
                    entity.Currencies.Add( new CountryCurrency
                    {
                        CountryId = entity.Id,
                        CurrencyId = item.ToGuid()
                    });                    
                }
                }
                _db.Countries.Add(entity);
                
               // var dbCurrencies = _db.CountryCurrencies.Where(x => x.CountryId == model.cou)

               _db.Save();
            }
            catch(Exception e )
            {
                //mail
               // _mailing.SendAsync(EnumAction.Insert, nameof(Countries));
               
            }

        
        }
    }
}
