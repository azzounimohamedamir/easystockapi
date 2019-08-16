using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Persistance.Identity;
using SmartRestaurant.Persistence.ApplicationDataBase;

namespace SmartRestaurant.Client.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var icontext = scope.ServiceProvider.GetService<ISmartRestaurantDatabaseService>();
                    var context = (SmartRestaurantDbContext)icontext;
                     
                    
                    ///// migrate database 
                   //var identitycontext = (SmartRestaurantIdentityDbContext)scope.ServiceProvider.GetService<SmartRestaurantIdentityDbContext>();
                   //var guestidentitycontext = (SmartRestaurantGuestIdentityDbContext)scope.ServiceProvider.GetService<SmartRestaurantGuestIdentityDbContext>();
                   //var Teamidentitycontext = (SmartRestaurantTeamIdentityDbContext)scope.ServiceProvider.GetService<SmartRestaurantTeamIdentityDbContext>();


                    //identitycontext.Database.Migrate();
                    //guestidentitycontext.Database.Migrate();
                    //Teamidentitycontext.Database.Migrate();

                    var seed = new SmartRestaurantDatabaseSeed(context);
                    //var seedidentity = new SmartRestaurantIdentitySeed(identitycontext);
                    //seedidentity.CreateRoles(scope.ServiceProvider ).Wait();
                    //seedidentity.CreateDummyUser(scope.ServiceProvider).Wait();
                    //context.Database.Migrate();
                    seed.ClearAllDataAsync().Wait();
                    seed.SeedEverythingAsync().Wait();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating or initializing the database.");
                }
            }
            try
            {
                        host.Run();
            }
            catch(Exception e )
            {

            }
          
        }
        //public static void Main(string[] args)
        //{
        //    CreateWebHostBuilder(args).Build().Run();
        //}

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
