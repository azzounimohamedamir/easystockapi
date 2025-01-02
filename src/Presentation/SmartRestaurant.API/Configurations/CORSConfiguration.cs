using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SmartRestaurant.API.Configurations
{
    public static class CORSConfiguration
    {
        public static void AddCORSConfiguation(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowOrigin", builder =>
            //    {
            //        builder.WithOrigins("http://smartrestaurant.io", "https://smartrestaurant.io")
            //            .AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            //    });
            //});
        }

        public static void UseCORS(IApplicationBuilder app)
        {
            app.UseCors("AllowAll");
        }
    }
}