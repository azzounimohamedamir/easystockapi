using FluentValidation;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Update;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.Restaurants.Restaurants;
using SmartRestaurant.Resources.Restaurants.Staffs;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Restaurants.Restaurants.Commands.Create
{
    public class CreateRestaurantCommandValidation : AbstractValidator<ICreateRestaurantModel>
    {
        public CreateRestaurantCommandValidation()
        {
            RuleFor(x => x.Alias)
               .MaximumLength(5)
               .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));

            RuleFor(x => x.Name)                
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage,BaseResource.Name));

            RuleFor(x => x.Name)
               .MaximumLength(256)               
               .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));


            RuleFor(x => x.OwnerId)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, StaffResource.Owner));

            RuleFor(x => x.RestaurantTypeId)
            .NotEmpty()
            .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, RestaurantResource.Restaurant));

            //RuleFor(x => x.AddressModel.Country)
            //   .NotEmpty()
            //   .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, RestaurantResource.Address_Country));

        }
    }
}