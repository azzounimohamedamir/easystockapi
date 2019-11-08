using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using SmartRestaurant.Application.Foods.Commands.Create;

namespace SmartRestaurant.Application.FoodCompositions.Commands.Update
{


    public interface IUpdateFoodCompositionsCommand
    {
        void Execute(UpdateFoodCompositionsModel model);
    }

    public class UpdateFoodCompositionsCommand : IUpdateFoodCompositionsCommand
    {
        private readonly ILoggerService<UpdateFoodCompositionsCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateFoodCompositionsCommand(
            ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateFoodCompositionsCommand> logger, 
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateFoodCompositionsModel model)
        {
            try
            {
                var validator = new UpdateFoodCompositionsCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                // checkig food composition
                var compositionGuid = model.Id.ToGuid();
                FoodComposition foodComposition =
                    db.FoodCompositions.FirstOrDefault(f => f.Id ==compositionGuid );

                if (foodComposition == null)
                    throw new NotFoundException(nameof(FoodComposition));

                var guid = model.FoodId.ToGuid();
                // checkig food  
                if (model.FoodId.IsNullOrEmpty() ||
                 !db.Foods.Any(c => c.Id == guid))
                    throw new NotFoundException(nameof(Food) + model.FoodId);

                foodComposition.FoodId = guid;
                foodComposition.Quantity = model.Quantity.ToVOQuantity();

                db.FoodCompositions.Update(foodComposition);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
