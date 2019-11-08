#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Mails.Commands.Create;
using SmartRestaurant.Application.Mails.Commands.Delete;
using SmartRestaurant.Application.Mails.Commands.Update;
using SmartRestaurant.Application.Mails.Queries.GelMailingItems;
using SmartRestaurant.Application.Mails.Queries.GetMailingById;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Configuration
{
    public static class MailingServices
    {
        public static IServiceCollection AddMailingServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateMailingCommand, CreateMailingCommand>();
            services.AddScoped<IUpdateMailingCommand, UpdateMailCommand>();
            services.AddScoped<IDeleteMailingCommand, DeleteMailingCommand>();
            //services.AddScoped<ISelectCountryQuery, SelectCountryQuery>();
            services.AddScoped<ICreateMailingFactory, CreateMailingFactory>();
            services.AddScoped<IGetAllMailingItemsQuerie, GetAllMailingitemsQuerie>();
            services.AddScoped<IGetMailingByIdQuerie, GetMailingByIdQuerie>();
            return services;
        }


    }
}
