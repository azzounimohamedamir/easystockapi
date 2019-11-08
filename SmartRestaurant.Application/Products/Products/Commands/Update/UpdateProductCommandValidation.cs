using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Products.ProductFamilies;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Products.Products.Commands.Update
{
    public class UpdateProductCommandValidation:AbstractValidator<IUpdateProductModel>
    {
        public UpdateProductCommandValidation()
        {
            RuleFor(x => x.Id)
              .NotEmpty()
              .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Id));
            RuleFor(x => x.Alias)
               .MaximumLength(5)
               .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));
            RuleFor(x => x.Name)
                .MaximumLength(256)
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));
            RuleFor(x => x.ProductFamilyId)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, ProductFamilyResource.ProductFamily));
        }
    }
}