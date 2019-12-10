using FluentValidation;
using SmartRestaurant.Application.Restaurants.Menu.Commands.Models;

namespace SmartRestaurant.Application.Restaurants.Menu.Commands.Update
{
    public class updateMenuValidator: AbstractValidator<MenuModel>
    {
        public updateMenuValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.RestaurantId).NotEmpty();
        }
    }
}
