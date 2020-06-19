using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Countries.Queries.GetCountriesList
{


    public interface IGetAllCountriesQuerie
    {
        List<CountryItemModel> Execute();
    }

    public class GetAllCountriesQuerie : IGetAllCountriesQuerie
    {
        private readonly ILoggerService<GetAllCountriesQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllCountriesQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllCountriesQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public List<CountryItemModel> Execute()
        {


            var entity = db.Countries

                .Select(p => new CountryItemModel()
                {
                    Id = p.Id,
                    IsoCode = p.IsoCode,
                    Name = p.Name,
                    Alias = p.Alias,
                    IsDisabled = p.IsDisabled.DisabledDisplay(),
                });
            return entity.ToList();
        }
    }

}
