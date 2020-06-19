using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
namespace SmartRestaurant.Application.Commun.Currencies.Commands.Update
{


    public interface IUpdateCurrencyCommand
    {
        void Execute(UpdateCurrencyModel model);
    }

    public class UpdateCurrencyCommand : IUpdateCurrencyCommand
    {
        private readonly ILoggerService<UpdateCurrencyCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateCurrencyCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateCurrencyCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateCurrencyModel model)
        {


            try
            {


                var validator = new UpdateCurrencyCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }

                var entity = db.Currencies.Find(model.Id.ToGuid());

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Currency) + model.Id);
                }

                entity.IsoCode = model.IsoCode;
                entity.Name = model.Name;
                entity.Alias = model.Alias;
                entity.IsDisabled = model.IsDisabled;
                entity.Symbol = model.Symbol;
                db.Currencies.Update(entity);
                db.Save();



            }
            catch
            {
            }


        }
    }

}
