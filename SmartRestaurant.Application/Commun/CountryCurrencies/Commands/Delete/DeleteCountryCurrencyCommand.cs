using SmartRestaurant.Application.Commun.CountryCurrencies.Queries;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using System;

namespace SmartRestaurant.Application.Commun.CountryCurrencies.Commands.Delete
{


    public interface IDeleteCountryCurrencyCommand
    {
        void Execute(CountryCurrencyItem model);
    }

    public class DeleteCountryCurrencyCommand : IDeleteCountryCurrencyCommand
    {
        private readonly ILoggerService<DeleteCountryCurrencyCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteCountryCurrencyCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteCountryCurrencyCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CountryCurrencyItem model)
        {
            try
            {
                var validator = new DeleteCountryCurrencyCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var entity = db.CountryCurrencies.Find(model.CountryId);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(CountryCurrency));
                }




                db.CountryCurrencies.Remove(entity);
                db.Save();


            }
            catch (Exception)
            {

            }


        }
    }

}
