#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Commun.Translates.Commands.Create;
using SmartRestaurant.Application.Commun.Translates.Commands.Delete;
using SmartRestaurant.Application.Commun.Translates.Commands.Update;
using SmartRestaurant.Application.Commun.Translates.Queries.GetByTableName;

#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Translates
{
    public static class TranslateServices
    {
        public static IServiceCollection AddTranslateServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateTranslateCommand, CreateTranslateCommand>();
            services.AddScoped<IUpdateTranslateCommand, UpdateTranslateCommand>();
            services.AddScoped<IDeleteTranslateCommand, DeleteTranslateCommand>();

            services.AddScoped<IGetTranslatesByTableNameQuery, GetTranslatesByTableNameQuery>();

            return services;
        }
    }
}
