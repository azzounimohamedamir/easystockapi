using FluentValidation;
using SmartRestaurant.Resources.Restaurants.Areas;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Restaurants.Tables.Commands.Create
{
    public class CreateTableCommandValidation : AbstractValidator<ICreateTableModel>
    {
        public CreateTableCommandValidation()
        {
            RuleFor(x => x.Alias)
              .MaximumLength(5)
              .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));
            RuleFor(x => x.Name)
                .MaximumLength(256)
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));
            RuleFor(x => x.AreaId)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, AreaResource.Area));

        }
    }
}