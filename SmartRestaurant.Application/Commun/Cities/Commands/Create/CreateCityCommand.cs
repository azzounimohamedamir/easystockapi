
using SmartRestaurant.Application.Commun.Cities.Commands.Factory;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Cities.Commands
{





    public class CreateCityCommand : ICreateCityCommand
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly INotifyService _notify;
        private readonly IMailingService _mailing;
        private readonly ILoggerService<CreateCityCommand> _log;
        private readonly ICreateCityFactory _factory;

        public CreateCityCommand(
            ISmartRestaurantDatabaseService db,
            INotifyService notify,
            IMailingService mailing,
            ILoggerService<CreateCityCommand> log,
            ICreateCityFactory createCityFactory
            )
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _notify = notify;
            _mailing = mailing;
            _log = log;
            _factory = createCityFactory;
        }
        public void Execute(CreateCityModel model)
        {


            try
            {



                var validator = new CreateCityCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }
                var entity = _factory.Create(model.Name, model.IsoCode, model.StateId, model.Alias, model.IsDisabled);
                entity.Id = Guid.NewGuid().ToString();
                entity.State = _db.States.FirstOrDefault(c => c.Id == model.StateId);
                _db.Cities.Add(entity);
                _db.Save();
            }
            catch (Exception e)
            {
                throw e;

            }



        }


    }








}











