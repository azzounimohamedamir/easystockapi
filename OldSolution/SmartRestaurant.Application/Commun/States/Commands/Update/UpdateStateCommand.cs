using FluentValidation.Results;
using SmartRestaurant.Application.Commun.States.Commands;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SmartRestaurant.Application.Commun.State.Commands.Create
{
    public class UpdateStateCommand : IUpdateStateCommand
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly INotifyService _notify;
        private readonly IMailingService _mailing;
        private readonly ILoggerService<UpdateStateCommand> _log;

        public UpdateStateCommand(
            ISmartRestaurantDatabaseService database,
            INotifyService notify,
            IMailingService mailing,
            ILoggerService<UpdateStateCommand> log)
        {
            _db = database ?? throw new ArgumentNullException(nameof(database));
            _notify = notify;
            _mailing = mailing;
            _log = log;
        }
        public void Execute(UpdateStateModel model)
        {

            try {


                var validator = new UpdateStateCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }
                var entity = _db.States.Find(model.Id);

                if (entity == null)
                {
                    throw new NotFoundException("State : " + model.Id);
                }

                entity.IsoCode = model.IsoCode;
                entity.Name = model.Name;
                entity.CountryId = model.CountryId;
                entity.Country = _db.Countries.FirstOrDefault(c => c.Id == model.CountryId);
                entity.Alias = model.Alias;
                entity.IsDisabled = model.IsDisabled;

                _db.States.Update(entity);
                _db.Save();
            }
            catch
            {

            }
          
        }
    }

    
}
