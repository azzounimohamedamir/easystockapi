using FluentValidation;
using SmartRestaurant.Application.Restaurants.Menu.Commands.Models;

namespace SmartRestaurant.Application.Restaurants.Menu.Commands.Create
{
    public class CreateMenuValidator: AbstractValidator<MenuModel>
    {
        public CreateMenuValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.RestaurantId).NotEmpty();
        }
    }
}
