using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.FoodBusinessEmployee.Commands
{
    public class UpdateProfilUserCommand : UpdateCommand
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string[] Roles { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoUrl { get; set; }
    }

    public class UpdateProfilUserCommandValidator : AbstractValidator<UpdateProfilUserCommand>
    {
        public UpdateProfilUserCommandValidator()
        {


            RuleFor(u => u.Id).NotEmpty();






            RuleFor(invitedUser => invitedUser.Roles).NotEmpty();

        }
    }
}