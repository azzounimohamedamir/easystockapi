using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Commun.Countries.Commands.Update;
using SmartRestaurant.Application.Interfaces;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Countries.Queries.GetCountryById
{


    public interface IGetCountryByIdQuerie
    {
        UpdateCountryModel Execute(string Id);
    }
    public class GetCountryByIdQuerie : IGetCountryByIdQuerie
    {
        private readonly ILoggerService<GetCountryByIdQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetCountryByIdQuerie(
            ISmartRestaurantDatabaseService db,
            ILoggerService<GetCountryByIdQuerie> logger,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateCountryModel Execute(string Id)
        {

            var entity = db.Countries
                .Where(p => p.Id == Id)
                .Include(c => c.Currencies)
                .Select(p => new UpdateCountryModel()
                {
                    Id = p.Id,
                    IsoCode = p.IsoCode,
                    Name = p.Name,
                    Alias = p.Alias,
                    CurrenciesId = p.Currencies.Select(c => c.CurrencyId.ToString()).ToList(),
                    IsDisabled = p.IsDisabled,
                }).FirstOrDefault();
            return entity;

        }
    }

}
