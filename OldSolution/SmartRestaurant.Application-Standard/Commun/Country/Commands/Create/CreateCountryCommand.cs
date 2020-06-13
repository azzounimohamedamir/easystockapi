using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
  
namespace SmartRestaurant.Application.Commun.Country.Commands.Create
{
    public class CreateCountryCommand : ICreateCountryCommand
    {
        private readonly ISmartRestaurantDatabaseService _database;
        private readonly INotifyService _notify;
        private readonly IMailingService _mailing;
        private readonly ILoggerService _log;
        private readonly IAutorisation _authorisation;

        public CreateCountryCommand(
            ISmartRestaurantDatabaseService database,
            INotifyService notify,
            IMailingService mailing,
            ILoggerService log,
            IAutorisation authorisation)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
            _notify = notify;
            _mailing = mailing;
            _log = log;
            _authorisation = authorisation;
        }
        public void Execute(CreateCountryModel model)
        {
            try
            {
                //if (!_authorisation.IsAuthorised("", "", ""))
                //{

                //}
                var validator = new CreateCountryCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var _country = _database.Countries.Where(c => c.Name == model.Name).FirstOrDefault();
                if (_country != null) throw new AlreadyExistsExeption("");

                var entity = new SmartRestaurant.Domain.Commun.Country(){
                    Alias = model.Alias ,
                    Name = model.Name , 
                    IsoCode = model.IsoCode ,                    
                };


                _database.Countries.Add(entity);
                _database.Save() ; 
            }
            catch
            {

            }
            
        }
    }
}
