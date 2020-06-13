#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.MailingUsers.Commands.Create;
using SmartRestaurant.Application.MailingUsers.Commands.Delete;
using SmartRestaurant.Application.MailingUsers.Queries.GetMailingUserByMailingId;
using SmartRestaurant.Application.MailingUsers.Queries.GetMailingUserItems;
using SmartRestaurant.Application.MailingUsers.Queries.GetMailingUsersByUserId;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Configuration
{
    public static class MailingUserServices
    {
        public static IServiceCollection AddMailingUserServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateMailingUserCommand, CreateMailingUserCommand>();
            services.AddScoped<IDeleteMailingUserCommand, DeleteMailingUserCommand>();
            
            services.AddScoped<IGetMailingUserByMailingIdQuery, GetMailingUserByMailingIdQuery>();
            services.AddScoped<IGetMailingUserByUserIdQuery, GetMailingUserByUserIdQuery>();
            services.AddScoped<IGetMailingUserItemsQuerie, GetMailingUserItemsQuerie>();

            return services;
        }
    }
}
