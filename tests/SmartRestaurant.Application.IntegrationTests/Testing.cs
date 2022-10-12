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
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Identity.Entities;
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
            httpContext.Request.Headers.Add("Accept-Language", "en");

            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.EnvironmentName == "Development" &&
                w.ApplicationName == "SmartRestaurant.API"));
            services.AddLogging();
            services.AddHttpContextAccessor();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton(Mock.Of<IHttpContextAccessor>(o =>
                o.HttpContext.User == httpContext.User &&
                o.HttpContext.Request.Headers == httpContext.Request.Headers
            )); 
            startup.ConfigureServices(services);

            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new[] {"__EFMigrationsHistory"}
            };

            _checkpointIdentity = new Checkpoint
            {
                TablesToIgnore = new[] {"__EFMigrationsHistory"}
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

        public static async Task<Dish> GetDish(Guid dishId)
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            return await context.Set<Dish>()
                 .Include(x => x.Ingredients)
                 .ThenInclude(x => x.Ingredient)
                 .Include(x => x.Supplements)
                 .ThenInclude(x => x.Supplement)
                 .Include(x => x.Specifications)
                 .ThenInclude(x=>x.ComboBoxContentTranslation)
                 .Where(u => u.DishId == dishId)
                 .FirstOrDefaultAsync()
                 .ConfigureAwait(false); 
        }

        public static async Task<Domain.Entities.Illness> GetIllness(Guid illnessId)
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            return await context.Set<Domain.Entities.Illness>()
                 .Include(x => x.IngredientIllnesses)
                 .ThenInclude(x => x.Ingredient)
                 .Where(u => u.IllnessId == illnessId)
                 .FirstOrDefaultAsync()
                 .ConfigureAwait(false);
        }

       public static async Task<List<string>> GetUsers(string email)
        {
            using var scope = _scopeFactory.CreateScope();
            var identitecontext = scope.ServiceProvider.GetService<IdentityContext>();
            var userids = identitecontext.ApplicationUser.Where(u => u.Email == email).Select(x =>x.Id).ToList();
            return userids;
        }


        public static async Task<bool> GetHotelByIdUser(List<string> idusers,Guid hotelid)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            var hoteluser = await context.hotelUsers
              .Where(u => u.HotelId == hotelid && idusers.Contains(u.ApplicationUserId))
              .FirstOrDefaultAsync()
              .ConfigureAwait(false);
            return hoteluser != null;
        }

        public static async Task<Order> GetOrder(Guid orderId)
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            return await context.Set<Order>()
                    .Include(o => o.FoodBusiness)
                    .Include(o => o.FoodBusinessClient)
                    .Include(o => o.Dishes)
                    .ThenInclude(o => o.Specifications)
                    .ThenInclude(o=>o.ComboBoxContentTranslation)
                    .Include(o => o.Dishes)
                    .ThenInclude(o => o.Ingredients)
                    .Include(o => o.Dishes)
                    .ThenInclude(o => o.Supplements)
                    .Include(o => o.Products)
                    .Include(o => o.OccupiedTables)
                    .Where(o => o.OrderId == orderId)
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false);
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