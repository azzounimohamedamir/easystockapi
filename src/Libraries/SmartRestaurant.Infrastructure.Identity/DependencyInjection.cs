using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Infrastructure.Identity.Persistence;

namespace SmartRestaurant.Infrastructure.Identity
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(IdentityDbContext).Assembly.FullName)));
            services.AddScoped<IIdentityDbContext>(provider => provider.GetService<IdentityDbContext>());

            return services;
        }
    }
}