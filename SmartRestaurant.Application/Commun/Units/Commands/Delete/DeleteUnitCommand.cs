using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain;
using System;

namespace SmartRestaurant.Application.Commun.Units.Commands.Delete
{
    public class DeleteUnitCommand : IDeleteUnitCommand
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly INotifyService _notify;
        private readonly IMailingService _mailing;
        private readonly ILoggerService<DeleteUnitCommand> _log;

        public DeleteUnitCommand(
            ISmartRestaurantDatabaseService db,
            INotifyService notify,
            IMailingService mailing,
            ILoggerService<DeleteUnitCommand> log)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _notify = notify;
            _mailing = mailing;
            _log = log;
        }
        public void Execute(DeleteUnitModel model)
        {
            try
            {
                var validator = new DeleteUnitCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var entity = _db.Units.Find(model.Id.ToGuid());

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Template) + model.Id);
                }


                _db.Units.Remove(entity);
                _db.Save();



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
