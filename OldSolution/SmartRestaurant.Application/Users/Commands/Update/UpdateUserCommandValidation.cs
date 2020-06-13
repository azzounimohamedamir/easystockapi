using FluentValidation;

namespace SmartRestaurant.Application.Users.Commands.Update
{
    public class UpdateUserCommandValidation : AbstractValidator<IUpdateUserModel>
    {
        public UpdateUserCommandValidation()
        {
        }
    }
}