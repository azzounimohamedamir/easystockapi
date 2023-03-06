using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Infrastructure.Email;
using SmartRestaurant.Infrastructure.Persistence;
using SmartRestaurant.Infrastructure.Services;
using System;

namespace SmartRestaurant.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient < IFirebaseRepository, FirebaseRepository> ();
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<ISaleOrderRepository, OdooSaleOrderRepository>();
            services.AddTransient<IEmailSender, EmailHelper>();
            return services;
        }
    }
}