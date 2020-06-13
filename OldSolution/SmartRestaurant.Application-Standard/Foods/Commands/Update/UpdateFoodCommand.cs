using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Application.Foods.Commands.Update
{


    public interface IUpdateFoodCommand
    {
        void Execute(UpdateFoodModel model);
    }

    public class UpdateFoodCommand : IUpdateFoodCommand
    {
        private readonly ILoggerService logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateFoodCommand(ISmartRestaurantDatabaseService db,
            ILoggerService logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateFoodModel model)
        {
            Food food = db.Foods.FirstOrDefault(f => f.Id == model.Id);
            if (food == null) throw new NotFoundException();

            UpdateCategory(ref food, model);

            var guid = model.FoodCategoryId.GuidFromString();
            if (model.FoodCategoryId == null ||
              !db.FoodCategories.Any(c => c.Id == guid))
                throw new NotFoundException("Food Categories Not Found");

            db.Foods.Update(food);
            db.Save();
        }

        private void UpdateCategory(ref Food food, UpdateFoodModel model)
        {
            food.Name = model.Name;
            food.Description = model.Description;
            food.Alias = model.Alias;
            food.FoodCategoryId = model.FoodCategoryId.GuidFromString();

            // 1.from null to new pic
            if (food.Picture == null && model.PictureUrl.NotNullOrEmpty())
            {
                var pic = db.Pictures.FirstOrDefault(x => x.ImageUrl == model.PictureUrl);
                if (pic != null) food.PictureId = pic.Id;
                else
                {
                    Guid picGuid = Guid.NewGuid();
                    Picture newPic = new Picture
                    {
                        Id = picGuid,
                        ImageUrl = model.PictureUrl
                    };
                    food.Picture = newPic;
                }
            }
            // 2.from pic to  null
            if(model.PictureUrl.IsNullOrEmpty())
            {
                food.PictureId = null;
            }
            // 3.from pic to  diferent pic
            if (food.Picture!=null  && food.Picture.ImageUrl != model.PictureUrl)
            {

            }
            // 4.from pic to the same pic
        }
    }

}
