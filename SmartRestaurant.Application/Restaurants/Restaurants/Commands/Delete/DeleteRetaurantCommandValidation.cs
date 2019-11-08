using FluentValidation;

namespace SmartRestaurant.Application.Restaurants.Restaurants.Commands.Delete
{
    internal class DeleteRestaurantCommandValidation : AbstractValidator<DeleteRestaurantModel>
    {
        public DeleteRestaurantCommandValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("");
        }
    }
}