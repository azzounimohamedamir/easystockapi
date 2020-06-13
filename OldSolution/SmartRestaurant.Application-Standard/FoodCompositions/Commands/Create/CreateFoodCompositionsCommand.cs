using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Foods.Commands.Create;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.FoodCompositions.Commands.Create
{


    public interface ICreateFoodCompositionCommand
    {
        void Execute(CreateFoodCompositionModel model);
    }

    public class CreateFoodCompositionCommand : ICreateFoodCompositionCommand
    {
        private readonly ILoggerService logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateFoodCompositionCommand(ISmartRestaurantDatabaseService db,
            ILoggerService logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateFoodCompositionModel model)
        {
            FoodComposition foodComposition = 
                db.FoodCompositions.FirstOrDefault(f => f.FoodId == model.FoodId);

            if (foodComposition== null)
                throw new NotFoundException("Food Not Found");

            foodComposition = GetFoodComposition(model);
           
            db.FoodCompositions.Add(foodComposition);
            db.Save();
        }

        private FoodComposition GetFoodComposition(CreateFoodCompositionModel model)
        {
            return new FoodComposition
            {
                Id=  Guid.NewGuid(),
                Alias = model.Alis,
                FoodId = model.FoodId,
                Quantity = model.Quantity.GetQuantity()
            };
        }
    }

}
