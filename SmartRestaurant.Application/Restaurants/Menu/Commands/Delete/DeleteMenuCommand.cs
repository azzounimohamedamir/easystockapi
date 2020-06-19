using System;
using System.Threading.Tasks;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Menu.Commands.Delete
{
    public interface IDeleteMenuCommand
    {
        Task Execute(DeleteMenuModel model);
    }
    public class DeleteMenuCommand : IDeleteMenuCommand
    {
        private readonly ILoggerService<CreateRestaurantCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteMenuCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateRestaurantCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public async Task Execute(DeleteMenuModel model)
        {
            var item =await db.Menus.FindAsync(Guid.Parse(model.Id));
            if (item == null) return;
            db.Menus.Remove(item);
            db.Save();
        }
    }
}
