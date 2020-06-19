using FluentValidation;
using SmartRestaurant.Application.MailingUsers.Queries;

namespace SmartRestaurant.Application.MailingUsers.Commands.Create
{
    public class CreateMailingUserCommandValidation: AbstractValidator<MailingUserItem>
    {
        public CreateMailingUserCommandValidation()
        {
        }
    }
}