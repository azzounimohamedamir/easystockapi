using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Resources.Utils;
using System;
using System.Linq;


public class DeleteCountryCommand : IDeleteCountryCommand
{
    private ISmartRestaurantDatabaseService _db;
    private INotifyService _notify;
    private IMailingService _mailing;
    private ILoggerService<DeleteCountryCommand> _log;

    public DeleteCountryCommand(
          ISmartRestaurantDatabaseService db,
          INotifyService notify,
          IMailingService mailing,
          ILoggerService<DeleteCountryCommand> log)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
        _notify = notify;
        _mailing = mailing;
        _log = log;
    }


    public void Execute(DeleteCountryModel model)
    {
        try
        {
            var validator = new DeleteCountryCommandValidation();
            var result = validator.Validate(model);
            if (!result.IsValid)
            {
                throw new NotValidException(result.Errors);
            }

            var entity = _db.Countries.Find(model.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Country) + model.Id);
            }

            var hasState = _db.States.Any(o => o.Country.Id == entity.Id);
            var hasCurrency = _db.CountryCurrencies.Any(o => o.CountryId == entity.Id);

            if (hasState || hasCurrency)
            {
                // TODO: Add functional Exception for this behaviour.
                //TODO: Send Notification to Alert User from Deleting this record 

                //throw new DeleteFailureException(nameof(Country) + model.Id + "There are existing counntry associated with this customer.");
                throw new NestedDeleteException(string.Format(
                        UtilsResource.NestedDeleteExceptionErrorMessage,
                        entity.Name));


            }


            _db.Countries.Remove(entity);
            _db.Save();


        }
        catch (Exception ex)
        {
            throw ex; 
        }
        

    }
}
