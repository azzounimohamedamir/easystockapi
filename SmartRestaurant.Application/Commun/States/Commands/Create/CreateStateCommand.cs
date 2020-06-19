using SmartRestaurant.Application.Commun.Countries.Commands.Create;
using SmartRestaurant.Application.Commun.States.Commands.Create;
using SmartRestaurant.Application.Commun.States.Factory;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Commun.State.Commands.Create
{
    public class CreateStateCommand : ICreateStateCommand
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly INotifyService _notify;
        private readonly IMailingService _mailing;
        private readonly ILoggerService<CreateStateCommand> _log;
        private readonly ICreateStateFactory _factory;

        public CreateStateCommand(
            ISmartRestaurantDatabaseService database,
            INotifyService notify,
            IMailingService mailing,
            ILoggerService<CreateStateCommand> log,
            ICreateStateFactory createStateFactory)
        {
            _db = database ?? throw new ArgumentNullException(nameof(database));
            _notify = notify;
            _mailing = mailing;
            _log = log;
            _factory = createStateFactory;


        }
        public void Execute(CreateStateModel model)
        {
            try
            {
                var validator = new CreateStateCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }

                var entity = _factory.Create(model.Name, model.IsoCode, model.CountryId, model.Alias, model.IsDisabled);
                entity.Id = Guid.NewGuid().ToString();
                entity.Country = _db.Countries.FirstOrDefault(c => c.Id == model.CountryId);




                _db.States.Add(entity);
                _db.Save();

            }
            catch (Exception)
            {




            }

        }

    }
}

