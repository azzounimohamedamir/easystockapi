using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.FoodCompositions.Commands.Delete
{


    public interface IDeleteFoodCompositionsCommand
    {
        void Execute(DeleteFoodCompositionsModel model);
    }

    public class DeleteFoodCompositionsCommand : IDeleteFoodCompositionsCommand
    {
        private readonly ILoggerService logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteFoodCompositionsCommand(ISmartRestaurantDatabaseService db,
            ILoggerService logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteFoodCompositionsModel model)
        {

        }
    }

}
