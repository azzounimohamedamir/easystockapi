using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.FoodCategories.Commands.Create
{
    public class CreateFoodCategoryCommandValidation : AbstractValidator<ICreateFoodCategoryModel>
    {
        public CreateFoodCategoryCommandValidation()
        {
            RuleFor(x => x.Alias)
                .MaximumLength(5)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, BaseResource.Name));

            RuleFor(x => x.Name)
                .MaximumLength(256)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));


        }
    }
}
