using FluentValidation;
using SmartRestaurant.Resources.Restaurants.Restaurants;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Products.ProductFamilies.Commands.Create
{
    public class CreateProductFamilyCommandValidation : AbstractValidator<ICreateProductFamilyModel>
    {
        public CreateProductFamilyCommandValidation()
        {
            RuleFor(x => x.Alias)
              .MaximumLength(5)
              .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));
            RuleFor(x => x.Name)
                .MaximumLength(256)
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));
            RuleFor(x => x.RestaurantId)
           .NotEmpty()
           .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, RestaurantResource.Restaurant));
        }
    }
}