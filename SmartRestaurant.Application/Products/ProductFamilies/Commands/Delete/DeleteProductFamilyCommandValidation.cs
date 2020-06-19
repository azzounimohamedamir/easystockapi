using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Products.ProductFamilies.Commands.Delete
{
    public class DeleteProductFamilyCommandValidation : AbstractValidator<DeleteProductFamilyModel>
    {
        public DeleteProductFamilyCommandValidation()
        {
            RuleFor(x => x.Id)
              .NotEmpty()
              .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Id));
        }
    }
}