using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
  
namespace SmartRestaurant.Application.Commun.Country.Commands.Create
{
    public class CreateCityCommand : ICreateCityCommand
    {
        private readonly ISmartRestaurantDatabaseService _database;
        private readonly INotifyService _notify;
        private readonly IMailingService _mailing;
        private readonly ILoggerService _log;

        public CreateCityCommand(
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
        public void Execute(CreateCityModel model)
        {
            try
            {
              
                var entity = new SmartRestaurant.Domain.Commun.City() {
                    Id = Guid.NewGuid().ToString() ,
                    Name = model.Name , 
                    IsoCode = model.IsoCode , 
                    
                };

                _database.Cities.Add(entity);
                _database.Save() ; 
            }
            catch
            {
                
            }
            
        }
    }
}
