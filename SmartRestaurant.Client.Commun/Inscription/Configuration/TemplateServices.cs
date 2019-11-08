#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Templates.Commands.Create;
using SmartRestaurant.Application.Templates.Commands.Delete;
using SmartRestaurant.Application.Templates.Commands.Factory;
using SmartRestaurant.Application.Templates.Commands.Update;
using SmartRestaurant.Application.Templates.Queries.GetTemplateById;
using SmartRestaurant.Application.Templates.Queries.GetTemplateItems;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Configuration
{
    public static class TemplateServices
    {
        public static IServiceCollection AddTemplateServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateTemplateFactory, CreateTemplateFactory>();
            services.AddScoped<ICreateTemplateCommand, CreateTemplateCommand>();
            services.AddScoped<IUpdateTemplateCommand, UpdateTemplateCommand>();
            services.AddScoped<IDeleteTemplateCommand, DeleteTemplateCommand>();
            //services.AddScoped<ISelectTemplateQuery, SelectCountryQuery>();
            services.AddScoped<IGetAllTemplateQuerie, GetAllTemplateQuerie>();
            services.AddScoped<IGetTemplateByIdQuerie, GetTemplateByIdQuerie>();

            return services;
        }


    }
}
