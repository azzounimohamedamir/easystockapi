using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Application.Foods.Commands.Create
{

    public interface ICreateFoodCommand
    {
        void Execute(CreateFoodModel model);
    }

    public class CreateFoodCommand : ICreateFoodCommand
    {
        private readonly ILoggerService logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateFoodCommand(ISmartRestaurantDatabaseService db,
            ILoggerService logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateFoodModel model)
        {
            Food food = db.Foods.FirstOrDefault(f => f.Name == model.Name);

            if (food != null)
                throw new AlreadyExistsExeption($"Food: {model.Name} Exists");

            // create food 
            food = GetFood(model);

            // check picture
            
            if (model.PictureUrl.NotNullOrEmpty())
            {
                var picture = db.Pictures.FirstOrDefault(x => x.ImageUrl == model.PictureUrl);
                //Picture exist
                if (picture != null)
                    food.PictureId = picture.Id;
                else // create picture
                {
                    var picId = Guid.NewGuid();
                    Picture pic = new Picture
                    {
                        Id = picId,
                        ImageUrl = model.PictureUrl
                    };
                    food.Picture = pic;
                }
            }

            var guid = model.FoodCategoryId.GuidFromString();
            if (model.FoodCategoryId == null ||
                !db.FoodCategories.Any(c => c.Id == guid))
                throw new NotFoundException("Food Categories Not Found");

            db.Foods.Add(food);
            db.Save();
        }

        public Food GetFood(CreateFoodModel model)
        {
            return new Food
            {
                Id = Guid.NewGuid(),
                Alias = model.Alias,
                FoodCategoryId = model.FoodCategoryId.GuidFromString(),
                Description = model.Description,
                Name = model.Name,
                Nutrition = model.Nutrition.GetNutrition()
            };
        }
    }

}
