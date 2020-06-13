using FluentValidation;
using SmartRestaurant.Application.MailingUsers.Queries;

namespace SmartRestaurant.Application.MailingUsers.Commands.Delete
{
    internal class DeleteMailingUserCommandValidation:AbstractValidator<MailingUserItem>
    {
        public DeleteMailingUserCommandValidation()
        {
        }
    }
}