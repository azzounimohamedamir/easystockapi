#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Allergies.Illnesses.Commands.Create;
using SmartRestaurant.Application.Allergies.Illnesses.Commands.Delete;
using SmartRestaurant.Application.Allergies.Illnesses.Commands.Update;
using SmartRestaurant.Application.Allergies.Illnesses.Queries;
using SmartRestaurant.Application.Allergies.Illnesses.Queries.GetAll;
using SmartRestaurant.Application.Allergies.Illnesses.Queries.GetById;
using SmartRestaurant.Application.Allergies.Illnesses.Queries.GetBySpesification;
using SmartRestaurant.Application.Allergies.Illnesses.Services;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Commun
{
    public static class IllnessServices
    {
        public static IServiceCollection AddIllnessServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateIllnessCommand, CreateIllnessCommand>();
            services.AddScoped<IUpdateIllnessCommand, UpdateIllnessCommand>();
            services.AddScoped<IDeleteIllnessCommand, DeleteIllnessCommand>();

            services.AddScoped<IGetIllnessesBySpecificationQuery, GetIllnessesBySpecificationQuery>();
            services.AddScoped<IGetAllIllnessesQuery, GetAllIllnessesQuery>();
            services.AddScoped<IGetIllnessByIdQuery, GetIllnessByIdQuery>();
            services.AddScoped<IIllnessQueries, IllnessQueries>();
            services.AddScoped<IIllnessService, IllnessService>();

            return services;
        }
    }
}
