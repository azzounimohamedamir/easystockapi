using MediatR;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Identity.Entities;

namespace SmartRestaurant.Application.Accounts.Commands
{
    public class SendEmailConfirmationCommand : IRequest<NoContent>
    {
        public ApplicationUser User { get; set; }
        public string token { get; set; }
    }
}
