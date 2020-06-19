using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Resources.Utils;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Units.Queries.GetUnitsList
{


    public interface IGetAllUnitsQuerie
    {
        List<UnitItemModel> Execute();
    }
    public class GetAllUnitsQuerie : IGetAllUnitsQuerie
    {
        private readonly ILoggerService<GetAllUnitsQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllUnitsQuerie(
            ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllUnitsQuerie> logger,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public List<UnitItemModel> Execute()
        {
            var entity = db.Units.OrderBy(u => u.Name)
                .Select(u => new UnitItemModel()
                {
                    Id = u.Id.ToString(),
                    Alias = u.Alias,
                    Symbol = u.Symbol,
                    Name = u.Name,
                    IsDisabled = u.IsDisabled ? UtilsResource.IsDisabledTrueValueText : UtilsResource.IsDisabledFalseValueText
                });


            return entity.ToList();
        }
    }

}
