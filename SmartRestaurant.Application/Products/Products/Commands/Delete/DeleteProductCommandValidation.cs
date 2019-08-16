using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Products.Products.Commands.Delete
{
    public class DeleteProductCommandValidation : AbstractValidator<DeleteProductModel>
    {
        public DeleteProductCommandValidation()
        {
            RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage,
             BaseResource.Id));

        }
    }
}