using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Foods.Models;
using SmartRestaurant.Application.Commun.Quantities;

namespace SmartRestaurant.Application.Foods.Commands.Create
{

    public interface ICreateFoodCommand
    {
        void Execute(CreateFoodModel model);        
    }

    public class CreateFoodCommand : ICreateFoodCommand
    {
        private readonly ILoggerService<CreateFoodCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateFoodCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateFoodCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateFoodModel model)
        {
            try
            {                
                var validator = new CreateFoodCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                Food food = db.Foods.FirstOrDefault(f => f.Name == model.FoodModel.Name);

                if (food != null)
                    throw new AlreadyExistsExeption($"Food: {model.FoodModel.Name} Exists");

                // create food 
                food = GetFood(model);

                // check picture
                food.PictureId =
                PictureHelper.AddPictureToEntity(db, model.FoodModel.Picture.Url);                

                var guid = model.FoodModel.FoodCategoryId.ToGuid();
                if (model.FoodModel.FoodCategoryId == null ||
                    !db.FoodCategories.Any(c => c.Id == guid))
                    throw new NotFoundException("Food Categories Not Found");
               
                db.Foods.Add(food);
                db.Save();
                //db.Areas.Select
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                

        public Food GetFood(CreateFoodModel model)
        {
            return new Food
            {
                Id = Guid.NewGuid(),
                Alias = model.FoodModel.Alias,
                FoodCategoryId = model.FoodModel.FoodCategoryId.ToGuid(),
                Description = model.FoodModel.Description,
                Name = model.FoodModel.Name,
                UnitId=model.FoodModel.UnitId.ToGuid(),
                PictureId =
                    PictureHelper.AddPictureToEntity(db, model.FoodModel.Picture.Url),
                Nutrition = new Nutrition(
                    new Quantity(
                        model.Nutrition.Quantity.UnitId.ToGuid(),
                        model.Nutrition.Quantity.Value),
                        model.Nutrition.GlycemicIndex,
                        model.Nutrition.Fibre,
                        model.Nutrition.Calorie,
                        model.Nutrition.Protein,
                        model.Nutrition.Carbohydrate,
                        model.Nutrition.Lipid
                    ),
                //Compositions = (from composition in model.Compositions
                //                select new FoodComposition
                //                {
                //                    IsDisabled=composition.IsDesabled,
                //                    Alias=composition.Alias,
                //                    FoodId=composition.FoodId.ToGuid(),
                //                }).ToList()
            };
        }
    }

}
