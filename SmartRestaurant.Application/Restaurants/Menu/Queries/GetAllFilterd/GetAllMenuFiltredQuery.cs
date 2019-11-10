using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Commun.Datatables;
using SmartRestaurant.Application.Interfaces;

namespace SmartRestaurant.Application.Restaurants.Menu.Queries.GetAllFilterd
{
    public interface IGetAllMenuFiltredQuery
    {
        DataatablesQueryModel<MenuQueryModel> Execute(int page , int skipe, string term, Guid? restaurantId);
    }
    public class GetAllMenuFiltredQuery :IGetAllMenuFiltredQuery
    {
        private ISmartRestaurantDatabaseService _db;
        private ILoggerService<GetAllMenuFiltredQuery> _logger;
        private IMailingService _mailing;
        private INotifyService _notify;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="logger"></param>
        /// <param name="mailing"></param>
        /// <param name="notify"></param>
        public GetAllMenuFiltredQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllMenuFiltredQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            _db = db;
            _logger = logger;
            _mailing = mailing;
            _notify = notify;
        }

        public DataatablesQueryModel<MenuQueryModel> Execute(int page, int skipe, string term, Guid? restaurantId)
        {
            var total = _db.Menus.Count();
            // build the query
            IQueryable<Domain.Restaurants.Menu> query = _db.Menus
                .Include(x => x.Restaurant);
            // where  clause
            if (!string.IsNullOrEmpty(term))
                // ReSharper disable once ComplexConditionExpression
                query = query.Where(x => x.Name.ToLower().Contains(term)
                                         || x.Description.ToLower().Contains(term)
                                         || x.Restaurant.Name.ToLower().Contains(term));
            if (restaurantId.HasValue)
                query = query.Where(x => x.RestaurantId == restaurantId);
            // order  by  clause   
            var data = query
                .OrderBy(x => x.Name)
                .Skip(page)
                // ReSharper disable once TooManyChainedReferences
                .Take(skipe).Select(x => new MenuQueryModel
                {
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    Description = x.Description,
                    RestaurantId = x.RestaurantId.ToString(),
                    Restaurant = x.Restaurant.Name
                });
            var totalFiltred = data.ToList().Count;
            return new DataatablesQueryModel<MenuQueryModel>
            {
                Data = data,
                RecordsTotal = total,
                RecordsFilterd = totalFiltred

            };
        }
    }
}
