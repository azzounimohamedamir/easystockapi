using FluentValidation;

namespace SmartRestaurant.Application.Users.Commands.Create
{
    public class CreateUserCommandValidation : AbstractValidator<ICreateUserModel>
    {
        public CreateUserCommandValidation()
        {
        }
    }
}