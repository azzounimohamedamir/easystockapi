using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
  
namespace SmartRestaurant.Application.Commun.Country.Commands.Create
{
    public class CreateStateCommand : ICreateStateCommand
    {
        private readonly ISmartRestaurantDatabaseService _database;
        private readonly INotifyService _notify;
        private readonly IMailingService _mailing;
        private readonly ILoggerService _log;

        public CreateStateCommand(
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
        public void Execute(CreateStateModel model)
        {
            try
            {
          //       var _country = _database.City.Where(c => c.Name == model.Name).FirstOrDefault();
            //    if (_country != null) throw new AlreadyExistsExeption("");

                var stateDto = new SmartRestaurant.Domain.Commun.State(){
                    Name = model.Name , 
                    IsoCode = model.IsoCode ,
                    Id = model.Id , 
                    CountryId = model.CountryId , 
                    Country =  _database.Countries.FirstOrDefault(c=>c.Id == model.CountryId)
                    
                };


                _database.States.Add(stateDto);
                _database.Save() ; 
            }
            catch
            {

            }
            
        }
    }
}
