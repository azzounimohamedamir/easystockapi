using FluentValidation;
using SmartRestaurant.Application.Commun.Units.Commands.Create;
using SmartRestaurant.Resources.Commun.City;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Commun.Units.Commands.Create
{
    public class CreateUnitCommandValidation : AbstractValidator<ICreateUnitModel>
    {

        public CreateUnitCommandValidation()
        {
            RuleFor(x => x.Name)
                .MaximumLength(50)
                .NotEmpty()
                .WithMessage(string.Format
                (SharedValidationResource.RequiredErrorMessage,
                CityResource.Name));

            RuleFor(x => x.Symbol)
                .MaximumLength(15)
                .WithMessage("Symbol must contain at least 15 Characters ");

            RuleFor(x => x.Alias)
                .MaximumLength(5)
                .WithMessage("Alias must contain at least 5 Characters ");

        }
    }
}
