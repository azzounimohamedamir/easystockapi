using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Application.Commun.Currencies.Commands.Delete
{


    public interface IDeleteCurrencyCommand
    {
        void Execute(DeleteCurrencyModel model);
    }

    public class DeleteCurrencyCommand : IDeleteCurrencyCommand
    {
        private readonly ILoggerService<DeleteCurrencyCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteCurrencyCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteCurrencyCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteCurrencyModel model)
        {

            try
            {
                var validator = new DeleteCurrencyCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var entity = db.Currencies.Find(model.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Currency.Name) + model.Id);
                }



                db.Currencies.Remove(entity);
                db.Save();

            }
            catch { }


        }
    }

}
