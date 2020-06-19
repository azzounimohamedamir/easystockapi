using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Resources.SharedException;
using System;
using System.Linq;

namespace SmartRestaurant.Application.FoodCategories.Commands.Delete
{



    public interface IDeleteFoodCatergoryCommand
    {
        void Execute(DeleteFoodCatergoryModel model);
    }

    public class DeleteFoodCatergoryCommand : IDeleteFoodCatergoryCommand
    {
        private readonly ILoggerService<DeleteFoodCatergoryCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteFoodCatergoryCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteFoodCatergoryCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteFoodCatergoryModel model)
        {
            try
            {
                var validator = new DeleteFoodCatergoryCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var guid = model.Id.ToGuid();
                var catergory = db.FoodCategories.Include(c => c.Foods)
                    .Include(c => c.Childs)
                    .FirstOrDefault(f => f.Id == guid);

                if (catergory == null) throw new NotFoundException();


                //
                if (catergory.Foods.Any() || catergory.Childs.Any())
                    throw new NestedDeleteException(string.Format(
                        SharedExceptionResource.NestedDeleteExceptionErrorMessage,
                        catergory.Name));

                db.FoodCategories.Remove(catergory);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }

}
