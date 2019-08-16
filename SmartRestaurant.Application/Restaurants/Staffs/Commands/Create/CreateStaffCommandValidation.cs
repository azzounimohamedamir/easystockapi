using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Restaurants.Owners;
using SmartRestaurant.Resources.Restaurants.Restaurants;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Restaurants.Staffs.Commands.Create
{
    public class CreateStaffCommandValidation:AbstractValidator<ICreateStaffModel>
    {
        public CreateStaffCommandValidation()
        {
            RuleFor(x => x.Alias)
              .MaximumLength(5)
              .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));
            RuleFor(x => x.Alias)
    .MaximumLength(5)
    .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));
            RuleFor(x => x.FirstName)
                 .NotNull()
                 .NotEmpty()
                 .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Name));

            RuleFor(x => x.FirstName)
                .MaximumLength(256)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));
            RuleFor(x => x.LastName)
               .NotNull()
               .NotEmpty()
               .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Name));

            RuleFor(x => x.LastName)
                .MaximumLength(256)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));

            RuleFor(x => x.DateOfBirth)
             .NotNull()
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.BirthDate));

            RuleFor(x => x.RestaurantId)
           .NotEmpty()
           .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, RestaurantResource.Restaurant));
        }
    }
}