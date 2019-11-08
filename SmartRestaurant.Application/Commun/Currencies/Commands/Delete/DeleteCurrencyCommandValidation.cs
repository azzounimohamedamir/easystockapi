using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Commun.Currencies.Commands.Delete
{
    public class DeleteCurrencyCommandValidation : AbstractValidator<DeleteCurrencyModel>
    {
        public DeleteCurrencyCommandValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage,
                BaseResource.Id));
        }
    }
}