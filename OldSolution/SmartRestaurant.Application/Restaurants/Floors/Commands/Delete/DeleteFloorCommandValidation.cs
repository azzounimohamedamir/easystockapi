using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Restaurants.Floors.Commands.Delete
{
    public class DeleteFloorCommandValidation : AbstractValidator<DeleteFloorModel>
    {
        public DeleteFloorCommandValidation()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Id));

        }
    }
}