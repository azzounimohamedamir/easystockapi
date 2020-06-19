#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Commun.Languages.Commands.Create;
using SmartRestaurant.Application.Commun.Languages.Commands.Delete;
using SmartRestaurant.Application.Commun.Languages.Commands.Update;
using SmartRestaurant.Application.Commun.Languages.Factory;
using SmartRestaurant.Application.Commun.Languages.Queries.GetLanguageById;
using SmartRestaurant.Application.Commun.Languages.Queries.GetLanguageByName;
using SmartRestaurant.Application.Commun.Languages.Queries.GetLanguagesList;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Commun
{
    public static class LanguageServices
    {
        public static IServiceCollection AddLanguageServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateLanguageCommand, CreateLanguageCommand>();
            services.AddScoped<IUpdateLanguageCommand, UpdateLanguageCommand>();
            services.AddScoped<IDeleteLanguageCommand, DeleteLanguageCommand>();
            
            services.AddScoped<ICreateLanguageFactory, CreateLanguageFactory>();

            services.AddScoped<IGetAllLanguagesQuerie, GetAllLanguagesQuerie>();
            services.AddScoped<IGetLanguageByIdQuerie, GetLanguageByIdQuerie>();
            services.AddScoped<IGetLanguageByNameQuerie, GetLanguageByNameQuerie>();

            return services;
        }

    }
}
