using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Delete
{
    public class DeleteRestaurantTypeCommandValidation:AbstractValidator<DeleteRestaurantTypeModel>
    {
        public DeleteRestaurantTypeCommandValidation()
        {
            RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Id));

        }
    }
}