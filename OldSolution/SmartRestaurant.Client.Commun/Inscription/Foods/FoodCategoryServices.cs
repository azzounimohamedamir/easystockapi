#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.FoodCategories.Commands;
using SmartRestaurant.Application.FoodCategories.Commands.Delete;
using SmartRestaurant.Application.FoodCategories.Commands.Update;
using SmartRestaurant.Application.FoodCategories.Queries.GetAll;
using SmartRestaurant.Application.FoodCategories.Queries.GetById;
using SmartRestaurant.Application.FoodCategories.Services;
using SmartRestaurant.Application.Foods.FoodCategories.Queries;
using SmartRestaurant.Application.Foods.FoodCategories.Queries.GetBySpecification;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Foods
{
    public static class FoodCategoryServices
    {
        public static IServiceCollection AddFoodCategoryServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateFoodCategoryCommand, CreateFoodCategoryCommand>();
            services.AddScoped<IUpdateFoodCategoryCommand, UpdateFoodCategoryCommand>();
            services.AddScoped<IDeleteFoodCatergoryCommand, DeleteFoodCatergoryCommand>();
            services.AddScoped<IFoodCategoryQueries, FoodCategoryQueries>();

            services.AddScoped<IGetAllFoodCategoriesQuery, GetAllFoodCategoriesQuery>();
            services.AddScoped<IGetFoodCategoryByIdQuery, GetFoodCategoryByIdQuery>();
            services.AddScoped<IGetFoodCategoryBySpecificationQuery, GetFoodCategoryBySpecificationQuery>();

            services.AddScoped<IFoodCategoryService, FoodCategoryService>();

            return services;
        }
    }
}
