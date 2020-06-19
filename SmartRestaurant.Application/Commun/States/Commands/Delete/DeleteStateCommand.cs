using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Commun.State.Commands.Delete
{
    public class DeleteStateCommand : IDeleteStateCommand
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly INotifyService _notify;
        private readonly IMailingService _mailing;
        private readonly ILoggerService<DeleteStateCommand> _log;

        public DeleteStateCommand(
            ISmartRestaurantDatabaseService database,
            INotifyService notify,
            IMailingService mailing,
            ILoggerService<DeleteStateCommand> log)
        {
            _db = database ?? throw new ArgumentNullException(nameof(database));
            _notify = notify;
            _mailing = mailing;
            _log = log;
        }
        public void Execute(DeleteStateModel model)
        {

            try
            {

                var validator = new DeleteStateCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var entity = _db.States.Find(model.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(State) + model.Id);
                }


                var hasCities = _db.Cities.Any(o => o.StateId == entity.Id);
                if (hasCities)
                {
                    // TODO: Add functional test for this behaviour.
                    throw new DeleteFailureException("State : " + entity.Id + "There are existing cities associated with this state.");

                }

                _db.States.Remove(entity);
                _db.Save();



            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
