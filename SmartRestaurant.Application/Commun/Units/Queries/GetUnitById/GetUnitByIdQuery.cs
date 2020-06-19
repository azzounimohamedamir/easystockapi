using Helpers;
using SmartRestaurant.Application.Commun.Units.Commands.Update;
using SmartRestaurant.Application.Interfaces;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Units.Queries.GetUnitById
{
    public interface IGetUnitByIdQuerie
    {
        UpdateUnitModel Execute(string Id);
    }
    public class GetUnitByIdQuerie : IGetUnitByIdQuerie
    {
        private readonly ILoggerService<GetUnitByIdQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetUnitByIdQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetUnitByIdQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateUnitModel Execute(string Id)
        {
            var entity = db.Units
                .Where(p => p.Id == Id.ToGuid())
               .Select(p => new UpdateUnitModel()
               {
                   Id = p.Id.ToString(),
                   Alias = p.Alias,
                   Symbol = p.Symbol,
                   Name = p.Name,
                   IsDisabled = p.IsDisabled,
               })
                .FirstOrDefault();
            return entity;

        }
    }




}
