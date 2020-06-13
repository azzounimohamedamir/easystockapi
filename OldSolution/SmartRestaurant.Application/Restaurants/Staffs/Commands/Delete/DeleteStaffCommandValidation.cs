using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Restaurants.Staffs.Commands.Delete
{
    public class DeleteStaffCommandValidation:AbstractValidator<DeleteStaffModel>
    {
        public DeleteStaffCommandValidation()
        {
            RuleFor(x => x.Id)
           .NotEmpty()
           .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage, BaseResource.Id));

        }
    }
}