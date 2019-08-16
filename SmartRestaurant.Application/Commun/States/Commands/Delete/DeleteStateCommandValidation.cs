using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Commun.State.Commands.Delete
{
    public class DeleteStateCommandValidation : AbstractValidator<DeleteStateModel>
    {
        public DeleteStateCommandValidation()
        {
            RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage,
             BaseResource.Id));
        }
    }
}