using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Restaurants.Restaurants;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Pricings.Tarifications.Commands.Update
{
    public class UpdateTarificationCommandValidation:AbstractValidator<IUpdateTarificationModel>
    {
        public UpdateTarificationCommandValidation()
        {
            RuleFor(x => x.Id)
        .NotEmpty()
        .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Id));
            RuleFor(x => x.Alias)
               .MaximumLength(5)
               .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));
            RuleFor(x => x.Name)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Name));

            RuleFor(x => x.Name)
                .MaximumLength(256)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));

            RuleFor(x => x.RestaurantId)
           .NotEmpty()
           .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, RestaurantResource.Restaurant));
        }
    }
}