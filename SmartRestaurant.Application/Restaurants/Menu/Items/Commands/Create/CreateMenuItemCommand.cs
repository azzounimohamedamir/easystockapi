using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Create;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Factory;
using System;

namespace SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Create
{
    public interface ICreateMenuItemCommand
    {
        void Execute(CreateMenuItemModel model);
    }
    public class CreateMenuItemCommand : ICreateMenuItemCommand
    {
        public CreateMenuItemCommand(
            ISmartRestaurantDatabaseService db,
            ILoggerService<CreateMenuItemCommand> logger,
            IMailingService mailingService,
            INotifyService notifyService,
            ICreateMenuItemFactory createDishFactory,
            ICreateGalleryForMenuItemCommand createGalleryForMenuItemCommand)
        {

        }

        public void Execute(CreateMenuItemModel model)
        {
            try
            {
                var validator = new CreateMenuItemModelValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
