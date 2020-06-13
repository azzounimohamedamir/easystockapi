using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Foods.Commands.Create;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using SmartRestaurant.Application.FoodCompositions.Commands.Models;
using SmartRestaurant.Application.Foods.FoodCompositions.Validations;

namespace SmartRestaurant.Application.FoodCompositions.Commands.Create
{
    public interface ICreateFoodCompositionCommand
    {
        void Execute(FoodCompositionModel model);
    }

    public class CreateFoodCompositionCommand : ICreateFoodCompositionCommand
    {
        private readonly ILoggerService<CreateFoodCompositionCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateFoodCompositionCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateFoodCompositionCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(FoodCompositionModel model)
        {
            try
            {
                var validator = new FoodCompositionModelValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var guid = model.FoodId.ToGuid();

                Food food = db.Foods.FirstOrDefault(f => f.Id == guid);

                if (food == null)
                    throw new NotFoundException(nameof(Food) + model.FoodId);

                var foodComposition = GetFoodComposition(model);

                db.FoodCompositions.Add(foodComposition);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private FoodComposition GetFoodComposition(FoodCompositionModel model)
        {
            return new FoodComposition
            {
                Id = Guid.NewGuid(),
                Alias = model.Alias,
                FoodId = model.FoodId.ToGuid(),
                Quantity = model.Quantity.ToVOQuantity()
            };
        }
    }

}
