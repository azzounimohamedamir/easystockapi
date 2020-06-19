using FluentValidation;
using SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Validations;

namespace SmartRestaurant.Application.Restaurants.Menu.Items.Commands.Create
{
    public class CreateMenuItemModelValidation : AbstractValidator<CreateMenuItemModel>
    {
        public CreateMenuItemModelValidation()
        {
            RuleFor(x => x.MenuItemModel).SetValidator(new MenuItemModelValidation());
        }
    }
}