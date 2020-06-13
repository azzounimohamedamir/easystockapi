using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Restaurants.Tables.Commands.Delete
{
    public class DeleteTableCommandValidation : AbstractValidator<DeleteTableModel>
    {
        public DeleteTableCommandValidation()
        {
            RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Id));

        }
    }
}