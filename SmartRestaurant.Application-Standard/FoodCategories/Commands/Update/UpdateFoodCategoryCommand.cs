using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.FoodCategories.Commands.Update
{


    public interface IUpdateFoodCategoryCommand
    {
        void Execute(UpdateFoodCategoryModel model);
    }

    public class UpdateFoodCategoryCommand : IUpdateFoodCategoryCommand
    {
        private readonly ILoggerService logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateFoodCategoryCommand(ISmartRestaurantDatabaseService db,
            ILoggerService logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateFoodCategoryModel model)
        {
            var catergory = db.FoodCategories.FirstOrDefault(f => f.Id == model.Id);
            if (catergory == null) throw new NotFoundException();

            //catergory = model.ToEntity();
            UpdateCategory(ref catergory, model);

            db.FoodCategories.Update(catergory);
            db.Save();
        }

        private void UpdateCategory(ref FoodCategory catergory,
            UpdateFoodCategoryModel model)
        {
            catergory.Name = model.Name;
            catergory.ParentId = model.ParentId;
            catergory.PictureId = model.PictureId;
            catergory.SlugUrl = model.SlugUrl;
            catergory.Alias = model.Alias;
            catergory.Description = model.Description;
        }
    }

}
