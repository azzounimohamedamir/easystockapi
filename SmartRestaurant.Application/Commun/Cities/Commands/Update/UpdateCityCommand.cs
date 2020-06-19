using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Cities.Commands.Update
{
    public class UpdateCityCommand : IUpdateCityCommand
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly INotifyService _notify;
        private readonly IMailingService _mailing;
        private readonly ILoggerService<UpdateCityCommand> _log;

        public UpdateCityCommand(
            ISmartRestaurantDatabaseService database,
            INotifyService notify,
            IMailingService mailing,
            ILoggerService<UpdateCityCommand> log)
        {
            _db = database ?? throw new ArgumentNullException(nameof(database));
            _notify = notify;
            _mailing = mailing;
            _log = log;
        }
        public void Execute(UpdateCityModel model)
        {
            try
            {

                var validator = new UpdateCityCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }

                var entity = _db.Cities.Find(model.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(City) + model.Id);
                }

                entity.IsoCode = model.IsoCode;
                entity.Name = model.Name;
                entity.StateId = model.StateId;
                entity.State = _db.States.FirstOrDefault(o => o.Id == model.StateId);
                entity.Alias = model.Alias;
                entity.IsDisabled = model.IsDisabled;

                _db.Cities.Update(entity);
                _db.Save();

            }
            catch
            {

            }


        }
    }
}
