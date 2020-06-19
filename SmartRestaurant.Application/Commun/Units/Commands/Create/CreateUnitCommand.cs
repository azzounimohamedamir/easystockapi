using SmartRestaurant.Application.Commun.Units.Commands.Factory;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Units.Commands.Create
{
    public class CreateUnitCommand : ICreateUnitCommand
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly INotifyService _notify;
        private readonly IMailingService _mailing;
        private readonly ILoggerService<CreateUnitCommand> _log;
        private readonly ICreateUnitFactory _factory;

        public CreateUnitCommand(
            ISmartRestaurantDatabaseService db,
            INotifyService notify,
            IMailingService mailing,
            ILoggerService<CreateUnitCommand> log , 
            ICreateUnitFactory createUnitFactory 
            )
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _notify = notify;
            _mailing = mailing;
            _log = log;
            _factory = createUnitFactory; 
        }
        public void Execute(CreateUnitModel model)
        {
            try
            {
                var validator = new CreateUnitCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }
                var entity = _factory.Create(model.Name,model.Symbol,model.Alias,model.IsDisabled);
                entity.Id = Guid.NewGuid();                
                _db.Units.Add(entity);
                _db.Save();
            }
            catch(Exception e )
            {
                throw e; 

            } 



        }
           
            
        }








}











