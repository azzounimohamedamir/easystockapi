using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain;
using System;

namespace SmartRestaurant.Application.Commun.City.Commands.Delete
{
    public class DeleteCityCommand : IDeleteCityCommand
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly INotifyService _notify;
        private readonly IMailingService _mailing;
        private readonly ILoggerService<DeleteCityCommand> _log;

        public DeleteCityCommand(
            ISmartRestaurantDatabaseService db,
            INotifyService notify,
            IMailingService mailing,
            ILoggerService<DeleteCityCommand> log)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _notify = notify;
            _mailing = mailing;
            _log = log;
        }
        public void Execute(DeleteCityModel model)
        {
            try
            {
                var validator = new DeleteCityCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }


                var entity = _db.Cities.Find(model.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Template) + model.Id);
                }


                _db.Cities.Remove(entity);
                _db.Save();



            }
            catch
            {

            }





        }
    }
}
