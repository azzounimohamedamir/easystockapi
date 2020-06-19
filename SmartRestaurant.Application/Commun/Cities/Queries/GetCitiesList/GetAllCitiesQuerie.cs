using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
namespace SmartRestaurant.Application.Commun.Cities.Queries.GetCitiesList
{


    public interface IGetAllCitiesQuerie
    {
        List<CityItemModel> Execute();
    }
    public class GetAllCitiesQuerie : IGetAllCitiesQuerie
    {
        private readonly ILoggerService<GetAllCitiesQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllCitiesQuerie(
            ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllCitiesQuerie> logger,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public List<CityItemModel> Execute()
        {
            var entity = db.Cities
                .Include(q => q.State)

                .Select(p => new CityItemModel()
                {
                    Id = p.Id,
                    StateId = p.StateId,
                    StateName = p.State.Name,
                    StateIsoCode = p.State.IsoCode,
                    Alias = p.Alias,
                    IsoCode = p.IsoCode,
                    Name = p.Name,
                    IsDisabled = p.IsDisabled.DisabledDisplay(),


                });


            return entity.ToList();
        }
    }

}
