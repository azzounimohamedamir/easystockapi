using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;

namespace SmartRestaurant.Application.Foods.Commands.Delete
{


    public interface IDeleteFoodCommand
    {
        void Execute(DeleteFoodModel model);
    }

    public class DeleteFoodCommand : IDeleteFoodCommand
    {
        private readonly ILoggerService<DeleteFoodCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteFoodCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteFoodCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteFoodModel model)
        {
            try
            {
                var validator = new DeleteFoodCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var guid = model.Id.ToGuid();
                Food food = db.Foods.FirstOrDefault(f => f.Id == guid);
                if (food == null)
                    throw new NotFoundException();

                

                db.Foods.Remove(food);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
