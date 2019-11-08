#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Foods.Commands.Create;
using SmartRestaurant.Application.Foods.Commands.Delete;
using SmartRestaurant.Application.Foods.Commands.Update;
using SmartRestaurant.Application.Foods.Foods.Queries.GetByCategoryId;
using SmartRestaurant.Application.Foods.Foods.Services;
using SmartRestaurant.Application.Foods.Queries;
using SmartRestaurant.Application.Foods.Queries.GetAll;
using SmartRestaurant.Application.Foods.Queries.GetById;
using SmartRestaurant.Application.Foods.Queries.GetBySpecification;
using SmartRestaurant.Application.Foods.Services;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Foods
{
    public static class FoodServices
    {
        public static IServiceCollection AddFoodServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateFoodCommand, CreateFoodCommand>();
            services.AddScoped<IUpdateFoodCommand, UpdateFoodCommand>();
            services.AddScoped<IDeleteFoodCommand, DeleteFoodCommand>();
            services.AddScoped<IFoodQueries, FoodQueries>();

            services.AddScoped<IGetAllFoodsQuery, GetAllFoodsQuery>();
            services.AddScoped<IGetFoodByIdQuery, GetFoodByIdQuery>();
            services.AddScoped<IGetFoodsByCategoryIdQuery, GetFoodsByCategoryIdQuery>();
            services.AddScoped<IGetFoodBySpecificationQuery, GetFoodBySpecificationQuery>();

            services.AddScoped<IFoodService, FoodService>();

            return services;
        }
    }
}
