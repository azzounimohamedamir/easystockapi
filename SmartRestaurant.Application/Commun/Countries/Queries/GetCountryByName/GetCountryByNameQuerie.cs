using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Countries.Queries.GetCountryByName
{


    public interface IGetCountryByNameQuery
    {
        CountryItemModel Execute(string Id);
    }
    public class GetCountryByNameQuery : IGetCountryByNameQuery
    {
        private readonly ILoggerService<GetCountryByNameQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetCountryByNameQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetCountryByNameQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public CountryItemModel Execute(string Name)
        {


            var entity = db.Countries
           .Where(p => p.Name == Name)
               .Select(p => new CountryItemModel()
               {
                   Id = p.Id,
                   IsoCode = p.IsoCode,
                   Name = p.Name,
                   Alias = p.Alias,
                   IsDisabled = p.IsDisabled.DisabledDisplay(),

               }).FirstOrDefault();
            return entity;


        }
    }

}
