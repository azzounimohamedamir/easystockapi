using Helpers;
using SmartRestaurant.Application.Commun.Specialites.Commands.Factory;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Resources.Commun.Specialities;
using SmartRestaurant.Resources.SharedException;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Specialites.Commands.Update
{
    public interface IUpdateSpecialityCommand
    {
        void Execute(UpdateSpecialityModel model);
    }
    public class UpdateSpecialityCommand : IUpdateSpecialityCommand
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly ILoggerService<UpdateSpecialityCommand> _logger;
        private readonly IMailingService _mailingService;
        private readonly INotifyService _notifyService;
        private readonly IUpdateSpecialityFactory _factory;

        public UpdateSpecialityCommand(
            ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateSpecialityCommand> logger,
            IMailingService mailingService,
            INotifyService notifyService,
            IUpdateSpecialityFactory factory
            )
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailingService = mailingService ?? throw new ArgumentNullException(nameof(mailingService));
            _notifyService = notifyService ?? throw new ArgumentNullException(nameof(notifyService));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        public void Execute(UpdateSpecialityModel model)
        {
            try
            {
                var validator = new UpdateSpecialityModelValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var _speciality = _db.Specialties
                    .FirstOrDefault(f => f.Id == model.Id.ToGuid());

                if (_speciality == null)
                    throw new NotFoundException(string.Format(SharedExceptionResource.NotFoundExceptionErrorMessage, SpecialityUtilsResource.TableName, model.Id));

                _speciality = _factory.Create(_speciality,
                    model.Name,
                    model.Alias,
                    model.Description,
                    model.IsDisabled);

                _db.Specialties.Update(_speciality);
                _db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
