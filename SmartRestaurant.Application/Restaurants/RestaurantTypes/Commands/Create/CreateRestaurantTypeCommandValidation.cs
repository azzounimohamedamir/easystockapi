using FluentValidation;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Create
{
    public class CreateRestaurantTypeCommandValidation : AbstractValidator<ICreateRestaurantTypeModel>
    {
        public CreateRestaurantTypeCommandValidation()
        {
            RuleFor(x => x.Alias)
               .MaximumLength(5)
               .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));
            RuleFor(x => x.Name)
                .MaximumLength(256)
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));

        }
    }
}