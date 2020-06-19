using SmartRestaurant.Application.Commun.Languages.Factory;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Languages.Commands.Create
{


    public interface ICreateLanguageCommand
    {
        void Execute(CreateLanguageModel model);
    }

    public class CreateLanguageCommand : ICreateLanguageCommand
    {
        private readonly ILoggerService<CreateLanguageCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ICreateLanguageFactory _factory;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateLanguageCommand(
            ISmartRestaurantDatabaseService db,
            ILoggerService<CreateLanguageCommand> logger,
            IMailingService mailing,
            INotifyService notify,
            ICreateLanguageFactory createLanguageFactory
            )
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
            _factory = createLanguageFactory;

        }
        public void Execute(CreateLanguageModel model)
        {

            try
            {
                var validator = new CreateLangaugeCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }
                var _currency = db.Languages.Where(c => c.Name == model.Name).FirstOrDefault();
                if (_currency != null)
                    throw new AlreadyExistsExeption($"Language: {model.Name} Exists");

                var entity = _factory.Create(model.Name, model.IsoCode, model.IsRTL, model.Alias, model.IsDisabled, model.EnglishName);
                entity.Id = Guid.NewGuid().ToString();
                db.Languages.Add(entity);
                db.Save();
            }
            catch
            {

            }


        }
    }

}
