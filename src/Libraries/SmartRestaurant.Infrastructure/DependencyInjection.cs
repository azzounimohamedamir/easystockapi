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
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5, // Number of retry attempts
                            maxRetryDelay: TimeSpan.FromSeconds(30), // Max delay between retries
                            errorNumbersToAdd: null // List of error numbers to consider for retry
                        );
                    }
                ).EnableSensitiveDataLogging(false)); // Disable sensitive data logging

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IEmailSender, EmailHelper>();

            return services;
        }
    }
}
