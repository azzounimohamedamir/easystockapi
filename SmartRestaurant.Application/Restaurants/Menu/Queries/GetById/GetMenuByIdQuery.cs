using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Menu.Commands.Models;
using SmartRestaurant.Application.Restaurants.Menu.Queries.GetAllFilterd;

namespace SmartRestaurant.Application.Restaurants.Menu.Queries.GetById
{
    public class GetMenuByIdQuery: IGetMenuByIdQuery
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
        public GetMenuByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllMenuFilterdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            _db = db;
            _logger = logger;
            _mailing = mailing;
            _notify = notify;
        }
        public MenuModel Execute(Guid id)
        {
            return _db.Menus.Include(x=>x.Restaurant).Where(m => m.Id == id).Select(x => new MenuModel()
            {
                MenuId = x.Id.ToString(),
                Name = x.Name,
                RestaurantId = x.RestaurantId.ToString(),
                IsDisabled = x.IsDisabled,
                Description = x.Description

            }).FirstOrDefault();
        }
    }

    public interface IGetMenuByIdQuery
    {
        MenuModel Execute(Guid id);
    }
}
