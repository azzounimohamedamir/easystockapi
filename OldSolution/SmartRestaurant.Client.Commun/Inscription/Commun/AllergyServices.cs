#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Allergies.Allergies.Commands.Create;
using SmartRestaurant.Application.Allergies.Allergies.Commands.Delete;
using SmartRestaurant.Application.Allergies.Allergies.Commands.Update;
using SmartRestaurant.Application.Allergies.Allergies.Queries;
using SmartRestaurant.Application.Allergies.Allergies.Queries.GetAll;
using SmartRestaurant.Application.Allergies.Allergies.Queries.GetById;
using SmartRestaurant.Application.Allergies.Allergies.Queries.GetBySpecification;
using SmartRestaurant.Application.Allergies.Allergies.Services;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Commun
{
    public static class AllergyServices
    {
        public static IServiceCollection AddAllergyServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateAllergyCommand, CreateAllergyCommand>();
            services.AddScoped<IUpdateAllergyCommand, UpdateAllergyCommand>();
            services.AddScoped<IDeleteAllergyCommand, DeleteAllergyCommand>();

            services.AddScoped<IGetAllergiesBySpecificationQuery, GetAllergiesBySpecificationQuery>();
            services.AddScoped<IGetAllAllergiesQuery, GetAllAllergiesQuery>();
            services.AddScoped<IGetAllergyByIdQuery, GetAllergyByIdQuery>();
            services.AddScoped<IAllergyQueries, AllergyQueries>();
            services.AddScoped<IAllergyService, AllergyService>();

            return services;
        }
    }
}
