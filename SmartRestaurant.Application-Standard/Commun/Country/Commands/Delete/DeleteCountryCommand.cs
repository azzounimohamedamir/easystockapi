using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using System;

public class DeleteCountryCommand : IDeleteCountryCommand
{
    private ISmartRestaurantDatabaseService _database;
    private INotifyService _notify;
    private IMailingService _mailing;
    private ILoggerService _log;

    public DeleteCountryCommand(
          ISmartRestaurantDatabaseService database,
          INotifyService notify,
          IMailingService mailing,
          ILoggerService log)
    {
        _database = database ?? throw new ArgumentNullException(nameof(database));
        _notify = notify;
        _mailing = mailing;
        _log = log;
    }


    public void Execute(DeleteCountryModel model)
    {

        var country =_database.Countries.Find(model.Id);

        if (country == null)
        {
            throw new NotFoundException(nameof(Country)+model.Id);
        }

        _database.Countries.Remove(country);
        _database.Save(); 


    }
}
