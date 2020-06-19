using SmartRestaurant.Application.Commun.Languages.Commands.Update;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Languages.Queries.GetLanguageById
{


    public interface IGetLanguageByIdQuerie
    {
        UpdateLanguageModel Execute(string Id);
    }
    public class GetLanguageByIdQuerie : IGetLanguageByIdQuerie
    {
        private readonly ILoggerService<GetLanguageByIdQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetLanguageByIdQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetLanguageByIdQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateLanguageModel Execute(string Id)
        {

            try
            {
                var entity = db.Languages
                .Where(p => p.Id.ToString() == Id)
                .Select(p => new UpdateLanguageModel()
                {

                    Name = p.Name,
                    IsoCode = p.IsoCode,
                    Alias = p.Alias,
                    IsRTL = p.IsRTL,
                    Id = p.Id,
                    EnglishName = p.EnglishName,
                    IsDisabled = p.IsDisabled,

                })
                .FirstOrDefault();

                return entity;


            }
            catch (Exception e)
            {
                throw e;
            }


        }


    }

}
