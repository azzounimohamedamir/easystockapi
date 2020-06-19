using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Foods;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Foods.Commands.Update
{


    public interface IUpdateFoodCommand
    {
        void Execute(UpdateFoodModel model);
    }

    public class UpdateFoodCommand : IUpdateFoodCommand
    {
        private readonly ILoggerService<UpdateFoodCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateFoodCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateFoodCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateFoodModel model)
        {
            try
            {
                var validator = new UpdateFoodCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var guid = model.FoodModel.Id.ToGuid();
                Food food = db.Foods.FirstOrDefault(f => f.Id == guid);
                if (food == null) throw new NotFoundException();

                var cguid = model.FoodModel.FoodCategoryId.ToGuid();
                if (model.FoodModel.FoodCategoryId == null ||
                  !db.FoodCategories.Any(c => c.Id == cguid))
                    throw new NotFoundException("Food Categories Not Found");

                food.Alias = model.FoodModel.Alias;
                food.FoodCategoryId = model.FoodModel.FoodCategoryId.ToGuid();
                food.Description = model.FoodModel.Description;
                food.Name = model.FoodModel.Name;
                food.PictureId = PictureHelper.AddPictureToEntity(db, model.FoodModel.Picture.Url);
                food.UnitId = model.FoodModel.UnitId.ToGuid();
                food.Nutrition = new Nutrition(
                     new Quantity(
                         model.Nutrition.Quantity.UnitId.ToGuid(),
                         model.Nutrition.Quantity.Value),
                         model.Nutrition.GlycemicIndex,
                         model.Nutrition.Fibre,
                         model.Nutrition.Calorie,
                         model.Nutrition.Protein,
                         model.Nutrition.Carbohydrate,
                         model.Nutrition.Lipid
                     );

                db.Foods.Update(food);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
