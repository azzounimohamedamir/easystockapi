using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Restaurants.Tables;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Restaurants.Places.Commands.Update
{
    public class UpdatePlaceCommandValidation : AbstractValidator<IUpdatePlaceModel>
    {
        public UpdatePlaceCommandValidation()
        {
            RuleFor(x => x.Id)
              .NotEmpty()
              .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Id));
            RuleFor(x => x.Alias)
               .MaximumLength(5)
               .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, BaseResource.Name));

            RuleFor(x => x.Name)
                .MaximumLength(256)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));
            RuleFor(x => x.TableId)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, TableResource.Table));

        }
    }
}