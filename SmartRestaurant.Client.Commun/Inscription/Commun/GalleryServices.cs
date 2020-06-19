using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Create;
using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Factory;
using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Update;

namespace SmartRestaurant.Client.Commun.Inscription.Commun
{
    public static class GalleryServices
    {
        public static IServiceCollection AddGalleryServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateGalleryForDishCommand, CreateGalleryForDishCommand>();
            services.AddScoped<IUpdateGalleryForDishCommand, UpdateGalleryForDishCommand>();
            services.AddScoped<IGalleryForDishFactory, GalleryForDishFactory>();
            services.AddScoped<IGalleryFactory, GalleryFactory>();//IGalleryPictureFactory
            services.AddScoped<IGalleryPictureFactory, GalleryPictureFactory>();
            services.AddScoped<IGalleryPictureForDishFactory, GalleryPictureForDishFactory>();
            services.AddScoped<IGalleryModelFactory, GalleryModelFactory>();
            services.AddScoped<IGalleryPictureModelFactory, GalleryPictureModelFactory>();
            return services;
        }
    }
}
