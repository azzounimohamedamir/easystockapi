using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Create;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Factory;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Models;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Dishes;
using SmartRestaurant.Resources.Dishes.Dish;
using SmartRestaurant.Resources.SharedException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Dishes.Dishes.Commands.Create
{
    public interface ICreateDishCommand
    {
        void Execute(CreateDishModel model);
    }
    public class CreateDishCommand : ICreateDishCommand
    {
        private readonly ISmartRestaurantDatabaseService db;
        private readonly ILoggerService<CreateDishCommand> logger;
        private readonly IMailingService mailingService;
        private readonly INotifyService notifyService;
        private readonly ICreateDishFactory createDishFactory;
        private readonly ICreateGalleryForDishCommand createGalleryForDishCommand;

        public CreateDishCommand(
            ISmartRestaurantDatabaseService db,
            ILoggerService<CreateDishCommand> logger,
            IMailingService mailingService,
            INotifyService notifyService,
            ICreateDishFactory createDishFactory,
            ICreateGalleryForDishCommand createGalleryForDishCommand
            )
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mailingService = mailingService ?? throw new ArgumentNullException(nameof(mailingService));
            this.notifyService = notifyService ?? throw new ArgumentNullException(nameof(notifyService));
            this.createDishFactory = createDishFactory ?? throw new ArgumentNullException(nameof(createDishFactory));
            this.createGalleryForDishCommand = createGalleryForDishCommand ?? throw new ArgumentNullException(nameof(createGalleryForDishCommand));
        }
        public void Execute(CreateDishModel model)
        {
            try
            {
                var validator = new CreateDishModelValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var dish = createDishFactory.Create(model.DishModel,
                                                    model.Ingredients,
                                                    model.Accompaniments,
                                                    model.Equivalences);

                Guid dishId= Guid.NewGuid();
                dish.Id = dishId;

                var restaurant = db.Restaurants.Find(dish.RestaurantId);
                if (restaurant == null)
                {
                    throw new NotValidOperation(string.Format(SharedExceptionResource.NotValidOperationErrorMessage, DishResource.RestaurantId));
                }

                foreach (var ingredient in dish.Ingredients)
                {
                    ingredient.Id = Guid.NewGuid();
                }

                if (dish.ChildAccompaniments != null)
                {
                    foreach (var accompaniment in dish.ChildAccompaniments)
                    {
                        accompaniment.ParentId = dishId;
                    }
                }
                
                var family = db.DishFamilies.Include(f=>f.Childs).FirstOrDefault(f=>f.Id==dish.FamillyId);
                if (family == null)
                {
                    throw new NotValidOperation(string.Format(SharedExceptionResource.NotValidOperationErrorMessage, DishResource.FamillyId));
                }
                if (family.Childs.Any())
                {
                    throw new NotValidOperation(string.Format(SharedExceptionResource.NotValidOperationErrorMessage, DishResource.FamillyId));
                }

                if (model.Gallery != null && model.Gallery.Pictures != null)
                {
                    createGalleryForDishCommand.Execute(dish.RestaurantId, dishId, model.Gallery, false);
                }


                db.Dishes.Add(dish);
                db.Save();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
