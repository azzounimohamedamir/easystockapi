using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
  
namespace SmartRestaurant.Application.Commun.Country.Commands.Create
{
    public class DeleteCityCommand : IDeleteCityCommand
    {
        private readonly ISmartRestaurantDatabaseService _database;
        private readonly INotifyService _notify;
        private readonly IMailingService _mailing;
        private readonly ILoggerService _log;

        public DeleteCityCommand(
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
        public void Execute(DeleteCityModel model)
        {


            var city = _database.Cities.Find(model.Id);

            if (city == null)
            {
                throw new NotFoundException(nameof(Country) + model.Id);
            }

            _database.Cities.Remove(city);
            _database.Save();




        }
    }
}
