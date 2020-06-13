using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;

namespace SmartRestaurant.Application.FoodCompositions.Commands.Delete
{
    public interface IDeleteFoodCompositionsCommand
    {
        void Execute(DeleteFoodCompositionsModel model);
    }

    public class DeleteFoodCompositionsCommand : IDeleteFoodCompositionsCommand
    {
        private readonly ILoggerService<DeleteFoodCompositionsCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteFoodCompositionsCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteFoodCompositionsCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteFoodCompositionsModel model)
        {
            try
            {
                var validator = new DeleteFoodCompositionsCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }
                var guid = model.Id.ToGuid();
                FoodComposition food = db.FoodCompositions.FirstOrDefault(f => f.Id == guid);
                if (food == null)
                    throw new NotFoundException();

                db.FoodCompositions.Remove(food);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
