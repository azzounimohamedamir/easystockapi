using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Create;
using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Update;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Dishes;
using SmartRestaurant.Resources.Dishes.Dish;
using SmartRestaurant.Resources.SharedException;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Dishes.Dishes.Commands.Update
{
    public interface IUpdateDishCommand
    {
        void Execute(UpdateDishModel model);
    }
    public class UpdateDishCommand : IUpdateDishCommand
    {
        private readonly ISmartRestaurantDatabaseService db;
        private readonly ILoggerService<UpdateDishCommand> logger;
        private readonly IMailingService mailingService;
        private readonly INotifyService notifyService;
        private readonly ICreateGalleryForDishCommand createGalleryForDishCommand;
        private readonly IUpdateGalleryForDishCommand updateGalleryForDishCommand;

        public UpdateDishCommand(
            ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateDishCommand> logger,
            IMailingService mailingService,
            INotifyService notifyService,
            ICreateGalleryForDishCommand createGalleryForDishCommand,
            IUpdateGalleryForDishCommand updateGalleryForDishCommand
            )
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mailingService = mailingService ?? throw new ArgumentNullException(nameof(mailingService));
            this.notifyService = notifyService ?? throw new ArgumentNullException(nameof(notifyService));
            this.createGalleryForDishCommand = createGalleryForDishCommand ?? throw new ArgumentNullException(nameof(createGalleryForDishCommand));
            this.updateGalleryForDishCommand = updateGalleryForDishCommand ?? throw new ArgumentNullException(nameof(updateGalleryForDishCommand));
        }



        public void Execute(UpdateDishModel model)
        {
            try
            {
                var validator = new UpdateDishModelValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var restaurant = db.Restaurants.Find(model.DishModel.RestaurantId.ToGuid());
                if (restaurant == null)
                {
                    throw new NotValidOperation(string.Format(SharedExceptionResource.NotValidOperationErrorMessage, DishResource.RestaurantId));
                }

                var family = db.DishFamilies
                    .Include(f => f.Childs)
                    .FirstOrDefault(f => f.Id == model.DishModel.FamillyId.ToGuid());

                if (family == null)
                {
                    throw new NotValidOperation(string.Format(SharedExceptionResource.NotValidOperationErrorMessage, DishResource.FamillyId));
                }
                if (family.Childs.Any())
                {
                    throw new NotValidOperation(string.Format(SharedExceptionResource.NotValidOperationErrorMessage, DishResource.FamillyId));
                }

                var dish = db.Dishes
                    .Include(d => d.Ingredients)
                    .Include(d => d.ChildAccompaniments)
                    .Include(d => d.Gallery).ThenInclude(g => g.Pictures)
                    .Where(d => d.Id == model.Id.ToGuid())
                    .FirstOrDefault();

                if (dish == null)
                {
                    throw new NotFoundException(string.Format(SharedExceptionResource.NotFoundExceptionErrorMessage, DishUtilsResource.TableName, model.Id));
                }

                //****************begin Edit************************
                dish.IsDisabled = model.DishModel.IsDisabled;
                dish.Alias = model.DishModel.Alias;
                dish.Name = model.DishModel.Name;
                dish.Description = model.DishModel.Description;
                dish.RestaurantId = model.DishModel.RestaurantId.ToGuid();
                dish.Type = model.DishModel.Type;
                dish.FamillyId = model.DishModel.FamillyId.ToGuid();
                //TODO: Swith between Gallery and Create gallery UI in the next version
                //dish.GalleryId =;
                dish.PreparationTime = new Time(model.DishModel.PreparationTime);
                dish.ServiceTime = new Time(model.DishModel.ServiceTime);

                EditAccompaniments(dish, model);
                EditIngredients(dish, model);

                if (model.Gallery != null && model.Gallery.Pictures != null)
                {
                    if (dish.Gallery != null)
                    {
                        updateGalleryForDishCommand.Execute(restaurant.Id, model.Gallery, false);
                    }
                    else
                    {
                        createGalleryForDishCommand.Execute(restaurant.Id, dish.Id, model.Gallery, false);
                    }
                }


                db.Dishes.Update(dish);
                db.Save();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EditAccompaniments(Dish dish, UpdateDishModel model)
        {
            if (dish.ChildAccompaniments != null && dish.ChildAccompaniments.Count > 0)
            {
                HashSet<string> accDBIds = new HashSet<string>(dish.ChildAccompaniments.Select(i => i.AccompanyingId.ToString()));
                HashSet<string> accModelIds = new HashSet<string>(model.Accompaniments.Select(i => i.AccompanyingId));

                foreach (string accDbId in accDBIds)
                {
                    var accDb = dish.ChildAccompaniments.FirstOrDefault(i => i.AccompanyingId == accDbId.ToGuid());
                    if (!accModelIds.Contains(accDbId))//Delete ingredient
                    {
                        dish.ChildAccompaniments.Remove(accDb);
                    }
                    else //update
                    {
                        var accModel = model.Accompaniments.FirstOrDefault(i => i.AccompanyingId == accDbId);
                        accDb.IsDisabled = accModel.IsDisabled;
                        accDb.Quantity = new Domain.Commun.Quantity(accModel.Quantity.UnitId.ToGuid(), accModel.Quantity.Value);
                    }
                }
                if (dish.ChildAccompaniments == null) dish.ChildAccompaniments = new List<DishAccompanying>();
                foreach (var accModel in model.Accompaniments.Where(i => string.IsNullOrEmpty(i.ParentId)))
                {
                    dish.ChildAccompaniments.Add(
                        new DishAccompanying
                        {
                            IsDisabled = accModel.IsDisabled,
                            ParentId = dish.Id,
                            AccompanyingId = accModel.AccompanyingId.ToGuid(),
                            Quantity = new Domain.Commun.Quantity(accModel.Quantity.UnitId.ToGuid(), accModel.Quantity.Value),
                        }
                        );
                }
            }
            else
            {

            }

        }

        private void EditIngredients(Dish dish, UpdateDishModel model)
        {
            HashSet<string> ingDBIds = new HashSet<string>(dish.Ingredients.Select(i => i.Id.ToString()));
            HashSet<string> ingModelIds = new HashSet<string>(model.Ingredients.Select(i => i.Id));

            foreach (string ingDbId in ingDBIds)
            {
                var ingDb = dish.Ingredients.FirstOrDefault(i => i.Id == ingDbId.ToGuid());
                if (!ingModelIds.Contains(ingDbId))//Delete ingredient
                {
                    dish.Ingredients.Remove(ingDb);
                }
                else //update
                {
                    var ingModel = model.Ingredients.FirstOrDefault(i => i.Id == ingDbId);
                    ingDb.IsDisabled = ingModel.IsDisabled;
                    ingDb.Alias = ingModel.Alias;
                    ingDb.Name = ingModel.Name;
                    ingDb.Description = ingModel.Description;
                    ingDb.FoodId = ingModel.FoodId.ToGuid();
                    ingDb.IsPrincipal = ingModel.IsPrincipal;
                    ingDb.IsSwitchable = ingModel.IsSwitchable;
                    ingDb.Quantity = new Domain.Commun.Quantity(ingModel.Quantity.UnitId.ToGuid(), ingModel.Quantity.Value);
                }
            }
            if (dish.Ingredients == null) dish.Ingredients = new List<DishIngredient>();
            foreach (var ingModel in model.Ingredients.Where(i => string.IsNullOrEmpty(i.Id)))
            {
                dish.Ingredients.Add(
                    new DishIngredient
                    {
                        Id = Guid.NewGuid(),
                        IsDisabled = ingModel.IsDisabled,
                        Alias = ingModel.Alias,
                        Name = ingModel.Name,
                        Description = ingModel.Description,
                        FoodId = ingModel.FoodId.ToGuid(),
                        IsPrincipal = ingModel.IsPrincipal,
                        IsSwitchable = ingModel.IsSwitchable,
                        Quantity = new Domain.Commun.Quantity(ingModel.Quantity.UnitId.ToGuid(), ingModel.Quantity.Value),
                    }
                    );
            }
        }
    }
}
