#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Notifications.Commands.Create;
using SmartRestaurant.Application.Notifications.Commands.Delete;
using SmartRestaurant.Application.Notifications.Commands.Factory;
using SmartRestaurant.Application.Notifications.Commands.Update;
using SmartRestaurant.Application.Notifications.Queries.GetNotificationById;
using SmartRestaurant.Application.Notifications.Queries.GetNotificationItems;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Configuration
{
    public static class NotificationServices
    {
        public static IServiceCollection AddNotificationServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateNotificationCommand, CreateNotificationCommand>();
            services.AddScoped<IUpdateNotificationCommand, UpdateNotificationCommand>();
            services.AddScoped<IDeleteNotificationCommand, DeleteNotificationCommand>();
            //services.AddScoped<ISelectCountryQuery, SelectCountryQuery>();
            services.AddScoped<ICreateNotificationFactory, CreateNotificationFactory>();
            services.AddScoped<IGetNotificationItemsQuery, GetNotificationItemsQuerie>();
            services.AddScoped<IGetNotificationByIdQuerie, GetNotificationByIdQuerie>();
            return services;
        }


    }
}
