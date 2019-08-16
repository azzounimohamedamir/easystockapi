using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
  
namespace SmartRestaurant.Application.Commun.Country.Commands.Create
{
    public class UpdateStateCommand : IUpdateStateCommand
    {
        private readonly ISmartRestaurantDatabaseService _database;
        private readonly INotifyService _notify;
        private readonly IMailingService _mailing;
        private readonly ILoggerService _log;

        public UpdateStateCommand(
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
        public void Execute(UpdateStateModel model)
        {


            var state = _database.States.Find(model.Id);

            if (state == null)
            {
                throw new NotFoundException(nameof(Country) + model.Id);
            }

            state.IsoCode = model.IsoCode;
               state.Name = model.Name;
            state.CountryId = model.CountryId;
            state.Country = _database.Countries.FirstOrDefault(c => c.Id == model.CountryId); 



            _database.States.Update(state);
            _database.Save(); 
        }
    }
}
