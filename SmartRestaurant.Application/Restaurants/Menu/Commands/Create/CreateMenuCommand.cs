using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Menu.Commands.Models;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Menu.Commands.Create
{
    public interface ICreateMenuCommand
    {
        void Execute(MenuModel model);
    }

    public class CreateMenuCommand : ICreateMenuCommand
    {
        private readonly ILoggerService<CreateRestaurantCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateMenuCommand(ISmartRestaurantDatabaseService db,
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
            var validator = new CreateMenuValidator();
            var result = validator.Validate(model);
            if (!result.IsValid)
            {
                throw new NotValidException(result.Errors);
            }

            db.Menus.Add(model.ToEntity());
            db.Save();

        }
    }
}