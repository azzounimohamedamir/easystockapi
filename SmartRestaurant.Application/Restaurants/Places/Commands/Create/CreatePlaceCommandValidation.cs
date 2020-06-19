using FluentValidation;
using SmartRestaurant.Resources.Restaurants.Tables;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Restaurants.Places.Commands.Create
{
    public class CreatePlaceCommandValidation : AbstractValidator<ICreatePlaceModel>
    {
        public CreatePlaceCommandValidation()
        {
            RuleFor(x => x.Alias)
              .MaximumLength(5)
              .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));
            RuleFor(x => x.Name)
                .MaximumLength(256)
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));
            RuleFor(x => x.TableId)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, TableResource.Table));

        }
    }
}