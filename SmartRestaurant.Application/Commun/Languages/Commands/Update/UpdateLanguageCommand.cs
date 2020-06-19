using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;

namespace SmartRestaurant.Application.Commun.Languages.Commands.Update
{


    public interface IUpdateLanguageCommand
    {
        void Execute(UpdateLanguageModel model);
    }

    public class UpdateLanguageCommand : IUpdateLanguageCommand
    {
        private readonly ILoggerService<UpdateLanguageCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateLanguageCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateLanguageCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateLanguageModel model)
        {
            try
            {
                var validator = new UpdateLanguageCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }

                var entity = db.Languages.Find(model.Id);

                if (entity == null)
                {
                    throw new NotFoundException("Languages" + model.Id);
                }

                entity.IsoCode = model.IsoCode;
                entity.Name = model.Name;
                entity.Alias = model.Alias;
                entity.IsDisabled = model.IsDisabled;
                entity.EnglishName = model.EnglishName;


                db.Languages.Update(entity);
                db.Save();
            }
            catch
            {

            }
        }
    }
}


