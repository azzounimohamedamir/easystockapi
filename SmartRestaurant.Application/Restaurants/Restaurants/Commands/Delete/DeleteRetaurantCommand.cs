using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Application.Restaurants.Restaurants.Commands.Delete
{


    public interface IDeleteRestaurantCommand
    {
        void Execute(DeleteRestaurantModel model);
    }

    public class DeleteRestaurantCommand : IDeleteRestaurantCommand
    {
        private readonly ILoggerService<DeleteRestaurantCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteRestaurantCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteRestaurantCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteRestaurantModel model)
        {
            try
            {
                var validator = new DeleteRestaurantCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var guid = model.Id.ToGuid();
                var restaurant = db.Restaurants.FirstOrDefault(x => x.Id == guid);
                if (restaurant == null)
                {
                    throw new NotFoundException(nameof(Restaurant));
                }

                if (db.Floors.Any(x => x.RestaurantId == guid))
                {
                    throw new DeleteFailureException(nameof(Restaurant) + model.Id);
                }

                db.Restaurants.Remove(restaurant);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
