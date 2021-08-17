using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Respawn;
using SmartRestaurant.API;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Identity.Enums;
using SmartRestaurant.Infrastructure.Identity.Persistence;
using SmartRestaurant.Infrastructure.Identity.Services;
using SmartRestaurant.Infrastructure.Persistence;

namespace SmartRestaurant.Application.IntegrationTests
{
    [SetUpFixture]
    public class Testing
    {
        private static IConfigurationRoot _configuration;
        private static IServiceScopeFactory _scopeFactory;
        private static Checkpoint _checkpoint;
        public static string _authenticatedUserId = "3cbf3570-4444-4444-8746-29b7cf568898";
        public static string _defaultRole = Roles.FoodBusinessAdministrator.ToString();
        private static Checkpoint _checkpointIdentity;

        [OneTimeSetUp] 
         public void RunBeforeAnyTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            var startup = new Startup(_configuration);

            var services = new ServiceCollection();

            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, "test user name"));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, _authenticatedUserId));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, _defaultRole));
            var claimsPrincipal = new ClaimsPrincipal(new[] {claimsIdentity});

            var httpContext = new DefaultHttpContext {User = claimsPrincipal};

            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.EnvironmentName == "Development" &&
                w.ApplicationName == "SmartRestaurant.API"));
            services.AddLogging();
            services.AddHttpContextAccessor();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton(Mock.Of<IHttpContextAccessor>(o =>
                o.HttpContext.User == httpContext.User
            ));
            startup.ConfigureServices(services);

            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new[] {"__EFMigrationsHistory"}
            };

            _checkpointIdentity = new Checkpoint
            {
                TablesToIgnore = new[] { "__EFMigrationsHistory" }
            };
            EnsureDatabase();
        }

        private static void EnsureDatabase()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();

            using var scopeIdentity = _scopeFactory.CreateScope();
            var identityContext = scopeIdentity.ServiceProvider.GetService<IdentityContext>();
            identityContext.Database.Migrate();
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<IMediator>();

            return await mediator.Send(request).ConfigureAwait(false);
        }

        public static async Task ResetState()
        {
            await _checkpoint.Reset(_configuration.GetConnectionString("DefaultConnection"));
            await _checkpointIdentity.Reset(_configuration.GetConnectionString("IdentityConnection"));
        }

        public static async Task<TEntity> FindAsync<TEntity>(Guid id)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            return await context.FindAsync<TEntity>(id);
        }

        public static async Task<List<TEntity>> GetAll<TEntity>()
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            return await context.Set<TEntity>().ToListAsync();
        }

        public static List<TEntity> Where<TEntity>(Func<TEntity, bool> predicate) where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            return context.Set<TEntity>().Where(predicate).ToList();
        }

        public static async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Add(entity);

            await context.SaveChangesAsync();
        }

        public static async Task AddIdentityAsync<TEntity>(TEntity entity)
           where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<IdentityContext>();

            context.Add(entity);

            await context.SaveChangesAsync();
        }

        public static async Task<TEntity> FindIdentityAsync<TEntity>(object[] id)
           where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<IdentityContext>();

            return await context.FindAsync<TEntity>(id);
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
}