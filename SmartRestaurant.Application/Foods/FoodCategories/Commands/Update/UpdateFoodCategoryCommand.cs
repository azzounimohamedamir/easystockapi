using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Foods;
using System;
using System.Linq;

namespace SmartRestaurant.Application.FoodCategories.Commands.Update
{


    public interface IUpdateFoodCategoryCommand
    {
        void Execute(UpdateFoodCategoryModel model);
    }

    public class UpdateFoodCategoryCommand : IUpdateFoodCategoryCommand
    {
        private readonly ILoggerService<UpdateFoodCategoryCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateFoodCategoryCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateFoodCategoryCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateFoodCategoryModel model)
        {
            try
            {
                var validator = new UpdateFoodCategoryCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var id = model.Id.ToGuid();
                var catergory = db.FoodCategories.FirstOrDefault(f => f.Id == id);
                if (catergory == null)
                    throw new NotFoundException();

                FoodCategory namedcategory =
                  db.FoodCategories.FirstOrDefault(f => f.Name == model.Name);


                if (namedcategory != null && catergory.Id != id)
                    throw new AlreadyExistsExeption($"{ nameof(FoodCategory)}:{model.Name} Exists");

                if (!string.IsNullOrEmpty(model.ParentId))
                {
                    var parentId = model.ParentId.ToGuid();
                    var parentCatergory = db.FoodCategories.FirstOrDefault(f => f.Id == parentId);
                    if (parentCatergory == null)
                        throw new NotFoundException(nameof(FoodCategory));
                }

                UpdateCategory(ref catergory, model);

                db.FoodCategories.Update(catergory);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateCategory(ref FoodCategory catergory,
                  UpdateFoodCategoryModel model)
        {
            Guid? parentId = null;
            if (!string.IsNullOrEmpty(model.ParentId))
            {
                parentId = model.ParentId.ToGuid();
            }
            catergory.Name = model.Name;
            catergory.ParentId = parentId;
            catergory.Alias = model.Alias;
            catergory.Description = model.Description;
            catergory.PictureId =
            PictureHelper.UpdateEntityPicture(db, model.PictureUrl);
        }
    }

}
