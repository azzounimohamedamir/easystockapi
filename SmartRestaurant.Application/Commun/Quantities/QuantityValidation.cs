using FluentValidation;
using SmartRestaurant.Resources.Commun.Quantity;
using SmartRestaurant.Resources.Commun.Unit;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Commun.Quantities
{
    public class QuantityValidation : AbstractValidator<IQuantityModel>
    {
        public QuantityValidation()
        {
            RuleFor(x => x.UnitId)
              .NotEmpty()
              .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, UnitResource.Unite));

            RuleFor(x => x.UnitId)
              .NotNull()
              .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, UnitResource.Unite));

            RuleFor(x => x.Value)
                          .NotEmpty()
                          .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, QuantityResource.Quantity));
        }
    }
}
