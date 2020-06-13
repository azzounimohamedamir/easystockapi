using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Foods.Commands.Delete
{


    public interface IDeleteFoodCommand
    {
        void Execute(DeleteFoodModel model);
    }

    public class DeleteFoodCommand : IDeleteFoodCommand
    {
        private readonly ILoggerService logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteFoodCommand(ISmartRestaurantDatabaseService db,
            ILoggerService logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteFoodModel model)
        {
            Food food = db.Foods.Include(c=>c.Compositions)
                .FirstOrDefault(f => f.Id == model.Id);
            if (food == null)
                throw new NotFoundException();

            if (food.Compositions.Any() )
                throw new DeleteFailureException(nameof(Food));

            db.Foods.Remove(food);
            db.Save();
        }
    }

}
