using SmartRestaurant.Application.Commun.Specialites.Commands.Factory;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;

namespace SmartRestaurant.Application.Commun.Specialites.Commands.Create
{
    public interface ICreateSpecialityCommand
    {
        void Execute(CreateSpecialityModel model);
    }
    public class CreateSpecialityCommand : ICreateSpecialityCommand
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly ILoggerService<CreateSpecialityCommand> _logger;
        private readonly IMailingService _mailingService;
        private readonly INotifyService _notifyService;
        private readonly ICreateSpecialityFactory _factory;

        public CreateSpecialityCommand(
            ISmartRestaurantDatabaseService db,
            ILoggerService<CreateSpecialityCommand> logger,
            IMailingService mailingService,
            INotifyService notifyService,
            ICreateSpecialityFactory createSpecialityFactory
            )
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailingService = mailingService ?? throw new ArgumentNullException(nameof(mailingService));
            _notifyService = notifyService ?? throw new ArgumentNullException(nameof(notifyService));
            _factory = createSpecialityFactory ?? throw new ArgumentNullException(nameof(createSpecialityFactory));
        }

        public void Execute(CreateSpecialityModel model)
        {
            try
            {
                var validator = new CreateSpecialityModelValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var speciality = _factory.Create(
                    model.Name,
                    model.Alias,
                    model.Description,
                    model.IsDisabled);

                _db.Specialties.Add(speciality);
                _db.Save();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
