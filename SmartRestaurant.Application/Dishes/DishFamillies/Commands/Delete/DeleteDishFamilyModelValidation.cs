using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Dishes.DishFamillies.Commands.Delete
{
    public class DeleteDishFamilyModelValidation : AbstractValidator<DeleteDishFamilyModel>
    {
        public DeleteDishFamilyModelValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Id));
        }
    }
}
