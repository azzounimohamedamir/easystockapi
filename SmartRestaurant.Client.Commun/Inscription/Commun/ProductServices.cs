#region using
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Products.ProductFamilies.Commands.Create;
using SmartRestaurant.Application.Products.ProductFamilies.Commands.Delete;
using SmartRestaurant.Application.Products.ProductFamilies.Commands.Update;
using SmartRestaurant.Application.Products.ProductFamilies.Queries.GetById;
using SmartRestaurant.Application.Products.ProductFamilies.Queries.GetByRestaurantId;
using SmartRestaurant.Application.Products.Products.Commands.Create;
using SmartRestaurant.Application.Products.Products.Commands.Delete;
using SmartRestaurant.Application.Products.Products.Commands.Update;
using SmartRestaurant.Application.Products.Products.Queries.GetByFamilyId;
using SmartRestaurant.Application.Products.Products.Queries.GetById;
#endregion

namespace SmartRestaurant.Client.Commun.Inscription.Commun
{
    public static class ProductServices
    {
        public static IServiceCollection AddProductFamilyServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateProductFamilyCommand, CreateProductFamilyCommand>();
            services.AddScoped<IUpdateProductFamilyCommand, UpdateProductFamilyCommand>();
            services.AddScoped<IDeleteProductFamilyCommand, DeleteProductFamilyCommand>();

            services.AddScoped<IGetProductFamilyByIdQuery, GetProductFamilyByIdQuery>();
            services.AddScoped<IGetProductFamiliesByRestaurantIdQuery, GetProductFamiliesByRestaurantIdQuery>();

            return services;
        }
        public static IServiceCollection AddProductServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateProductCommand, CreateProductCommand>();
            services.AddScoped<IUpdateProductCommand, UpdateProductCommand>();
            services.AddScoped<IDeleteProductCommand, DeleteProductCommand>();

            services.AddScoped<IGetProductByIdQuery, GetProductByIdQuery>();
            services.AddScoped<IGetProductByProductFamilyIdQuery, GetProductByProductFamilyIdQuery>();

            return services;
        }
    }
}
