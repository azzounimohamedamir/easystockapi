using System;
using System.Collections.Generic;
using System.Text;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Menu.Commands.Create;
using SmartRestaurant.Application.Restaurants.Menu.Commands.Models;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Menu.Commands.Update
{
    public interface IUpdateMenuCommand
    {
        void Execute(MenuModel model);
    }
    public class UpdateMenuCommand :IUpdateMenuCommand
    {
        private readonly ILoggerService<CreateRestaurantCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateMenuCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateRestaurantCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public void Execute(MenuModel model)
        {
            var validator = new updateMenuValidator();
            var result = validator.Validate(model);
            if (!result.IsValid)
            {
                throw new NotValidException(result.Errors);
            }

            db.Menus.Update(model.ToEntity());
            db.Save();
        }
    }
}
