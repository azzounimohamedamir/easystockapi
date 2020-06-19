using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Dishes.DishFamily;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Dishes.DishFamillies.Commands.Create
{
    public class CreateDishFamilyModelValidation : AbstractValidator<ICreateDishFamilyModel>
    {
        public CreateDishFamilyModelValidation()
        {
            RuleFor(x => x.Alias)
                .MaximumLength(5)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));

            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, BaseResource.Name));

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, BaseResource.Name));

            RuleFor(x => x.Name)
                .MaximumLength(256)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));

            RuleFor(x => x.Description)
               .MaximumLength(380)
               .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "380"));

            RuleFor(x => x.RestaurantId)
               .NotEmpty()
               .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, DishFamilyResource.RestaurantId));

            RuleFor(x => x.RestaurantId)
                .NotNull()
                .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, DishFamilyResource.RestaurantId));

        }
    }
}
