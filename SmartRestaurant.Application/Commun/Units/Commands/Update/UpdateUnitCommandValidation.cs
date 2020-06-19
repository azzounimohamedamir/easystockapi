using FluentValidation;

namespace SmartRestaurant.Application.Commun.Units.Commands.Update
{
    public class UpdateUnitCommandValidation : AbstractValidator<IUpdateUnitModel>
    {

        public UpdateUnitCommandValidation()
        {
            RuleFor(x => x.Name).MaximumLength(50).NotEmpty().WithMessage("Name Is Requiered");
            RuleFor(x => x.Symbol).MaximumLength(15).WithMessage("Symbol must contain at least 5 Characters ");
            RuleFor(x => x.Alias).MaximumLength(5).WithMessage("Alias must contain at least 5 Characters ");

        }
    }
}
