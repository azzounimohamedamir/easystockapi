using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.FoodCategories.Commands.Delete
{



    public interface IDeleteFoodCatergoryCommand
    {
        void Execute(DeleteFoodCatergoryModel model);
    }

    public class DeleteFoodCatergoryCommand : IDeleteFoodCatergoryCommand
    {
        private readonly ILoggerService logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteFoodCatergoryCommand(ISmartRestaurantDatabaseService db,
            ILoggerService logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteFoodCatergoryModel model)
        {
            var catergory = db.FoodCategories.Include(c=>c.Foods)
                .Include(c => c.Childs)
                .FirstOrDefault(f => f.Id == model.Id);

            if (catergory == null)
                throw new NotFoundException();

            if(catergory.Foods.Any()|| catergory.Childs.Any())
                throw new DeleteFailureException(nameof(FoodCategory));

            db.FoodCategories.Remove(catergory);
            db.Save();
        }
    }

}
