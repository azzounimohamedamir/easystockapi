using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Products.ProductFamilies;
using SmartRestaurant.Resources.Products.Products;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Products.Products.Commands.Create
{
    public class CreateProductCommandValidation : AbstractValidator<ICreateProductModel>
    {
        public CreateProductCommandValidation()
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
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256")); RuleFor(x => x.ProductFamilyId)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, ProductFamilyResource.ProductFamily));
        }
    }
}