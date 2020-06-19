using SmartRestaurant.Application.Interfaces;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Languages.Queries.GetLanguageByName
{


    public interface IGetLanguageByNameQuerie
    {
        GetLanguageByNameModel Execute(string Id);
    }
    public class GetLanguageByNameQuerie : IGetLanguageByNameQuerie
    {
        private readonly ILoggerService<GetLanguageByNameQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetLanguageByNameQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetLanguageByNameQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public GetLanguageByNameModel Execute(string Name)
        {
            var entity = db.Languages
                .Where(p => p.Name.ToString() == Name)
                .Select(p => new GetLanguageByNameModel()
                {

                    Name = p.Name,
                    IsoCode = p.IsoCode,
                    Alias = p.Alias,
                    Id = p.Id,
                    IsRTL = p.IsRTL,
                    EnglishName = p.EnglishName,

                })
                .FirstOrDefault();
            ;

            return entity;

        }
    }

}
