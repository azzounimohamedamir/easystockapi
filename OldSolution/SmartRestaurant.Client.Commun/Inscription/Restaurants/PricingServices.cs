#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Pricings.Tarifications.Commands.Create;
using SmartRestaurant.Application.Pricings.Tarifications.Commands.Delete;
using SmartRestaurant.Application.Pricings.Tarifications.Commands.Update;
using SmartRestaurant.Application.Pricings.Tarifications.Queries.GetAll;
using SmartRestaurant.Application.Pricings.Tarifications.Queries.GetById;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Restaurants
{
    public static class PricingServices
    {
        public static IServiceCollection AddTarificationServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateTarificationCommand, CreateTarificationCommand>();
            services.AddScoped<IUpdateTarificationCommand, UpdateTarificationCommand>();
            services.AddScoped<IDeleteTarificationCommand, DeleteTarificationCommand>();

            services.AddScoped<IGetTarificationByIdQuery, GetTarificationByIdQuery>();
            services.AddScoped<IGetTarificationsByRestaurantIdQuery, GetTarificationsByRestaurantIdQuery>();

            return services;
        }
    }
}
