using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Resources.Commun.Specialities;
using SmartRestaurant.Resources.SharedException;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Specialites.Commands.Delete
{
    public interface IDeleteSpecialityCommand
    {
        void Execute(DeleteSpecialityModel model);
    }
    public class DeleteSpecialityCommand : IDeleteSpecialityCommand
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly ILoggerService<DeleteSpecialityCommand> _logger;
        private readonly IMailingService _mailingService;
        private readonly INotifyService _notifyService;

        public DeleteSpecialityCommand(
            ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteSpecialityCommand> logger,
            IMailingService mailingService,
            INotifyService notifyService
            )
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailingService = mailingService ?? throw new ArgumentNullException(nameof(mailingService));
            _notifyService = notifyService ?? throw new ArgumentNullException(nameof(notifyService));
        }
        public void Execute(DeleteSpecialityModel model)
        {
            try
            {
                var validator = new DeleteSpecialityModelValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var _speciality = _db.Specialties
                    .FirstOrDefault(f => f.Id == model.Id.ToGuid());

                if (_speciality == null)
                    throw new NotFoundException(string.Format(SharedExceptionResource.NotFoundExceptionErrorMessage, SpecialityUtilsResource.TableName, model.Id));



                _db.Specialties.Remove(_speciality);
                _db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
