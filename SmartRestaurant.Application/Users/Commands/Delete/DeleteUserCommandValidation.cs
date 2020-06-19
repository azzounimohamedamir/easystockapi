using FluentValidation;

namespace SmartRestaurant.Application.Users.Commands.Delete
{
    public class DeleteUserCommandValidation : AbstractValidator<IDeleteUserModel>
    {
        public DeleteUserCommandValidation()
        {
        }
    }
}