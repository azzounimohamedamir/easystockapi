using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Commun.Units.Commands.Delete
{
    public class DeleteUnitCommandValidation: AbstractValidator<DeleteUnitModel>
    {
        public DeleteUnitCommandValidation()
        {
            RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage,
             BaseResource.Id));
        }
    }
}