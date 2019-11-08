using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;

namespace SmartRestaurant.Application.Commun.Units.Commands.Update
{
    public class UpdateUnitCommand : IUpdateUnitCommand
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly INotifyService _notify;
        private readonly IMailingService _mailing;
        private readonly ILoggerService<UpdateUnitCommand> _log;

        public UpdateUnitCommand(
            ISmartRestaurantDatabaseService database,
            INotifyService notify,
            IMailingService mailing,
            ILoggerService<UpdateUnitCommand> log)
        {
            _db = database ?? throw new ArgumentNullException(nameof(database));
            _notify = notify;
            _mailing = mailing;
            _log = log;
        }
        public void Execute(UpdateUnitModel model)
        {
            try {

                var validator = new UpdateUnitCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var entity = _db.Units.Find(model.Id.ToGuid());

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Unit) + model.Id);
                }

                entity.Symbol = model.Symbol;
                entity.Name = model.Name;                
                entity.Alias = model.Alias;
                entity.IsDisabled = model.IsDisabled;
                _db.Units.Update(entity);
                _db.Save();

            }
            catch(Exception ex)
            {
                throw ex;
            }

             
        }
    }
}
