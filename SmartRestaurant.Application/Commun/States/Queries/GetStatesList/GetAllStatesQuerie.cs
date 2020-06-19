using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Commun.States.Queries.GetStatesList
{


    public interface IGetAllStatesQuerie
    {
        List<StateItemModel> Execute();
    }
    public class GetAllStatesQuerie : IGetAllStatesQuerie
    {
        private readonly ILoggerService<GetAllStatesQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllStatesQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllStatesQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public List<StateItemModel> Execute()
        {
            var entity = db.States
               .Include(p => p.Country)
               .Select(p => new StateItemModel()
               {
                   Id = p.Id,
                   CountryId = p.CountryId,
                   CountryIsoCode = p.Country.IsoCode,
                   CountryName = p.Country.Name,
                   IsoCode = p.IsoCode,
                   Name = p.Name,
                   Alias = p.Alias,
                   IsDisabled = p.IsDisabled.DisabledDisplay(),
               }

            );


            return entity.ToList();

        }
    }

}
