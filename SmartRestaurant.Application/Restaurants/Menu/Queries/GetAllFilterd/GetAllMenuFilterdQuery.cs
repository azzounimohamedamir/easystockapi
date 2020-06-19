using System;
using System.Collections.Generic;
using System.Linq;
using DataTables.AspNetCore.Mvc.Binder;
using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Commun.Datatables;
using SmartRestaurant.Application.Interfaces;
using System.Linq.Dynamic.Core;

namespace SmartRestaurant.Application.Restaurants.Menu.Queries.GetAllFilterd
{
    public interface IGetAllMenuFilterdQuery
    {
        DatatablesQueryModel<MenuQueryModel> Execute(int page , int skipe, string term, IEnumerable<Order> orderClause, Guid? restaurantId);
    }
    public class GetAllMenuFilterdQuery :IGetAllMenuFilterdQuery
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
        public GetAllMenuFilterdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllMenuFilterdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            _db = db;
            _logger = logger;
            _mailing = mailing;
            _notify = notify;
        }

        public DatatablesQueryModel<MenuQueryModel> Execute(int page, int skipe, string term,IEnumerable<Order> orderClause, Guid? restaurantId)
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
            if (orderClause !=null)
            {
                foreach (var order in orderClause)
                {
                    var propertyNam = LinqHelper.GetPropertyNameByIndex<MenuQueryModel>(order.Column);
                    if (propertyNam.Contains("Restaurant"))
                        propertyNam = "Restaurant.Name";
                    query = query.OrderBy(String.Concat( propertyNam, order.Dir =="asc"? "" : " descending"));
                }
                
                
            }
            else
                query = query
                    .OrderBy(x => x.Name);


            var data = query.Skip(page)
                // ReSharper disable once TooManyChainedReferences
                .Take(skipe).Select(x => new MenuQueryModel
                {
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    Description = x.Description,
                    RestaurantId = x.RestaurantId.ToString(),
                    Restaurant = x.Restaurant.Name,
                    IsDisabled = x.IsDisabled
                });
            var totalFiltred = data.ToList().Count;
            return new DatatablesQueryModel<MenuQueryModel>
            {
                Data = data,
                RecordsTotal = total,
                RecordsFilterd = totalFiltred

            };
        }
    }
}
