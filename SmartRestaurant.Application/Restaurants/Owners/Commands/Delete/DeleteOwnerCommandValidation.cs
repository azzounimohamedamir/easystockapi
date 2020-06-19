using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Restaurants.Owners.Commands.Delete
{
    public class DeleteOwnerCommandValidation : AbstractValidator<DeleteOwnerModel>
    {
        public DeleteOwnerCommandValidation()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Id));

        }
    }
}