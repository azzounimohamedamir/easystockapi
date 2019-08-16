using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Commun.Country.Commands.Update
{
    public class UpdateCountryCommand : IUpdateCountryCommand
    {





        private ISmartRestaurantDatabaseService _database;
        private INotifyService _notify;
        private IMailingService _mailing;
        private ILoggerService _log;

        public UpdateCountryCommand(
              ISmartRestaurantDatabaseService database,
              INotifyService notify,
              IMailingService mailing,
              ILoggerService log)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
            _notify = notify;
            _mailing = mailing;
            _log = log;
        }


        public void Execute(UpdateCountryModel model)
        {
            var country = _database.Countries.Find(model.Id);

            if (country == null)
            {
                throw new NotFoundException(nameof(Country) + model.Id);
            }

            country.IsoCode = model.IsoCode;
            country.Name = model.Name;
            country.Id = model.Id;
            country.Alias = model.Alias; 


            _database.Countries.Update(country);
            _database.Save();

        }
    }
}
