using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.FoodCategories.Commands.Create;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.FoodCategories.Commands
{


    public interface ICreateFoodCategoryCommand
    {
        void Execute(CreateFoodCategoryModel model);
    }

    public class CreateFoodCategoryCommand : ICreateFoodCategoryCommand
    {
        private readonly ILoggerService logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateFoodCategoryCommand(ISmartRestaurantDatabaseService db,
            ILoggerService logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateFoodCategoryModel model)
        {
            var category = db.FoodCategories.FirstOrDefault(f => f.Name == model.Name);
            //TODO:$"FoodCategories: {model.Name} Exists" to globalization
            if (category != null)
                throw new AlreadyExistsExeption($"FoodCategories: {model.Name} Exists");

            category = model.ToEntity();
            category.Id = Guid.NewGuid();

            int foodsCount = db.Foods.Count(x => x.FoodCategoryId == model.ParentId);
            if (foodsCount != 0)
            {               
                throw new NotValidOperation("Can't add subCategory to" +
                    $" {model.Name} Because it contains Food");
            }

            db.FoodCategories.Add(category);
            db.Save();
            //TODO: try 
        }
    }

}
