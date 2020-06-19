using System;
using System.Collections.Generic;
using System.Linq;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Menu.Queries.GetAllFilterd;

namespace SmartRestaurant.Application.Restaurants.Menu.Queries.GetAllMenus
{
   public class GetAllMenusQuery: IGetAllMenusQuery
    {
        private ISmartRestaurantDatabaseService _db;
        private ILoggerService<GetAllMenuFilterdQuery> _logger;
        private IMailingService _mailing;
        private INotifyService _notify;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="logger"></param>
        /// <param name="mailing"></param>
        /// <param name="notify"></param>
        public GetAllMenusQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllMenuFilterdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            _db = db;
            _logger = logger;
            _mailing = mailing;
            _notify = notify;
        }

        public IEnumerable<MenuQueryModel> Execute(string restaurantId)
        {
            IQueryable<Domain.Restaurants.Menu> query = _db.Menus;
            if (!string.IsNullOrEmpty(restaurantId))
                query = query.Where(x => x.RestaurantId == Guid.Parse(restaurantId));
            foreach (var menu in query)
                yield return new MenuQueryModel(menu);

        }
    }

    public interface IGetAllMenusQuery
    {
        IEnumerable<MenuQueryModel> Execute(string restaurantId);

    }
}
