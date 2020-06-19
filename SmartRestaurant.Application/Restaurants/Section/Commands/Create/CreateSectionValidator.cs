using FluentValidation;
using SmartRestaurant.Application.Restaurants.Section.Commands.Models;

namespace SmartRestaurant.Application.Restaurants.Section.Commands.Create
{
    public class CreateSectionValidator: AbstractValidator<SectionModel>
    {
        public CreateSectionValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.RestaurantId).NotEmpty();
            RuleFor(x => x.MenuId).NotEmpty();
        }
    }
}
