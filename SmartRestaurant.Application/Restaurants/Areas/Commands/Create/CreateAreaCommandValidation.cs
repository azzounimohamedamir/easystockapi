using FluentValidation;
using SmartRestaurant.Resources.Restaurants.Floors;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Restaurants.Areas.Commands.Create
{
    public class CreateAreaCommandValidation : AbstractValidator<ICreateAreaModel>
    {
        public CreateAreaCommandValidation()
        {
            RuleFor(x => x.Alias)
                 .MaximumLength(5)
                 .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));
            RuleFor(x => x.Name)
                .MaximumLength(256)
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));
            RuleFor(x => x.FloorId)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, FloorResource.Floor));

        }
    }
}