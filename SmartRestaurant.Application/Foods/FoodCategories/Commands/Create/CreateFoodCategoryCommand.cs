using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.FoodCategories.Commands.Create;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Foods;
using System;
using System.Linq;

namespace SmartRestaurant.Application.FoodCategories.Commands
{
    public interface ICreateFoodCategoryCommand
    {
        void Execute(CreateFoodCategoryModel model);
    }

    public class CreateFoodCategoryCommand : ICreateFoodCategoryCommand
    {
        private readonly ILoggerService<CreateFoodCategoryCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateFoodCategoryCommand(
            ISmartRestaurantDatabaseService db,
            ILoggerService<CreateFoodCategoryCommand> logger,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateFoodCategoryModel model)
        {
            try
            {
                var validator = new CreateFoodCategoryCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                FoodCategory category =
                    db.FoodCategories.FirstOrDefault(f => f.Name == model.Name);


                if (category != null)
                    throw new AlreadyExistsExeption($"{ nameof(FoodCategory)}:{model.Name} Exists");

                category = model.ToEntity();
                var categotyGuid = Guid.NewGuid();
                category.Id = categotyGuid;

                var parentGuid = model.ParentId.ToGuid();

                if (db.Foods.Any(x => x.FoodCategoryId == parentGuid))
                {
                    throw new NotValidOperation("Can't add subCategory to" +
                        $" {model.Name} Because it contains Food");
                }
                category.PictureId =
                    PictureHelper.AddPictureToEntity(db, model.PictureUrl);

                db.FoodCategories.Add(category);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
