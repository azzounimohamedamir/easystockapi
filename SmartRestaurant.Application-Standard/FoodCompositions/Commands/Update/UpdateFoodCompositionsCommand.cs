using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.FoodCompositions.Commands.Update
{


    public interface IUpdateFoodCompositionsCommand
    {
        void Execute(UpdateFoodCompositionsModel model);
    }

    public class UpdateFoodCompositionsCommand : IUpdateFoodCompositionsCommand
    {
        private readonly ILoggerService logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateFoodCompositionsCommand(ISmartRestaurantDatabaseService db,
            ILoggerService logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateFoodCompositionsModel model)
        {

        }
    }

}
